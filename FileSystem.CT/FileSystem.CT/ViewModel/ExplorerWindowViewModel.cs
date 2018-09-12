using FileSystem.CT.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileSystem.CT.ViewModel
{
    class ExplorerWindowViewModel: ViewModelBase
    {
        //Attribute
        private DirInfo _currentDirectory;
        private FileExplorerViewModel _fileTreeVM;
        private DirViewerViewModel _dirViewerVM;
        private IList<DirInfo> _currentItems;
        private bool _showDirectoryTree = true;
        private ICommand _showTreeCommand;

        //Properties
        public DirInfo CurrentDirectory { get { return this._currentDirectory; } set { this._currentDirectory = value; RefreshCurrentItems(); OnPropertyChanged("CrruntDirectory"); } }
        public FileExplorerViewModel FileTreeVM { get { return this._fileTreeVM; } set { this._fileTreeVM = value; OnPropertyChanged("FileTreeVM"); } }
        public DirViewerViewModel DirViewerVM { get { return this._dirViewerVM; } set { this._dirViewerVM = value; OnPropertyChanged("DirViewVM"); } }
        public IList<DirInfo> CurrentItems { get { if (this._currentItems == null) { this._currentItems = new List<DirInfo>(); } return this._currentItems; } set { this._currentItems = value; OnPropertyChanged("CurrentItems"); } }
        public bool ShowDirectoryTree { get { return this._showDirectoryTree; } set { this._showDirectoryTree = value; OnPropertyChanged("ShowdirectoryTree"); } }
        public ICommand ShowTreeCommand { get { return this._showTreeCommand; } set { this._showTreeCommand = value; OnPropertyChanged("ShowTreeCommand"); } }

        //Construtor
        public ExplorerWindowViewModel()
        {
            this.FileTreeVM = new FileExplorerViewModel(this);
            this.DirViewerVM = new DirViewerViewModel(this);
            this.ShowTreeCommand = new RelayCommand(ParamArrayAttribute => this.DirectoryTreeHideHandler());
        }

        //Method
        private void DirectoryTreeHideHandler()
        {
            ShowDirectoryTree = false;
        }

        protected void RefreshCurrentItems()
        {
            IList<DirInfo> childDirList = new List<DirInfo>();
            IList<DirInfo> childFileList = new List<DirInfo>();

            if (CurrentDirectory.Name.Equals(Resources.My_Computer_string))
                childDirList = (from rd in FileSytemExplorerService.GetRootDirectories() select new DirInfo(rd)).ToList();
            else
            {
                childDirList = (from dir in FileSystemExplorerService.GetChildDirectories(CurrentDirectory.Path) select new DirInfo(dir)).ToList();

                childFileList = (from fobj in FileSystemExplorerService.GetChildFiles(CurrentDirectory.Path) select new DirInfo(fobj)).ToList();

                childDirList = childDirList.Concat(childFileList).ToList();
            }
            CurrentItems = childDirList;
        }

    }
}
