namespace MDocWriter.WinFormMain
{
    partial class FrmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDescription = new System.Windows.Forms.TabPage();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.tpLicenses = new System.Windows.Forms.TabPage();
            this.tpRefAssemblies = new System.Windows.Forms.TabPage();
            this.tpPlugIns = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.tabControl1, 1, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // logoPictureBox
            // 
            resources.ApplyResources(this.logoPictureBox, "logoPictureBox");
            this.logoPictureBox.Image = global::MDocWriter.WinFormMain.Properties.Resources.mdocwriter;
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            resources.ApplyResources(this.labelProductName, "labelProductName");
            this.labelProductName.Name = "labelProductName";
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.Name = "labelVersion";
            // 
            // labelCopyright
            // 
            resources.ApplyResources(this.labelCopyright, "labelCopyright");
            this.labelCopyright.Name = "labelCopyright";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Name = "okButton";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDescription);
            this.tabControl1.Controls.Add(this.tpLicenses);
            this.tabControl1.Controls.Add(this.tpRefAssemblies);
            this.tabControl1.Controls.Add(this.tpPlugIns);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tpDescription
            // 
            this.tpDescription.Controls.Add(this.textBoxDescription);
            resources.ApplyResources(this.tpDescription, "tpDescription");
            this.tpDescription.Name = "tpDescription";
            this.tpDescription.UseVisualStyleBackColor = true;
            // 
            // textBoxDescription
            // 
            resources.ApplyResources(this.textBoxDescription, "textBoxDescription");
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.TabStop = false;
            // 
            // tpLicenses
            // 
            resources.ApplyResources(this.tpLicenses, "tpLicenses");
            this.tpLicenses.Name = "tpLicenses";
            this.tpLicenses.UseVisualStyleBackColor = true;
            // 
            // tpRefAssemblies
            // 
            resources.ApplyResources(this.tpRefAssemblies, "tpRefAssemblies");
            this.tpRefAssemblies.Name = "tpRefAssemblies";
            this.tpRefAssemblies.UseVisualStyleBackColor = true;
            // 
            // tpPlugIns
            // 
            resources.ApplyResources(this.tpPlugIns, "tpPlugIns");
            this.tpPlugIns.Name = "tpPlugIns";
            this.tpPlugIns.UseVisualStyleBackColor = true;
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpDescription.ResumeLayout(false);
            this.tpDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TabPage tpRefAssemblies;
        private System.Windows.Forms.TabPage tpPlugIns;
        private System.Windows.Forms.TabPage tpLicenses;
    }
}
