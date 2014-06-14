using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MDocWriter.Documents;

namespace MDocWriter.WinFormMain
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DocumentNode node = new DocumentNode("test");

            //using (FileStream fs = new FileStream(@"c:\test.binary", FileMode.Create, FileAccess.Write))
            //{
            //    var formatter = new BinaryFormatter();
            //    formatter.Serialize(fs, node);
            //    fs.Flush();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using (FileStream fs = new FileStream(@"c:\test.binary", FileMode.Open, FileAccess.Read))
            //{
            //    var formatter = new BinaryFormatter();
            //    var node = formatter.Deserialize(fs);
            //}
        }


    }
}
