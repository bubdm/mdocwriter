namespace MDocWriter.Documents
{
    using MDocWriter.Common;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class Document : PropertyChangedNotifier, ISerializable, IVisitorAcceptor
    {
        private readonly ObservableCollection<DocumentNode> children = new ObservableCollection<DocumentNode>();

        private readonly ObservableCollection<DocumentResource> resources = new ObservableCollection<DocumentResource>();

        private string title;

        private string author;

        private DateTime dateCreated = DateTime.UtcNow;
 
        public Document()
        {
            this.children.CollectionChanged += (s, e) => this.OnPropertyChanged("Children");
            this.resources.CollectionChanged += (s, e) => this.OnPropertyChanged("Resources");
        }

        private Document(SerializationInfo info, StreamingContext context)
            : this()
        {
            this.title = info.GetString("Title");
            this.author = info.GetString("Author");
            this.dateCreated = info.GetDateTime("DateCreated");
            this.children =
                (ObservableCollection<DocumentNode>)
                info.GetValue("Children", typeof(ObservableCollection<DocumentNode>));
            this.resources =
                (ObservableCollection<DocumentResource>)
                info.GetValue("Resources", typeof(ObservableCollection<DocumentResource>));
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (this.author != value)
                {
                    this.author = value;
                    this.OnPropertyChanged("Author");
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

        public IEnumerable<DocumentNode> Children
        {
            get
            {
                return this.children;
            }
        }

        public IEnumerable<DocumentResource> Resources
        {
            get
            {
                return this.resources;
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
            return this.title;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            var other = obj as Document;
            if (other == null) return false;
            return this.title == other.title;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Utils.GetHashCode(
                this.title.GetHashCode(),
                this.author.GetHashCode(),
                this.dateCreated.GetHashCode(),
                this.children.GetHashCode(),
                this.resources.GetHashCode());
        }

        #region ISerializable Members

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", this.title);
            info.AddValue("Author", this.author);
            info.AddValue("DateCreated", this.dateCreated);
            info.AddValue("Children", this.children);
            info.AddValue("Resources", this.resources);
        }

        #endregion

        public DocumentNode AddChildDocumentNode(string name, string content = null, DocumentNode parent = null)
        {
            if (this.children.Any(child => child.Name == name))
            {
                throw new InvalidOperationException("The document node already exists.");
            }
            var documentNode = new DocumentNode(name, content, parent);
            documentNode.PropertyChanged += (s, e) => this.OnPropertyChanged("Children");
            this.children.Add(documentNode);
            return documentNode;
        }

        public DocumentResource AddDocumentResource(string fileName, string base64Data)
        {
            if (this.resources.Any(resource => resource.FileName == fileName))
            {
                throw new InvalidOperationException("The document resource already exists.");
            }
            var documentResource = new DocumentResource(fileName, base64Data);
            documentResource.PropertyChanged += (s, e) => this.OnPropertyChanged("Resources");
            this.resources.Add(documentResource);
            return documentResource;
        }

        #region IVisitorAcceptor Members

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var child in this.children)
            {
                child.Accept(visitor);
            }
            foreach (var resource in this.resources)
            {
                resource.Accept(visitor);
            }
        }

        #endregion
    }
}
