using System;
using System.Collections.Generic;

namespace BE
{
    public class FrozenYogurt : Product
    {
        private double _fat;
        private MILKTYPE _milkType;
        public double Fat{ get; set; }
        public MILKTYPE MILKTYPE { get; set; }


        public bool Search(Dictionary<string, List<object>> dictionary)
        {

            // Checking for no properties in the search
            if (dictionary.Count == 0)
                return false;

            bool result = true;

            // Check whether the fat of the product is the fat required
            if (dictionary.ContainsKey("Fat"))
            {
                double fat = (double)dictionary["Fat"][0];
                result = result && fat == Fat;
            }

            // Check whether the fat of the product is the fat required
            if (dictionary.ContainsKey("MilkType"))
            {
                MILKTYPE milk = (MILKTYPE)dictionary["MilkType"][0];
                result = result && milk == MILKTYPE;
            }

            return base.Search(dictionary) && result;
        }
    }
}
