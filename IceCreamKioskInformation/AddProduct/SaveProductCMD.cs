using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddProduct
{
    class SaveProductCMD : ICommand
    {
        private AddProductUserControlVM VM;
        private BackgroundWorker SaveProductBW;

        public SaveProductCMD(AddProductUserControlVM VM)
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
            VM.CheckingProductData();
            SaveProductBW = new BackgroundWorker();
            SaveProductBW.WorkerSupportsCancellation = true;
            SaveProductBW.DoWork += SaveProduct;
            SaveProductBW.RunWorkerCompleted += ProductSaved;
            SaveProductBW.RunWorkerAsync();
        }

        private void SaveProduct(object sender, DoWorkEventArgs e)
        {
            AddProductUserControlM M = new AddProductUserControlM();
            try
            {
                M.SaveProduct(VM.SelectedProduct, VM.SelectedShop); 
                e.Result = "";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void ProductSaved(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Result as string) == "")
                VM.ProductSaved();
            else
                VM.ProductNotSaved(e.Result as string);
        }
    }
}
