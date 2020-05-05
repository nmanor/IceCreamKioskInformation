using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.SearchResultsList
{
    public class SearchResultsListUserControlM
    {
        public List<Tuple<Product, string>> IncludeBlanks(List<Tuple<Product, string>> products, string blank)
        {
            List<Tuple<Product, string>> result = new List<Tuple<Product, string>>();
            foreach (Tuple<Product, string> tuple in products)
            {
                if (tuple.Item2 != blank)
                    result.Add(tuple);
            }
            return result;
        }
    }
}
