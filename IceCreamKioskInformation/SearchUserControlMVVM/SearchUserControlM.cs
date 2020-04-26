using BE;
using BL;
using DAL;
using System.Collections.Generic;

namespace IceCreamKioskInformation
{
    class SearchUserControlM
    {
        public List<Product> PerformSearch(Dictionary<string, List<object>> Dictionary) 
        {
            List<Product> result = new List<Product>();
            BLimp bLimp = new BLimp();

            foreach( Product product in bLimp.Get_all_Products())
            {
                if (product.Search(Dictionary))
                    result.Add(product);
            }

            return result;
        }
    }
}
