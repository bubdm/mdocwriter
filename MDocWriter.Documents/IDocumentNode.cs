

namespace MDocWriter.Documents
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents that the implemented classes are document nodes.
    /// </summary>
    public interface IDocumentNode
    {
        /// <summary>
        /// Gets the unique identifier of the current node.
        /// </summary>
        /// <value>
        /// The unique identifier which represents the current node.
        /// </value>
        Guid Id { get; }

        /// <summary>
        /// Gets the parent of the current node.
        /// </summary>
        /// <value>
        /// The parent of the current node.
        /// </value>
        IDocumentNode Parent { get; }

        /// <summary>
        /// Gets the child document nodes of the current document node.
        /// </summary>
        /// <value>
        /// The child document nodes of the current document node.
        /// </value>
        IEnumerable<DocumentNode> Children { get; }

        /// <summary>
        /// Adds the child document node.
        /// </summary>
        /// <param name="name">The name of the child node to be added.</param>
        /// <param name="content">The content of the child node to be added.</param>
        /// <returns>A <see cref="DocumentNode"/> instance which represents a document node
        /// in the document model.</returns>
        DocumentNode AddDocumentNode(string name, string content = null);

        /// <summary>
        /// Removes the document node from the children collection of this node.
        /// </summary>
        /// <param name="id">The identifier of the document node that needs to be removed.</param>
        void RemoveDocumentNode(Guid id);
    }
}
