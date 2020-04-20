using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace IceCreamKioskInformation.MainWindowMVVM
{
    class LoadAddNewProductCMD : ICommand
    {
        private MainWindowVM VM;

        public LoadAddNewProductCMD(MainWindowVM VM)
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
                VM.BindLoadCommand(VM.AddProduct);
                VM.OpenLogInArea();
            }
            else
            {
                PasswordBox passwordBox = parameter as PasswordBox;
                if(new MainWindowM().AdminPasswordVerification(passwordBox.Password))
                {
                    passwordBox.Password = "";
                    VM.DisplayRightPassword();
                    VM.BindLoadCommand(null);
                    VM.CloseLogInArea();
                    VM.LoadAddProduct();
                }
                else
                {
                    VM.DisplayWorngPassword();
                }
            }
        }
    }
}
