using BE;
using BL;
using DAL;
using System;
using System.Collections.Generic;

namespace IceCreamKioskInformation
{
    class SearchUserControlM
    {
        public List<Tuple<Product, string>> PerformSearch(Dictionary<string, List<object>> Dictionary, List<Product> products)
        {
            List<Tuple<Product, string>> result = new List<Tuple<Product, string>>();
            //List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                Dictionary<string, List<object>> newDictionary = new Dictionary<string, List<object>>(Dictionary);
                KeyValuePair<bool, Dictionary<string, List<object>>> search = product.Search(newDictionary);
                string missingParmeters = "";
                if (search.Key)
                {
                    foreach (var parmeter in search.Value.Keys)
                    {
                        if (TranslatedParmeters.ContainsKey(parmeter))
                            missingParmeters += TranslatedParmeters[parmeter] + ", ";
                        else
                            missingParmeters += parmeter + ", ";
                    }
                    if (missingParmeters.Length > 0)
                        missingParmeters = missingParmeters.Remove(missingParmeters.Length - 2);
                    result.Add(new Tuple<Product, string>(product, missingParmeters));
                }
            }
            return result;
        }

        public List<Product> GetAllProducts()
        {
            return new BLimp().Get_all_Products();
        }

        private Dictionary<string, string> TranslatedParmeters = new Dictionary<string, string>
        {
            ["MilkType"] = "סוג חלב",
            ["MilkFat"] = "אחוזי שומן",
            ["GlutenFree"] = "ללא גלוטן",
            ["FreeExtras"] = "תוספות חינם"
        };
    }
}
