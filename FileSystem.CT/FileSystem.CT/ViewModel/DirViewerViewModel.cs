using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using FileSystem.CT.Model;
using FileSystem.CT.Stuff;

namespace FileSystem.CT.ViewModel
{
    class DirViewerViewModel : ViewModelBase
    {
        //Attribute
        private ExplorerWindowViewModel _evm;
        private DirInfo _currentItem;

        //Properties
        public DirInfo CurrentItem { get { return this._currentItem; } set { this._currentItem = value; } }

        //Constructor
        public DirViewerViewModel(ExplorerWindowViewModel evm)
        {
            this._evm = evm;
        }

        //Method
        public void OpenCurrentObject()
        {
            int objType = CurrentItem.DirType;

            if((ObjectType)CurrentItem.DirType == ObjectType.File)
            {
                System.Diagnostics.Process.Start(CurrentItem.Path);
            }
            else
            {
                this._evm.CurrentDirectory = CurrentItem;
                this._evm.FileTreeVM.ExpandToCurrentNode(this._evm.CurrentDirectory);
            }
        }
    }
}
