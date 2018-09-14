using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.GUI.ViewModel
{
    class TreeItem
    {
        public Logic.FileManager.Item.Folder Folder { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }
        public TreeItem(Logic.FileManager.Item.Folder folder, bool isExpanded, bool isSelected)
        {
            this.Folder = folder;
            this.IsExpanded = isExpanded;
            this.IsSelected = IsSelected;
        }
    }
}
