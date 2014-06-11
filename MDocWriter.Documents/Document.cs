using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Documents
{
    [Serializable]
    public sealed class Document
    {
        public Document()
        {
            this.Children = new List<DocumentNode>();
            this.Resources = new List<DocumentResource>();
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public List<DocumentNode> Children { get; set; }

        public List<DocumentResource> Resources { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
