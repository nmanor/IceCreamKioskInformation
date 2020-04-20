using IceCreamKioskInformation.MainWindowMVVM;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace IceCreamKioskInformation
{
    class LoadAddNewShopCMD : ICommand
    {
        private MainWindowVM VM;

        public LoadAddNewShopCMD(MainWindowVM VM)
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
            if (parameter == null)
            {
                VM.BindLoadCommand(VM.AddShop);
                VM.OpenLogInArea();
            }
            else
            {
                PasswordBox passwordBox = parameter as PasswordBox;
                if (new MainWindowM().AdminPasswordVerification(passwordBox.Password))
                {
                    passwordBox.Password = "";
                    VM.DisplayRightPassword();
                    VM.BindLoadCommand(null);
                    VM.CloseLogInArea();
                    VM.LoadAddShop();
                }
                else
                {
                    VM.DisplayWorngPassword();
                }
            }
        }
    }
}
