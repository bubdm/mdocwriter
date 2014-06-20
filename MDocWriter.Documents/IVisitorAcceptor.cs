namespace MDocWriter.Documents
{
    public interface IVisitorAcceptor
    {
        void Accept(IVisitor visitor);
    }
}
