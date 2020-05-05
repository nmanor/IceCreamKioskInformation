using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BE
{
    public class FrenchCrape : Product
    {
        private bool _freeExtras;
        public bool FreeExtras
        {
            get { return _freeExtras; }
            set
            {
                _freeExtras = value;
                OnPropertyChanged("FreeExtras");
            }
        }

        public FrenchCrape() : base() { }
        public FrenchCrape(Product p)
        {
            this.Description = p.GetType().GetProperty("Description").GetValue(p).ToString();
            this.FreeExtras = (bool)p.GetType().GetProperty("FreeExtras").GetValue(p);
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
        public new KeyValuePair<bool, Dictionary<string, List<object>>> Search(Dictionary<string, List<object>> dictionary)
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

            // Check whether the product is FreeExtras or not, as required
            if (dictionary.ContainsKey("FreeExtras"))
            {
                bool freeExtras = (bool)dictionary["FreeExtras"][0];
                result = result && FreeExtras == freeExtras;
                dictionary.Remove("FreeExtras");
            }

            keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(result, dictionary);
            return keyValue;
        }

        public override string GetParms()
        {
            string text ="קרפ צרפתי, "+ base.GetParms();
            if (FreeExtras)
                text += "תוספות חינם, ";
            return text;
        }
    }
}
