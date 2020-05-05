using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BE
{
    public class FrozenYogurt : Product
    {
        private double _fat;
        public double Fat
        {
            get { return _fat; }
            set
            {
                _fat = value;
                OnPropertyChanged("Fat");
            }
        }

        private MILKTYPE _milkType;
        public MILKTYPE MilkType
        {
            get { return _milkType; }
            set
            {
                _milkType = value;
                OnPropertyChanged("MilkType");
            }
        }

        public FrozenYogurt() : base() { }
        public FrozenYogurt(Product p)
        {
            this.Description = p.GetType().GetProperty("Description").GetValue(p).ToString();
            this.Fat = (double)p.GetType().GetProperty("Fat").GetValue(p);
            this.MilkType = (MILKTYPE)p.GetType().GetProperty("Fat").GetValue(p);
            this.Name = p.GetType().GetProperty("Name").GetValue(p).ToString();
            this.NutritionalValues = p.GetType().GetProperty("NutritionalValues").GetValue(p).ToString();
            this.Price = (double)p.GetType().GetProperty("Price").GetValue(p);
            this.ProductID = p.GetType().GetProperty("ProductID").GetValue(p).ToString();
            this.Reviews = (ObservableCollection<Review>)p.GetType().GetProperty("Reviews").GetValue(p);
            this.Shop = (Shop)p.GetType().GetProperty("Shop").GetValue(p);
            this.ShopID = p.GetType().GetProperty("ShopID").GetValue(p).ToString();
            this.SugarFree = (bool)p.GetType().GetProperty("SugarFree").GetValue(p);
            this.Vegan = (bool)p.GetType().GetProperty("Vegan").GetValue(p);
        }

        public override KeyValuePair<bool, Dictionary<string, List<object>>> Search(Dictionary<string, List<object>> dictionary)
        {
            KeyValuePair<bool, Dictionary<string, List<object>>> keyValue;
            // Checking for no properties in the search
            if (dictionary.Count == 0)
            {
                keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(false, dictionary);
                return keyValue;
            }

            keyValue = base.Search(dictionary);
            bool result = keyValue.Key;
            dictionary = keyValue.Value;

            // Check whether the fat of the product is the fat required
            if (dictionary.ContainsKey("Fat"))
            {
                double fat = (double)dictionary["Fat"][0];
                result = result && fat == Fat;
                dictionary.Remove("Fat");
            }

            // Check whether the fat of the product is the fat required
            if (dictionary.ContainsKey("MilkType"))
            {
                bool milkResult = false;
                foreach (var milk in dictionary["MilkType"])
                {
                    if ((MILKTYPE)Enum.Parse(typeof(MILKTYPE), milk.ToString()) == MilkType)
                    {
                        milkResult = true;
                        break;
                    }
                }
                result = result && milkResult;
                dictionary.Remove("MilkType");
            }

            keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(result, dictionary);
            return keyValue;
        }

        public override string GetParms()
        {
            string text = "פרוזן יוגורט" + base.GetParms();
            if (MilkType == MILKTYPE.CowMilk)
                text += ", חלב פרה";
            if (MilkType == MILKTYPE.GoatMilk)
                text += ", חלב עיזים";
            if (MilkType == MILKTYPE.SoyMilk)
                text += ", חלב סויה";
            text += ", " + Fat + " אחוז שומן";
            return text;
        }
    }
}
