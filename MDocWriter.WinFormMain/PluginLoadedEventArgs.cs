using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MDocWriter.Application.Plugins;

namespace MDocWriter.WinFormMain
{
    public class PluginLoadedEventArgs : EventArgs
    {
        public IPlugin Plugin { get; private set; }

        public PluginLoadedEventArgs(IPlugin plugin)
        {
            this.Plugin = plugin;
        }
    }
}
