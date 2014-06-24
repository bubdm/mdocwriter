namespace MDocWriter.Documents
{
    using System;
    using System.Runtime.Serialization;
    using MDocWriter.Common;

    /// <summary>
    /// Represents the document resource object in the document model.
    /// </summary>
    [Serializable]
    public sealed class DocumentResource : PropertyChangedNotifier, ISerializable, IVisitorAcceptor
    {
        #region Private Fields
        private readonly Guid id;
        private string fileName;
        private string base64Data;
        #endregion

        internal DocumentResource(string fileName, string base64Data)
            : this()
        {
            this.fileName = fileName;
            this.base64Data = base64Data;
        }

        private DocumentResource()
        {
            this.id = Guid.NewGuid();
        }

        private DocumentResource(SerializationInfo info, StreamingContext context)
        {
            this.id = (Guid)info.GetValue("Id", typeof(Guid));
            this.fileName = info.GetString("FileName");
            this.base64Data = info.GetString("Base64Data");
        }

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                if (this.fileName != value)
                {
                    this.fileName = value;
                    this.OnPropertyChanged("FileName");
                }
            }
        }

        public string Base64Data
        {
            get
            {
                return this.base64Data;
            }
            set
            {
                if (this.base64Data != value)
                {
                    this.base64Data = value;
                    this.OnPropertyChanged("Base64Data");
                }
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
            return this.fileName;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as DocumentResource;
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
            info.AddValue("FileName", this.fileName);
            info.AddValue("Base64Data", this.base64Data);
        }

        #endregion

        #region IVisitorAcceptor Members

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor to be accepted by the current acceptor.</param>
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        #endregion
    }
}

