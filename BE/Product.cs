using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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

        private Dictionary<string, double> _nutritinosValuesDictonary;
        [NotMapped]
        public Dictionary<string, double> NutritinosValuesDictonary
        {
            get { return _nutritinosValuesDictonary; }
            set
            {
                _nutritinosValuesDictonary = value;
                OnPropertyChanged("NutritinosValuesDictonary");
            }
        }

        /// <summary>
        /// 
        /// </summary
        private ObservableCollection<Review> _reviews;

        public virtual ObservableCollection<Review> Reviews
        {
            get { return _reviews; }
           set 
            {
                if(_reviews == null)
                    _reviews =  new ObservableCollection<Review>();
                foreach (Review r in value)
                    this.AddReview(r);
            }
        }

        private Delegate[] InvocationList;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
        public void ClearPropertyChanged() { InvocationList = PropertyChanged.GetInvocationList(); PropertyChanged = null; }
        public void RestorePropertyChanged() 
        {
            foreach (var item in InvocationList)
            {
                PropertyChanged += (PropertyChangedEventHandler)item;
            }
        }

        public string ShopID { get; set; }

        private Shop _shop;
        public Shop Shop
        {
            get
            {
                return _shop;
            }
            set
            {
                _shop = value;
                if(value != null)
                    ShopID = _shop.ShopID;
                OnPropertyChanged("Shop");
            }
        }

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
        public virtual KeyValuePair<bool,Dictionary<string, List<object>>> Search(Dictionary<string, List<object>> dictionary)
        {
            KeyValuePair<bool, Dictionary<string, List<object>>> keyValue;

            // Checking for no properties in the search
            if (dictionary.Count == 0)
            {
                keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(false, dictionary);
                return keyValue;
            }

            bool result = true;

            // Check if the name or description contains one of the free text words
            if (dictionary.ContainsKey("FreeText"))
            {
                Tools tools = new Tools();
                string content = (string)dictionary["FreeText"][0];
                result = result && (tools.Similar(Name, content) || tools.Similar(Description, content));
                dictionary.Remove("FreeText");
            }

            // Check whether the price of the product is less than the maximum price requested
            if (dictionary.ContainsKey("MaxPrice"))
            {
                double maxPrice = double.Parse(dictionary["MaxPrice"][0].ToString());
                result = result && Price <= maxPrice;
                dictionary.Remove("MaxPrice");
            }

            // Check whether the price of the product is more than the minimum price requested
            if (dictionary.ContainsKey("MinPrice"))
            {
                double minPrice = double.Parse(dictionary["MinPrice"][0].ToString());
                result = result && Price >= minPrice;
                dictionary.Remove("MinPrice");
            }

            // Check whether the rating of the product is less than the maximum rating requested
            if (dictionary.ContainsKey("MaxRating"))
            {
                int max = int.MinValue;
                foreach (Review review in Reviews)
                    if (review.Rating > max)
                        max = review.Rating;
                result = result && max <= int.Parse(dictionary["MaxRating"][0].ToString());
                dictionary.Remove("MaxRating");
            }

            // Check whether the rating of the product is more than the minimum rating requested
            if (dictionary.ContainsKey("MinRating"))
            {
                int min = int.MaxValue;
                foreach (Review review in Reviews)
                    if (review.Rating < min)
                        min = review.Rating;
                result = result && min >= int.Parse(dictionary["MinRating"][0].ToString());
                dictionary.Remove("MinRating");
            }

            // Check whether the product is vegan or not, as required
            if (dictionary.ContainsKey("Vegan"))
            {
                bool vegan = bool.Parse(dictionary["Vegan"][0].ToString());
                result = result && Vegan == vegan;
                dictionary.Remove("Vegan");
            }

            // Check whether the product is sugar free or not, as required
            if (dictionary.ContainsKey("SugarFree"))
            {
                bool sugarFree = bool.Parse(dictionary["SugarFree"][0].ToString());
                result = result && SugarFree == sugarFree;
                dictionary.Remove("SugarFree");
            }

            // Check if the product meets the required nutritional components
            if (dictionary.ContainsKey("NutritionalValues"))
            {
                List<KeyValuePair<string, double>> keys = new List<KeyValuePair<string, double>>();
                foreach (KeyValuePair<string, double> values in dictionary["NutritionalValues"])
                    if (NutritinosValuesDictonary.ContainsKey(values.Key))
                    {
                        result = result && (values.Value <= NutritinosValuesDictonary[values.Key]);
                        keys.Add(values);
                    }
                foreach (KeyValuePair<string, double> s in keys)
                    dictionary["NutritionalValues"].Remove(s);
                if (dictionary["NutritionalValues"].Count == 0)
                    dictionary.Remove("NutritionalValues");
                
            }

            keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(result, dictionary);
            return keyValue;
        }

        public void AddReview(Review review)
        {
            if (review.Product != null)
                _reviews.Remove(review);
            review.Product = this;
            _reviews.Add(review);
        }

        public virtual string GetParms()
        {
            string text = "";
            if (SugarFree)
                text += ", ללא סוכר";
            if (Vegan)
                text += ", טבעוני";
            return text;
        }
    }
}
