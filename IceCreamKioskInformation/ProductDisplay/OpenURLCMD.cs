using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.ProductDisplay
{
    class OpenURLCMD : ICommand
    {
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
            try
            {
                Process.Start(new ProcessStartInfo(new ProductDisplayUserControlM().ConvertToFullURL(parameter)));
            }
            catch (Exception) { }
        }
    }
}
