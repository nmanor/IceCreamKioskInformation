using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BE
{
    public class Shop : INotifyPropertyChanged
    {

        private Address _address;
        private string _phone;
        private string _website;
        private string _facebook;
        private string _instagram;
        private string _imageURL;
        private List<Product> _products;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ShopID { get; set; }
        public Address Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Website { get => _website; set => _website = value; }
        public string Facebook { get => _facebook; set => _facebook = value; }
        public string Instagram { get => _instagram; set => _instagram = value; }
        public string ImageURL
        {
            get => _imageURL; set
            {
                _imageURL = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageURL"));
            }
        }
        public List<Product> Products { get => _products; set => _products = value; }

        public Shop(string name, Address address, string phone, string website, string facebook, string instagram, string imageURL, List<Product> products)
        {
            // Name = name;
            Address = address;
            Phone = phone;
            Website = website;
            Facebook = facebook;
            Instagram = instagram;
            ImageURL = imageURL;
            Products = products;

        }
    }
}