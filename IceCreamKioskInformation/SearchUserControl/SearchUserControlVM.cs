using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IceCreamKioskInformation
{
    public class SearchUserControlVM
    {
        public SearchUserControlVM(SearchUserControl searchUserControl)
        {
            this.SearchUserControl = searchUserControl;
            Dictionary = new Dictionary<string, List<object>>();
        }

        /// <summary>
        /// Action of clicking one of the tags
        /// </summary>
        private ICommand addFilter;
        public ICommand AddFilter
        {
            get
            {
                if (addFilter == null)
                    addFilter = new AddFilterCMD(this);
                return addFilter;
            }
            set
            {
                addFilter = value;
            }
        }

        public SearchUserControl SearchUserControl { get; set; }

        private Dictionary<string, List<object>> Dictionary;
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

        public void moveTag(Tag tag, Tag newTag)
        {
            SearchUserControl.moveTag(tag, newTag);
        }

        public void bringTagBack(Tag tag, Tag originalTag)
        {
            SearchUserControl.bringTagBack(tag, originalTag);
        }
    }
}
