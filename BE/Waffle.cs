using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Waffle: Product
    {
        private bool _glutenFree;

        public bool GlutenFree 
        {
            set { _glutenFree = value; }
            get { return _glutenFree; }
        }

        public new bool Search(Dictionary<string, List<object>> dictionary)
        {
            return base.Search(dictionary);
        }
    }
}

