namespace MDocWriter.WinFormMain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using MDocWriter.Application;

    public partial class FrmDocumentPropertyEditor : Form
    {
        public FrmDocumentPropertyEditor()
        {
            InitializeComponent();
        }

        public WorkspaceSettings WorkspaceSettings { get; private set; }

        private void FrmNewDocument_Shown(object sender, EventArgs e)
        {
            txtTitle.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, "You must specify the title for the document.");
                this.DialogResult = DialogResult.None;
                return;
            }
            this.WorkspaceSettings = new WorkspaceSettings
                                         {
                                             DocumentAuthor = this.txtAuthor.Text,
                                             DocumentTitle = this.txtTitle.Text
                                         };
        }
    }
}
