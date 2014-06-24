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
    using MDocWriter.Documents;
    using MDocWriter.WinFormMain.Properties;

    public partial class FrmDocumentPropertyEditor : Form
    {
        private readonly DocumentPropertyEditorBehavior behavior;

        private readonly Document document;

        public FrmDocumentPropertyEditor()
        {
            InitializeComponent();
            this.behavior = DocumentPropertyEditorBehavior.NewDocument;
        }

        public FrmDocumentPropertyEditor(Document document)
            : this()
        {
            this.behavior = DocumentPropertyEditorBehavior.EditDocument;
            this.document = document;
        }

        public WorkspaceSettings WorkspaceSettings { get; private set; }

        private void FrmNewDocument_Shown(object sender, EventArgs e)
        {
            switch (this.behavior)
            {
                case DocumentPropertyEditorBehavior.NewDocument:
                    lblDlgTitle.Text = Resources.CreateNewDocument;
                    lblDlgDesc.Text = Resources.CreateNewDocumentPrompt;
                    txtTitle.Text = string.Empty;
                    txtAuthor.Text = string.Empty;
                    this.Text = Resources.CreateNewDocument;
                    this.Icon = Resources.NewIcon;
                    break;
                case DocumentPropertyEditorBehavior.EditDocument:
                    lblDlgTitle.Text = Resources.EditDocumentProperty;
                    lblDlgDesc.Text = Resources.EditDocumentPropertyPrompt;
                    txtTitle.Text = this.document.Title;
                    txtAuthor.Text = this.document.Author;
                    this.Text = Resources.EditDocumentProperty;
                    this.Icon = Resources.EditIcon;
                    break;

            }
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

    public enum DocumentPropertyEditorBehavior
    {
        NewDocument,
        EditDocument
    }
}
