

namespace MDocWriter.WinFormMain.Controls
{
    using MDocWriter.Templates;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class TemplatePicker : UserControl
    {
        private Guid selectedTemplateId;
        private readonly TemplateReader templateReader = new TemplateReader();
        public TemplatePicker()
        {
            InitializeComponent();
        }

        public Guid SelectedTemplateId
        {
            get
            {
                return selectedTemplateId;
            }
            set
            {
                this.selectedTemplateId = value;
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
                if (this.selectedTemplateId == Guid.Empty ||
                    !this.templateReader.Exists(this.selectedTemplateId)) this.cbName.SelectedIndex = 0;
                else
                    this.cbName.SelectedItem =
                        templates.First(
                            t =>
                            String.Compare(
                                this.selectedTemplateId.ToString(),
                                t.Id,
                                StringComparison.InvariantCultureIgnoreCase) == 0);

            }

        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var template = (Template)this.cbName.SelectedItem;
            this.selectedTemplateId = new Guid(template.Id);
            this.BindTemplate(template);
        }

    }
}
