using IceCreamKioskInformation.MainWindowMVVM;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace IceCreamKioskInformation
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private MainWindow View;

        public MainWindowVM(MainWindow mainWindow)
        {
            View = mainWindow;
        }

        private int _timeAsAdmin;
        public int TimeAsAdmin
        {
            get { return _timeAsAdmin; }
            set
            {
                _timeAsAdmin = value;
                OnPropertyChanged("TimeAsAdmin");
            }
        }

        public string EnterdPassword { get; set; }

        /// <summary>
        /// An command that activates the functions for displaying a new store screen
        /// </summary>
        public ICommand AddShop { get { return new LoadAddNewShopCMD(this); } }

        /// <summary>
        /// An command that activates the functions for displaying a new product screen
        /// </summary>
        public ICommand AddProduct { get { return new LoadAddNewProductCMD(this); } }

        /// <summary>
        /// An command that activates the functions for displaying the shops management screen
        /// </summary>
        public ICommand ShopsManagement { get { return new LoadShopsManagementCMD(this); } }

        /// <summary>
        /// An command that activates the functions for displaying the products management screen
        /// </summary>
        public ICommand ProductsManagement { get { return new LoadProductsManagementCMD(this); } }

        /// <summary>
        /// An command that activates the functions for displaying a new store screen
        /// </summary>
        public ICommand WaitForGoBackPermission { get { return new GoBackCMD(this); } }

        /// <summary>
        /// Allows the user to enter a password and login as an admin
        /// </summary>
        public ICommand LogInAsAdmin { get { return new LogInAsAdminCMD(this); } }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public void LoadSearch() { View.LoadSearch(); }
        public void LoadAddProduct() { View.LoadAddProduct(); }
        public void LoadAddShop() { View.LoadAddShop(); }
        public void LoadShopsManagement() { View.LoadShopsManagement(); }
        public void LoadProductsManagement() { View.LoadProductsManagement(); }

        public void GoBack() { View.GoBack(); }

        public void OpenLogInArea() { View.OpenLogInArea(); }
        public void CloseLogInArea() { View.CloseLogInArea(); TimeAsAdmin = 0; }
        public void DisplayWorngPassword() { View.DisplayWorngPassword(); }
        public void DisplayRightPassword() { View.DisplayRightPassword(); }
    }
}
