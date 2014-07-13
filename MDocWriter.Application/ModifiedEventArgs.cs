using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Application
{
    using MDocWriter.Documents;

    public sealed class ModifiedEventArgs : System.EventArgs
    {
        public Document Originator { get; private set; }
        public string PropertyName { get; private set; }

        public ModifiedEventArgs(Document originator, string propertyName)
        {
            this.Originator = originator;
            this.PropertyName = propertyName;
        }
    }
}
