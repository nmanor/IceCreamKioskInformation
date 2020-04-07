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
            
            using (var context = new shopReviewsdb())
            {
                try
                {
                    List<Review> reviews = new List<Review>() { new Review( "ass kissing", new DateTime(1999, 3, 5), "you should go taste the ass kicking waffle its the best", 5, "ass", new DateTime(2019, 3, 6), "123456") };
                    List<Product> products = new List<Product>() { new Waffle("1234","the waffle ass", 34.3,false,false,"the best ass tasting waflle in town",reviews,"none") };
                    var shop = new Shop("pets", new Address("123","ass", 3, "assface"), "123456789", "wwww.ass.co.il", "tuches", "ass", "pokito", products);
                    //context.shops.Add(shop);
                    context.SaveChanges();

             
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }

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
               // context.Products.Add(product);
                context.SaveChanges();
            }
        }


    }
}
