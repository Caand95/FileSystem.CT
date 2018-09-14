using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Logic.FileManager
{
    class FileController
    {
        Interfaces.IFileManager man;
        public FileController(string fileSystem)
        {
            switch (fileSystem.ToLower())
            {
                case "win":
                    man = new WindowsFileManager();
                    break;
                case "unix":
                    //man = new UnixFileSystem();
                    break;
            }
        }
        public List<Item.Item> GetFolderContents(string path)
        {
            return man.GetFolderContents(path);
        }
        public string GetRootPath(string path)
        {
            return man.GetRootDirectory(path);
        }
        public List<Item.Folder> GetFoldersFromFolder(string path)
        {
            return man.GetFoldersFromFolder(path);
        }
    }
}
