using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Logic.FileManager.Item
{
    public abstract class Item
    {
        //Properties
        public string Path { get; internal set; }
        public string Name { get; internal set; }
        public string Size { get; internal set; }
        public string Owner { get; internal set; }
        public FileType Type { get; internal set; }
        public DateTime CreationDate { get; internal set; }
        public bool IsWriteProtected { get; internal set; }

        //Constructor
        internal Item(string path, string name, string size, string owner, FileType type, DateTime creationDate, bool writeprotection)
        {
            this.Path = path;
            this.Name = name;
            this.Size = size;
            this.Owner = owner;
            this.Type = type;
            this.CreationDate = creationDate;
            this.IsWriteProtected = writeprotection;
        }
        //Methods
        internal virtual string Open()
        {
            return $"{this.Path}";
        }

    }
}
