using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Documents
{
    [Serializable]
    public sealed class DocumentNode
    {
        public DocumentNode()
        {
            this.Children = new List<DocumentNode>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime? DateLastModified { get; set; }

        public DocumentNode Parent { get; set; }

        public List<DocumentNode> Children { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
