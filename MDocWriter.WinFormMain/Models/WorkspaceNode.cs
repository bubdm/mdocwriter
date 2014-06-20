using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.WinFormMain.Models
{
    public class WorkspaceNode
    {
        public object NodeValue { get; set; }

        public WorkspaceNodeType NodeType { get; set; }

        public WorkspaceNode() { }

        public WorkspaceNode(WorkspaceNodeType nodeType, object nodeValue = null)
        {
            this.NodeType = nodeType;
            this.NodeValue = nodeValue;
        }
    }
}
