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
        public SearchResultsListUserControl(List<Product> results)
        {
            InitializeComponent();
            this.DataContext = new SearchResultsListUserControlVM(this, results);
        }
    }
}
