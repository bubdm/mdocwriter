using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MDocWriter.Application.Settings
{
    public abstract class SettingModel
    {
        public override string ToString()
        {
            return this.ToString(Encoding.ASCII);
        }

        public string ToString(Encoding encoding)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var xmlSerializer = new XmlSerializer(this.GetType());
                    xmlSerializer.Serialize(memoryStream, this);
                    return encoding.GetString(memoryStream.ToArray());
                }
            }
            catch
            {
                return base.ToString();
            }
        }
    }
}
