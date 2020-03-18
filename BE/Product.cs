using System;
using System.Collections.Generic;

namespace BE
{
    public abstract class Product
    {
        // Fields
        private string _code;
        /// <summary>
        /// Code Property.
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _name;
        /// <summary>
        /// Name Property.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _price;
        /// <summary>
        /// Code Property.
        /// </summary>
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private bool _vegan;
        /// <summary>
        /// Code Property.
        /// </summary>
        public bool Vegan
        {
            get { return _vegan; }
            set { _vegan = value; }
        }

        private bool _sugarFree;
        /// <summary>
        /// Code Property.
        /// </summary>
        public bool SugarFree
        {
            get { return _sugarFree; }
            set { _sugarFree = value; }
        }

        private string _description;
        /// <summary>
        /// Code Property.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private List<Review> _review_list = new List<Review>();
        /// <summary>
        /// 
        /// </summary>
        public List<Review> Review_list
        {
            get { return _review_list; }
            set
            {
                _review_list.Clear();
                foreach (Review review in value)
                    _review_list.Add(review);
            }
        }

        private string _nutritionalValues;
        /// <summary>
        /// Code Property.
        /// </summary>
        public string NutritionalValues
        {
            get { return _nutritionalValues; }
            set { _nutritionalValues = value; }
        }


        public Product()
        {
        }

        public abstract bool Search(Dictionary<string, List<Object>> dictionary);

        public void AddReview(Review review)
        {
            Review_list.Add(review);
        }
    }
}
