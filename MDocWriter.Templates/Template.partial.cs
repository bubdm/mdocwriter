

namespace MDocWriter.Templates
{
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    partial class Template
    {
        public const string TemplateFileExtension = "mdocxtemplate";
        public const string TemplateDefinitionFileName = @"TemplateDefinition.xml";
        public const string TemplateDirectory = @"templates";

        [XmlIgnore]
        public string MDocxTemplateFileName { get; internal set; }

        public override string ToString()
        {
            return this.Name;
        }

        public static string TemplatePath
        {
            get
            {
                return Path.Combine(Application.StartupPath, TemplateDirectory);
            }
        }

        public static string TemplateFileSearchPattern
        {
            get
            {
                return string.Format("*.{0}", TemplateFileExtension);
            }
        }
    }
}
