namespace MDocWriter.WinFormMain.Controls
{
    partial class MarkdownEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpEditor = new System.Windows.Forms.TabPage();
            this.tpHtmlView = new System.Windows.Forms.TabPage();
            this.tpBrowserView = new System.Windows.Forms.TabPage();
            this.editor = new System.Windows.Forms.TextBox();
            this.html = new System.Windows.Forms.TextBox();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.tabControl.SuspendLayout();
            this.tpEditor.SuspendLayout();
            this.tpHtmlView.SuspendLayout();
            this.tpBrowserView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpEditor);
            this.tabControl.Controls.Add(this.tpHtmlView);
            this.tabControl.Controls.Add(this.tpBrowserView);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(490, 457);
            this.tabControl.TabIndex = 0;
            // 
            // tpEditor
            // 
            this.tpEditor.Controls.Add(this.editor);
            this.tpEditor.Location = new System.Drawing.Point(4, 22);
            this.tpEditor.Name = "tpEditor";
            this.tpEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tpEditor.Size = new System.Drawing.Size(482, 431);
            this.tpEditor.TabIndex = 0;
            this.tpEditor.Text = "Editor";
            this.tpEditor.UseVisualStyleBackColor = true;
            // 
            // tpHtmlView
            // 
            this.tpHtmlView.Controls.Add(this.html);
            this.tpHtmlView.Location = new System.Drawing.Point(4, 22);
            this.tpHtmlView.Name = "tpHtmlView";
            this.tpHtmlView.Padding = new System.Windows.Forms.Padding(3);
            this.tpHtmlView.Size = new System.Drawing.Size(482, 431);
            this.tpHtmlView.TabIndex = 1;
            this.tpHtmlView.Text = "Html View";
            this.tpHtmlView.UseVisualStyleBackColor = true;
            // 
            // tpBrowserView
            // 
            this.tpBrowserView.Controls.Add(this.browser);
            this.tpBrowserView.Location = new System.Drawing.Point(4, 22);
            this.tpBrowserView.Name = "tpBrowserView";
            this.tpBrowserView.Padding = new System.Windows.Forms.Padding(3);
            this.tpBrowserView.Size = new System.Drawing.Size(482, 431);
            this.tpBrowserView.TabIndex = 2;
            this.tpBrowserView.Text = "Browser View";
            this.tpBrowserView.UseVisualStyleBackColor = true;
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(3, 3);
            this.editor.Multiline = true;
            this.editor.Name = "editor";
            this.editor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.editor.Size = new System.Drawing.Size(476, 425);
            this.editor.TabIndex = 0;
            // 
            // html
            // 
            this.html.Dock = System.Windows.Forms.DockStyle.Fill;
            this.html.Location = new System.Drawing.Point(3, 3);
            this.html.Multiline = true;
            this.html.Name = "html";
            this.html.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.html.Size = new System.Drawing.Size(476, 425);
            this.html.TabIndex = 0;
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(3, 3);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(476, 425);
            this.browser.TabIndex = 0;
            // 
            // MarkdownEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "MarkdownEditor";
            this.Size = new System.Drawing.Size(490, 457);
            this.tabControl.ResumeLayout(false);
            this.tpEditor.ResumeLayout(false);
            this.tpEditor.PerformLayout();
            this.tpHtmlView.ResumeLayout(false);
            this.tpHtmlView.PerformLayout();
            this.tpBrowserView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpEditor;
        private System.Windows.Forms.TabPage tpHtmlView;
        private System.Windows.Forms.TabPage tpBrowserView;
        private System.Windows.Forms.TextBox editor;
        private System.Windows.Forms.TextBox html;
        private System.Windows.Forms.WebBrowser browser;
    }
}
