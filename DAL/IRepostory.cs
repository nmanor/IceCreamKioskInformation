using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepostory
    {
        List<Shop> Get_all_Shops();
        List<Review> Get_all_Reviews();
        List<Address> Get_all_Adrress();
        List<Product> Get_all_Products();

        void add_Shop(Shop shop);
        void add_Product(Product product);
        void add_Review(Review review);
        void add_Address(Address address);

        void update_Shop(Shop shop);
        void update_Product(Product product);
        void update_Review(Review review);
        void update_Address(Address address);
    }
}
