
namespace MDocWriter.Application
{
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;
    using MDocWriter.Documents;
    using MDocWriter.Templates;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the workspace concept on which the users
    /// are able to manipulate the documents.
    /// </summary>
    public sealed class Workspace
    {
        #region Private Constants

        private const string TemplateTempDirectoryPattern = @"_t_{0}";
        #endregion

        #region Private Fields
        private readonly string workingDirectory;
        private readonly Document document;

        private WorkspaceStatus status = WorkspaceStatus.NewlyCreated;
        private string fileName;
        private bool isModified;
        #endregion

        /// <summary>
        /// Prevents a default instance of the <see cref="Workspace"/> class from being created.
        /// </summary>
        //private Workspace()
        //    : this(new WorkspaceSettings { DocumentAuthor = null, DocumentTitle = null, Version = new Version(1, 0, 0, 0) })
        //{
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="Workspace"/> class.
        /// </summary>
        /// <param name="settings">The <see cref="WorkspaceSettings"/> instance.</param>
        private Workspace(WorkspaceSettings settings)
            : this(
                string.Empty,
                Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()),
                new Document(settings.DocumentTitle, settings.Version, settings.DocumentAuthor, settings.TemplateId))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Workspace"/> class.
        /// </summary>
        /// <param name="fileName">Name of the document file.</param>
        /// <param name="workingDirectory">The working directory.</param>
        /// <param name="document">The document instance.</param>
        /// <param name="attachDocumentEvent">if set to <c>true</c> [attach document event].</param>
        private Workspace(string fileName, string workingDirectory, Document document, bool attachDocumentEvent = true)
        {
            this.fileName = fileName;
            this.workingDirectory = workingDirectory;
            this.document = document;
            if (attachDocumentEvent) this.document.PropertyChanged += (s, e) => this.OnModified((Document)s, e.PropertyName);
        }

        public event EventHandler<ModifiedEventArgs> Modified;

        public event EventHandler Saved;

        public string WorkingDirectory
        {
            get
            {
                return this.workingDirectory;
            }
        }

