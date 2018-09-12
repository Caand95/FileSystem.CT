using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using FileSystem.CT.Properties; // <-- huh?
using FileSystem.CT.Stuff;
using System.Windows;
using System.Collections;

namespace FileSystem.CT.ViewModel
{
    public class DirInfo : DependencyObject
    {
        //Props
        public string Name { get; set; }
        public string Path { get; set; }
        public string Root { get; set; }
        public string Size { get; set; }
        public string Ext { get; set; }
        public int DirType { get; set; }

        public static readonly DependencyProperty propertyChilds = DependencyProperty.Register("Childs", typeof(IList<DirInfo>), typeof(DirInfo));
        public IList<DirInfo> SubDirectories
        {
            get { return (IList<DirInfo>)GetValue(propertyChilds); }
            set { SetValue(propertyChilds, value); }
        }

        public static readonly DependencyProperty propertyIsExpanded = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(DirInfo));
        public bool IsExpanded
        {
            get { return (bool)GetValue(propertyIsExpanded); }
            set { SetValue(propertyIsExpanded, value); }
        }

        public static readonly DependencyProperty propertyIsSelected = DependencyProperty.Register("IsSelected", typeof(bool), typeof(DirInfo));
        public bool IsSelected
        {
            get { return (bool)GetValue(propertyIsSelected); }
            set { SetValue(propertyIsSelected, value); }
        }

        //Constructors
        public DirInfo()
        {
            SubDirectories = new List<DirInfo>();
            SubDirectories.Add(new DirInfo("TempDir"));
        }
        public DirInfo(string directoryName)
        {
            Name = directoryName;
        }

        //dir ctor
        public DirInfo(DirectoryInfo dir) :this()
        {
            Name = dir.Name;
            Root = dir.Root.Name;
            Path = dir.FullName;
            DirType = (int)ObjectType.Directory;
        }
        //File ctor
        public DirInfo(FileInfo fileobj)
        {
            Name = fileobj.Name;
            Path = fileobj.FullName;
            DirType = (int)ObjectType.File;
            Size = $"{(fileobj.Length / 1024)} KB";
            Ext = $"{fileobj.Extension} File";
        }
        //Drive ctor
        public DirInfo(DriveInfo driveobj) : this()
        {
            if (driveobj.Name.EndsWith(@"\"))
                Name = driveobj.Name.Substring(0, driveobj.Name.Length - 1);
            else
                Name = driveobj.Name;

            Path = driveobj.Name;
            DirType = (int)ObjectType.DiskDrive;
        }
    }
}
