using BE;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace IceCreamKioskInformation.SearchResultsList
{
    /// <summary>
    /// Interaction logic for SearchResultsListUserControl.xaml
    /// </summary>
    public partial class SearchResultsListUserControl : UserControl
    {
        public SearchResultsListUserControl(List<Tuple<Product, string>> results)
        {
            InitializeComponent();
            this.DataContext = new SearchResultsListUserControlVM(this, results);
            ProductsList.SelectionChanged += (x, y) => 
            {
                Product product;
                try { product = (ProductsList.SelectedItem as Tuple<Product, string>).Item1; }
                catch(Exception) { product = null; }
                SwitchProduct?.Invoke(this, new SwitchProductEventArgs { Product = product }); 
            };
        }

        public event EventHandler GoBack;
        public event EventHandler SwitchProduct;

        /// <summary>
        /// Activate the backward event from this screen
        /// </summary>
        public void InvokeGoBack() { GoBack?.Invoke(this, null); }
    }
}
