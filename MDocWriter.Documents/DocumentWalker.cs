using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Documents
{
    public abstract class DocumentWalker : IVisitor
    {
        public void VisitDocument(Document document)
        {
            document.Accept(this);
        }

        #region IVisitor Members

        public abstract void Visit(Document document);

        public abstract void Visit(DocumentNode documentNode);

        public abstract void Visit(DocumentResource documentResource);

        #endregion
    }
}
