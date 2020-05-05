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

        public override KeyValuePair<bool, Dictionary<string, List<object>>> Search(Dictionary<string, List<object>> dictionary)
        {
            KeyValuePair<bool, Dictionary<string, List<object>>> keyValue;
            bool result = false;

            // Checking for no properties in the search
            if (dictionary.Count == 0)
            {
                keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(false, dictionary);
                return keyValue;
            }

            if (dictionary.ContainsKey("FreeText"))
            {
                Tools tools = new Tools();
                string content = (string)dictionary["FreeText"][0];
                result = tools.Similar(Flaver, content);
            }

            keyValue = base.Search(dictionary);
            keyValue = new KeyValuePair<bool, Dictionary<string, List<object>>>(result || keyValue.Key, keyValue.Value);
            return keyValue;
        }

        
        public override string GetParms()
        {
            return ", " + _flaver + base.GetParms();
        }

    }
}
