
using System;

namespace MDocWriter.Documents
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents that the implemented classes are document nodes.
    /// </summary>
    public interface IDocumentNode
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; }

        /// <summary>
        /// Gets the children of the current document node.
        /// </summary>
        /// <value>
        /// The children of the current document node.
        /// </value>
        IEnumerable<DocumentNode> Children { get; }

        /// <summary>
        /// Adds the child document node.
        /// </summary>
        /// <param name="name">The name of the child node to be added.</param>
        /// <param name="content">The content of the child node to be added.</param>
        /// <param name="parent">The parent node, usually it is the current node.</param>
        /// <returns>A <see cref="DocumentNode"/> instance.</returns>
        DocumentNode AddChildDocumentNode(string name, string content = null, DocumentNode parent = null);
    }
}
