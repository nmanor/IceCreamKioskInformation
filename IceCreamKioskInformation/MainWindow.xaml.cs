using BE;
using BL;
using IceCreamKioskInformation.AddProduct;
using IceCreamKioskInformation.AddReview;
using IceCreamKioskInformation.AddShop;
using IceCreamKioskInformation.MapDisplay;
using IceCreamKioskInformation.ProductDisplay;
using IceCreamKioskInformation.SearchResultsList;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

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
            DataContext = new MainWindowVM(this);
            LoadSearch();
            //LoadSearchResult();
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
        public void LoadAddProduct()
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

        public void LoadSearchResult()
        {
            MessageArea.IsOpen = false;
            
            MainGrid.Children.Remove(CurrnetUserConrol);

            SearchResultsListUserControl searchResults = new SearchResultsListUserControl();
            searchResults.Margin = new Thickness(20);
            searchResults.HorizontalAlignment = HorizontalAlignment.Stretch;
            searchResults.VerticalAlignment = VerticalAlignment.Stretch;
            Grid.SetColumn(searchResults, 2);
            MainGrid.Children.Insert(0, searchResults);

            ProductDisplayUserControl productDisplay = new ProductDisplayUserControl();
            productDisplay.Margin = new Thickness(0, 20, 0, 20);
            productDisplay.HorizontalAlignment = HorizontalAlignment.Stretch;
            productDisplay.VerticalAlignment = VerticalAlignment.Stretch;
            Grid.SetColumn(productDisplay, 1);
            MainGrid.Children.Insert(0, productDisplay);

            MapDisplayUserControl mapDisplay = new MapDisplayUserControl();
            mapDisplay.Margin = new Thickness(20);
            mapDisplay.HorizontalAlignment = HorizontalAlignment.Stretch;
            mapDisplay.VerticalAlignment = VerticalAlignment.Stretch;
            Grid.SetColumn(mapDisplay, 0);
            MainGrid.Children.Insert(0, mapDisplay);
        }

        /// <summary>
        /// A function that binds to commands on the admin password confirmation button
        /// </summary>
        /// <param name="command">The command she needs to bind</param>
        public void BindLoadCommand(ICommand command)
        {
            CheckPassowrd.Command = command;
        }

        /// <summary>
        /// Open the area of the log in as admin
        /// </summary>
        public void OpenLogInArea()
        {
            PasswordDescription.Text = "פעולה זו דורשת התחברות כמנהל מערכת\nאנא הכנס סיסמת מנהל ולאחר מכן לחץ על המשך";
            PasswordDescription.Foreground = Brushes.Black;
            LockLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.Lock;
            LogInAsAdmin.IsOpen = true;
        }

        /// <summary>
        /// Close the area of the log in as admin
        /// </summary>
        public void CloseLogInArea()
        {
            LogInAsAdmin.IsOpen = false;
        }

        /// <summary>
        /// Cahnge the view to show that the password is worng
        /// </summary>
        public void DisplayWorngPassword()
        {
            PasswordDescription.Text = "סיסמה שגויה\nאנא נסה שוב";
            PasswordDescription.Foreground = Brushes.Red;
            Password.Foreground = Brushes.Red;
            LockLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.Lock;
        }

        /// <summary>
        /// Cahnge the view to show that the password is right
        /// </summary>
        public void DisplayRightPassword()
        {
            Password.Foreground = Brushes.Black;
            LockLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.LockOpenVariant;
        }
    }
}
