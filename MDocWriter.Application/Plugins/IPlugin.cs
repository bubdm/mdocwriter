

namespace MDocWriter.Application.Plugins
{
    using MDocWriter.Application.Workspaces;
    using System;
    using System.Drawing;

    /// <summary>
    /// Represents that the implemented classes are Markdown Document Writer plugins.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Gets the unique identifier of the plugin.
        /// </summary>
        /// <value>
        /// The unique identifier of the plugin.
        /// </value>
        /// <remarks>This unique identifier will be used when identifying a single plugin
        /// in the Markdown Doucment Writer execution context.</remarks>
        Guid Id { get; }
        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <value>
        /// The name of the plugin.
        /// </value>
        string Name { get; }
        /// <summary>
        /// Gets the detailed description information about the plugin.
        /// </summary>
        /// <value>
        /// The description about the plugin.
        /// </value>
        string Description { get; }
        /// <summary>
        /// Gets the author of the plugin.
        /// </summary>
        /// <value>
        /// The author of the plugin.
        /// </value>
        /// <remarks></remarks>
        string Author { get; }
        /// <summary>
        /// Gets the company that develops the plugin.
        /// </summary>
        /// <value>
        /// The company that develops the plugin.
        /// </value>
        string Company { get; }
        /// <summary>
        /// Gets the copyright information of the plugin.
        /// </summary>
        /// <value>
        /// The copyright information of the plugin.
        /// </value>
        string Copyright { get; }
        /// <summary>
        /// Gets the version information of the plugin.
        /// </summary>
        /// <value>
        /// The version information of the plugin.
        /// </value>
        Version Version { get; }
        /// <summary>
        /// Gets the icon image of the plugin.
        /// </summary>
        /// <value>
        /// The icon image of the plugin.
        /// </value>
        /// <remarks>This icon image will be used to show on the menu.</remarks>
        Image Icon { get; }
        /// <summary>
        /// Gets the menu text.
        /// </summary>
        /// <value>
        /// The menu text.
        /// </value>
        string MenuText { get; }
        /// <summary>
        /// Gets the type of the plugin.
        /// </summary>
        /// <value>
        /// The type of the plugin.
        /// </value>
        /// <remarks>The <see cref="PluginType"/> value indicates the position where the plugin menu item
        /// should be placed.</remarks>
        PluginType Type { get; }
        /// <summary>
        /// Executes the plugin on the specified workspace instance.
        /// </summary>
        /// <param name="workspace">The workspace instance on which the plugin is executed..</param>
        /// <returns>True if the execution was successful, otherwise, false.</returns>
        bool Execute(IWorkspace workspace);
        /// <summary>
        /// Called when the workspace has changed.
        /// </summary>
        void OnWorkspaceChanged();
        /// <summary>
        /// Called when the workspace has been saved.
        /// </summary>
        void OnWorkspaceSaved();
    }
}
