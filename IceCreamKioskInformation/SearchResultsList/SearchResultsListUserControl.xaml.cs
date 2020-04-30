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

        public event EventHandler GoBack;

        /// <summary>
        /// Activate the backward event from this screen
        /// </summary>
        public void InvokeGoBack()
        {
            GoBack?.Invoke(this, null);
        }
    }
}
