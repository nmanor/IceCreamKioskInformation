using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BE
{
    public class Shop : INotifyPropertyChanged
    {
        private string _shopID;
        private string _shopName;
        private Address _address;
        private ObservableCollection<Product> _products;
        private string _phone;
        private string _website;
        private string _facebook;
        private string _instagram;
        private string _imageURL;


        public string ShopID
        {
            get { return _shopID; }
            set
            {
                _shopID = value;
                OnPropertyChanged("ShopID");
            }
        }

        public string ShopName
        {
            get { return _shopName; }
            set
            {
                _shopName = value;
                OnPropertyChanged("ShopName");
            }
        }

        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        public virtual ObservableCollection<Product> Products
        {
            get { return _products; }
            private set { _products = value; } 
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Website
        {
            get { return _website; }
            set
            {
                _website = value;
                OnPropertyChanged("Website");
            }
        }
        public string Facebook
        {
            get { return _facebook; }
            set
            {
                _facebook = value;
                OnPropertyChanged("Facebook");
            }
        }
        public string Instagram
        {
            get { return _instagram; }
            set
            {
                _instagram = value;
                OnPropertyChanged("Instagram");
            }
        }
        public string ImageURL
        {
            get { return _imageURL; }
            set
            {
                _imageURL = value;
                OnPropertyChanged("ImageURL");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Shop( string shopName, Address address, string phone, string website, string facebook, string instagram, string imageURL)
        {
            ShopID =  DateTime.Now.Ticks.ToString("X");
            ShopName = shopName;
            Address = address;
            Phone = phone;
            Website = website;
            Facebook = facebook;
            Instagram = instagram;
            ImageURL = imageURL;
            Products = new ObservableCollection<Product>();
        }

        /// <summary>
        /// Add a new product to the shop
        /// </summary>
        /// <param name="product">The product you want to add to the store</param>
        public void AddProduct(Product product)
        {
            if (product.Shop != null)
                _products.Remove(product);
            product.Shop = this;
            product.ShopID = ShopID;
            _products.Add(product);
        }

        public Shop()
        {
            ShopID = DateTime.Now.Ticks.ToString("X");
            Products = new ObservableCollection<Product>();
        }

        public void equale(Shop shop)
        {
            ShopID = shop.ShopID;
            ShopName = shop.ShopName;
            Address = shop.Address;
            Products = shop.Products;
            Phone = shop.Phone;
            Website = shop.Website;
            Facebook = shop.Facebook;
            Instagram = shop.Instagram;
            ImageURL = shop.ImageURL;
        }
    }
}