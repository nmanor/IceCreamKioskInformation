using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace IceCreamKioskInformation.Convertors
{
    /// <summary>
    /// Convert Base64 images to a viewable image
    /// </summary>
    class Base64ToBitmapImageConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "/IceCreamKioskInformation;component/Images/emailQRCode.png";

            byte[] binaryData = System.Convert.FromBase64String((string)value);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();
            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
