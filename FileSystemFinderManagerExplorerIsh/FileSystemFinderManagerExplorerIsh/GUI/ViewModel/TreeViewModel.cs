using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExplorer.Logic.FileManager.Item;

namespace FileExplorer.GUI.ViewModel
{
    class TreeViewModel
    {
        public TreeItem CurrentTreeItem { get; set; }
        public RelayCommand ExpandCommand { get; set; }
        private bool CanExecuteExpandCommand(object parameter)
        {
            if (CurrentTreeItem.IsExpanded)
                return false;
            else
                return true;
        }
        public Logic.FileManager.FileController Ctrler;
        public ObservableCollection<TreeItem> TreeItems { get; set; }
        public TreeViewModel()
        {
            ExpandCommand = new RelayCommand(ExecuteExpandCommand, CanExecuteExpandCommand);
            TreeItems = new ObservableCollection<TreeItem>();
            Ctrler = new Logic.FileManager.FileController("win");
            GetTreeItem();
        }
        private void GetTreeItem()
        {
            List<Folder> folders = new List<Folder>(Ctrler.GetFoldersFromFolder(@"C:\Users\vimka\source\repos\flaskeBonBånd\flaskeBonBånd"));
            foreach (Folder item in folders)
            {
                TreeItems.Add(new TreeItem(item, false, false));
            }
        }

        #region Commands
        public void ExecuteExpandCommand(object o)
        {

        }
        #endregion
    }
}
