using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BE
{
    public abstract class Product: INotifyPropertyChanged
    {
        private string _productID;
        public string ProductID
        {
            get { return _productID; }
            set
            {
                _productID = value;
                OnPropertyChanged("ProductID");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        private bool _vegan;
        public bool Vegan
        {
            get { return _vegan; }
            set
            {
                _vegan = value;
                OnPropertyChanged("Vegan");
            }
        }

        private bool _sugarFree;
        public bool SugarFree
        {
            get { return _sugarFree; }
            set
            {
                _sugarFree = value;
                OnPropertyChanged("SugarFree");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _nutritionalValues;
        public string NutritionalValues
        {
            get { return _nutritionalValues; }
            set
            {
                _nutritionalValues = value;
                OnPropertyChanged("NutritionalValues");
            }
        }

        /// <summary>
        /// 
        /// </summary
        private ObservableCollection<Review> _reviews;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual ObservableCollection<Review> Reviews
        {
            get { return _reviews; }
            private set { _reviews = value; }
        }

        public string FirstImage
        {
            get
            {
                try { return Reviews[0].Image; }
                catch (Exception) { return ""; }
            }
        }
        
        public string ShopID { get; set; }
        public virtual Shop Shop { get; set; }

        public Product()
        {
            ProductID = DateTime.Now.Ticks.ToString("X");
            Reviews = new ObservableCollection<Review>();
        }

        protected Product( string name, double price, bool vegan, bool sugarFree, string description)
        {
            ProductID  = DateTime.Now.Ticks.ToString("X");
            Name = name;
            Price = price;
            Vegan = vegan;
            SugarFree = sugarFree;
            Description = description;
            Reviews = new ObservableCollection<Review>();

        }

        /// <summary>
        /// A function that receives the desired parameters in the search and returns whether the product 
        /// itself meets the parameters or not
        /// </summary>
        /// <param name="dictionary">A dictionary defined from pairs of key & value: the key is a string that
        /// describes the type of search parameter, and the value is a list of several possible results for 
        /// that search parameter</param>
        /// <returns>Boolean variable: Whether the product stands in the search conditions or not</returns>
        public virtual bool Search(Dictionary<string, List<object>> dictionary)
        {
            // Checking for no properties in the search
            if (dictionary.Count == 0)
                return false;

            bool result = true;

            // Check if the name or description contains one of the free text words
            if (dictionary.ContainsKey("FreeText"))
            {
                Tools tools = new Tools();
                string content = (string)dictionary["FreeText"][0];
                result = result && (tools.Similar(Name, content) || tools.Similar(Description, content));
            }

            // Check whether the price of the product is less than the maximum price requested
            if (dictionary.ContainsKey("MaxPrice"))
            {
                double maxPrice = (double)dictionary["MaxPrice"][0];
                result = result && Price < maxPrice;
            }

            // Check whether the price of the product is more than the minimum price requested
            if (dictionary.ContainsKey("MinPrice"))
            {
                double minPrice = (double)dictionary["MinPrice"][0];
                result = result && Price > minPrice;
            }

            // Check whether the product is vegan or not, as required
            if (dictionary.ContainsKey("Vegan"))
            {
                bool vegan = (bool)dictionary["Vegan"][0];
                result = result && Vegan == vegan;
            }

            // Check whether the product is sugar free or not, as required
            if (dictionary.ContainsKey("SugarFree"))
            {
                bool sugarFree = (bool)dictionary["SugarFree"][0];
                result = result && SugarFree == sugarFree;
            }

            // Check if the product meets the required nutritional components
            if (dictionary.ContainsKey("NutritionalValues"))
            {
                foreach (KeyValuePair<string, double> values in dictionary["NutritionalValues"])
                {
                    // TODO: לסדר את הרכיבים התזונתיים
                    result = result && false;
                }
            }

            return result;
        }

        public void AddReview(Review review)
        {
            if (review.Product != null)
                _reviews.Remove(review);
            review.Product = this;
            _reviews.Add(review);
        }
    }
}
