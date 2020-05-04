using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace IceCreamKioskInformation.MainWindowMVVM
{
    class LogInAsAdminCMD : ICommand
    {
        private MainWindowVM VM;

        public LogInAsAdminCMD(MainWindowVM VM)
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
                VM.OpenLogInArea();
            }
            else
            {
                PasswordBox passwordBox = parameter as PasswordBox;
                if (new MainWindowM().AdminPasswordVerification(passwordBox.Password))
                {
                    passwordBox.Password = "";
                    new Thread(() =>
                    {
                        for (int i = 10; i > -1; i--)
                        {
                            VM.TimeAsAdmin = i;
                            Thread.Sleep(1000);
                        }
                    }).Start();
                }
                else
                {
                    VM.DisplayWorngPassword();
                }
            }
        }
    }
}
