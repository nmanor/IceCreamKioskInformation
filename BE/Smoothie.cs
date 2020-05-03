using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BE
{
    public class Smoothie : FlavoredProduct
    {

        public Smoothie() : base() { }
        public Smoothie(Product p)
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
            this.Flaver = p.GetType().GetProperty("Flaver").GetValue(p).ToString();
        }
        public bool Search(Dictionary<string, List<Object>> dictionary)
        {
          
            return base.Search(dictionary) ;
        }

        public string GetParms()
        {
            string text = "שייק, " + base.GetParms();

            return text;
        }

    }
}
