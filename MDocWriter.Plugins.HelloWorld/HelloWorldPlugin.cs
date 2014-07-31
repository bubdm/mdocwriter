using MDocWriter.Application.Plugins;
using MDocWriter.Application.Workspaces;
using System;
using System.Windows.Forms;

namespace MDocWriter.Plugins.HelloWorld
{
    public class HelloWorldPlugin : Plugin
    {
        public override Guid Id
        {
            get { return new Guid("EF5B0795-99A5-4894-BED2-6C415AE2AB0A"); }
        }

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
    }
}
