using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddShop
{
    class VerifyImageAsStoreCMD : ICommand
    {
        private AddShopUserControlVM VM;
        private BackgroundWorker VerifyImageBW;

        public VerifyImageAsStoreCMD(AddShopUserControlVM VM)
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
            return VM.NewShop.ImageURL != "";
        }

        public void Execute(object parameter)
        {
            VM.VerifyingImage();
            VerifyImageBW = new BackgroundWorker();
            VerifyImageBW.WorkerSupportsCancellation = true;
            VerifyImageBW.DoWork += VerifyImage;
            VerifyImageBW.RunWorkerCompleted += ImageVerified;
            VerifyImageBW.RunWorkerAsync();
        }

        private void VerifyImage(object sender, DoWorkEventArgs e)
        {
            AddShopUserControlM M = new AddShopUserControlM();
            VM.ImageVerify = false;
            try
            {
                VM.ImageVerify = M.VerifyImageAsStore(VM.NewShop.ImageURL);
            }
            catch (Exception)
            {
                VerifyImageBW.CancelAsync();
                VM.ImageVerify = false;
            }
        }

        private void ImageVerified(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)VM.ImageVerify)
                VM.ImageVerified();
            else
                VM.ImageNotVerified();
        }
    }
}
