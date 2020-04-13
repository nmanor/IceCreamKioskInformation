using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BE
{
    public class Shop : ObservableCollection<Product>
    {
        private string _shopID;
        private string _shopName;
        private Address _address;
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

        private void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Add a new product to the shop
        /// </summary>
        /// <param name="product">The product you want to add to the store</param>
        public new void Add(Product product)
        {
            if (product.Shop != null)
                product.Shop.Remove(product);
            product.Shop = this;
            base.Add(product);
        }

        public Shop() { }
    }
}