using System;
using System.Collections.Generic;

namespace BE
{
    public class FrenchCrape : Product
    {
        private bool _freeExtras;

        public bool FreeExtras
        {
            set { _freeExtras = value; }
            get { return _freeExtras; }
        }

        public bool Search(Dictionary<string, List<object>> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
