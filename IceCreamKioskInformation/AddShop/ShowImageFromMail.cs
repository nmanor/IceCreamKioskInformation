using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddShop
{
    class ShowImageFromMail : ICommand
    {
        private AddShopUserControlVM VM;
        public ShowImageFromMail(AddShopUserControlVM VM)
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

        public async void Execute(object parameter)
        {
            var th = new Thread(t);
            th.Start();
        }

        private async void t()
        {
            AddShopUserControlM M = new AddShopUserControlM();
            VM.Newshop.ImageURL = await M.getImageFrom("natanmanor@gmail.com", VM.ImageTrys++);
        }
    }
}
