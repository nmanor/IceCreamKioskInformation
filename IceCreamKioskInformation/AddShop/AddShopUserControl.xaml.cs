using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IceCreamKioskInformation.AddShop
{
    /// <summary>
    /// Interaction logic for AddShopUserControl.xaml
    /// </summary>
    public partial class AddShopUserControl : UserControl
    {
        public AddShopUserControl()
        {
            InitializeComponent();
            this.DataContext = new AddShopUserControlVM(this);
        }

        public event EventHandler GoBack;

        /// <summary>
        /// Changes the view while bringing the image from the email
        /// </summary>
        public void LookingForImage()
        {
            SendImageDescirption.Text = "מייבא את התמונה ששלחת...";
            SendImageDescirption.Visibility = Visibility.Visible;
            ShopImage.Visibility = Visibility.Collapsed;
            FetchImage.Visibility = Visibility.Collapsed;
            FetchingImagePB.Visibility = Visibility.Visible;
            FetchAgianOptions.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Changes the display if the image is in the email
        /// </summary>
        public void ImageFound()
        {
            SendImageDescirption.Visibility = Visibility.Collapsed;
            ShopImage.Visibility = Visibility.Visible;
            FetchImage.Visibility = Visibility.Collapsed;
            FetchingImagePB.Visibility = Visibility.Collapsed;
            FetchAgianOptions.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Changes the display if the image is not in the email
        /// </summary>
        public void ImageNotFound()
        {
            SendImageDescirption.Text = "התמונה לא נמצאה\nאנא נסה לשלוח שוב או נסה להוסיף את החנות בפעם אחרת\nשים לב שלעיתים לוקח למייל קצת זמן להישלח";
            SendImageDescirption.Visibility = Visibility.Visible;
            FetchImage.Visibility = Visibility.Visible;
            ShopImage.Visibility = Visibility.Collapsed;
            FetchingImagePB.Visibility = Visibility.Collapsed;
            FetchAgianOptions.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Changes the view while bringing the image from the email
        /// </summary>
        public void VerifyingImage()
        {
            SendImageDescirption.Text = "מנתח חזותית את התמונה שהעלת\nתהליך זה יכול לקחת כדקה או שתיים";
            SendImageDescirption.Visibility = Visibility.Visible;
            ShopImage.Visibility = Visibility.Collapsed;
            FetchImage.Visibility = Visibility.Collapsed;
            FetchingImagePB.Visibility = Visibility.Visible;
            FetchAgianOptions.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Changes the display if the image is not verified
        /// </summary>
        public void ImageNotVerified()
        {
            SendImageDescirption.Text = "ניתוח חזותי של התמונה שלך מצא את התמונה לא מתאימה\nאנא נסה לשלוח תמונה אחרת";
            SendImageDescirption.Visibility = Visibility.Visible;
            FetchImage.Visibility = Visibility.Visible;
            ShopImage.Visibility = Visibility.Collapsed;
            FetchingImagePB.Visibility = Visibility.Collapsed;
            FetchAgianOptions.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Changes the display if the image is in the email
        /// </summary>
        public void ImageVerified()
        {
            SendImageDescirption.Text = "התמונה שלך מתאימה!";
            SendImageDescirption.Visibility = Visibility.Visible;
            ShopImage.Visibility = Visibility.Visible;
            FetchImage.Visibility = Visibility.Collapsed;
            FetchingImagePB.Visibility = Visibility.Collapsed;
            FetchAgianOptions.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Change view when verifying data
        /// </summary>
        public void VerifyingData()
        {
            DataView.IsEnabled = false;
            ShopImage.Opacity = 0.4;
            CheckingDataPB.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Collapsed;
            StatusDescirption.Visibility = Visibility.Visible;
            StatusDescirption.Text = "רק מוודאים שהכל תקין...";
            StatusDescirption.Foreground = new SolidColorBrush(Colors.Black);
        }

        /// <summary>
        /// Changes the display if the data not saved
        /// </summary>
        public void DataNotVerified(string error)
        {
            DataView.IsEnabled = true;
            ShopImage.Opacity = 1;
            CheckingDataPB.Visibility = Visibility.Collapsed;
            Save.Visibility = Visibility.Visible;
            StatusDescirption.Visibility = Visibility.Visible;
            StatusDescirption.Text = error;
            StatusDescirption.Foreground = new SolidColorBrush(Colors.IndianRed);
        }

        /// <summary>
        /// Changes the display if the data saved
        /// </summary>
        public void DataVerified()
        {
            EditData.Visibility = Visibility.Hidden;
            SuccessfullySavedMessage.Visibility = Visibility.Visible;
            CheckingDataPB.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// A function that triggers the event of a backward move
        /// </summary>
        public void OnGoBackClicked()
        {
            GoBack.Invoke(this, null);
        }
    }
}
