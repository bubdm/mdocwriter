namespace MDocWriter.Documents
{
    using MDocWriter.Common;

    public interface IVisitor
    {
        void Visit(Document document);
        void Visit(DocumentNode documentNode);
        void Visit(DocumentResource documentResource);
    }
}
