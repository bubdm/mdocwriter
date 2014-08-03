using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using MDocWriter.Application.Plugins;

namespace MDocWriter.WinFormMain
{
    public sealed class PluginManager
    {
        private const string PluginFileExtension = "dll";

        private const string PluginDirectory = "plugins";

        private readonly string pluginFullPath = Path.Combine(
            System.Windows.Forms.Application.StartupPath,
            PluginDirectory);

        private readonly List<IPlugin> plugins = new List<IPlugin>();

        public event EventHandler<PluginLoadedEventArgs> PluginLoaded;

        private void OnPluginLoaded(IPlugin plugin)
        {
            var temp = this.PluginLoaded;
            if (temp!=null)
                temp(this, new PluginLoadedEventArgs(plugin));
        }

        public IEnumerable<IPlugin> Plugins
        {
            get
            {
                return this.plugins;
            }
        }
 

        public void Load(string pluginFullPath)
        {
            var pluginFiles = Directory.GetFiles(pluginFullPath, "*." + PluginFileExtension);
            foreach(var pluginFile in pluginFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFile(pluginFile);
                    var pluginTypes = from p in assembly.GetExportedTypes()
                                      where typeof(IPlugin).IsAssignableFrom(p) &&
                                      p.IsDefined(typeof(PluginAttribute), true)
                                      select p;
                    foreach(var pluginType in pluginTypes)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(pluginType);
                        this.plugins.Add(plugin);
                        this.OnPluginLoaded(plugin);
                    }
                }
                    // ReSharper disable EmptyGeneralCatchClause
                catch
                    // ReSharper restore EmptyGeneralCatchClause
                {
                    
                }
            }
        }

        public void Load()
        {
            this.Load(this.pluginFullPath);
        }
    }
}
