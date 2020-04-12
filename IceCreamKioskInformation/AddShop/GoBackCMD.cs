using System;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddShop
{
    class GoBackCMD : ICommand
    {
        private AddShopUserControlVM VM;

        public GoBackCMD(AddShopUserControlVM VM)
        {
            this.VM = VM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.OnGoBackClicked();
        }
    }
}
