using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MarkdownSharp;

namespace MDocWriter.WinFormMain.Controls
{
    public partial class MarkdownEditor : UserControl
    {
        private readonly Markdown markdown = new Markdown();
        public MarkdownEditor()
        {
            InitializeComponent();
        }

        #region Public Properties
        /// <summary>
        /// Gets or sets a value indicating whether the editor should wrap the line.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the editor should wrap the line; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Gets or sets a value indicating whether the editor should wrap the line.")]
        public bool EditorLineWrap
        {
            get
            {
                return editor.ScrollBars == ScrollBars.Vertical;
            }
            set
            {
                editor.ScrollBars = value ? ScrollBars.Vertical : ScrollBars.Both;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the html editor should wrap the line.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the html editor should wrap the line; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Gets or sets a value indicating whether the html editor should wrap the line.")]
        public bool HtmlLineWrap
        {
            get
            {
                return html.ScrollBars == ScrollBars.Vertical;
            }
            set
            {
                editor.ScrollBars = value ? ScrollBars.Vertical : ScrollBars.Both;
            }
        }

        /// <summary>
        /// Gets or sets the style sheet for displaying the generated html in the browser view.
        /// </summary>
        /// <value>
        /// The style sheet.
        /// </value>
        [Category("Appearance")]
        [Description("Gets or sets the styles for displaying the generated html in the browser view.")]
        public string Styles { get; set; }
        #endregion

        #region Public Methods
        ///// <summary>
        ///// Transforms the markdown into the html format.
        ///// </summary>
        ///// <returns>The html string.</returns>
        public string Transform()
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            if (!string.IsNullOrEmpty(Styles))
            {
                sb.Append("  <head>");
                sb.Append("    <style>");
                sb.Append(Styles);
                sb.Append("    </style>");
                sb.Append("  </head>");
            }
            sb.Append("  <body>");
            sb.Append(markdown.Transform(editor.Text));
            sb.Append("  </body");
            sb.Append("</html>");
            return sb.ToString();
        }
        #endregion
    }

}
