namespace MDocWriter.Application
{
    /// <summary>
    /// Represents the status of the workspace.
    /// </summary>
    public enum WorkspaceStatus
    {
        /// <summary>
        /// Indicates that the workspace is a newly created one.
        /// </summary>
        NewlyCreated,
        /// <summary>
        /// Indicates that the workspace is an existing one, which means that it
        /// was opened from an existing file.
        /// </summary>
        Existing
    }
}
