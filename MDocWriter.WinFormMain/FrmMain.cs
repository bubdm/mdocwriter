using MDocWriter.WinFormMain.Models;

namespace MDocWriter.WinFormMain
{
    using System;
    using System.Windows.Forms;

    using MDocWriter.Application;

    public partial class FrmMain : Form
    {
        private Workspace workspace;

        public FrmMain()
        {
            InitializeComponent();
        }

        private bool CloseCurrentWorkspace()
        {
            if (this.workspace != null)
            {
                if (this.workspace.IsModified)
                {
                    var dialogResult =
                        MessageBox.Show(
                            "The current document has been modified, do you want to save it before you continue?",
                            "Confirmation",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question);
                    switch (dialogResult)
                    {
                        case DialogResult.Cancel:
                            return false;
                        case DialogResult.Yes:
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
                            break;
                    }
                }
                workspace.Modified -= this.workspace_Modified;
                workspace.Saved -= this.workspace_Saved;
                workspace = null;
            }
            return true;
        }

        

        /// <summary>
        /// Loads the workspace to the GUI.
        /// </summary>
        /// <param name="wks">The workspace instance to be loaded.</param>
        private void LoadWorkspace(Workspace wks)
        {
            tvWorkspace.Nodes.Clear();
            var documentNode = tvWorkspace.Nodes.Add(wks.Document.Id.ToString(), wks.Document.Title);
            documentNode.Tag = new WorkspaceNode(WorkspaceNodeType.Document, wks.Document);
            var documentNodesNode = documentNode.Nodes.Add("<DOCUMENT_NODES>", "Document Nodes");
            documentNodesNode.Tag = new WorkspaceNode(WorkspaceNodeType.DocumentNodes);
            var resourcesNode = documentNode.Nodes.Add("<RESOURCE_NODES>", "Resources");
            resourcesNode.Tag = new WorkspaceNode(WorkspaceNodeType.ResourceNodes);
        }


        private void ActionNew(object sender, EventArgs e)
        {
            // TODO: Check if current workspace has been saved
            workspace = Workspace.New();
            this.LoadWorkspace(workspace);
        }

        private void workspace_Modified(object sender, EventArgs e)
        {
            this.mnuSave.Enabled = true;
            this.tbtnSave.Enabled = true;
        }

        private void workspace_Saved(object sender, EventArgs e)
        {
            this.mnuSave.Enabled = false;
            this.tbtnSave.Enabled = false;
        }
    }
}
