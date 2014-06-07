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
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public List<DocumentNode> Children { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
