using BL;
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
            //LoadSearch();
            LoadAddReview();
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
            search.GoBack += (sender, e) => { MessageArea.IsOpen = true; };
            CurrnetUserConrol = search;
        }

        /// <summary>
        /// Loading the UserControl of the add review to the main screen and logging its events
        /// </summary>
        internal void LoadAddReview()
        {
            MessageArea.IsOpen = false;
            AddReviewUserControl search = new AddReviewUserControl();
            CurrnetUserConrol = search;
        }
    }
}
