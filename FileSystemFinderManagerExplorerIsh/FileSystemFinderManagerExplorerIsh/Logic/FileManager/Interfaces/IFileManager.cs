using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Logic.FileManager.Interfaces
{
    public interface IFileManager
    {
        List<Item.Item> GetFolderContents(string path);
        string GetRootDirectory(string path);
        List<Item.Folder> GetFoldersFromFolder(string path);
    }
}
