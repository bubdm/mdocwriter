

namespace MDocWriter.Styles
{
    using System.IO;
    using System.Windows.Forms;

    partial class Style
    {
        public const string StyleDefinitionFileName = @"StyleDefinition.xml";

        public const string StyleDirectory = @"styles";

        public static string StylePath
        {
            get
            {
                return Path.Combine(Application.StartupPath, StyleDirectory);
            }
        }
    }
}
