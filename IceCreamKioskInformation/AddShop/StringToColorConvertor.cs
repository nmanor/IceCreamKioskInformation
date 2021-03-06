﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace IceCreamKioskInformation.AddShop
{
    class StringToColorConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool correct = new AddShopUserControlM().VerifyStringAs((string)parameter, (string)value);
            if (!correct)
                return new SolidColorBrush(Colors.Red);
            else
                return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
