using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTestApp.Import;
using WpfTestApp.Properties;

namespace WpfTestApp.ViewModel
{
    class AddressBarViewModel
    {

        private string _currentFolderPath;

        public string CurrentFolderPath { get { return this._currentFolderPath; } set { this._currentFolderPath = value; /*OnPropertyChanged("CurrentFolder");*/ } }

        public DelegateCommand GoToCommand { get; set; }

        public AddressBarViewModel()
        {
            this._currentFolderPath = $"{DriveInfo.GetDrives().ToList()[0].RootDirectory.ToString()}ccfs\\";
            GoToCommand = new DelegateCommand(GoTo);
        }

        private void GoTo(object obj)
        {
            this._currentFolderPath = obj.ToString();
        }
    }
}
