using IceCreamKioskInformation.MainWindowMVVM;
using System;
using System.Windows.Input;

namespace IceCreamKioskInformation
{
    class MainWindowVM
    {
        private MainWindow View;

        public MainWindowVM(MainWindow mainWindow)
        {
            View = mainWindow;
        }

        /// <summary>
        /// An command that activates the functions for displaying a new store screen
        /// </summary>
        public ICommand AddShop { get { return new LoadAddNewShopCMD(this); } }

        /// <summary>
        /// An command that activates the functions for displaying a new product screen
        /// </summary>
        public ICommand AddProduct { get { return new LoadAddNewProductCMD(this); } }

        /// <summary>
        /// An command that activates the functions for displaying a new store screen
        /// </summary>
        public ICommand WaitForGoBackPermission { get { return new GoBackCMD(this); } }

        public void LoadSearch() { View.LoadSearch(); }

        internal void LoadAddProduct() { View.LoadAddProduct(); }
        public void LoadAddShop() { View.LoadAddShop(); }
    }
}
