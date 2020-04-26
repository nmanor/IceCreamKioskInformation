using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.SearchResultsList
{
    class SearchResultsListUserControlVM
    {
        private SearchResultsListUserControl View;
        public List<Product> Products { get; set; }

        public SearchResultsListUserControlVM(SearchResultsListUserControl searchResultsListUserControl, List<Product> results)
        {
            this.View = searchResultsListUserControl;
            this.Products = results;
        }
    }
}
