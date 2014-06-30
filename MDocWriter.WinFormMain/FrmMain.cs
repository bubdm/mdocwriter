namespace MDocWriter.WinFormMain
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using MDocWriter.Application;
    using MDocWriter.Common;
    using MDocWriter.Documents;
    using MDocWriter.WinFormMain.Models;
    using MDocWriter.WinFormMain.Properties;

    public partial class FrmMain : Form
    {
        private Workspace workspace;

        public FrmMain()
        {
            InitializeComponent();
            Application.Idle += (sender, e) => lblStatus.Text = Resources.Ready;
        }

        #region Private Methods
        /// <summary>
        /// Closes the current workspace.
        /// </summary>
        /// <returns></returns>
        private bool CloseCurrentWorkspace()
        {
            if (this.workspace != null)
            {
                if (this.workspace.IsModified)
                {
                    var dialogResult =
                        MessageBox.Show(
                            Resources.SaveConfirm,
                            Resources.Confirmation,
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question);
                    switch (dialogResult)
                    {
                        case DialogResult.Cancel:
                            return false;
                        case DialogResult.Yes:
                            if (!this.SaveCurrentWorkspace()) return false;
                            break;
                    }
                }
                Workspace.Close(ref this.workspace, this.WorkspaceModified, this.WorkspaceSaved);
                
            }
            return true;
        }

        /// <summary>
        /// Saves the workspace.
        /// </summary>
        /// <returns>True if the workspace is saved, otherwise, false, which means the user canceled
        /// the saving.</returns>
        private bool SaveCurrentWorkspace()
        {
            switch (this.workspace.Status)
            {
                case WorkspaceStatus.Existing:
                    Workspace.Save(this.workspace.FileName, this.workspace);
                    break;
                case WorkspaceStatus.NewlyCreated:
                    if (this.saveDocumentDialog.ShowDialog() == DialogResult.OK)
                    {
                        Workspace.Save(this.saveDocumentDialog.FileName, this.workspace);
                    }
                    else
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        /// <summary>
        /// Sets the tree node image.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="imageKey">The image key.</param>
        private void SetTreeNodeImage(TreeNode node, string imageKey)
        {
            node.ImageKey = node.StateImageKey = node.SelectedImageKey = imageKey;
        }

        /// <summary>
        /// Loads the workspace to the GUI.
        /// </summary>
        /// <param name="wks">The workspace instance to be loaded.</param>
        private void LoadWorkspace(Workspace wks)
        {
            tvWorkspace.Nodes.Clear();
            // Create the root document node
            var documentNode = tvWorkspace.Nodes.Add(wks.Document.Id.ToString(), wks.Document.Title);
            documentNode.Tag = new WorkspaceNode(WorkspaceNodeType.Document, wks.Document);
            this.SetTreeNodeImage(documentNode, "Document");

            // Create the DocumentNodes node
            var documentNodesNode = documentNode.Nodes.Add("<DOCUMENT_NODES>", Resources.DocumentNodesText);
            documentNodesNode.Tag = new WorkspaceNode(WorkspaceNodeType.DocumentNodes);
            this.SetTreeNodeImage(documentNodesNode, "DocumentNodes");

            // Add the document nodes, recursively
            this.AddDocumentNode(documentNodesNode, wks.Document);
            documentNodesNode.Expand();

            // Create the ResourceNodes node
            var resourcesNode = documentNode.Nodes.Add("<RESOURCE_NODES>", Resources.ResourcesText);
            resourcesNode.Tag = new WorkspaceNode(WorkspaceNodeType.ResourceNodes);
            this.SetTreeNodeImage(resourcesNode, "Resources");

            // Add the resources
            foreach (var resource in wks.Document.Resources)
            {
                var resourceNode = resourcesNode.Nodes.Add(resource.Id.ToString(), resource.FileName);
                resourceNode.Tag = new WorkspaceNode(WorkspaceNodeType.ResourceNode, resource);
                this.SetTreeNodeImage(resourceNode, "Resource");
            }

            documentNode.Expand();
        }

        /// <summary>
        /// Adds the document node, recursively.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="documentNode">The document node.</param>
        private void AddDocumentNode(TreeNode parent, IDocumentNode documentNode)
        {
            foreach(var childNode in documentNode.Children)
            {
                var childTreeNode = parent.Nodes.Add(childNode.Id.ToString(), childNode.ToString());
                childTreeNode.Tag = new WorkspaceNode(WorkspaceNodeType.DocumentNode, childNode);
                this.SetTreeNodeImage(childTreeNode, "File");
                if (childNode.Children.Any())
                {
                    this.SetTreeNodeImage(childTreeNode, "BookClose");
                    AddDocumentNode(childTreeNode, childNode);
                }
            }
        }

        /// <summary>
        /// Adds a new document node under the specified tree node.
        /// </summary>
        /// <param name="parent">The parent node on which the new document node should be added.</param>
        private void AddDocumentNode(TreeNode parent)
        {
            var parentHasChild = parent.Nodes.Count != 0;
            // firstly, check and get the name of the document.
            var childNodeTexts = (from TreeNode childNode in parent.Nodes select childNode.Text).ToList();

            var newNodeText = Utils.GetUniqueName(childNodeTexts, "Document Node");
            var parentNodeTag = (WorkspaceNode)parent.Tag;
            IDocumentNode parentDocumentNode;

            if (parentNodeTag.NodeType == WorkspaceNodeType.DocumentNodes) parentDocumentNode = (IDocumentNode)((WorkspaceNode)parent.Parent.Tag).NodeValue;
            else parentDocumentNode = (IDocumentNode)parentNodeTag.NodeValue;

            var newDocumentNode = parentDocumentNode.AddDocumentNode(newNodeText, string.Empty);
            var newTreeNode = parent.Nodes.Add(newDocumentNode.Id.ToString(), newNodeText);
            newTreeNode.Tag = new WorkspaceNode(WorkspaceNodeType.DocumentNode, newDocumentNode);
            this.SetTreeNodeImage(newTreeNode, "File");

            if (parentNodeTag.NodeType == WorkspaceNodeType.DocumentNode && !parentHasChild)
            {
                this.SetTreeNodeImage(parent, "BookOpen");
            }
            parent.Expand();
            tvWorkspace.SelectedNode = newTreeNode;
            newTreeNode.BeginEdit();
        }

        private void UpdateNodeMoveMenuStatus(TreeNode node)
        {
            var documentNode = (DocumentNode)((WorkspaceNode)node.Tag).NodeValue;
            mnuMoveUp.Enabled = documentNode.CanMoveUp;
            mnuMoveDown.Enabled = documentNode.CanMoveDown;
            mnuPromote.Enabled = documentNode.CanPromote;
            mnuDegrade.Enabled = documentNode.CanDegrade;
            cmnuMoveUp.Enabled = documentNode.CanMoveUp;
            cmnuMoveDown.Enabled = documentNode.CanMoveDown;
            cmnuPromote.Enabled = documentNode.CanPromote;
            cmnuDegrade.Enabled = documentNode.CanDegrade;
            tbtnMoveUp.Enabled = documentNode.CanMoveUp;
            tbtnMoveDown.Enabled = documentNode.CanMoveDown;
            tbtnPromote.Enabled = documentNode.CanPromote;
            tbtnDegrade.Enabled = documentNode.CanDegrade;
        }

        private void ResetMenuToolStatus()
        {
            this.mnuSave.Enabled = false;
            this.tbtnSave.Enabled = false;
            this.mnuClose.Enabled = false;
            this.mnuProperties.Enabled = false;
            this.mnuOpenWorkingFolder.Enabled = false;

            this.mnuAddChild.Enabled = false;
            this.tbtnAddNode.Enabled = false;
            this.mnuRename.Enabled = false;
            this.tbtnRename.Enabled = false;
            this.mnuDelete.Enabled = false;
            this.tbtnDelete.Enabled = false;

            this.mnuMoveUp.Enabled = false;
            this.mnuMoveDown.Enabled = false;
            this.mnuPromote.Enabled = false;
            this.mnuDegrade.Enabled = false;

            this.cmnuMoveUp.Enabled = false;
            this.cmnuMoveDown.Enabled = false;
            this.cmnuPromote.Enabled = false;
            this.cmnuDegrade.Enabled = false;

            this.tbtnMoveUp.Enabled = false;
            this.tbtnMoveDown.Enabled = false;
            this.tbtnPromote.Enabled = false;
            this.tbtnDegrade.Enabled = false;
        }
        #endregion

        #region Private ToolStrip Actions
        private void ActionNew(object sender, EventArgs e)
        {
            if (this.CloseCurrentWorkspace())
            {
                var frmNewDocument = new FrmDocumentPropertyEditor();
                if (frmNewDocument.ShowDialog() == DialogResult.OK)
                {
                    this.workspace = Workspace.New(
                        this.WorkspaceModified,
                        this.WorkspaceSaved,
                        frmNewDocument.WorkspaceSettings);

                    this.LoadWorkspace(this.workspace);

                    this.ResetMenuToolStatus();
                    this.editor.Text = null;
                    this.editor.Enabled = false;
                    this.browser.DocumentText = null;

                    this.mnuClose.Enabled = true;
                    this.mnuProperties.Enabled = true;
                    this.mnuOpenWorkingFolder.Enabled = true;
                }
            }
        }

        private void ActionOpen(object sender, EventArgs e)
        {
            if (this.CloseCurrentWorkspace())
            {
                if (this.openDocumentDialog.ShowDialog() == DialogResult.OK)
                {
                    this.workspace = Workspace.Open(
                        this.WorkspaceModified,
                        this.WorkspaceSaved,
                        this.openDocumentDialog.FileName);

                    this.LoadWorkspace(this.workspace);

                    this.ResetMenuToolStatus();
                    this.editor.Text = null;
                    this.editor.Enabled = false;
                    this.browser.DocumentText = null;

                    this.mnuClose.Enabled = true;
                    this.mnuProperties.Enabled = true;
                    this.mnuOpenWorkingFolder.Enabled = true;
                }
            }
        }

        private void ActionSave(object sender, EventArgs e)
        {
            if (tvWorkspace.SelectedNode.IsEditing)
            {
                tvWorkspace.SelectedNode.EndEdit(false);
            }
            this.SaveCurrentWorkspace();
        }

        private void ActionClose(object sender, EventArgs e)
        {
            if (this.CloseCurrentWorkspace())
            {
                tvWorkspace.Nodes.Clear();
                this.ResetMenuToolStatus();
                this.editor.Text = null;
                this.editor.Enabled = false;
                this.browser.DocumentText = null;
            }
        }

        private void ActionEditDocumentProperty(object sender, EventArgs e)
        {
            if (this.workspace != null && this.workspace.Document != null)
            {
                var frmDocumentPropertyEditor = new FrmDocumentPropertyEditor(this.workspace.Document);
                if (frmDocumentPropertyEditor.ShowDialog() == DialogResult.OK)
                {
                    var settings = frmDocumentPropertyEditor.WorkspaceSettings;
                    this.workspace.Document.Title = settings.DocumentTitle;
                    this.workspace.Document.Author = settings.DocumentAuthor;
                    var documentTreeNode = tvWorkspace.Nodes.Find(this.workspace.Document.Id.ToString(), false).First();
                    documentTreeNode.Text = this.workspace.Document.Title;
                }
            }
        }

        private void ActionOpenWorkingFolder(object sender, EventArgs e)
        {
            if (this.workspace != null &&
                Directory.Exists(this.workspace.WorkingDirectory))
            {
                Process.Start(this.workspace.WorkingDirectory);
            }
        }

        private void ActionAddDocumentNode(object sender, EventArgs e)
        {
            var currentNode = tvWorkspace.SelectedNode;
            this.AddDocumentNode(currentNode);
        }

        private void ActionRemoveDocumentNode(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.DeleteDocumentNodeConfirmPrompt, Resources.Confirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                var currentNode = tvWorkspace.SelectedNode;
                var currentDocumentNode = (DocumentNode)((WorkspaceNode)currentNode.Tag).NodeValue;
                var parentDocumentNode = currentDocumentNode.Parent;
                parentDocumentNode.RemoveDocumentNode(currentDocumentNode.Id);
                var parentNode = currentNode.Parent;
                tvWorkspace.SelectedNode = parentNode;
                tvWorkspace.Nodes.Remove(currentNode);
                if (((WorkspaceNode)parentNode.Tag).NodeType == WorkspaceNodeType.DocumentNode
                    && parentNode.Nodes.Count == 0)
                {
                    this.SetTreeNodeImage(parentNode, "File");
                }
            }
        }

        private void ActionRenameDocumentNode(object sender, EventArgs e)
        {
            tvWorkspace.SelectedNode.BeginEdit();
        }

        private void ActionDocumentNodeMoveUp(object sender, EventArgs e)
        {
            var current = tvWorkspace.SelectedNode;
            var status = current.IsExpanded;
            var cloned = (TreeNode)current.Clone();
            var parent = current.Parent;
            var currentIndex = parent.Nodes.IndexOf(current);
            parent.Nodes.RemoveAt(currentIndex);
            parent.Nodes.Insert(currentIndex - 1, cloned);
            var documentNode = (DocumentNode)((WorkspaceNode)cloned.Tag).NodeValue;
            documentNode.MoveUp();
            if (status)
                cloned.Expand();
            this.UpdateNodeMoveMenuStatus(cloned);
            tvWorkspace.SelectedNode = cloned;
        }

        private void ActionDocumentNodeMoveDown(object sender, EventArgs e)
        {
            var current = tvWorkspace.SelectedNode;
            var status = current.IsExpanded;
            var cloned = (TreeNode)current.Clone();
            var parent = current.Parent;
            var currentIndex = parent.Nodes.IndexOf(current);
            parent.Nodes.RemoveAt(currentIndex);
            parent.Nodes.Insert(currentIndex + 1, cloned);
            var documentNode = (DocumentNode)((WorkspaceNode)cloned.Tag).NodeValue;
            documentNode.MoveDown();
            if (status)
                cloned.Expand();
            this.UpdateNodeMoveMenuStatus(cloned);
            tvWorkspace.SelectedNode = cloned;
        }

        private void ActionDocumentNodePromote(object sender, EventArgs e)
        {
            var current = tvWorkspace.SelectedNode;
            if (current.Parent != null && current.Parent.Parent != null)
            {
                var parent = current.Parent;
                var grand = current.Parent.Parent;
                var parentIndex = grand.Nodes.IndexOf(parent);
                var currentIndex = parent.Nodes.IndexOf(current);
                var cloned = (TreeNode)current.Clone();
                var status = current.IsExpanded;
                parent.Nodes.RemoveAt(currentIndex);
                if (parent.Nodes.Count == 0) this.SetTreeNodeImage(parent, "File");
                grand.Nodes.Insert(parentIndex + 1, cloned);
                grand.Expand();
                if (((WorkspaceNode)grand.Tag).NodeType == WorkspaceNodeType.DocumentNode) this.SetTreeNodeImage(grand, "BookOpen");
                if (status) cloned.Expand();
                var documentNode = (DocumentNode)((WorkspaceNode)cloned.Tag).NodeValue;
                documentNode.Promote();
                this.UpdateNodeMoveMenuStatus(cloned);
                tvWorkspace.SelectedNode = cloned;
            }
        }

        private void ActionDocumentNodeDegrade(object sender, EventArgs e)
        {
            var current = tvWorkspace.SelectedNode;
            var parent = current.Parent;
            var prevSibling = current.PrevNode;
            if (parent != null && prevSibling != null)
            {
                var cloned = (TreeNode)current.Clone();
                var status = current.IsExpanded;
                var currentIndex = parent.Nodes.IndexOf(current);
                parent.Nodes.RemoveAt(currentIndex);
                if (parent.Nodes.Count == 0) this.SetTreeNodeImage(parent, "File");
                prevSibling.Nodes.Add(cloned);
                prevSibling.Expand();
                this.SetTreeNodeImage(prevSibling, "BookOpen");
                if (status) cloned.Expand();
                var documentNode = (DocumentNode)((WorkspaceNode)cloned.Tag).NodeValue;
                documentNode.Degrade();
                this.UpdateNodeMoveMenuStatus(cloned);
                tvWorkspace.SelectedNode = cloned;
            }
        }

        private void ActionAddResource(object sender, EventArgs e)
        {
            if (openResourceDialog.ShowDialog() == DialogResult.OK)
            {
                var resourceFileName = openResourceDialog.FileName;
                var plainFileName = Path.GetFileName(resourceFileName);
                var resourceFileNameInWorkingFolder = Path.Combine(this.workspace.WorkingDirectory, plainFileName);
                File.Copy(
                    resourceFileName,
                    resourceFileNameInWorkingFolder);
                var resource = this.workspace.Document.AddDocumentResource(
                    plainFileName,
                    Utils.GetBase64OfFile(resourceFileNameInWorkingFolder));
                var resourceNode = tvWorkspace.Nodes[0].Nodes[1].Nodes.Add(resource.Id.ToString(), plainFileName);
                resourceNode.Tag = new WorkspaceNode(WorkspaceNodeType.ResourceNode, resource);
                this.SetTreeNodeImage(resourceNode, "Resource");
            }
        }

        private void ActionAbout(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog();
        }
        #endregion

        #region Custom Event Handlers
        private void WorkspaceModified(object sender, EventArgs e)
        {
            this.mnuSave.Enabled = true;
            this.tbtnSave.Enabled = true;
        }

        private void WorkspaceSaved(object sender, EventArgs e)
        {
            this.mnuSave.Enabled = false;
            this.tbtnSave.Enabled = false;
        }
        #endregion

        private void tvWorkspace_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvWorkspace.SelectedNode = e.Node;
            var wksNode = (WorkspaceNode)e.Node.Tag;
            // Checks if it is the right button click
            if (e.Button == MouseButtons.Right) 
            {
                switch (wksNode.NodeType)
                {
                    case WorkspaceNodeType.Document:
                        cmsDocument.Show(tvWorkspace, e.X, e.Y);
                        break;
                    case WorkspaceNodeType.DocumentNodes:
                        cmsDocumentNodes.Show(tvWorkspace, e.X, e.Y);
                        break;
                    case WorkspaceNodeType.DocumentNode:
                        cmsDocumentNode.Show(tvWorkspace, e.X, e.Y);
                        break;
                    case WorkspaceNodeType.ResourceNodes:
                        cmsResources.Show(tvWorkspace, e.X, e.Y);
                        break;
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.ResetMenuToolStatus();
            this.editor.Text = null;
            this.editor.Enabled = false;
            this.browser.DocumentText = null;
        }

        private void tvWorkspace_AfterExpand(object sender, TreeViewEventArgs e)
        {
            var wksType = ((WorkspaceNode)e.Node.Tag).NodeType;
            if (wksType == WorkspaceNodeType.DocumentNode && e.Node.Nodes.Count > 0)
            {
                this.SetTreeNodeImage(e.Node, "BookOpen");
            }
        }

        private void tvWorkspace_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            var wksType = ((WorkspaceNode)e.Node.Tag).NodeType;
            if (wksType == WorkspaceNodeType.DocumentNode && e.Node.Nodes.Count > 0)
            {
                this.SetTreeNodeImage(e.Node, "BookClose");
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.CloseCurrentWorkspace();
        }

        private void tvWorkspace_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var workspaceNodeType = ((WorkspaceNode)e.Node.Tag).NodeType;
            e.CancelEdit = workspaceNodeType != WorkspaceNodeType.DocumentNode;
        }

        private void tvWorkspace_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null && !string.IsNullOrEmpty(e.Label))
            {
                e.Node.Text = e.Label;
                var documentNode = (DocumentNode)((WorkspaceNode)e.Node.Tag).NodeValue;
                documentNode.Name = e.Label;
            }
        }

        private void tvWorkspace_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var wksNode = (WorkspaceNode)e.Node.Tag;
            // Enable/Disable the menus and tools properly
            switch (wksNode.NodeType)
            {
                case WorkspaceNodeType.DocumentNodes:
                    mnuAddChild.Enabled = true;
                    mnuRename.Enabled = false;
                    tbtnRename.Enabled = false;
                    mnuDelete.Enabled = false;
                    tbtnDelete.Enabled = false;
                    tbtnAddNode.Enabled = true;
                    this.mnuMoveUp.Enabled = false;
                    this.mnuMoveDown.Enabled = false;
                    this.mnuPromote.Enabled = false;
                    this.mnuDegrade.Enabled = false;
                    this.cmnuMoveUp.Enabled = false;
                    this.cmnuMoveDown.Enabled = false;
                    this.cmnuPromote.Enabled = false;
                    this.cmnuDegrade.Enabled = false;
                    this.tbtnMoveUp.Enabled = false;
                    this.tbtnMoveDown.Enabled = false;
                    this.tbtnPromote.Enabled = false;
                    this.tbtnDegrade.Enabled = false;
                    break;
                case WorkspaceNodeType.DocumentNode:
                    mnuAddChild.Enabled = true;
                    tbtnAddNode.Enabled = true;
                    mnuRename.Enabled = true;
                    tbtnRename.Enabled = true;
                    mnuDelete.Enabled = true;
                    tbtnDelete.Enabled = true;
                    this.UpdateNodeMoveMenuStatus(e.Node);
                    break;
                default:
                    this.mnuAddChild.Enabled = false;
                    this.tbtnAddNode.Enabled = false;
                    this.mnuRename.Enabled = false;
                    this.tbtnRename.Enabled = false;
                    this.mnuDelete.Enabled = false;
                    this.tbtnDelete.Enabled = false;
                    this.mnuMoveUp.Enabled = false;
                    this.mnuMoveDown.Enabled = false;
                    this.mnuPromote.Enabled = false;
                    this.mnuDegrade.Enabled = false;
                    this.cmnuMoveUp.Enabled = false;
                    this.cmnuMoveDown.Enabled = false;
                    this.cmnuPromote.Enabled = false;
                    this.cmnuDegrade.Enabled = false;
                    this.tbtnMoveUp.Enabled = false;
                    this.tbtnMoveDown.Enabled = false;
                    this.tbtnPromote.Enabled = false;
                    this.tbtnDegrade.Enabled = false;
                    break;
            }
        }

        private void tvWorkspace_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var wksNode = (WorkspaceNode)e.Node.Tag;
            switch (wksNode.NodeType)
            {
                case WorkspaceNodeType.DocumentNode:
                    var documentNode = (DocumentNode)wksNode.NodeValue;
                    editor.Text = documentNode.Content;
                    editor.Enabled = true;
                    editor.Focus();
                    editor.SelectionStart = 0;
                    editor.SelectionLength = 0;
                    break;
                
            }
        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            if (this.workspace != null &&
                tvWorkspace.SelectedNode!=null)
            {
                var wksNode = (WorkspaceNode)tvWorkspace.SelectedNode.Tag;
                switch (wksNode.NodeType)
                {
                    case WorkspaceNodeType.DocumentNode:
                        var documentNode = (DocumentNode)wksNode.NodeValue;
                        documentNode.Content = editor.Text;
                        break;

                }
            }
        }
    }
}
