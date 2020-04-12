using System;
using System.Windows.Input;

namespace IceCreamKioskInformation.MainWindowMVVM
{
    class GoBackCMD : ICommand
    {
        private MainWindowVM VM;

        public GoBackCMD(MainWindowVM VM)
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
            VM.LoadSearch();
        }
    }
}
