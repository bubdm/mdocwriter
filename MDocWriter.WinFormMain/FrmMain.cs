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
        }

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
                    this.SetTreeNodeImage(childTreeNode, "FolderClose");
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

            var newDocumentNode = parentDocumentNode.AddChildDocumentNode(newNodeText, string.Empty);
            var newTreeNode = parent.Nodes.Add(newDocumentNode.Id.ToString(), newNodeText);
            newTreeNode.Tag = new WorkspaceNode(WorkspaceNodeType.DocumentNode, newDocumentNode);
            this.SetTreeNodeImage(newTreeNode, "File");

            if (parentNodeTag.NodeType == WorkspaceNodeType.DocumentNode && !parentHasChild)
            {
                this.SetTreeNodeImage(parent, "FolderOpen");
            }
            parent.Expand();
            tvWorkspace.SelectedNode = newTreeNode;
        }


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
                }
            }
        }

        private void ActionSave(object sender, EventArgs e)
        {
            this.SaveCurrentWorkspace();
        }

        private void ActionClose(object sender, EventArgs e)
        {
            if (this.CloseCurrentWorkspace())
            {
                tvWorkspace.Nodes.Clear();
                this.tbtnSave.Enabled = false;
                this.mnuSave.Enabled = false;
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

        private void tvWorkspace_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvWorkspace.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right) 
            {
                // Right click
                var wksNode = (WorkspaceNode)e.Node.Tag;
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
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.mnuSave.Enabled = false;
            this.tbtnSave.Enabled = false;
        }

        private void tvWorkspace_AfterExpand(object sender, TreeViewEventArgs e)
        {
            var wksType = ((WorkspaceNode)e.Node.Tag).NodeType;
            if (wksType == WorkspaceNodeType.DocumentNode && e.Node.Nodes.Count > 0)
            {
                this.SetTreeNodeImage(e.Node, "FolderOpen");
            }
        }

        private void tvWorkspace_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            var wksType = ((WorkspaceNode)e.Node.Tag).NodeType;
            if (wksType == WorkspaceNodeType.DocumentNode && e.Node.Nodes.Count > 0)
            {
                this.SetTreeNodeImage(e.Node, "FolderClose");
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.CloseCurrentWorkspace();
        }
    }
}
