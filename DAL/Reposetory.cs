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
    public class Reposetory: IRepostory
    {
        public Reposetory() { }

        public List<Shop> Get_all_Shops()
        {
            List<Shop> result = new List<Shop>();
            using (var context = new ShopReviewsdb())
            {
                result = context.shops.Include(a => a.Address).Include(p => p.Products).Include(l => l.Products.Select(r => r.Reviews)).ToList<Shop>();
            }
            return result;
        }

        public List<Review> Get_all_Reviews()
        {
            List<Review> result = new List<Review>();
            using (var context = new ShopReviewsdb())
            {
                result = context.Reviews.ToList<Review>();
            }
            return result;
        }
        public List<Address> Get_all_Adrress()
        {
            List<Address> result = new List<Address>();
            using (var context = new ShopReviewsdb())
            {
                result = context.Addresses.ToList<Address>();
            }
            return result;
        }
        public List<Product> Get_all_Products()
        {
            List<Product> result = new List<Product>();
            using (var context = new ShopReviewsdb())
            {
                result = context.Products.Include(s => s.Shop).Include(r => r.Reviews).Include(a => a.Shop.Address).ToList<Product>();
                  
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
