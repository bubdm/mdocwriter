using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MDocWriter.Application.Settings
{
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class Setting : ISerializable
    {
        protected Setting(SerializationInfo info, StreamingContext context)
        {
        }

        #region ISerializable Members

        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        #endregion
    }
}
