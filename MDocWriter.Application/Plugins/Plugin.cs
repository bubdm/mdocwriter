using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MDocWriter.Application.Properties;
using MDocWriter.Application.Workspaces;

namespace MDocWriter.Application.Plugins
{
    public abstract class Plugin : IPlugin
    {

        #region IPlugin Members

        /// <summary>
        /// Gets the unique identifier of the plugin.
        /// </summary>
        /// <value>
        /// The unique identifier of the plugin.
        /// </value>
        /// <remarks>
        /// This unique identifier will be used when identifying a single plugin
        /// in the Markdown Doucment Writer execution context.
        /// </remarks>
        public abstract Guid Id { get; }

        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <value>
        /// The name of the plugin.
        /// </value>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the detailed description information about the plugin.
        /// </summary>
        /// <value>
        /// The description about the plugin.
        /// </value>
        public abstract string Description { get; }

        /// <summary>
        /// Gets the author of the plugin.
        /// </summary>
        /// <value>
        /// The author of the plugin.
        /// </value>
        public virtual string Author
        {
            get
            {
                return "Sunny Chen (Qingyang Chen)";
            }
        }

        /// <summary>
        /// Gets the company that develops the plugin.
        /// </summary>
        /// <value>
        /// The company that develops the plugin.
        /// </value>
        public virtual string Company
        {
            get
            {
                return "daxnet";
            }
        }

        /// <summary>
        /// Gets the copyright information of the plugin.
        /// </summary>
        /// <value>
        /// The copyright information of the plugin.
        /// </value>
        public virtual string Copyright
        {
            get
            {
                return "Copyright (C) 2014, daxnet, all rights reserved.";
            }
        }

        /// <summary>
        /// Gets the version information of the plugin.
        /// </summary>
        /// <value>
        /// The version information of the plugin.
        /// </value>
        public virtual Version Version
        {
            get
            {
                return Version.Parse("1.0.0.0");
            }
        }

        /// <summary>
        /// Gets the icon image of the plugin.
        /// </summary>
        /// <value>
        /// The icon image of the plugin.
        /// </value>
        /// <remarks>
        /// This icon image will be used to show on the menu.
        /// </remarks>
        public virtual Image Icon
        {
            get
            {
                switch(this.Type)
                {
                    case PluginType.DocumentImporter:
                        return Resources.Import;
                    case PluginType.DocumentExporter:
                        return Resources.Export;
                }
                return Resources.Component;
            }
        }

        public abstract string MenuText { get; }

        /// <summary>
        /// Gets the type of the plugin.
        /// </summary>
        /// <value>
        /// The type of the plugin.
        /// </value>
        /// <remarks>
        /// The <see cref="PluginType" /> value indicates the position where the plugin menu item
        /// should be placed.
        /// </remarks>
        public virtual PluginType Type
        {
            get
            {
                return PluginType.Tool;
            }
        }

        /// <summary>
        /// Executes the plugin on the specified workspace instance.
        /// </summary>
        /// <param name="workspace">The workspace instance on which the plugin is executed..</param>
        /// <returns>
        /// True if the execution was successful, otherwise, false.
        /// </returns>
        public abstract bool Execute(IWorkspace workspace);

        /// <summary>
        /// Called when the workspace has changed.
        /// </summary>
        public virtual void OnWorkspaceChanged()
        {
            
        }

        /// <summary>
        /// Called when the workspace has been saved.
        /// </summary>
        public virtual void OnWorkspaceSaved()
        {
            
        }

        #endregion
    }
}
