
using System;

namespace MDocWriter.Documents
{
    using System.ComponentModel;

    /// <summary>
    /// Represents the base class of the classes that will listen to
    /// the <c>PropertyChanged</c> event and be notified by this event.
    /// </summary>
    [Serializable]
    public abstract class PropertyChangedNotifier : INotifyPropertyChanged
    {
        /// <summary>
        /// Called when <c>PropertyChanged</c> event occurs.
        /// </summary>
        /// <param name="propertyName">Name of the property which causes the event to occur.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
