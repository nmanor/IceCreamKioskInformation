using System.Collections.Generic;

namespace BE
{
    public class Waffle : Product
    {
        private bool _glutenFree;

        public bool GlutenFree
        {
            set { _glutenFree = value; }
            get { return _glutenFree; }
        }

        public Waffle(string productID, string name, double price, bool vegan, bool sugarFree, string description, List<Review> review_list, string nutritionalValues) : base(productID, name, price, vegan, sugarFree, description, review_list, nutritionalValues)
        {

        }

        public new bool Search(Dictionary<string, List<object>> dictionary)
        {
            return base.Search(dictionary);
        }
    }
}

