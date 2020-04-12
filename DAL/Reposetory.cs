using BE;
using System.Collections.Generic;

namespace DAL
{
    public class Reposetory
    {

        private List<Product> products;
        private List<Shop> shops;
        private List<Review> reviews;
        private List<Address> Addresses;

        public Reposetory()
        {

        }

        public void add_Shop(Shop shop)
        {
            using (var context = new ShopReviewsdb())
            {
                context.shops.Add(shop);
                context.SaveChanges();
            }
        }

        public void add_Product(Product product)
        {
            using (var context = new ShopReviewsdb())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void add_Review(Review review)
        {
            using (var context = new ShopReviewsdb())
            {
                context.Reviews.Add(review);
                context.SaveChanges();
            }
        }
        public void add_Address(Address address)
        {
            using (var context = new ShopReviewsdb())
            {
                context.Addresses.Add(address);
                context.SaveChanges();
            }
        }


    }
}
