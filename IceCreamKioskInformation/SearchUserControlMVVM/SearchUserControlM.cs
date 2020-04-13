using BE;
using DAL;
using System.Collections.Generic;

namespace IceCreamKioskInformation
{
    class SearchUserControlM
    {
        public List<Product> searchProducts(Dictionary<string, List<object>> Dictionary) 
        {
            List<Product> result = new List<Product>();
            Reposetory reposetory = new Reposetory();

            foreach( Product product in reposetory.get_all_Products())
            {
                if (product.Search(Dictionary))
                    result.Add(product);
            }

            return result;
        }
    }
}
