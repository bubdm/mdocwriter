namespace MDocWriter.Documents
{
    /// <summary>
    /// Represents the base class for the visitors that will
    /// walk through the whole <see cref="Document"/> instance.
    /// </summary>
    public abstract class DocumentWalker : IVisitor
    {
        /// <summary>
        /// Visits the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        public void VisitDocument(Document document)
        {
            document.Accept(this);
        }

        #region IVisitor Members

        /// <summary>
        /// Visits the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        public abstract void Visit(Document document);

        /// <summary>
        /// Visits the specified document node.
        /// </summary>
        /// <param name="documentNode">The document node.</param>
        public abstract void Visit(DocumentNode documentNode);

        /// <summary>
        /// Visits the specified document resource.
        /// </summary>
        /// <param name="documentResource">The document resource.</param>
        public abstract void Visit(DocumentResource documentResource);

        #endregion
    }
}
