using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FileSystem.CT.Model
{
    //Class to get file system Info
    class FSExplorerService
    {
        //Get files in Dir
        public static IList<FileInfo> GetChildFiles(string directory)
        {
            try
            {
                return (from x in Directory.GetFiles(directory) select new FileInfo(x)).ToList();
            } catch (Exception e)
            {
                Debug.WriteLine($"\n{e.Message}\n");
            }
            return new List<FileInfo>();
        }

        //Get Dir in Dir
        public static IList<DirectoryInfo> GetChildDirectories(string directory)
        {
            try
            {
                return (from x in Directory.GetDirectories(directory) select new DirectoryInfo(x)).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"\n{e.Message}\n");
            }
            return new List<DirectoryInfo>();
        }

        //Get Root Dir / logical drives
        public static IList<DriveInfo> GetRootDirectories()
        {
            return (from x in DriveInfo.GetDrives() select x).ToList();
        }
    }
}
