using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.SearchResultsList
{
    class SearchResultsListUserControlVM : INotifyPropertyChanged
    {
        private SearchResultsListUserControl View;
        public List<Product> Products { get; set; }

        private Product _product;
        public Product SelectedProduct
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public SearchResultsListUserControlVM(SearchResultsListUserControl searchResultsListUserControl, List<Product> results)
        {
            this.View = searchResultsListUserControl;
            this.Products = results;
            if (Products.Count > 0)
                this.SelectedProduct = Products[0];
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

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
