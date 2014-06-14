using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using MDocWriter.Common;

namespace MDocWriter.Documents
{
    [Serializable]
    public sealed class DocumentResource : PropertyChangedNotifier, ISerializable
    {
        private Guid id;

        private string fileName;

        private string base64Data;

        public DocumentResource()
        {

        }

        private DocumentResource(SerializationInfo info, StreamingContext context)
            : this()
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
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.OnPropertyChanged("Id");
                }
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
            return Utils.GetHashCode(this.id.GetHashCode(), this.fileName.GetHashCode(), this.base64Data.GetHashCode());
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.id);
            info.AddValue("FileName", this.fileName);
            info.AddValue("Base64Data", this.base64Data);
        }

        #endregion
    }
}

