using BE;
using System.Data.Entity;

namespace DAL
{
    class shopReviewsdb : DbContext
    {

        public shopReviewsdb() : base("name=shopReveiwdb")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> shops { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
