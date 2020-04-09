using System;
using System.Collections.Generic;
using BL;

namespace BE
{
    public abstract class Product
    {
   
        /// </summary>
        public string ProductID{ get; set;}

        public string Name
        {
            get;
            set;
        }



        public double Price
        {
            get;
            set;
        }


        public bool Vegan
        {
            get;
            set;
        }


        public bool SugarFree
        {
            get;
            set;
        }


        public string Description
        {
            get;
            set;
        }

 
        /// <summary>
        /// 
        /// </summary>
        public List<Review> Review_list
        {
            get;
            set;
        }

        /// <summary>
        /// Code Property.
        /// </summary>
        public string NutritionalValues
        {
            get;
            set;
        }

        public string FirstImage
        {
            get { return Review_list[0].ImageURL; }
        }

        public Product()
        {
            
        }

        protected Product(string productID, string name, double price, bool vegan, bool sugarFree, string description, List<Review> review_list,  string nutritionalValues)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            Vegan = vegan;
            SugarFree = sugarFree;
            Description = description;
            Review_list = review_list;
            NutritionalValues = nutritionalValues;
        
        }

        /// <summary>
        /// A function that receives the desired parameters in the search and returns whether the product 
        /// itself meets the parameters or not
        /// </summary>
        /// <param name="dictionary">A dictionary defined from pairs of key & value: the key is a string that
        /// describes the type of search parameter, and the value is a list of several possible results for 
        /// that search parameter</param>
        /// <returns>Boolean variable: Whether the product stands in the search conditions or not</returns>
        public bool Search(Dictionary<string, List<object>> dictionary)
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
            if(dictionary.ContainsKey("NutritionalValues"))
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
            Review_list.Add(review);
        }
    }
}
