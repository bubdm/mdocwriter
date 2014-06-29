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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenWorkingFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPromote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDegrade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnSave = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tvWorkspace = new System.Windows.Forms.TreeView();
            this.tvImageList = new System.Windows.Forms.ImageList(this.components);
            this.saveDocumentDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDocumentDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmsDocument = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOpenWorkingFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDocumentNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDocumentNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuAddNode2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDeleteDocumentNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuPromote = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDegrade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tbtnMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tbtnPromote = new System.Windows.Forms.ToolStripButton();
            this.tbtnDegrade = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnRename = new System.Windows.Forms.ToolStripButton();
            this.tbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
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
            this.mnuDocument,
            this.mnuHelp});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuSave,
            this.toolStripMenuItem1,
            this.mnuClose,
            this.toolStripMenuItem4,
            this.mnuOpenWorkingFolder});
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // mnuClose
            // 
            this.mnuClose.Image = global::MDocWriter.WinFormMain.Properties.Resources.Close;
            this.mnuClose.Name = "mnuClose";
            resources.ApplyResources(this.mnuClose, "mnuClose");
            this.mnuClose.Click += new System.EventHandler(this.ActionClose);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // mnuOpenWorkingFolder
            // 
            this.mnuOpenWorkingFolder.Image = global::MDocWriter.WinFormMain.Properties.Resources.FolderTemp;
            this.mnuOpenWorkingFolder.Name = "mnuOpenWorkingFolder";
            resources.ApplyResources(this.mnuOpenWorkingFolder, "mnuOpenWorkingFolder");
            this.mnuOpenWorkingFolder.Click += new System.EventHandler(this.ActionOpenWorkingFolder);
            // 
            // mnuDocument
            // 
            this.mnuDocument.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddChild,
            this.mnuRename,
            this.mnuDelete,
            this.toolStripMenuItem3,
            this.mnuMoveUp,
            this.mnuMoveDown,
            this.mnuPromote,
            this.mnuDegrade,
            this.toolStripMenuItem6,
            this.mnuProperties});
            this.mnuDocument.Name = "mnuDocument";
            resources.ApplyResources(this.mnuDocument, "mnuDocument");
            // 
            // mnuAddChild
            // 
            this.mnuAddChild.Image = global::MDocWriter.WinFormMain.Properties.Resources.AddNode;
            this.mnuAddChild.Name = "mnuAddChild";
            resources.ApplyResources(this.mnuAddChild, "mnuAddChild");
            this.mnuAddChild.Click += new System.EventHandler(this.ActionAddDocumentNode);
            // 
            // mnuRename
            // 
            this.mnuRename.Image = global::MDocWriter.WinFormMain.Properties.Resources.Rename;
            this.mnuRename.Name = "mnuRename";
            resources.ApplyResources(this.mnuRename, "mnuRename");
            this.mnuRename.Click += new System.EventHandler(this.ActionRenameDocumentNode);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::MDocWriter.WinFormMain.Properties.Resources.Delete;
            this.mnuDelete.Name = "mnuDelete";
            resources.ApplyResources(this.mnuDelete, "mnuDelete");
            this.mnuDelete.Click += new System.EventHandler(this.ActionRemoveDocumentNode);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // mnuMoveUp
            // 
            this.mnuMoveUp.Image = global::MDocWriter.WinFormMain.Properties.Resources.MoveUp;
            this.mnuMoveUp.Name = "mnuMoveUp";
            resources.ApplyResources(this.mnuMoveUp, "mnuMoveUp");
            this.mnuMoveUp.Click += new System.EventHandler(this.ActionDocumentNodeMoveUp);
            // 
            // mnuMoveDown
            // 
            this.mnuMoveDown.Image = global::MDocWriter.WinFormMain.Properties.Resources.MoveDown;
            this.mnuMoveDown.Name = "mnuMoveDown";
            resources.ApplyResources(this.mnuMoveDown, "mnuMoveDown");
            this.mnuMoveDown.Click += new System.EventHandler(this.ActionDocumentNodeMoveDown);
            // 
            // mnuPromote
            // 
            this.mnuPromote.Image = global::MDocWriter.WinFormMain.Properties.Resources.Promote;
            this.mnuPromote.Name = "mnuPromote";
            resources.ApplyResources(this.mnuPromote, "mnuPromote");
            this.mnuPromote.Click += new System.EventHandler(this.ActionDocumentNodePromote);
            // 
            // mnuDegrade
            // 
            this.mnuDegrade.Image = global::MDocWriter.WinFormMain.Properties.Resources.Degrade;
            this.mnuDegrade.Name = "mnuDegrade";
            resources.ApplyResources(this.mnuDegrade, "mnuDegrade");
            this.mnuDegrade.Click += new System.EventHandler(this.ActionDocumentNodeDegrade);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // mnuProperties
            // 
            this.mnuProperties.Image = global::MDocWriter.WinFormMain.Properties.Resources.Property;
            this.mnuProperties.Name = "mnuProperties";
            resources.ApplyResources(this.mnuProperties, "mnuProperties");
            this.mnuProperties.Click += new System.EventHandler(this.ActionEditDocumentProperty);
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
            this.mnuAbout.Click += new System.EventHandler(this.ActionAbout);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnNew,
            this.tbtnOpen,
            this.tbtnSave,
            this.toolStripSeparator1,
            this.tbtnAddNode,
            this.tbtnRename,
            this.tbtnDelete,
            this.toolStripSeparator2,
            this.tbtnMoveUp,
            this.tbtnMoveDown,
            this.tbtnPromote,
            this.tbtnDegrade});
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
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
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
            this.tvWorkspace.LabelEdit = true;
            this.tvWorkspace.Name = "tvWorkspace";
            this.tvWorkspace.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvWorkspace_BeforeLabelEdit);
            this.tvWorkspace.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvWorkspace_AfterLabelEdit);
            this.tvWorkspace.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvWorkspace_AfterCollapse);
            this.tvWorkspace.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvWorkspace_AfterExpand);
            this.tvWorkspace.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvWorkspace_AfterSelect);
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
            this.tvImageList.Images.SetKeyName(4, "Resource.png");
            this.tvImageList.Images.SetKeyName(5, "BookClose");
            this.tvImageList.Images.SetKeyName(6, "BookOpen");
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
            this.cmnuOpenWorkingFolder,
            this.toolStripMenuItem2,
            this.cmnuProperties});
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // cmnuProperties
            // 
            this.cmnuProperties.Image = global::MDocWriter.WinFormMain.Properties.Resources.Property;
            this.cmnuProperties.Name = "cmnuProperties";
            resources.ApplyResources(this.cmnuProperties, "cmnuProperties");
            this.cmnuProperties.Click += new System.EventHandler(this.ActionEditDocumentProperty);
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
            this.cmnuAddNode.Image = global::MDocWriter.WinFormMain.Properties.Resources.AddNode;
            this.cmnuAddNode.Name = "cmnuAddNode";
            resources.ApplyResources(this.cmnuAddNode, "cmnuAddNode");
            this.cmnuAddNode.Click += new System.EventHandler(this.ActionAddDocumentNode);
            // 
            // cmsDocumentNode
            // 
            this.cmsDocumentNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuAddNode2,
            this.cmnuRename,
            this.cmnuDeleteDocumentNode,
            this.toolStripMenuItem5,
            this.cmnuMoveUp,
            this.cmnuMoveDown,
            this.cmnuPromote,
            this.cmnuDegrade});
            this.cmsDocumentNode.Name = "cmsDocumentNode";
            resources.ApplyResources(this.cmsDocumentNode, "cmsDocumentNode");
            // 
            // cmnuAddNode2
            // 
            this.cmnuAddNode2.Image = global::MDocWriter.WinFormMain.Properties.Resources.AddNode;
            this.cmnuAddNode2.Name = "cmnuAddNode2";
            resources.ApplyResources(this.cmnuAddNode2, "cmnuAddNode2");
            this.cmnuAddNode2.Click += new System.EventHandler(this.ActionAddDocumentNode);
            // 
            // cmnuRename
            // 
            this.cmnuRename.Image = global::MDocWriter.WinFormMain.Properties.Resources.Rename;
            this.cmnuRename.Name = "cmnuRename";
            resources.ApplyResources(this.cmnuRename, "cmnuRename");
            this.cmnuRename.Click += new System.EventHandler(this.ActionRenameDocumentNode);
            // 
            // cmnuDeleteDocumentNode
            // 
            this.cmnuDeleteDocumentNode.Image = global::MDocWriter.WinFormMain.Properties.Resources.Delete;
            this.cmnuDeleteDocumentNode.Name = "cmnuDeleteDocumentNode";
            resources.ApplyResources(this.cmnuDeleteDocumentNode, "cmnuDeleteDocumentNode");
            this.cmnuDeleteDocumentNode.Click += new System.EventHandler(this.ActionRemoveDocumentNode);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // cmnuMoveUp
            // 
            this.cmnuMoveUp.Image = global::MDocWriter.WinFormMain.Properties.Resources.MoveUp;
            this.cmnuMoveUp.Name = "cmnuMoveUp";
            resources.ApplyResources(this.cmnuMoveUp, "cmnuMoveUp");
            this.cmnuMoveUp.Click += new System.EventHandler(this.ActionDocumentNodeMoveUp);
            // 
            // cmnuMoveDown
            // 
            this.cmnuMoveDown.Image = global::MDocWriter.WinFormMain.Properties.Resources.MoveDown;
            this.cmnuMoveDown.Name = "cmnuMoveDown";
            resources.ApplyResources(this.cmnuMoveDown, "cmnuMoveDown");
            this.cmnuMoveDown.Click += new System.EventHandler(this.ActionDocumentNodeMoveDown);
            // 
            // cmnuPromote
            // 
            this.cmnuPromote.Image = global::MDocWriter.WinFormMain.Properties.Resources.Promote;
            this.cmnuPromote.Name = "cmnuPromote";
            resources.ApplyResources(this.cmnuPromote, "cmnuPromote");
            this.cmnuPromote.Click += new System.EventHandler(this.ActionDocumentNodePromote);
            // 
            // cmnuDegrade
            // 
            this.cmnuDegrade.Image = global::MDocWriter.WinFormMain.Properties.Resources.Degrade;
            this.cmnuDegrade.Name = "cmnuDegrade";
            resources.ApplyResources(this.cmnuDegrade, "cmnuDegrade");
            this.cmnuDegrade.Click += new System.EventHandler(this.ActionDocumentNodeDegrade);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tbtnMoveUp
            // 
            this.tbtnMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnMoveUp.Image = global::MDocWriter.WinFormMain.Properties.Resources.MoveUp;
            resources.ApplyResources(this.tbtnMoveUp, "tbtnMoveUp");
            this.tbtnMoveUp.Name = "tbtnMoveUp";
            this.tbtnMoveUp.Click += new System.EventHandler(this.ActionDocumentNodeMoveUp);
            // 
            // tbtnMoveDown
            // 
            this.tbtnMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnMoveDown.Image = global::MDocWriter.WinFormMain.Properties.Resources.MoveDown;
            resources.ApplyResources(this.tbtnMoveDown, "tbtnMoveDown");
            this.tbtnMoveDown.Name = "tbtnMoveDown";
            this.tbtnMoveDown.Click += new System.EventHandler(this.ActionDocumentNodeMoveDown);
            // 
            // tbtnPromote
            // 
            this.tbtnPromote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnPromote.Image = global::MDocWriter.WinFormMain.Properties.Resources.Promote;
            resources.ApplyResources(this.tbtnPromote, "tbtnPromote");
            this.tbtnPromote.Name = "tbtnPromote";
            this.tbtnPromote.Click += new System.EventHandler(this.ActionDocumentNodePromote);
            // 
            // tbtnDegrade
            // 
            this.tbtnDegrade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDegrade.Image = global::MDocWriter.WinFormMain.Properties.Resources.Degrade;
            resources.ApplyResources(this.tbtnDegrade, "tbtnDegrade");
            this.tbtnDegrade.Name = "tbtnDegrade";
            this.tbtnDegrade.Click += new System.EventHandler(this.ActionDocumentNodeDegrade);
            // 
            // tbtnAddNode
            // 
            this.tbtnAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddNode.Image = global::MDocWriter.WinFormMain.Properties.Resources.AddNode;
            resources.ApplyResources(this.tbtnAddNode, "tbtnAddNode");
            this.tbtnAddNode.Name = "tbtnAddNode";
            this.tbtnAddNode.Click += new System.EventHandler(this.ActionAddDocumentNode);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tbtnRename
            // 
            this.tbtnRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnRename.Image = global::MDocWriter.WinFormMain.Properties.Resources.Rename;
            resources.ApplyResources(this.tbtnRename, "tbtnRename");
            this.tbtnRename.Name = "tbtnRename";
            this.tbtnRename.Click += new System.EventHandler(this.ActionRenameDocumentNode);
            // 
            // tbtnDelete
            // 
            this.tbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDelete.Image = global::MDocWriter.WinFormMain.Properties.Resources.Delete;
            resources.ApplyResources(this.tbtnDelete, "tbtnDelete");
            this.tbtnDelete.Name = "tbtnDelete";
            this.tbtnDelete.Click += new System.EventHandler(this.ActionRemoveDocumentNode);
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem cmnuDeleteDocumentNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmnuProperties;
        private System.Windows.Forms.ToolStripMenuItem cmnuRename;
        private System.Windows.Forms.ToolStripMenuItem mnuDocument;
        private System.Windows.Forms.ToolStripMenuItem mnuProperties;
        private System.Windows.Forms.ToolStripMenuItem mnuAddChild;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuRename;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenWorkingFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem cmnuPromote;
        private System.Windows.Forms.ToolStripMenuItem cmnuDegrade;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem mnuPromote;
        private System.Windows.Forms.ToolStripMenuItem mnuDegrade;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnMoveUp;
        private System.Windows.Forms.ToolStripButton tbtnMoveDown;
        private System.Windows.Forms.ToolStripButton tbtnPromote;
        private System.Windows.Forms.ToolStripButton tbtnDegrade;
        private System.Windows.Forms.ToolStripButton tbtnAddNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnRename;
        private System.Windows.Forms.ToolStripButton tbtnDelete;

    }
}

