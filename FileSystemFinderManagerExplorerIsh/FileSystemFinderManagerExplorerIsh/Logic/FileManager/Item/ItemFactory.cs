using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Logic.FileManager.Item
{
    class ItemFactory
    {
        #region old code
        //public static Item CreateItem(string path, string name, string size, string owner, FileType type, DateTime creationDate, bool writeProtection, string extension, DateTime lastOpenedDate, DateTime lastWriteDate)
        //{
        //    string folderFileType = GetType(type, extension);
        //    switch (folderFileType)
        //    {
        //        case "folder":
        //            return CreateFolder(path, name, size, owner, type, creationDate, writeProtection);
        //        case "file":
        //            return CreateFile(path, name, size, owner, type, creationDate, writeProtection, lastOpenedDate, lastWriteDate, extension);
        //        case "link":
        //            return CreateLink(path, name, size, owner, type, creationDate, writeProtection);
        //        default:
        //            return null;
        //    }
        //}
        //private static string GetType(FileType type, string extension)
        //{
        //    if (type == FileType.Directory)
        //    {
        //        return "folder";
        //    }
        //    else if (extension.ToLower() == ".lnk")
        //    {
        //        return "link";
        //    }
        //    else
        //    {
        //        return "file";
        //    }
        //}
        #endregion
        internal static Folder CreateFolder(string path, string name/*, string size*/, string owner, FileType type, DateTime creationDate, bool writeProtection, bool isEmpty)
        {
            return new Folder(path, name,/* size, */owner, type, creationDate, writeProtection, isEmpty);
        }
        internal static File CreateFile(string path, string name, string size, string owner, FileType type, DateTime creationDate, bool writeProtection, DateTime lastOpenedDate, DateTime lastWriteDate, string extension)
        {
            return new File(path, name, size, owner, type, creationDate, writeProtection, lastOpenedDate, lastWriteDate, extension);
        }
        internal static LinkFile CreateLink(string path, string name, string size, string owner, FileType type, DateTime creationDate, bool writeProtection, DateTime lastOpenedDate, DateTime lastWriteDate, string extension, string linkPath, string[] runArgs,/* FileType linkedFileType,*/ string comment)
        {
            return new LinkFile(path, name, size, owner, type, creationDate, writeProtection, lastOpenedDate, lastOpenedDate, linkPath, runArgs,/* linkedFileType,*/ comment);
        }
    }
}
