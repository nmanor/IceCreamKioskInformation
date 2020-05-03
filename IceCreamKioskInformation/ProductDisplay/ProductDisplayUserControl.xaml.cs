using BE;
using BL;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Resources;

namespace IceCreamKioskInformation.ProductDisplay
{
    /// <summary>
    /// Interaction logic for ProductDisplayUserControl.xaml
    /// </summary>
    public partial class ProductDisplayUserControl : UserControl
    {
        public ProductDisplayUserControl()
        {
            InitializeComponent();
            LoadProduct(null);

            StreamResourceInfo sriCurs = Application.GetResourceStream(new Uri("Images/magnifying-glass.cur", UriKind.Relative));
            BigImageView1.Cursor = new Cursor(sriCurs.Stream);
            sriCurs = Application.GetResourceStream(new Uri("Images/magnifying-glass.cur", UriKind.Relative));
            BigImageView2.Cursor = new Cursor(sriCurs.Stream);
        }

        public event EventHandler AddReviewEvent;
        public void LoadProduct(Product product) { this.DataContext = new ProductDisplayUserControlVM(product, this); }
        public void InvokeAddReview(Product product) { AddReviewEvent?.Invoke(this, new AddReviewEvantArgs { Product = product }); }

    }
}
