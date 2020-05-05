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

        public List<Tuple<Product, string>> _products;
        public List<Tuple<Product, string>> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                _products.Sort(delegate(Tuple<Product, string> x, Tuple<Product, string> y)
                {
                    return x.Item2.Length.CompareTo(y.Item2.Length);
                });
                OnPropertyChanged("Products");
                try { SelectedProduct = _products[0]; }
                catch (Exception) { SelectedProduct = null; }
            }
        }

        private Tuple<Product, string> _product;
        public Tuple<Product, string> SelectedProduct
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public SearchResultsListUserControlVM(SearchResultsListUserControl searchResultsListUserControl, List<Tuple<Product, string>> results)
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
        /// Action for filtering missing properties
        /// </summary>
        public ICommand IncludeBlanksCMD { get { return new IncludeBlanksCMD(this); } }

        /// <summary>
        /// Activate the backward event from this screen
        /// </summary>
        public void InvokeGoBack() { View.InvokeGoBack(); }
    }
}
