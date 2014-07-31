using MDocWriter.Documents;

namespace MDocWriter.Application.Workspaces
{
    public sealed class WorkspaceModifiedEventArgs : System.EventArgs
    {
        public Document Originator { get; private set; }
        public string PropertyName { get; private set; }

        public WorkspaceModifiedEventArgs(Document originator, string propertyName)
        {
            this.Originator = originator;
            this.PropertyName = propertyName;
        }
    }
}
