using BE;
using System.ComponentModel;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddShop
{
    class AddShopUserControlVM : INotifyPropertyChanged
    {
        // Fields and Properties
        public int ImageTrys { get; set; }
        public Shop NewShop { get; set; }
        private AddShopUserControl View;

        private bool _imageVerify;
        public bool ImageVerify
        {
            get { return _imageVerify; }
            set
            {
                _imageVerify = value;
                OnPropertyChanged("ImageVerify");
            }
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public AddShopUserControlVM(AddShopUserControl userControl)
        {
            View = userControl;
            ImageTrys = 0;
            NewShop = new Shop() { Address = new Address() };
        }

        /// <summary>
        /// Action of clicking the search image from mail button
        /// </summary>
        public ICommand ShowImage { get { return new ShowImageFromMailCMD(this); } }

        /// <summary>
        /// Action of clicking the search image from mail button
        /// </summary>
        public ICommand VerifyImage { get { return new VerifyImageAsStoreCMD(this); } }

        /// <summary>
        /// Save the new shop into the DB
        /// </summary>
        public ICommand SaveShop { get { return new SaveShopCMD(this); } }

        /// <summary>
        /// Action for triggering the backward event
        /// </summary>
        public ICommand GoBack { get { return new GoBackCMD(this); } }

        public void LookingForImage() { View.LookingForImage(); }
        public void ImageFound() { View.ImageFound(); }
        public void ImageNotFound() { View.ImageNotFound(); }

        public void VerifyingImage() { View.VerifyingImage(); }
        public void ImageVerified() { View.ImageVerified(); }
        public void ImageNotVerified() { View.ImageNotVerified(); }

        public void CheckingData() { View.VerifyingData(); }
        public void DataVerified() { View.DataVerified(); }
        public void DataNotVerified(string error) { View.DataNotVerified(error); }

        public void OnGoBackClicked() { View.OnGoBackClicked(); }
    }
}
