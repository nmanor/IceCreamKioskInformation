using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class FrenchCrape: Product
    {
        private bool _freeExtras;

        public bool FreeExtras
        {
            set { _freeExtras = value; }
            get { return _freeExtras; }
        }

        public override bool Search(Dictionary<string, List<object>> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
