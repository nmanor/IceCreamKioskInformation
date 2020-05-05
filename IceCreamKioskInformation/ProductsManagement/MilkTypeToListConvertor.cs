using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IceCreamKioskInformation.ProductsManagement
{
    class MilkTypeToListConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<MILKTYPE, string> milk = new Dictionary<MILKTYPE, string>()
            {
                [MILKTYPE.CowMilk] = "חלב פרה",
                [MILKTYPE.GoatMilk] = "חלב עיזים",
                [MILKTYPE.SoyMilk] = "חלב סויה"
            };
            try { return milk[(MILKTYPE)value]; }
            catch (Exception) { return milk.Values; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string, MILKTYPE> milk = new Dictionary<string, MILKTYPE>()
            {
                ["חלב פרה"] = MILKTYPE.CowMilk,
                ["חלב עיזים"] = MILKTYPE.GoatMilk,
                ["חלב סויה"] = MILKTYPE.SoyMilk
            };
            try { return milk[(string)value]; }
            catch (Exception) { return milk.Values; }
        }
    }
}
