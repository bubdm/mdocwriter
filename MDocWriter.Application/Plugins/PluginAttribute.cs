using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Application.Plugins
{
    public class PluginAttribute : System.Attribute
    {
        public Guid Id { get; private set; }

        public PluginAttribute(string id)
        {
            this.Id = new Guid(id);
        }
    }
}
