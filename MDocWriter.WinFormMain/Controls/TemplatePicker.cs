

namespace MDocWriter.WinFormMain.Controls
{
    using MDocWriter.Templates;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class TemplatePicker : UserControl
    {
        private Template selectedTemplate;
        private readonly TemplateReader templateReader = new TemplateReader();
        public TemplatePicker()
        {
            InitializeComponent();
        }

        public Template SelectedTemplate
        {
            get
            {
                return selectedTemplate;
            }
            set
            {
                this.selectedTemplate = value;
            }
        }

        private void BindTemplate(Template template)
        {
            this.txtAuthor.Text = template.Author;
            this.txtCompany.Text = template.Company;
            this.txtCopyright.Text = template.Copyright;
            this.txtDescription.Text = template.Description;
            this.txtVersion.Text = template.Version.ToString();
            this.previewImage.Image = templateReader.GetPreviewImage(template);
        }

        private void TemplatePicker_Load(object sender, EventArgs e)
        {
            this.cbName.Items.Clear();
            var templates = templateReader.Templates as Template[] ?? templateReader.Templates.ToArray();
            if (templates.Any())
            {
                foreach (var template in templates)
                {
                    this.cbName.Items.Add(template);
                }
                if (this.selectedTemplate == null) this.cbName.SelectedIndex = 0;
                else this.cbName.SelectedItem = templates.First(t => t.Id == this.selectedTemplate.Id);

            }

        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedTemplate = (Template)this.cbName.SelectedItem;
            this.BindTemplate(this.selectedTemplate);
        }

    }
}
