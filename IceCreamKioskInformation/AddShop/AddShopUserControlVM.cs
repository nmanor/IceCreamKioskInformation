using BE;
using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public bool ImageChekced { get; set; }
        private AddShopUserControl View;

        /// <summary>
        /// Action of clicking the search image from mail button
        /// </summary>
        public ICommand ShowImage { get { return new ShowImageFromMailCMD(this); } }

        /// <summary>
        /// Action of clicking the search image from mail button
        /// </summary>
        public ICommand VerifyImage { get { return new VerifyImageAsStoreCMD(this); } }

        public AddShopUserControlVM(AddShopUserControl userControl)
        {
            View = userControl;
            ImageTrys = 0;
            Newshop = new Shop();
        }

        public void LookingForImage() { View.LookingForImage(); }
        public void ImageFound() { View.ImageFound(); }
        public void ImageNotFound() { View.ImageNotFound(); }

        public void VerifyingImage() { View.VerifyingImage(); }
        public void ImageVerified() { View.ImageVerified(); }
        public void ImageNotVerified() { View.ImageNotVerified(); }
    }
}
