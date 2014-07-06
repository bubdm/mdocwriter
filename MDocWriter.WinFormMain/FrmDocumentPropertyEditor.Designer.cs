namespace MDocWriter.WinFormMain
{
    partial class FrmDocumentPropertyEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumentPropertyEditor));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.numRevision = new System.Windows.Forms.NumericUpDown();
            this.numMinor = new System.Windows.Forms.NumericUpDown();
            this.numMajor = new System.Windows.Forms.NumericUpDown();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDlgDesc = new System.Windows.Forms.Label();
            this.lblDlgTitle = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tpTemplate = new System.Windows.Forms.TabPage();
            this.templatePicker = new MDocWriter.WinFormMain.Controls.TemplatePicker();
            this.tabControl.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMajor)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tpTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tpGeneral);
            this.tabControl.Controls.Add(this.tpTemplate);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.numRevision);
            this.tpGeneral.Controls.Add(this.numMinor);
            this.tpGeneral.Controls.Add(this.numMajor);
            this.tpGeneral.Controls.Add(this.lblVersion);
            this.tpGeneral.Controls.Add(this.txtAuthor);
            this.tpGeneral.Controls.Add(this.lblAuthor);
            this.tpGeneral.Controls.Add(this.txtTitle);
            this.tpGeneral.Controls.Add(this.lblTitle);
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // numRevision
            // 
            resources.ApplyResources(this.numRevision, "numRevision");
            this.numRevision.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numRevision.Name = "numRevision";
            this.toolTip.SetToolTip(this.numRevision, resources.GetString("numRevision.ToolTip"));
            // 
            // numMinor
            // 
            resources.ApplyResources(this.numMinor, "numMinor");
            this.numMinor.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numMinor.Name = "numMinor";
            this.toolTip.SetToolTip(this.numMinor, resources.GetString("numMinor.ToolTip"));
            // 
            // numMajor
            // 
            resources.ApplyResources(this.numMajor, "numMajor");
            this.numMajor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMajor.Name = "numMajor";
            this.toolTip.SetToolTip(this.numMajor, resources.GetString("numMajor.ToolTip"));
            this.numMajor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // txtAuthor
            // 
            resources.ApplyResources(this.txtAuthor, "txtAuthor");
            this.txtAuthor.Name = "txtAuthor";
            this.toolTip.SetToolTip(this.txtAuthor, resources.GetString("txtAuthor.ToolTip"));
            // 
            // lblAuthor
            // 
            resources.ApplyResources(this.lblAuthor, "lblAuthor");
            this.lblAuthor.Name = "lblAuthor";
            // 
            // txtTitle
            // 
            resources.ApplyResources(this.txtTitle, "txtTitle");
            this.txtTitle.Name = "txtTitle";
            this.toolTip.SetToolTip(this.txtTitle, resources.GetString("txtTitle.ToolTip"));
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblDlgDesc);
            this.pnlTop.Controls.Add(this.lblDlgTitle);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // lblDlgDesc
            // 
            resources.ApplyResources(this.lblDlgDesc, "lblDlgDesc");
            this.lblDlgDesc.Name = "lblDlgDesc";
            // 
            // lblDlgTitle
            // 
            resources.ApplyResources(this.lblDlgTitle, "lblDlgTitle");
            this.lblDlgTitle.Name = "lblDlgTitle";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // tpTemplate
            // 
            this.tpTemplate.Controls.Add(this.templatePicker);
            resources.ApplyResources(this.tpTemplate, "tpTemplate");
            this.tpTemplate.Name = "tpTemplate";
            this.tpTemplate.UseVisualStyleBackColor = true;
            // 
            // templatePicker
            // 
            resources.ApplyResources(this.templatePicker, "templatePicker");
            this.templatePicker.Name = "templatePicker";
            // 
            // FrmDocumentPropertyEditor
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDocumentPropertyEditor";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.FrmNewDocument_Shown);
            this.tabControl.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMajor)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tpTemplate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblDlgTitle;
        private System.Windows.Forms.Label lblDlgDesc;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown numMajor;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.NumericUpDown numMinor;
        private System.Windows.Forms.NumericUpDown numRevision;
        private System.Windows.Forms.TabPage tpTemplate;
        private Controls.TemplatePicker templatePicker;
    }
}