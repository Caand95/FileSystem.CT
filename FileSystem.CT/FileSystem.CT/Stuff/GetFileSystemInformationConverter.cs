using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.CT.Stuff
{
    public class GetFileSystemInformationConverter : IValueConverter
    {
        //Converter
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                DirInfo nodeToExpand = value as DirInfo;
                if (nodeToExpand == null)
                    return null;
                if((ObjectType)nodeToExpand.DirType == ObjectType.MyComputer)
                {
                    return (from sd in FileSystemExplorerService.GetRootDirectories() select new DirInfo(sd)).ToList();
                } 
                else
                {
                    return (from dirs in FileSystemExplorerService.GetChildDirectories(nodeToExpand.Path) select new DirInfo(dirs)).ToList();
                }
            }
            catch { return null; }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
