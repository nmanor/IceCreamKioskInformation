using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.SearchResultsList
{
    class IncludeBlanksCMD : ICommand
    {
        private SearchResultsListUserControlVM VM;

        public IncludeBlanksCMD(SearchResultsListUserControlVM VM)
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
            VM.Products = new SearchResultsListUserControlM().IncludeBlanks(VM.Products, (string)parameter);
        }
    }
}