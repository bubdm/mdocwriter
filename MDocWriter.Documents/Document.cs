namespace MDocWriter.Documents
{
    using System.IO;

    using MDocWriter.Common;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;

    using MDocWriter.Templates;

    /// <summary>
    /// Represents the document model for the Markdown Document Writer.
    /// </summary>
    [Serializable]
    public sealed class Document : PropertyChangedNotifier, ISerializable, IVisitorAcceptor, IDocumentNode
    {
        #region Private Fields
        private readonly ObservableCollection<DocumentNode> children = new ObservableCollection<DocumentNode>();
        private readonly ObservableCollection<DocumentResource> resources = new ObservableCollection<DocumentResource>();
        private readonly Guid id;
        private string title;
        private string author;
        private Version version;
        private Guid templateId;
        private DateTime dateCreated = DateTime.UtcNow;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        public Document()
        {
            this.id = Guid.NewGuid();
            this.version = Version.Parse("1.0");
            this.children.CollectionChanged += (s, e) => this.OnPropertyChanged("Children");
            this.resources.CollectionChanged += (s, e) => this.OnPropertyChanged("Resources");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        /// <param name="title">The title of the document, for example, Anna Karenina.</param>
        /// <param name="author">The author of the document, for example, Leo Tolstoy.</param>
        public Document(string title, Version version, string author = null, Guid templateId = default(Guid))
            : this()
        {
            this.title = title;
            this.version = version;
            this.author = author;
            this.templateId = templateId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        private Document(SerializationInfo info, StreamingContext context)
        {
            this.id = (Guid)info.GetValue("Id", typeof(Guid));
            this.title = info.GetString("Title");
            this.author = info.GetString("Author");
            this.dateCreated = info.GetDateTime("DateCreated");
            this.version = (Version)info.GetValue("Version", typeof(Version));
            this.templateId = (Guid)info.GetValue("TemplateId", typeof(Guid));
            this.children =
                (ObservableCollection<DocumentNode>)
                info.GetValue("Children", typeof(ObservableCollection<DocumentNode>));
            this.resources =
                (ObservableCollection<DocumentResource>)
                info.GetValue("Resources", typeof(ObservableCollection<DocumentResource>));

            this.children.CollectionChanged += (s, e) => this.OnPropertyChanged("Children");
            this.resources.CollectionChanged += (s, e) => this.OnPropertyChanged("Resources");
        }
        #endregion

        #region Private Methods
        [OnDeserialized]
        private void OnDocumentDeserialized(StreamingContext context)
        {
            if (this.children.Any())
            {
                foreach (var child in this.children) child.PropertyChanged += (s, e) => this.OnPropertyChanged("Children");
            }
            if (this.resources.Any())
            {
                foreach (var resource in this.resources) resource.PropertyChanged += (s, e) => this.OnPropertyChanged("Resources");
            }
            this.children.CollectionChanged += (s, e) => this.OnPropertyChanged("Children");
            this.resources.CollectionChanged += (s, e) => this.OnPropertyChanged("Resources");
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the title of the document, for example, Anna Karenina.
        /// </summary>
        /// <value>
        /// The title of the document.
        /// </value>
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

        /// <summary>
        /// Gets or sets the author of the document, for example, Leo Tolstoy.
        /// </summary>
        /// <value>
        /// The author of the document.
        /// </value>
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

        /// <summary>
        /// Gets or sets the date on which the document was created.
        /// </summary>
        /// <value>
        /// The document created date.
        /// </value>
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

        /// <summary>
        /// Gets or sets the version of the document.
        /// </summary>
        /// <value>
        /// The version of the document.
        /// </value>
        public Version Version
        {
            get
            {
                return this.version;
            }
            set
            {
                if (this.version != value)
                {
                    this.version = value;
                    this.OnPropertyChanged("Version");
                }
            }
        }

        public Guid TemplateId
        {
            get
            {
                return this.templateId;
            }
            set
            {
                if (this.templateId != value)
                {
                    this.templateId = value;
                    this.OnPropertyChanged("TemplateId");
                }
            }
        }

        /// <summary>
        /// Gets the resources used by the current document.
        /// </summary>
        /// <value>
        /// The resources that was used by the current document.
        /// </value>
        public IEnumerable<DocumentResource> Resources
        {
            get
            {
                return this.resources;
            }
        }
        #endregion

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
            return this.id == other.id;
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

        public void RemoveDocumentResource(Guid id)
        {
            var resource = this.resources.FirstOrDefault(r => r.Id == id);
            if (resource != null)
            {
                this.resources.Remove(resource);
            }
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
            info.AddValue("Title", this.title);
            info.AddValue("Author", this.author);
            info.AddValue("DateCreated", this.dateCreated);
            info.AddValue("Version", this.version);
            info.AddValue("TemplateId", this.templateId);
            info.AddValue("Children", this.children);
            info.AddValue("Resources", this.resources);
        }

        #endregion

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

        #region IDocumentNode Members
        /// <summary>
        /// Gets the unique identifier of the current node.
        /// </summary>
        /// <value>
        /// The unique identifier which represents the current node.
        /// </value>
        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the parent of the current node.
        /// </summary>
        /// <value>
        /// The parent of the current node.
        /// </value>
        /// <remarks>For the <see cref="Document"/> instance, the Parent is always
        /// <c>null</c> (<c>Nothing</c> in Visual Basic).</remarks>
        public IDocumentNode Parent
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the child document nodes of the current document node.
        /// </summary>
        /// <value>
        /// The child document nodes of the current document node.
        /// </value>
        public IEnumerable<DocumentNode> Children
        {
            get
            {
                return this.children;
            }
        }

        /// <summary>
        /// Adds the child document node.
        /// </summary>
        /// <param name="name">The name of the child node to be added.</param>
        /// <param name="content">The content of the child node to be added.</param>
        /// <returns>
        /// A <see cref="DocumentNode" /> instance which represents a document node
        /// in the document model.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">The document node already exists.</exception>
        public DocumentNode AddDocumentNode(string name, string content = null)
        {
            if (this.children.Any(child => child.Name == name))
            {
                throw new InvalidOperationException("The document node already exists.");
            }
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
            DocumentNode.RemoveChildNodes(found);
            this.children.Remove(found);
        }
        #endregion
    }
}
