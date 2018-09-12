using FileSystem.CT.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.CT.ViewModel
{
    class FileExplorerViewModel : ViewModelBase
    {
        //Attribute
        private ExplorerWindowViewModel _evm;
        private DirInfo _currentTreeItem;
        private IList<DirInfo> _sysDirSource;

        //Properties
        public IList<DirInfo> SystemDirectorySource
        {
            get { return this._sysDirSource; }
            set { this._sysDirSource = value; OnPropertyChanged("SystemDiretorySource"); }
        }

        public DirInfo CurrentTreeItem
        {
            get { return this._currentTreeItem; }
            set { this._currentTreeItem = value; this._evm.CurrentDirectory = this._currentTreeItem; }
        }

        //Construtor
        public FileExplorerViewModel(ExplorerWindowViewModel evm)
        {
            this._evm = evm;

            DirInfo rootNode = new DirInfo(Resources.My_Computer_String);

            rootNode.Path = Resources.My_Computer_String;

            this._evm.CurrentDirectory = rootNode;

            SystemDirectorySource = new List<DirInfo> { rootNode };
        }

        //Methods
        public void ExpandToCurrentNode(DirInfo curDir)
        {
            if (CurrentTreeItem != null && (curDir.Path.Contains(CurrentTreeItem.Path) || CurrentTreeItem.Path == Resources.My_Computer_String))
            {
                CurrentTreeItem.IsExpanded = false;
                CurrentTreeItem.IsExpanded = true;
            }
        }

    }
}

