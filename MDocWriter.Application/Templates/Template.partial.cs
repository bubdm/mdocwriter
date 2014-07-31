

using System.IO;
using System.Xml.Serialization;

namespace MDocWriter.Application.Templates
{
    partial class Template
    {
        public const string TemplateFileExtension = "mdocxtemplate";
        public const string TemplateDefinitionFileName = @"TemplateDefinition.xml";
        public const string TemplateDirectory = @"templates";

        public const string MacroTemporaryTemplatePath = "{$template_path$}";

        public const string MacroDocumentVersion = "{$document_version$}";

        public const string MacroDocumentTitle = "{$document_title$}";

        public const string MacroDocumentAuthor = "{$document_author$}";

        public const string MacroDocumentBody = "{$document_body$}";

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
                return Path.Combine(System.Windows.Forms.Application.StartupPath, TemplateDirectory);
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
