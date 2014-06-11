using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Documents
{
    [Serializable]
    public sealed class DocumentNode : INotifyPropertyChanged
    {
        private Guid id;

        private string name;

        private string content;

        private DateTime? dateLastModified;

        private DocumentNode parent;

        private ObservableCollection<DocumentNode> children = new ObservableCollection<DocumentNode>();

        public DocumentNode()
        {
        //    children.CollectionChanged
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime? DateLastModified { get; set; }

        public DocumentNode Parent { get; set; }

        public List<DocumentNode> Children { get; set; }

        public override string ToString()
        {
            return Name;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
