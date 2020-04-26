using BL;
using System.Collections.Generic;

namespace BE
{
    public abstract class FlavoredProduct : Product
    {
        private string _flaver;
        public string Flaver
        {
            get { return _flaver; }
            set
            {
                _flaver = value;
                OnPropertyChanged("Flaver");
            }
        }

        public bool Search(Dictionary<string, List<object>> dictionary)
        {
            // Checking for no properties in the search
            if (dictionary.Count == 0)
                return false;

            bool result = true;

            if (dictionary.ContainsKey("Flaver"))
            {
                Tools tools = new Tools();
                string content = (string)dictionary["Flaver"][0];
                result = result && tools.Similar(Flaver, content);
            }

            return base.Search(dictionary) && result;
        }

        public string GetParms()
        {
            string text = base.GetParms();
            text += ", " + _flaver;

            return text;
            
        }

    }
}
