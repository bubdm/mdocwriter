using MDocWriter.Application.Plugins;
using MDocWriter.Application.Workspaces;
using System;
using System.Windows.Forms;

namespace MDocWriter.Plugins.HelloWorld
{
    [Plugin("730644EB-7294-45A0-8BF1-C3692BDEE3F5")]
    public class HelloWorldPlugin : Plugin
    {
        public override string Name
        {
            get { return "Hello World"; }
        }

        public override string Description
        {
            get { return "A Hello World Plugin."; }
        }

        public override bool Execute(IWorkspace workspace)
        {
            MessageBox.Show(workspace.FileName);
            return true;
        }

        public override string MenuText
        {
            get { return "Hello World..."; }
        }

        public override PluginType Type
        {
            get
            {
                return PluginType.DocumentImporter;
            }
        }
    }
}
