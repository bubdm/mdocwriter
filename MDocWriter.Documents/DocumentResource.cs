namespace MDocWriter.Documents
{
    using System;
    using System.Runtime.Serialization;
    using MDocWriter.Common;

    [Serializable]
    public sealed class DocumentResource : PropertyChangedNotifier, ISerializable, IVisitorAcceptor
    {
        private readonly Guid id;

        private string fileName;

        private string base64Data;

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

        public override string ToString()
        {
            return this.fileName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as DocumentResource;
            if (other == null) return false;
            return this.id.Equals(other.id);
        }

        public override int GetHashCode()
        {
            return Utils.GetHashCode(this.id.GetHashCode());
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.id);
            info.AddValue("FileName", this.fileName);
            info.AddValue("Base64Data", this.base64Data);
        }

        #endregion

        #region IVisitorAcceptor Members

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        #endregion
    }
}

