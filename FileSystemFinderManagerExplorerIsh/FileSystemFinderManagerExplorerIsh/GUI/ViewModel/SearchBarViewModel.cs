using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTestApp.Import;

namespace WpfTestApp.ViewModel
{
    class SearchBarViewModel
    {
        private string _searchParam;

        public string SearchParam { get { return this._searchParam; } set { this._searchParam = value; /*OnPropertyChanged("SearchParam");*/ } }

        public DelegateCommand SearchCommand { get; set; }

        public SearchBarViewModel()
        {
            SearchCommand = new DelegateCommand(SearchFor);
        }

        private void SearchFor(object obj)
        {
            this._searchParam = obj.ToString(); // MAGIC HAPPENS HERE
        }
    }
}
