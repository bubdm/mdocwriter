namespace MDocWriter.Documents
{
    /// <summary>
    /// Represents that the implemented classes are visitors.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// Visits the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        void Visit(Document document);
        /// <summary>
        /// Visits the specified document node.
        /// </summary>
        /// <param name="documentNode">The document node.</param>
        void Visit(DocumentNode documentNode);
        /// <summary>
        /// Visits the specified document resource.
        /// </summary>
        /// <param name="documentResource">The document resource.</param>
        void Visit(DocumentResource documentResource);
    }
}
