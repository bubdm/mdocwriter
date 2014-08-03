using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Application.Settings
{
    using System.Runtime.Serialization;

    public class ApplicationSetting : Setting
    {
        protected ApplicationSetting(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }
    }
}
