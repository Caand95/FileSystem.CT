using System;
using System.Collections.Generic;

namespace FileExplorer.Logic.FileManager.Item
{
    public class Folder : Item
    {
        //Attributes & Properties
        public List<Item> ListofItems { get; internal set; }
        public bool IsEmpty { get; protected set; }
        //Constructors
        private Folder() : base (null,"dummy",null,null,FileType.Directory,DateTime.MaxValue,false)
        {
        }
        internal Folder(string path, string name,/* string size, */string owner, FileType type, DateTime creationDate, bool writeprotection, bool isEmpty) : base(path, name, "1",/*size, */owner, type, creationDate, writeprotection)
        {
            ListofItems = new List<Item>();
            if (isEmpty)
            {
                ListofItems.Add(this);
            }
        }

        //Methods
        internal override string Open()
        {
            return $"{this.Path}{this.Name}/";
        }
    }
}
