using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.SearchUserControlMVVM
{
    public class PerformSearchCMD : ICommand
    {
        private SearchUserControlVM VM;
        private BackgroundWorker PerformSearchBW;

        public PerformSearchCMD(SearchUserControlVM VM)
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
            VM.Working = true;
            PerformSearchBW = new BackgroundWorker();
            PerformSearchBW.DoWork += StartSearch;
            PerformSearchBW.RunWorkerCompleted += SearchDone;
            PerformSearchBW.RunWorkerAsync();
        }

        private void StartSearch(object sender, DoWorkEventArgs e)
        {
            while (VM.FetchingFromDB)
                Thread.Yield();
            SearchUserControlM M = new SearchUserControlM();
            try
            {
                e.Result = M.PerformSearch(VM.Dictionary, VM.Products);
            }
            catch (Exception)
            {
                e.Result = null;
            }
        }

        private void SearchDone(object sender, RunWorkerCompletedEventArgs e)
        {
            VM.Working = false;
            if (e.Result != null)
                VM.InvokeSerachDone(e.Result as List<Tuple<Product, string>>);
        }
    }
}