        public Document Document
        {
            get
            {
                return this.document;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
        }

        public WorkspaceStatus Status
        {
            get
            {
                return this.status;
            }
        }

        public bool IsModified
        {
            get
            {
                return this.isModified;
            }
        }

        private void OnModified(Document originator, string propertyName)
        {
            var handler = this.Modified;
            if (handler != null)
            {
                handler(this, new ModifiedEventArgs(originator, propertyName));
            }
            this.isModified = true;
        }

        private void OnSaved()
        {
            var handler = this.Saved;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
            this.isModified = false;
        }

        public void ExtractTemplateResources()
        {
            if (this.document == null) throw new InvalidOperationException("There is no document opened in the workspace.");
            var templateId = this.document.TemplateId;
            var templateReader = new TemplateReader();
            var template = templateReader.GetTemplate(templateId);
            if (template != null && template.Resources != null &&
                template.Resources.Length > 0)
            {
                // prepare the directory under working directory to store the resources
                var templateResourceDirectory = Path.Combine(
                    this.workingDirectory,
                    string.Format(TemplateTempDirectoryPattern, templateId.ToString().ToUpper().Replace("-", "_")));
                if (Directory.Exists(templateResourceDirectory))
                    Directory.Delete(templateResourceDirectory, true);

                Directory.CreateDirectory(templateResourceDirectory);

                // read all the entries in the zip file, and find the resource items
                using (var templateFileStream = File.OpenRead(template.MDocxTemplateFileName))
                using (var zipFile = new ZipFile(templateFileStream))
                {
                    foreach (ZipEntry zipEntry in zipFile)
                    {
                        var zipEntryName = zipEntry.Name.Replace('/', '\\');
                        if (zipEntry.IsFile && template.Resources.Any(r => string.Equals(zipEntryName, r)))
                        {
                            var outputFileName = Path.Combine(templateResourceDirectory, zipEntryName);
                            var outputDirectoryName = Path.GetDirectoryName(outputFileName);
                            if (!string.IsNullOrEmpty(outputDirectoryName) && !Directory.Exists(outputDirectoryName)) Directory.CreateDirectory(outputDirectoryName);
                            using (var zipEntryStream = zipFile.GetInputStream(zipEntry))
                            using (var outputFileStream = File.OpenWrite(outputFileName))
                            {
                                var buffer = new byte[4096];
                                StreamUtils.Copy(zipEntryStream, outputFileStream, buffer);
                            }
                        }
                    }
                }
            }
        }

        public string Transform(string htmlBodyContent)
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     {
                                         Template.MacroTemporaryTemplatePath,
                                         Path.Combine(
                                             this.workingDirectory,
                                             string.Format(
                                                 TemplateTempDirectoryPattern,
                                                 this.document.TemplateId.ToString()
                                         .ToUpper()
                                         .Replace("-", "_")))
                                     },
                                     { Template.MacroDocumentTitle, this.document.Title },
                                     { Template.MacroDocumentAuthor, this.document.Author },
                                     {
                                         Template.MacroDocumentVersion,
                                         this.document.Version.ToString()
                                     },
                                     { Template.MacroDocumentBody, htmlBodyContent }
                                 };
            return Transform(parameters);
        }

        private string Transform(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var templateReader = new TemplateReader();
            var template = templateReader.GetTemplate(this.document.TemplateId);
            if (template != null)
            {
                var templateContent = templateReader.GetTemplateContent(template);
                foreach (var kvp in parameters)
                {
                    if (templateContent.IndexOf(kvp.Key, StringComparison.Ordinal) > 0)
                    {
                        templateContent = templateContent.Replace(kvp.Key, kvp.Value);
                    }
                }
                return templateContent;
            }
            var keyValuePairs = parameters as KeyValuePair<string, string>[] ?? parameters.ToArray();
            return keyValuePairs.Any(p => p.Key.Equals(Template.MacroDocumentBody))
                       ? keyValuePairs.First(p => p.Key.Equals(Template.MacroDocumentBody)).Value
                       : null;
        }

        public static Workspace Open(EventHandler<ModifiedEventArgs> onModifiedHandler, EventHandler onSavedHandler, string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var workingDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                if (!Directory.Exists(workingDirectory)) Directory.CreateDirectory(workingDirectory);
                var serializer = new BinaryFormatter();
                var document = (Document)serializer.Deserialize(fileStream);
                var wks = new Workspace(fileName, workingDirectory, document) { status = WorkspaceStatus.Existing };
                // Extract the resources
                if (document.Resources != null &&
                    document.Resources.Any())
                {
                    Parallel.ForEach(
                        document.Resources,
                        resource => File.WriteAllBytes(
                            Path.Combine(workingDirectory, resource.FileName),
                            Convert.FromBase64String(resource.Base64Data)));
                }
                // Prepare the template resources
                if (document.TemplateId != Guid.Empty)
                {
                    wks.ExtractTemplateResources();
                }
                if (onModifiedHandler != null) wks.Modified += onModifiedHandler;
                if (onSavedHandler != null) wks.Saved += onSavedHandler;
                return wks;
            }
        }

        

        public static void Save(string fileName, Workspace workspace)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(fileStream, workspace.Document);
                workspace.fileName = fileName;
                workspace.status = WorkspaceStatus.Existing;
                workspace.OnSaved();
            }
        }

        public static Workspace New(EventHandler<ModifiedEventArgs> onModifiedHandler, EventHandler onSavedHandler, WorkspaceSettings settings)
        {
            var newWorkspace = new Workspace(settings);
            if (onModifiedHandler != null)
            {
                newWorkspace.Modified += onModifiedHandler;
            }
            if (onSavedHandler != null)
            {
                newWorkspace.Saved += onSavedHandler;
            }
            newWorkspace.OnModified(newWorkspace.Document, string.Empty);
            if (!Directory.Exists(newWorkspace.WorkingDirectory)) Directory.CreateDirectory(newWorkspace.WorkingDirectory);
            if (settings.TemplateId != Guid.Empty)
            {
                newWorkspace.ExtractTemplateResources();
            }
            return newWorkspace;
        }

        //public static Workspace New(EventHandler onModifiedHandler, EventHandler onSavedHandler)
        //{
        //    var newWorkspace = new Workspace();
        //    if (onModifiedHandler != null)
        //    {
        //        newWorkspace.Modified += onModifiedHandler;
        //    }
        //    if (onSavedHandler != null)
        //    {
        //        newWorkspace.Saved += onSavedHandler;
        //    }
        //    newWorkspace.OnModified();
        //    if (!Directory.Exists(newWorkspace.WorkingDirectory)) Directory.CreateDirectory(newWorkspace.WorkingDirectory);
        //    return newWorkspace;
        //}

        public static void Close(ref Workspace workspace, EventHandler<ModifiedEventArgs> onModifiedHandler, EventHandler onSavedHandler)
        {
            if (workspace != null)
            {
                workspace.Modified -= onModifiedHandler;
                workspace.Saved -= onSavedHandler;
                workspace = null;
            }
        }
    }
}
