using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.SearchResultsList
{
    class SearchResultsListUserControlVM
    {
        private SearchResultsListUserControl View;

        public SearchResultsListUserControlVM(SearchResultsListUserControl searchResultsListUserControl)
        {
            this.View = searchResultsListUserControl;

            Products = new List<Product>();
            for (int i = 0; i < 50; i++)
            {
                Shop shop = new Shop() { ShopName = "חנות מספר " + i };
                Product product = new BE.IceCream() { Name = "גלידה מספר " + i, Shop = shop };
                Products.Add(product);
            }
        }

        public List<Product> Products { get; set; }
    }
}
