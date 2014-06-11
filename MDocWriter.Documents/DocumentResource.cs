using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Documents
{
    [Serializable]
    public sealed class DocumentResource
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Base64Data { get; set; }
    }
}
