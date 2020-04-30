using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        /// <summary>
        /// Action for triggering the backward event
        /// </summary>
        public ICommand GoBackCMD { get { return new GoBackCMD(this); } }

        /// <summary>
        /// Activate the backward event from this screen
        /// </summary>
        public void InvokeGoBack() { View.InvokeGoBack(); }
    }
}
