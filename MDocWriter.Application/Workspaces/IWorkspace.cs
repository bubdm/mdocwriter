using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MDocWriter.Documents;

namespace MDocWriter.Application.Workspaces
{
    public interface IWorkspace
    {
        Document Document { get; }
        string FileName { get; }
        bool IsModified { get; }
        WorkspaceStatus Status { get; }
        string WorkingDirectory { get; }

    }
}
