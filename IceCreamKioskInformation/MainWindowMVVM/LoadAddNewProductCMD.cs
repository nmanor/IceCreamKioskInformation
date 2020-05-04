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
            VM.CloseLogInArea();
            VM.LoadAddProduct();
        }
    }
}

