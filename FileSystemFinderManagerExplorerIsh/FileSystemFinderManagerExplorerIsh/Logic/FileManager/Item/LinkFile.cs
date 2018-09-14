using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Logic.FileManager.Item
{
    class LinkFile: File
    {
        //Properties
        public string LinkPath { get; internal set; }
        public string[] RunArgs { get; internal set; }
        public FileType RunFileType { get; internal set; }
        public string Comment { get; internal set; }

        //Constructors
        internal LinkFile(string path, string name, string size, string owner, FileType type, DateTime creationDate, bool writeprotection, DateTime lastOpenedDate, DateTime modifiedDate, string linkPath, string[] runArgs,/* FileType runfileType,*/ string comment) : base(path, name, size, owner, type, creationDate, writeprotection, lastOpenedDate, modifiedDate, "start " + linkPath) // sorry had to
        {
            this.LinkPath = linkPath;
            this.RunArgs = runArgs;
            //this.RunFileType = runfileType;
            this.Comment = comment;
        }

        //Methods
        internal override string Open()
        {
            string output = $"\"{this.CommandToRun}\" ";
            foreach (string arg in RunArgs)
            {
                output += $"{arg} ";
            }
            return output;
        }
        internal string Link()
        {
            return $"{this.LinkPath}";
        }

    }
}
 