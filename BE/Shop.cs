using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BE
{
    public class Shop : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        public string ShopID { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        private string 
        public string ImageURL _imageURL;
        {
            get { return _imageURL; } 
            set
            {
                _imageURL = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageURL"));
            }
        }
        public List<Product> Products { get; set; }

        public Shop(string shopID, Address address, string phone, string website, string facebook, string instagram, string imageURL, List<Product> products)
        {
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