using System;
using System.Collections.Generic;

namespace BE
{
    public class Shop
    {
        
        

        public string ShopID { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string ImageURL { get; set; }
        public List<Product> Products { get; set; }

        public Shop(string shopID, Address address, string phone, string website, string facebook, string instagram, string imageURL, List<Product> products)
        {
            ShopID = shopID;
            Address = address;
            Phone = phone;
            Website = website;
            Facebook = facebook;
            Instagram = instagram;
            ImageURL = imageURL;
            Products = products;

        }
        public Shop() { }
    }
}