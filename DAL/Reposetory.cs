using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //add_Address(new BE.Address("123", "יפו", 12, "ירושלים"));
            get_all_Adrress();
            products = get_all_Products();
            get_all_Reviews();
            get_all_Shops();
        }

        private void get_all_Shops()
        {
            using (var context = new ShopReviewsdb())
            {
                shops = context.shops.ToList<Shop>();
            }
        }

        private void get_all_Reviews()
        {
            using (var context = new ShopReviewsdb())
            {
                reviews = context.Reviews.ToList<Review>();
            }
        }
        private void get_all_Adrress()
        {
            using (var context = new ShopReviewsdb())
            {
                Addresses = context.Addresses.ToList<Address>();
            }
        }
        public List<Product> get_all_Products()
        {
            List<Product> result = new List<Product>();
            using (var context = new ShopReviewsdb())
            {
                result = context.Products.ToList<Product>();
            }
            return result;
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

        public void getProductsWithSearch(Dictionary<string, List<object>> Dictionary)
        {

        }


    }
}
