using BE;
using BL;
using IceCreamKioskInformation.AddProduct;
using IceCreamKioskInformation.AddReview;
using IceCreamKioskInformation.AddShop;
using System.Windows;
using System.Windows.Controls;

namespace IceCreamKioskInformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Contains the UserControl currently displayed to the user
        /// </summary>
        public UserControl CurrnetUserConrol
        {
            get { return _currnetUserConrol; }
            set
            {
                MainGrid.Children.Remove(_currnetUserConrol);
                _currnetUserConrol = value;
                _currnetUserConrol.Margin = new Thickness(0, 0, 60, 0);
                _currnetUserConrol.HorizontalAlignment = HorizontalAlignment.Stretch;
                _currnetUserConrol.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetColumn(_currnetUserConrol, 1);
                Grid.SetColumnSpan(_currnetUserConrol, 2);
                MainGrid.Children.Insert(0, _currnetUserConrol);
            }
        }
        private UserControl _currnetUserConrol;

        public MainWindow()
        {
            InitializeComponent();
            new Tools().tryrepos();
            DataContext = new MainWindowVM(this);
            LoadSearch();
        }

        /// <summary>
        /// Loading the UserControl of the search to the main screen and logging its events
        /// </summary>
        internal void LoadSearch()
        {
            MessageArea.IsOpen = false;
            SearchUserControl search = new SearchUserControl();
            CurrnetUserConrol = search;
        }

        /// <summary>
        /// Loading the UserControl of the add shop to the main screen and logging its events
        /// </summary>
        internal void LoadAddShop()
        {
            MessageArea.IsOpen = false;
            AddShopUserControl search = new AddShopUserControl();
            search.GoBack += (sender, e) =>
            {
                GoBackEventArgs args = e as GoBackEventArgs;
                if (!args.IsWorkDone)
                {
                    MessageAreaText.Text = args.Message;
                    MessageArea.IsOpen = true;
                }
                else
                    LoadSearch();
            };
            CurrnetUserConrol = search;
        }

        /// <summary>
        /// Loading the UserControl of the add review to the main screen and logging its events
        /// </summary>
        internal void LoadAddReview()
        {
            MessageArea.IsOpen = false;
            AddReviewUserControl addReview = new AddReviewUserControl(new Waffle() { Name = "וופל בלגי TO GO: וופל בלגי עם קצפת + 3 כדורי גלידה" });
            addReview.GoBack += (sender, e) =>
            {
                GoBackEventArgs args = e as GoBackEventArgs;
                if (!args.IsWorkDone)
                {
                    MessageAreaText.Text = args.Message;
                    MessageArea.IsOpen = true;
                }
                else
                    LoadSearch();
            };
            CurrnetUserConrol = addReview;
        }

        /// <summary>
        /// Loading the UserControl of the add review to the main screen and logging its events
        /// </summary>
        internal void LoadAddProduct()
        {
            MessageArea.IsOpen = false;
            AddProductUserControl addProduct = new AddProductUserControl();
            addProduct.GoBack += (sender, e) =>
            {
                GoBackEventArgs args = e as GoBackEventArgs;
                if (!args.IsWorkDone)
                {
                    MessageAreaText.Text = args.Message;
                    MessageArea.IsOpen = true;
                }
                else
                    LoadSearch();
            };
            CurrnetUserConrol = addProduct;
        }
    }
}
