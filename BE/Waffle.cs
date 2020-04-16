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

        public Waffle() { }
        public Waffle( string name, double price, bool vegan, bool sugarFree, string description, string nutritionalValues) : base( name, price, vegan, sugarFree, description, nutritionalValues)
        {

        }

        public new bool Search(Dictionary<string, List<object>> dictionary)
        {
            // Checking for no properties in the search
            if (dictionary.Count == 0)
                return false;

            bool result = true;

            // Check whether the product is GlutenFree or not, as required
            if (dictionary.ContainsKey("GlutenFree"))
            {
                bool glutenFree = (bool)dictionary["GlutenFree"][0];
                result = result && GlutenFree == glutenFree;
            }

            return base.Search(dictionary) && result;
        }
    }
}

