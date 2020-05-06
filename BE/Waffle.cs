using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BE
{
    public class Waffle : Product
    {
        private bool _glutenFree;
        public bool GlutenFree
        {
            get { return _glutenFree; }
            set
            {
                _glutenFree = value;
                OnPropertyChanged("GlutenFree");
            }
        }

        public Waffle():base() { }

        public Waffle(Product p)
        {
            this.Description = p.GetType().GetProperty("Description").GetValue(p).ToString();
            this.Name = p.GetType().GetProperty("Name").GetValue(p).ToString();
            this.NutritionalValues = p.GetType().GetProperty("NutritionalValues").GetValue(p).ToString();
            this.Price = (double)p.GetType().GetProperty("Price").GetValue(p);
            this.ProductID = p.GetType().GetProperty("ProductID").GetValue(p).ToString();
            this.Reviews = (ObservableCollection<Review>)p.GetType().GetProperty("Reviews").GetValue(p);
            this.Shop = (Shop)p.GetType().GetProperty("Shop").GetValue(p);
            this.ShopID = p.GetType().GetProperty("ShopID").GetValue(p).ToString();
            this.SugarFree = (bool)p.GetType().GetProperty("SugarFree").GetValue(p);
            this.Vegan = (bool)p.GetType().GetProperty("Vegan").GetValue(p);
            this.GlutenFree = (bool)p.GetType().GetProperty("GlutenFree").GetValue(p);
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

            // Check whether the product is GlutenFree or not, as required
            if (dictionary.ContainsKey("GlutenFree"))
            {
                bool glutenFree = bool.Parse(dictionary["GlutenFree"][0].ToString());
                result = result && GlutenFree == glutenFree;
                dictionary.Remove("GlutenFree");
            }

            keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(result, dictionary);
            return keyValue;
        }
        public override string GetParms()
        {
            string text = "וופל בלגי" + base.GetParms();
            if (GlutenFree)
                text += ", ללא גלוטן";
            return text;
        }
    }
}

