using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.ProductDisplay
{
    class SwitchReviewCMD : ICommand
    {
        private ProductDisplayUserControlVM VM;

        public SwitchReviewCMD(ProductDisplayUserControlVM VM)
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
            int index = VM.Product.Reviews.IndexOf(VM.CurrentReview);
            if ((parameter as string) == "Next")
                VM.CurrentReview = VM.Product.Reviews[(index + 1) % VM.Product.Reviews.Count];
            else
                VM.CurrentReview = VM.Product.Reviews[Math.Abs((index - 1) % VM.Product.Reviews.Count)];
        }
    }
}
