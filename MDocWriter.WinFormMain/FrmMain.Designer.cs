namespace MDocWriter.WinFormMain
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnSave = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tvWorkspace = new System.Windows.Forms.TreeView();
            this.tvImageList = new System.Windows.Forms.ImageList(this.components);
            this.saveDocumentDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDocumentDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmsDocument = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOpenWorkingFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDocumentNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDocumentNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuAddNode2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.cmsDocument.SuspendLayout();
            this.cmsDocumentNodes.SuspendLayout();
            this.cmsDocumentNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuSave});
            this.mnuFile.Name = "mnuFile";
            resources.ApplyResources(this.mnuFile, "mnuFile");
            // 
            // mnuNew
            // 
            this.mnuNew.Image = global::MDocWriter.WinFormMain.Properties.Resources.New;
            this.mnuNew.Name = "mnuNew";
            resources.ApplyResources(this.mnuNew, "mnuNew");
            this.mnuNew.Click += new System.EventHandler(this.ActionNew);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = global::MDocWriter.WinFormMain.Properties.Resources.Open;
            this.mnuOpen.Name = "mnuOpen";
            resources.ApplyResources(this.mnuOpen, "mnuOpen");
            this.mnuOpen.Click += new System.EventHandler(this.ActionOpen);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = global::MDocWriter.WinFormMain.Properties.Resources.Save;
            this.mnuSave.Name = "mnuSave";
            resources.ApplyResources(this.mnuSave, "mnuSave");
            this.mnuSave.Click += new System.EventHandler(this.ActionSave);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            resources.ApplyResources(this.mnuHelp, "mnuHelp");
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            resources.ApplyResources(this.mnuAbout, "mnuAbout");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnNew,
            this.tbtnOpen,
            this.tbtnSave});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // tbtnNew
            // 
            this.tbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnNew.Image = global::MDocWriter.WinFormMain.Properties.Resources.New;
            resources.ApplyResources(this.tbtnNew, "tbtnNew");
            this.tbtnNew.Name = "tbtnNew";
            this.tbtnNew.Click += new System.EventHandler(this.ActionNew);
            // 
            // tbtnOpen
            // 
            this.tbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnOpen.Image = global::MDocWriter.WinFormMain.Properties.Resources.Open;
            resources.ApplyResources(this.tbtnOpen, "tbtnOpen");
            this.tbtnOpen.Name = "tbtnOpen";
            this.tbtnOpen.Click += new System.EventHandler(this.ActionOpen);
            // 
            // tbtnSave
            // 
            this.tbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSave.Image = global::MDocWriter.WinFormMain.Properties.Resources.Save;
            resources.ApplyResources(this.tbtnSave, "tbtnSave");
            this.tbtnSave.Name = "tbtnSave";
            this.tbtnSave.Click += new System.EventHandler(this.ActionSave);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tvWorkspace);
            // 
            // tvWorkspace
            // 
            resources.ApplyResources(this.tvWorkspace, "tvWorkspace");
            this.tvWorkspace.FullRowSelect = true;
            this.tvWorkspace.HideSelection = false;
            this.tvWorkspace.ImageList = this.tvImageList;
            this.tvWorkspace.Name = "tvWorkspace";
            this.tvWorkspace.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvWorkspace_AfterCollapse);
            this.tvWorkspace.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvWorkspace_AfterExpand);
            this.tvWorkspace.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWorkspace_NodeMouseClick);
            // 
            // tvImageList
            // 
            this.tvImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tvImageList.ImageStream")));
            this.tvImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tvImageList.Images.SetKeyName(0, "Document");
            this.tvImageList.Images.SetKeyName(1, "DocumentNodes");
            this.tvImageList.Images.SetKeyName(2, "Resources");
            this.tvImageList.Images.SetKeyName(3, "File");
            this.tvImageList.Images.SetKeyName(4, "FolderClose");
            this.tvImageList.Images.SetKeyName(5, "FolderOpen");
            // 
            // saveDocumentDialog
            // 
            resources.ApplyResources(this.saveDocumentDialog, "saveDocumentDialog");
            // 
            // openDocumentDialog
            // 
            resources.ApplyResources(this.openDocumentDialog, "openDocumentDialog");
            // 
            // cmsDocument
            // 
            this.cmsDocument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuOpenWorkingFolder});
            this.cmsDocument.Name = "cmsDocument";
            resources.ApplyResources(this.cmsDocument, "cmsDocument");
            // 
            // cmnuOpenWorkingFolder
            // 
            this.cmnuOpenWorkingFolder.Image = global::MDocWriter.WinFormMain.Properties.Resources.FolderTemp;
            this.cmnuOpenWorkingFolder.Name = "cmnuOpenWorkingFolder";
            resources.ApplyResources(this.cmnuOpenWorkingFolder, "cmnuOpenWorkingFolder");
            this.cmnuOpenWorkingFolder.Click += new System.EventHandler(this.ActionOpenWorkingFolder);
            // 
            // cmsDocumentNodes
            // 
            this.cmsDocumentNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuAddNode});
            this.cmsDocumentNodes.Name = "cmsDocumentNodes";
            resources.ApplyResources(this.cmsDocumentNodes, "cmsDocumentNodes");
            // 
            // cmnuAddNode
            // 
            this.cmnuAddNode.Name = "cmnuAddNode";
            resources.ApplyResources(this.cmnuAddNode, "cmnuAddNode");
            this.cmnuAddNode.Click += new System.EventHandler(this.ActionAddDocumentNode);
            // 
            // cmsDocumentNode
            // 
            this.cmsDocumentNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuAddNode2});
            this.cmsDocumentNode.Name = "cmsDocumentNode";
            resources.ApplyResources(this.cmsDocumentNode, "cmsDocumentNode");
            // 
            // cmnuAddNode2
            // 
            this.cmnuAddNode2.Name = "cmnuAddNode2";
            resources.ApplyResources(this.cmnuAddNode2, "cmnuAddNode2");
            this.cmnuAddNode2.Click += new System.EventHandler(this.ActionAddDocumentNode);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.cmsDocument.ResumeLayout(false);
            this.cmsDocumentNodes.ResumeLayout(false);
            this.cmsDocumentNode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView tvWorkspace;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripButton tbtnNew;
        private System.Windows.Forms.ToolStripButton tbtnOpen;
        private System.Windows.Forms.ToolStripButton tbtnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.SaveFileDialog saveDocumentDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ImageList tvImageList;
        private System.Windows.Forms.OpenFileDialog openDocumentDialog;
        private System.Windows.Forms.ContextMenuStrip cmsDocument;
        private System.Windows.Forms.ToolStripMenuItem cmnuOpenWorkingFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ContextMenuStrip cmsDocumentNodes;
        private System.Windows.Forms.ToolStripMenuItem cmnuAddNode;
        private System.Windows.Forms.ContextMenuStrip cmsDocumentNode;
        private System.Windows.Forms.ToolStripMenuItem cmnuAddNode2;

    }
}

