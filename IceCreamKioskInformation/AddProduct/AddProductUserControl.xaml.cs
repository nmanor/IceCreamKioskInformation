using BE;
using IceCreamKioskInformation.AddReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IceCreamKioskInformation.AddProduct
{
    /// <summary>
    /// Interaction logic for AddProductUserControl.xaml
    /// </summary>
    public partial class AddProductUserControl : UserControl
    {
        private AddReviewUserControl AddReviewUserControl;

        public AddProductUserControl()
        {
            InitializeComponent();
            this.DataContext = new AddProductUserControlVM(this);
        }

        /// <summary>
        /// Open a new window for reviews and wait for it's events to continue saving the product
        /// </summary>
        /// <param name="product">The product on which it should add the review</param>
        public void AddReview(Product product)
        {
            this.Visibility = Visibility.Collapsed;
            var parent = Parent as Grid;
            if(AddReviewUserControl == null)
            {
                AddReviewUserControl = new AddReviewUserControl(product);
                AddReviewUserControl.Margin = Margin;
                AddReviewUserControl.HorizontalAlignment = HorizontalAlignment;
                AddReviewUserControl.VerticalAlignment = VerticalAlignment;
                Grid.SetColumn(AddReviewUserControl, 1);
                Grid.SetColumnSpan(AddReviewUserControl, 2);
                parent.Children.Insert(0, AddReviewUserControl);
            }
            AddReviewUserControl.Visibility = Visibility.Visible;

            AddReviewUserControl.GoBack += (object sender, EventArgs e) =>
            {
                AddReviewUserControl.Visibility = Visibility.Collapsed;
                this.Visibility = Visibility.Visible;
            };

            AddReviewUserControl.ReviewCreated += (object sender, EventArgs e) =>
            {
                GetReview.Visibility = Visibility.Collapsed;
                Save.Visibility = Visibility.Visible;
                AddReviewUserControl.Visibility = Visibility.Collapsed;
                Visibility = Visibility.Visible;
            };
        }

        public void SaveProduct()
        {
            Save.Visibility = Visibility.Collapsed;
            CheckingDataPB.Visibility = Visibility.Visible;
        }
    }
}
