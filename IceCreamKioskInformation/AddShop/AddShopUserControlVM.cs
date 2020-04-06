using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddShop
{
    class AddShopUserControlVM
    {
        public int ImageTrys { get; set; }
        public Shop Newshop { get; set; }

        /// <summary>
        /// Action of clicking the search image from mail button
        /// </summary>
        private ICommand showImage;
        public ICommand ShowImage
        {
            get
            {
                if (showImage == null)
                    showImage = new ShowImageFromMail(this);
                return showImage;
            }
            set
            {
                showImage = value;
            }
        }

        public AddShopUserControlVM(AddShopUserControl userControl)
        {
            ImageTrys = 0;
            Newshop = new Shop(null, null, null, null, null, null, null, null);
        }
    }
}
