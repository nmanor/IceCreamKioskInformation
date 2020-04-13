using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddReview
{
    class ShowImageFromMailCMD: ICommand
    {
        private AddReviewUserControlVM VM;
        private BackgroundWorker FetchImageBW;

        public ShowImageFromMailCMD(AddReviewUserControlVM VM)
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
            return VM.Review.ReviwerEmail != "";
        }

        public void Execute(object parameter)
        {
            VM.LookingForImage();
            FetchImageBW = new BackgroundWorker();
            FetchImageBW.WorkerSupportsCancellation = true;
            FetchImageBW.DoWork += FetchImage;
            FetchImageBW.RunWorkerCompleted += ImageFound;
            FetchImageBW.RunWorkerAsync();
        }

        private async void FetchImage(object sender, DoWorkEventArgs e)
        {
            AddReviewUserControlM M = new AddReviewUserControlM();
            try
            {
                VM.Review.Image = await M.getImageFrom(VM.Review.ReviwerEmail, VM.ImageTrys++);
                e.Result = true;
            }
            catch (Exception)
            {
                FetchImageBW.CancelAsync();
                e.Result = false;
            }
        }

        private void ImageFound(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
                VM.ImageFound();
            else
                VM.ImageNotFound();
        }
    }
}
