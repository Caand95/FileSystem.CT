using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExplorer.Logic.FileManager.Item;

namespace FileExplorer.GUI.ViewModel
{
    class FolderViewModel
    {
        public Logic.FileManager.FileController Ctrler;

        public ObservableCollection<Item> Itemlist{ get; set; }

        public FolderViewModel()
        {
            Ctrler = new Logic.FileManager.FileController("Win");
            Itemlist =  new ObservableCollection<Item>(Ctrler.GetFolderContents(@"C:\Users\vimka\source\repos\flaskeBonBånd\flaskeBonBånd"));
        }

    }
}
