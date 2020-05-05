using BE;
using BL;
using DAL;
using System.Collections.Generic;

namespace IceCreamKioskInformation
{
    class SearchUserControlM
    {
        public List<Product> PerformSearch(Dictionary<string, List<object>> Dictionary, List<Product> products) 
        {
            List<Product> result = new List<Product>();
            foreach(Product product in products)
            {
                Dictionary<string, List<object>> newDictionary = new Dictionary<string, List<object>>(Dictionary);
                KeyValuePair<bool, Dictionary<string, List<object>>> search = product.Search(newDictionary);
                if (search.Key)
                {
                    if(search.Value.Count == 0)
                        result.Add(product);
                }
                    
            }
            return result;
        }

        public List<Product> GetAllProducts()
        {
            return new BLimp().Get_all_Products();
        }
    }
}
