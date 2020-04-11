using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddShop
{
    class SaveShopCMD : ICommand
    {
        private AddShopUserControlVM VM;
        private BackgroundWorker SaveShopBW;

        public SaveShopCMD(AddShopUserControlVM VM)
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
            VM.CheckingData();
            SaveShopBW = new BackgroundWorker();
            SaveShopBW.DoWork += SaveShop;
            SaveShopBW.RunWorkerCompleted += DoneSaving;
            SaveShopBW.RunWorkerAsync();
        }

        private void SaveShop(object sender, DoWorkEventArgs e)
        {
            try
            {
                new AddShopUserControlM().SaveShop(VM.NewShop);
                e.Result = "";
            }
            catch(Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void DoneSaving(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Result as string) == "")
                VM.DataVerified();
            else
                VM.DataNotVerified(e.Result as string);
        }
    }
}
