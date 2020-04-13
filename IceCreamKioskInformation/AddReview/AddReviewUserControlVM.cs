using BE;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace IceCreamKioskInformation.AddReview
{
    class AddReviewUserControlVM: INotifyPropertyChanged
    {
        // Fields and Properties
        public Product Product { get; set; }
        public Review Review { get; set; }
        public int ImageTrys { get; set; }
        private AddReviewUserControl View;
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

        public AddReviewUserControlVM(AddReviewUserControl addReviewUserControl, Product product)
        {
            this.View = addReviewUserControl;
            this.Product = product;
            this.Review = new Review();
            ImageVerify = false;
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        /// <summary>
        /// Action of clicking the search image from mail button
        /// </summary>
        public ICommand ShowImage { get { return new ShowImageFromMailCMD(this); } }

        /// <summary>
        /// Action of clicking the search image from mail button
        /// </summary>
        public ICommand VerifyImage { get { return new VerifyImageAsFoodCMD(this); } }

        /// <summary>
        /// Save the new shop into the DB
        /// </summary>
        public ICommand SaveReview { get { return new SaveReviewCMD(this); } }

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
