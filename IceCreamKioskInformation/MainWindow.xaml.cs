using BE;
using BL;
using DAL;
using IceCreamKioskInformation.AddProduct;
using IceCreamKioskInformation.AddReview;
using IceCreamKioskInformation.AddShop;
using IceCreamKioskInformation.MapDisplay;
using IceCreamKioskInformation.ProductDisplay;
using IceCreamKioskInformation.ProductsManagement;
using IceCreamKioskInformation.SearchResultsList;
using IceCreamKioskInformation.ShopsManagement;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

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
                ChangeSearchResultControlsVisibility(Visibility.Collapsed);
                MainGrid.Children.Insert(0, _currnetUserConrol);
                this.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/background.jpg")));
            }
        }

        private UserControl _currnetUserConrol;
        private UserControl[] SearchResultControls = null;

        public MainWindow()
        {
            InitializeComponent();
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
            search.SerachDone += (sender, e) =>
            {
                SearchResultEventArgs args = e as SearchResultEventArgs;
                LoadSearchResult(args.SearchResult);
            };
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
            this.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/background.jpg")));
        }

        /// <summary>
        /// Loading the UserControl of the add review to the main screen and logging its events
        /// </summary>
        internal void LoadAddReview(Product product)
        {
            MessageArea.IsOpen = false;
            AddReviewUserControl addReview = new AddReviewUserControl(product);
            addReview.GoBack += (sender, e) =>
            {
                GoBackEventArgs args = e as GoBackEventArgs;
                if (!args.IsWorkDone)
                {
                    MessageAreaText.Text = args.Message;
                    MessageArea.IsOpen = true;
                }
                else
                    LoadSearchResult(null);
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

        /// <summary>
        /// Loading the ShopsManagementUserControl 
        /// </summary>
        public void LoadShopsManagement()
        {
            MessageArea.IsOpen = false;
            ShopsManagementUserControl shopsManagement = new ShopsManagementUserControl();
            CurrnetUserConrol = shopsManagement;
        }

        /// <summary>
        /// Loading the ProductsManagementUserControl 
        /// </summary>
        public void LoadProductsManagement()
        {
            MessageArea.IsOpen = false;
            ProductsManagementUserControl productsManagement = new ProductsManagementUserControl();
            CurrnetUserConrol = productsManagement;
        }

        /// <summary>
        /// Loading the User Controls that showing the search result.
        /// This function can use the same controls more then one time if needed.
        /// </summary>
        public void LoadSearchResult(List<Tuple<Product, string>> results)
        {
            MessageArea.IsOpen = false;
            MainGrid.Children.Remove(CurrnetUserConrol);

            if (SearchResultControls == null)
            {
                SearchResultsListUserControl searchResults = new SearchResultsListUserControl(results);
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

                // Register for go switch product event through the product list display
                searchResults.SwitchProduct += (sender, args) =>
                {
                    Product product = (args as SwitchProductEventArgs).Product;
                    productDisplay.LoadProduct(product);
                    mapDisplay.ReloadMap(product.Shop.Address);
                };

                // Register for go back event through the product list display
                searchResults.GoBack += (sender, args) =>
                {
                    LoadSearch();
                    SearchResultControls = null;
                };

                // Register for add review event through the product display
                productDisplay.AddReviewEvent += (sender, args) =>
                {
                    searchResults.Visibility = Visibility.Hidden;
                    productDisplay.Visibility = Visibility.Hidden;
                    mapDisplay.Visibility = Visibility.Hidden;

                    LoadAddReview((args as AddReviewEvantArgs).Product);
                };

                SearchResultControls = new UserControl[3];
                SearchResultControls[0] = searchResults;
                SearchResultControls[1] = productDisplay;
                SearchResultControls[2] = mapDisplay;
            }
            else
            {
                ChangeSearchResultControlsVisibility(Visibility.Visible);
            }

            this.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/background2.jpg")));
        }

        /// <summary>
        /// Change the type of visibility to all controls in the search results view
        /// </summary>
        /// <param name="visibility">Type of visibility</param>
        private void ChangeSearchResultControlsVisibility(Visibility visibility)
        {
            if (SearchResultControls != null)
                foreach (var item in SearchResultControls)
                    item.Visibility = visibility;
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
            PasswordDescription.Text = "פעולה זו דורשת התחברות כמנהל מערכת\nאנא הכנס סיסמת מנהל ולאחר מכן לחץ על המשך";
            PasswordDescription.Foreground = Brushes.Black;
            LockLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.Lock;
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
            PasswordDescription.Text = "פעולה זו דורשת התחברות כמנהל מערכת\nאנא הכנס סיסמת מנהל ולאחר מכן לחץ על המשך";
            PasswordDescription.Foreground = Brushes.Black;
            LockLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.LockOpenVariant;
        }

        /// <summary>
        /// Selects which screen to return when requesting to go back
        /// </summary>
        public void GoBack()
        {
            if (SearchResultControls != null)
                LoadSearchResult(null);
            else
                LoadSearch();
        }
    }
}
