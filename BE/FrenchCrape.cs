using System;
using System.Collections.Generic;

namespace BE
{
    public class FrenchCrape : Product
    {
        private bool _freeExtras;
        public bool FreeExtras
        {
            get { return _freeExtras; }
            set
            {
                _freeExtras = value;
                OnPropertyChanged("FreeExtras");
            }
        }

        public bool Search(Dictionary<string, List<object>> dictionary)
        {
            // Checking for no properties in the search
            if (dictionary.Count == 0)
                return false;

            bool result = true;

            // Check whether the product is FreeExtras or not, as required
            if (dictionary.ContainsKey("FreeExtras"))
            {
                bool freeExtras = (bool)dictionary["FreeExtras"][0];
                result = result && FreeExtras == freeExtras;
            }

            return base.Search(dictionary) && result;
        }

        public string GetParms()
        {
            string text ="קרפ צרפתי, "+ base.GetParms();
            if (FreeExtras)
                text += ", תוספות";
            return text;
        }
    }
}
