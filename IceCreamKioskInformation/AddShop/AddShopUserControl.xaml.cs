using BE;
using BL;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public void CheckingData()
        {
            DataView.IsEnabled = false;
            DataView.Opacity = 0.7;
            CheckingDataPB.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Collapsed;
        }
    }
}
