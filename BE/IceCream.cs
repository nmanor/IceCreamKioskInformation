using System;
using System.Collections.Generic;

namespace BE
{
    public class IceCream : FlavoredProduct
    {
        public bool Search(Dictionary<string, List<Object>> dictionary)
        {  
            return base.Search(dictionary);
        }
    }
}
