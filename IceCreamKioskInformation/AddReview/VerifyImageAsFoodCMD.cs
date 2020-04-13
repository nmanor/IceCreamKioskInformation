using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddReview
{
    class VerifyImageAsFoodCMD: ICommand
    {
        private AddReviewUserControlVM VM;
        private BackgroundWorker VerifyImageBW;

        public VerifyImageAsFoodCMD(AddReviewUserControlVM VM)
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
            return VM.Review.Image != "";
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
            AddReviewUserControlM M = new AddReviewUserControlM();
            VM.ImageVerify = false;
            try
            {
                VM.ImageVerify = M.VerifyImageAsFood(VM.Review.Image);
            }
            catch (Exception)
            {
                VerifyImageBW.CancelAsync();
                VM.ImageVerify = false;
            }
        }

        private void ImageVerified(object sender, RunWorkerCompletedEventArgs e)
        {
            if (VM.ImageVerify)
                VM.ImageVerified();
            else
                VM.ImageNotVerified();
        }
    }
}
