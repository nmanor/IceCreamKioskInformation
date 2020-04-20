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
            IsWorkDone = false;
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
                Visibility = Visibility.Visible;
            };

            AddReviewUserControl.ReviewCreated += (object sender, EventArgs e) =>
            {
                AddReviewUserControl.Visibility = Visibility.Collapsed;
                Visibility = Visibility.Visible;
            };
        }

        public bool IsWorkDone { get; set; }
        public event EventHandler GoBack;

        /// <summary>
        /// Changes the display while trying to save the product
        /// </summary>
        public void CheckingProductData()
        {
            CheckingDataPB.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Collapsed;
            Expenders.IsEnabled = false;
            Expenders.Opacity = 0.7;
            CloseAllExpanders();
        }

        /// <summary>
        /// Changes the display if the product saved
        /// </summary>
        public void ProductSaved()
        {
            Expenders.Visibility = Visibility.Hidden;
            SuccessfullySavedMessage.Visibility = Visibility.Visible;
            IsWorkDone = true;
        }

        /// <summary>
        /// Changes the display if the product not saved
        /// </summary>
        public void ProductNotSaved(string error)
        {
            CheckingDataPB.Visibility = Visibility.Collapsed;
            Save.Visibility = Visibility.Visible;
            Expenders.IsEnabled = true;
            Expenders.Opacity = 1;
            CloseAllExpanders();
            IsWorkDone = false;
        }

        /// <summary>
        /// Function that close all the expanders
        /// </summary>
        private void CloseAllExpanders()
        {
            Expander1.IsExpanded = false;
            Expander2.IsExpanded = false;
            Expander3.IsExpanded = false;
            Expander4.IsExpanded = false;
        }

        /// <summary>
        /// A function that triggers the event of a backward move
        /// </summary>
        public void OnGoBackClicked()
        {
            GoBackEventArgs args;
            string message = null;
            if (!IsWorkDone)
                message = "לא שמרת את המוצר עדיין\nהאם את רוצה לחזור בכל זאת?";
            args = new GoBackEventArgs() { IsWorkDone = this.IsWorkDone, Message = message };
            GoBack?.Invoke(this, args);
        }
    }
}