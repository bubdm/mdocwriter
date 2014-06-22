namespace MDocWriter.Application
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading.Tasks;

    using MDocWriter.Documents;

    public sealed class Workspace
    {
        private readonly string workingDirectory;
        private readonly Document document;

        private WorkspaceStatus status = WorkspaceStatus.NewlyCreated;

        private string fileName;
        private bool isModified;

        private Workspace()
            : this(new WorkspaceSettings { DocumentAuthor = null, DocumentTitle = null })
        {
        }

        private Workspace(WorkspaceSettings settings)
            : this(
                string.Empty,
                Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()),
                new Document(settings.DocumentTitle, settings.DocumentAuthor))
        {
        }

        private Workspace(string fileName, string workingDirectory, Document document, bool attachDocumentEvent = true)
        {
            this.fileName = fileName;
            this.workingDirectory = workingDirectory;
            this.document = document;
            if (attachDocumentEvent) this.document.PropertyChanged += (s, e) => this.OnModified();
        }

        public event EventHandler Modified;

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

        private void OnModified()
        {
            var handler = this.Modified;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
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

        public static Workspace Open(EventHandler onModifiedHandler, EventHandler onSavedHandler, string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var workingDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                if (!Directory.Exists(workingDirectory)) Directory.CreateDirectory(workingDirectory);
                var serializer = new BinaryFormatter();
                var document = (Document)serializer.Deserialize(fileStream);
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
                var wks = new Workspace(fileName, workingDirectory, document) { status = WorkspaceStatus.Existing };
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

        public static Workspace New(EventHandler onModifiedHandler, EventHandler onSavedHandler, WorkspaceSettings settings)
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
            newWorkspace.OnModified();
            if (!Directory.Exists(newWorkspace.WorkingDirectory)) Directory.CreateDirectory(newWorkspace.WorkingDirectory);
            return newWorkspace;
        }

        public static Workspace New(EventHandler onModifiedHandler, EventHandler onSavedHandler)
        {
            var newWorkspace = new Workspace();
            if (onModifiedHandler != null)
            {
                newWorkspace.Modified += onModifiedHandler;
            }
            if (onSavedHandler != null)
            {
                newWorkspace.Saved += onSavedHandler;
            }
            newWorkspace.OnModified();
            if (!Directory.Exists(newWorkspace.WorkingDirectory)) Directory.CreateDirectory(newWorkspace.WorkingDirectory);
            return newWorkspace;
        }

        public static void Close(Workspace workspace, EventHandler onModifiedHandler, EventHandler onSavedHandler)
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
