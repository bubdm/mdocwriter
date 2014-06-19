namespace MDocWriter.WinFormMain
{
    using System;
    using System.Windows.Forms;

    using MDocWriter.Application;

    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the workspace to the GUI.
        /// </summary>
        /// <param name="wks">The workspace instance to be loaded.</param>
        private void LoadWorkspace(Workspace wks)
        {
            tvWorkspace.Nodes.Clear();
            
        }

        private void ActionNew(object sender, EventArgs e)
        {
            // TODO: Check if current workspace has been saved

        }
    }
}
