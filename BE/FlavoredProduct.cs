using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    abstract class FlavoredProduct : Product
    {
        private string _flaver;
        public string Flaver { get; set; }

    }
}
