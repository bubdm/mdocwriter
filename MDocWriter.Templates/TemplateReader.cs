

namespace MDocWriter.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Xml.Serialization;

    using ICSharpCode.SharpZipLib.Zip;

    public sealed class TemplateReader
    {
        private readonly List<Template> templates = new List<Template>();

        public TemplateReader()
            : this(Template.TemplatePath, Template.TemplateFileSearchPattern)
        {
        }

        public TemplateReader(string templatePath, string templateFileSearchPattern)
        {
            var templateFiles = Directory.GetFiles(templatePath, templateFileSearchPattern, SearchOption.TopDirectoryOnly);
            foreach (var templateFile in templateFiles)
            {
                try
                {
                    using (var fileStream = File.OpenRead(templateFile))
                    {
                        var zipFile = new ZipFile(fileStream);
                        foreach (ZipEntry zipEntry in zipFile)
                        {
                            if (zipEntry.IsFile && zipEntry.Name == Template.TemplateDefinitionFileName)
                            {
                                using (var zipStream = zipFile.GetInputStream(zipEntry))
                                {
                                    var xmlSerializer = new XmlSerializer(typeof(Template));
                                    var template = (Template)xmlSerializer.Deserialize(zipStream);
                                    template.MDocxTemplateFileName = templateFile;
                                    this.templates.Add(template);
                                }
                            }
                        }
                    }
                }
                    // ReSharper disable EmptyGeneralCatchClause
                catch
                    // ReSharper restore EmptyGeneralCatchClause
                {
                }
            }
        }

        public string GetTemplateContent(Template template)
        {
            if (template==null)
                throw new ArgumentNullException("template");
            if (string.IsNullOrEmpty(template.MDocxTemplateFileName))
                throw new ArgumentNullException("template.TemplateFileName");
            using (var fileStream = File.OpenRead(template.MDocxTemplateFileName))
            {
                var zipFile = new ZipFile(fileStream);
                var cssEntry = zipFile.GetEntry(template.TemplateFile);
                using (var reader = new StreamReader(zipFile.GetInputStream(cssEntry)))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public Image GetPreviewImage(Template template)
        {
            if (template==null)
                throw new ArgumentNullException("template");
            if (string.IsNullOrEmpty(template.MDocxTemplateFileName))
                throw new ArgumentNullException("template.TemplateFileName");
            using (var fileStream = File.OpenRead(template.MDocxTemplateFileName))
            {
                var zipFile = new ZipFile(fileStream);
                var previewImageEntry = zipFile.GetEntry(template.Preview);
                return Image.FromStream(zipFile.GetInputStream(previewImageEntry));
            }
        }

        /// <summary>
        /// Checks if the template with the given Id exists.
        /// </summary>
        /// <param name="templateId">The template identifier.</param>
        /// <returns>true if exists, otherwise, false.</returns>
        public bool Exists(Guid templateId)
        {
            return
                this.templates.Exists(
                    t => String.Compare(t.Id, templateId.ToString(), StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        public IEnumerable<Template> Templates
        {
            get
            {
                return this.templates;
            }
        }

    }
}
