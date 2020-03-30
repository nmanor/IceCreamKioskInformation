using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Reposetory
    {

        private List<Product> products;
        private List<Shop> shops;
        private List<Review> reviews;
        private List<Address> Addresses;

        public void add_Shop(Shop shop)
        {
            using (var context = new shopReviewsdb())
            {
                context.shops.Add(shop);
                context.SaveChanges();
            }
        }

        public void add_Product(Product product)
        {
            using (var context = new shopReviewsdb())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }


    }
}
