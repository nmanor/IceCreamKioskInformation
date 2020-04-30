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
        /// An command that activates the functions for displaying a new store screen
        /// </summary>
        public ICommand WaitForGoBackPermission { get { return new GoBackCMD(this); } }

        public void LoadSearch() { View.LoadSearch(); }
        public void LoadAddProduct() { View.LoadAddProduct(); }
        public void LoadAddShop() { View.LoadAddShop(); }

        public void GoBack() { View.GoBack(); }

        public void BindLoadCommand(ICommand command) { View.BindLoadCommand(command); }
        public void OpenLogInArea() { View.OpenLogInArea(); }
        public void CloseLogInArea() { View.CloseLogInArea(); }
        public void DisplayWorngPassword() { View.DisplayWorngPassword(); }
        public void DisplayRightPassword() { View.DisplayRightPassword(); }
    }
}
