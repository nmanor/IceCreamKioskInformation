using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
            //Shop shop = new Shop( "dogs", new Address("יפו", 43, "תל אביב"), "0543672343", "www.dogs.co.il", "tada", "@tada", "www.touchme.co.il");
            //Product product = new Waffle("waffleass", 12.3, true, false, "good waffle", "456");
            //Review review = new Review("dd", new DateTime(1799, 2, 1), "1234", "1234", 3, "2", new DateTime(1799, 2, 1));
            //product.AddReview(review);
            //shop.AddProduct(product);
            //add_Shop(shop);

            

            Addresses = get_all_Adrress();
            products = get_all_Products();
            reviews = get_all_Reviews();
            shops = get_all_Shops();

           
        }

        public List<Shop> get_all_Shops()
        {
            List<Shop> result = new List<Shop>();
            using (var context = new ShopReviewsdb())
            {
                result = context.shops.Include(a => a.Address).Include(p => p.Products).Include(l => l.Products.Select(r => r.Reviews)).ToList<Shop>();
            }
            return result;
        }

        public List<Review> get_all_Reviews()
        {
            List<Review> result = new List<Review>();
            using (var context = new ShopReviewsdb())
            {
                result = context.Reviews.ToList<Review>();
            }
            return result;
        }
        public List<Address> get_all_Adrress()
        {
            List<Address> result = new List<Address>();
            using (var context = new ShopReviewsdb())
            {
                result = context.Addresses.ToList<Address>();
            }
            return result;
        }
        public List<Product> get_all_Products()
        {
            List<Product> result = new List<Product>();
            using (var context = new ShopReviewsdb())
            {
                result = context.Products.Include(s => s.Shop).Include(r => r.Reviews).ToList<Product>();
                  
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
                product.Shop = null;
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
