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
                if (product.Search(Dictionary))
                    result.Add(product);
            }
            return result;
        }

        public List<Product> GetAllProducts()
        {
            return new BLimp().Get_all_Products();
        }
    }
}
