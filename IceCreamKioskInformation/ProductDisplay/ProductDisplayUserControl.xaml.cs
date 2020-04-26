using BE;
using BL;
using System;
using System.Windows;
using System.Windows.Controls;
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
            this.DataContext = new ProductDisplayUserControlVM(new BLimp().Get_all_Products()[0]);

            StreamResourceInfo sriCurs = Application.GetResourceStream(new Uri("Images/magnifying-glass.cur", UriKind.Relative));
            BigImageView.Cursor = new Cursor(sriCurs.Stream);
        }
    }
}
