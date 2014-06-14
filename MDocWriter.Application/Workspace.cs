using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using MDocWriter.Documents;

namespace MDocWriter.Application
{
    public class Workspace
    {
        private readonly string workingDirectory;
        private readonly Document document;

        private Workspace()
        {
            this.document = new Document();
            this.workingDirectory = Path.GetTempPath();
        }

        private Workspace(string workingDirectory, Document document)
        {
            this.workingDirectory = workingDirectory;
            this.document = document;
        }

        public string WorkingDirectory
        {
            get
            {
                return workingDirectory;
            }
        }

        public Document Document
        {
            get
            {
                return this.document;
            }
        }

        public static Workspace Open(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var workingDirectory = Path.GetTempPath();
                if (!Directory.Exists(workingDirectory)) Directory.CreateDirectory(workingDirectory);
                var serializer = new BinaryFormatter();
                var document = (Document)serializer.Deserialize(fileStream);
                // Extract the resources
                if (document.Resources != null &&
                    document.Resources.Count() > 0)
                {
                    Parallel.ForEach(
                        document.Resources,
                        resource => File.WriteAllBytes(
                            Path.Combine(workingDirectory, resource.FileName),
                            Convert.FromBase64String(resource.Base64Data)));
                }
                return new Workspace(workingDirectory, document);
            }
        }

        public static void Save(string fileName)
        {
            
        }

        public static Workspace New()
        {
            var newWorkspace = new Workspace();
            if (!Directory.Exists(newWorkspace.WorkingDirectory)) Directory.CreateDirectory(newWorkspace.WorkingDirectory);
            return newWorkspace;
        }
    }
}
