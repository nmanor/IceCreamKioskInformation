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

        public new KeyValuePair<bool, Dictionary<string, List<object>>> Search(Dictionary<string, List<object>> dictionary)
        {
            KeyValuePair<bool, Dictionary<string, List<object>>> keyValue;
            // Checking for no properties in the search
            if (dictionary.Count == 0)
            {
                keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(false, dictionary);
                return keyValue;
            }

            keyValue = base.Search(dictionary);
            bool result = keyValue.Key;
            dictionary = keyValue.Value;

            if (dictionary.ContainsKey("Flaver"))
            {
                Tools tools = new Tools();
                string content = (string)dictionary["Flaver"][0];
                result = result && tools.Similar(Flaver, content);
                dictionary.Remove("Flaver");
            }

            keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(result, dictionary);
            return keyValue;
        }

        
        public override string GetParms()
        {
            return ", " + _flaver + base.GetParms();
        }

    }
}
