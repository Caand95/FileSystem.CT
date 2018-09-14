using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Logic.FileManager.Item
{
    internal class File : Item
    {
        //Properties
        public DateTime LastOpenedDate { get; internal set; }
        public DateTime ModifiedDate { get; internal set; }
        public string CommandToRun { get; internal set; }
        public string Extention { get; internal set; }

        //Constructors
        internal File(string path, string name, string size, string owner, FileType type, DateTime creationDate, bool writeprotection, DateTime lastOpenedDate, DateTime modifiedDate, string extention) : base(path, name, size, owner, type, creationDate, writeprotection)
        {
            this.LastOpenedDate = lastOpenedDate;
            this.ModifiedDate = modifiedDate;
            this.CommandToRun = "start " + path;
            this.Extention = extention;
        }

        //Methods
        internal override string Open()
        {
            return $"{this.CommandToRun}";
        }
        internal string GetPath()
        {
            return $"{this.Path}";
        }

    }
}
