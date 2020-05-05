using BE;
using IceCreamKioskInformation.SearchUserControlMVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

namespace IceCreamKioskInformation
{
    public class SearchUserControlVM : INotifyPropertyChanged
    {
        public SearchUserControlVM(SearchUserControl searchUserControl)
        {
            this.View = searchUserControl;
            Dictionary = new Dictionary<string, List<object>>();
            Working = false;
            new Thread(() =>
            {
                FetchingFromDB = true;
                Products = new SearchUserControlM().GetAllProducts();
                FetchingFromDB = false;
            }).Start();
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

        public bool FetchingFromDB { get; set; }
        public List<Product> Products { get; set; }

        private bool _working;
        public bool Working
        {
            get { return _working; }
            set
            {
                _working = value;
                OnPropertyChanged("Working");
            }
        }

        public Dictionary<string, List<object>> _dictionary;
        public Dictionary<string, List<object>> Dictionary
        {
            get { return _dictionary; }
            set
            {
                _dictionary = value;
                OnPropertyChanged("TagsDictionary");
            }
        }

        private string _freeText;
        public string FreeText
        {
            get { return _freeText; }
            set
            {
                _freeText = value;
                if (string.IsNullOrEmpty(_freeText))
                {
                    if (Dictionary.ContainsKey("FreeText"))
                        Dictionary.Remove("FreeText");
                }
                else
                {
                    if (Dictionary.ContainsKey("FreeText"))
                        Dictionary["FreeText"][0] = _freeText;
                    else
                        Dictionary.Add("FreeText", new List<object> { _freeText });
                }
                OnPropertyChanged("FreeText");
                OnPropertyChanged("Dictionary");
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
            OnPropertyChanged("Dictionary");
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
            OnPropertyChanged("Dictionary");
        }

        public void moveTag(Tag tag, Tag newTag) { View.moveTag(tag, newTag); }
        public void bringTagBack(Tag tag, Tag originalTag) { View.bringTagBack(tag, originalTag); }

        public void InvokeSerachDone(List<Tuple<Product, string>> results) { View.InvokeSerachDone(results); }
    }
}
