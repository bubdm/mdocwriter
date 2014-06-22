namespace MDocWriter.Documents
{
    /// <summary>
    /// Represents that the implemented classes are visitor acceptors
    /// that can accepts a visitor and take specific actions.
    /// </summary>
    public interface IVisitorAcceptor
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor to be accepted by the current acceptor.</param>
        void Accept(IVisitor visitor);
    }
}
