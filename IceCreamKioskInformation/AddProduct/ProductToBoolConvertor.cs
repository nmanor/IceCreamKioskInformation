using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IceCreamKioskInformation.AddProduct
{
    class ProductToBoolConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            foreach (PropertyInfo item in value.GetType().GetProperties())
            {
                if (item.Name == "NutritionalValues" || item.Name == "FirstImage" || item.Name == "ShopID")
                    continue;

                if (item.PropertyType == typeof(string))
                    if (string.IsNullOrEmpty((string)item.GetValue(value)))
                        return false;

                if (item.PropertyType == typeof(int) || item.PropertyType == typeof(double) || item.PropertyType == typeof(float))
                    if ((double)item.GetValue(value) == 0)
                        return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
