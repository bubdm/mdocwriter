namespace MDocWriter.Documents
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;

    using MDocWriter.Common;

    /// <summary>
    /// Represents a document node in the document model.
    /// </summary>
    [Serializable]
    public sealed class DocumentNode : PropertyChangedNotifier, ISerializable, IVisitorAcceptor, IDocumentNode
    {
        #region Private Fields
        private readonly ObservableCollection<DocumentNode> children = new ObservableCollection<DocumentNode>();
        private readonly Guid id;
        private string name;
        private string content;
        private DateTime dateCreated;
        private DateTime? dateLastModified;
        private IDocumentNode parent;
        #endregion

        internal DocumentNode(string name, string content = null, IDocumentNode parent = null)
            : this()
        {
            this.name = name;
            this.content = content;
            this.parent = parent;
            this.dateCreated = DateTime.UtcNow;
        }

        private DocumentNode()
        {
            this.id = Guid.NewGuid();
            children.CollectionChanged += (s, e) => this.OnPropertyChanged("Children");
        }

        private DocumentNode(SerializationInfo info, StreamingContext context)
        {
            this.id = (Guid)info.GetValue("Id", typeof(Guid));
            this.name = info.GetString("Name");
            this.content = info.GetString("Content");
            this.dateLastModified = (DateTime?)info.GetValue("DateLastModified", typeof(DateTime?));
            this.dateCreated = info.GetDateTime("DateCreated");
            this.parent = (IDocumentNode)info.GetValue("Parent", typeof(IDocumentNode));
            this.children =
                (ObservableCollection<DocumentNode>)
                info.GetValue("Children", typeof(ObservableCollection<DocumentNode>));
        }

        [OnDeserialized]
        private void OnDocumentNodeDeserialized(StreamingContext context)
        {
            if (this.children.Any())
            {
                foreach (var child in this.children) child.PropertyChanged += (s, e) => this.OnPropertyChanged("Children");
            }
            this.children.CollectionChanged += (s, e) => this.OnPropertyChanged("Children");
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                if (this.content != value)
                {
                    this.content = value;
                    this.OnPropertyChanged("Content");
                }
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated;
            }
            set
            {
                if (this.dateCreated != value)
                {
                    this.dateCreated = value;
                    this.OnPropertyChanged("DateCreated");
                }
            }
        }

        public DateTime? DateLastModified
        {
            get
            {
                return this.dateLastModified;
            }
            set
            {
                if (this.dateLastModified != value)
                {
                    this.dateLastModified = value;
                    this.OnPropertyChanged("DateLastModified");
                }
            }
        }

        public IDocumentNode Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                if (!this.parent.Equals(value))
                {
                    this.parent = value;
                    this.OnPropertyChanged("Parent");
                }
            }
        }

        public IEnumerable<DocumentNode> Children
        {
            get
            {
                return this.children;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.name;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"></see>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as DocumentNode;
            if (other == null) return false;
            return this.id.Equals(other.id);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Utils.GetHashCode(this.id.GetHashCode());
        }

        #region ISerializable Members

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.id);
            info.AddValue("Name", this.name);
            info.AddValue("Content", this.content);
            info.AddValue("DateCreated", this.dateCreated);
            info.AddValue("DateLastModified", this.dateLastModified);
            info.AddValue("Parent", this.parent);
            info.AddValue("Children", this.children);
        }

        #endregion

        public DocumentNode AddDocumentNode(string name, string content = null)
        {
            if (this.children.Any(child => child.Name == name))
                throw new InvalidOperationException("The document node already exists.");
            var documentNode = new DocumentNode(name, content, this);
            documentNode.PropertyChanged += (s, e) => this.OnPropertyChanged("Children");
            this.children.Add(documentNode);
            return documentNode;
        }

        /// <summary>
        /// Removes the document node from the children collection of this node.
        /// </summary>
        /// <param name="id">The identifier of the document node that needs to be removed.</param>
        public void RemoveDocumentNode(Guid id)
        {
            if (this.children.All(child => child.Id != id))
            {
                throw new InvalidOperationException("The document node doesn't exist.");
            }
            var found = this.children.First(dn => dn.Id == id);
            RemoveChildNodes(found);
            this.children.Remove(found);
        }

        internal static void RemoveChildNodes(DocumentNode parent)
        {
            var children = parent.Children.ToArray();
            var count = children.Length;
            for (var i = 0; i < count; i++)
            {
                RemoveChildNodes(children[i]);
                parent.RemoveDocumentNode(children[i].Id);
            }
        }

        #region IVisitorAcceptor Members

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var child in this.children)
            {
                child.Accept(visitor);
            }
        }

        #endregion
    }
}
