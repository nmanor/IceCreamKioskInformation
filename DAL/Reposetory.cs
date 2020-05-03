using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RestSharp.Extensions;

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
            List<Product> retrn = new List<Product>();
            using (var context = new ShopReviewsdb())
            {
                result = context.Products.Include(s => s.Shop).Include(r => r.Reviews).Include(a => a.Shop.Address).ToList<Product>();

            }
            foreach (Product p in result)
            {
                var field = p.GetType().GetField("_entityWrapper");

                if (field == null)
                    retrn.Add(p);

                var wrapper = field.GetValue(p);
                var property = wrapper.GetType().GetProperty("IdentityType").GetValue(wrapper);
                var name = property.GetType().GetProperty("Name").GetValue(property);
                Product prod = null;
                if(name.ToString() == "IceCream")
                    prod = new IceCream(p);
                if (name.ToString() == "FrozenYogurt")
                    prod = new FrozenYogurt(p);
                if (name.ToString() == "Waffle")
                    prod = new Waffle(p);
                if (name.ToString() == "FrenchCrape")
                    prod = new FrenchCrape(p);
                if (name.ToString() == "Smoothie")
                    prod = new Smoothie(p);
                prod.nutritinos = new GetNutritions().GetProductNutritions(prod.NutritionalValues);
                retrn.Add(prod);
            }

            return retrn;
        }

        public void add_Shop(Shop shop)
        {
            using (var context = new ShopReviewsdb())
            {
                context.shops.Add(shop);
                context.SaveChanges();
            }
        }

        public void update_Shop(Shop shop)
        {
            using (var context = new ShopReviewsdb())
            {
                var old = context.shops.Find(shop.ShopID);
                update_Address(shop.Address);
                old.Facebook = shop.Facebook;
                old.ImageURL = shop.ImageURL;
                old.Instagram = shop.Instagram;
                old.ShopID = shop.ShopID;
                old.Website = shop.Website;
                old.Phone = shop.Phone;
                context.SaveChanges();
            }
        }

        public void update_Product(Product p)
        {
            using (var context = new ShopReviewsdb())
            {
                var old = context.Products.Find(p.ProductID);
                old.ProductID = p.ProductID;
                old.Name = p.Name;
                old.NutritionalValues = p.NutritionalValues;
                old.Price = p.Price;
                old.ShopID = p.ShopID;
                old.SugarFree = p.SugarFree;
                old.Vegan = p.Vegan;
                old.ShopID = p.ShopID;
                old.Description = p.Description;
                try
                {
                    old.GetType().GetProperty("FreeExtras").SetValue(old, p.GetType().GetProperty("FreeExtras").GetValue(p));
                }
                catch (Exception e) { }
                try
                {
                    old.GetType().GetProperty("Fat").SetValue(old, p.GetType().GetProperty("Fat").GetValue(p));
                }
                catch (Exception e) { }
                try
                {
                    old.GetType().GetProperty("MilkType").SetValue(old, p.GetType().GetProperty("MilkType").GetValue(p));
                }
                catch (Exception e) { }
                try
                {
                    old.GetType().GetProperty("Flaver").SetValue(old, p.GetType().GetProperty("Flaver").GetValue(p));
                }
                catch (Exception e) { }
                try
                {
                    old.GetType().GetProperty("GlutenFree").SetValue(old, p.GetType().GetProperty("GlutenFree").GetValue(p));
                }
                catch (Exception e) { }
                context.SaveChanges();
            }
        }

        public void update_Review(Review r)
        {
            using (var context = new ShopReviewsdb())
            {
                var old = context.Reviews.Find(r.ReviewID);
                old.ProductID = r.ProductID;
                old.Image = r.Image;
                old.PublishDate = r.PublishDate;
                old.Rating = r.Rating;
                old.ReviewContent = r.ReviewContent;
                old.ReviewerName = r.ReviewerName;
                old.ReviewID = r.ReviewID;
                old.ReviwerBirthday = r.ReviwerBirthday;
                old.ReviwerEmail = r.ReviwerEmail;
                context.SaveChanges();
            }
        }

        public void update_Address(Address a)
        {
            using (var context = new ShopReviewsdb())
            {
                var old = context.Addresses.Find(a.AddressID);
                old.AddressID = a.AddressID;
                old.BuildingNumber = a.BuildingNumber;
                old.City = a.City;
                old.Street = a.Street;
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
                review.Product = null;
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
