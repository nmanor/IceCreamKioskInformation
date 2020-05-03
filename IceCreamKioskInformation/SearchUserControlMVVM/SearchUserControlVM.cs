using BE;
using IceCreamKioskInformation.SearchUserControlMVVM;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace IceCreamKioskInformation
{
    public class SearchUserControlVM : INotifyPropertyChanged
    {
        public SearchUserControlVM(SearchUserControl searchUserControl)
        {
            this.View = searchUserControl;
            Dictionary = new Dictionary<string, List<object>>();
        }

        /// <summary>
        /// Action of clicking one of the tags
        /// </summary>
        public ICommand AddFilter { get { return new AddFilterCMD(this); } }

        /// <summary>
        /// Start the search operation
        /// </summary>
        public ICommand PerformSearch { get { return new PerformSearchCMD(this); } }

        public SearchUserControl View { get; set; }

        public Dictionary<string, List<object>> Dictionary { get; set; }

        private string _freeText;
        public string FreeText 
        { 
            get { return _freeText; }
            set
            {
                _freeText = value;
                if (Dictionary.ContainsKey("FreeText"))
                    Dictionary["FreeText"][0] = _freeText;
                else
                    Dictionary.Add("FreeText", new List<object> { _freeText });
                OnPropertyChanged("FreeText");
            }
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        /// <summary>
        /// A function that adds values to the search dictionary
        /// </summary>
        /// <param name="Category">The catalog to which the new entry belongs</param>
        /// <param name="Data">The value of the new search parameter itself</param>
        public void addToDictionary(string Category, object Data)
        {
            if (Dictionary.ContainsKey(Category))
                Dictionary[Category].Add(Data);
            else
                Dictionary.Add(Category, new List<object> { Data });
        }

        public void removeFromDictionary(string Category, object Data)
        {
            try
            {
                if (Dictionary[Category].Count > 1)
                    Dictionary[Category].Remove(Data);
                else
                    Dictionary.Remove(Category);
            }
            catch { }
        }

        public void moveTag(Tag tag, Tag newTag) { View.moveTag(tag, newTag); }
        public void bringTagBack(Tag tag, Tag originalTag) { View.bringTagBack(tag, originalTag); }

        public void InvokeSerachDone(List<Product> results) { View.InvokeSerachDone(results); }
    }
}
