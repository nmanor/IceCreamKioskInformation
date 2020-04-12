using System;
using System.Windows.Input;

namespace IceCreamKioskInformation
{
    /// <summary>
    /// Adds the tag to the search dictionary and passes the tag to the tags in the filter
    /// </summary>
    class AddFilterCMD : ICommand
    {
        private SearchUserControlVM VM;

        public AddFilterCMD(SearchUserControlVM VM)
        {
            this.VM = VM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Adds the tag to the search dictionary and passes the tag to the tags in the filter
        /// </summary>
        public void Execute(object parameter)
        {
            Tag tag = (Tag)parameter;

            // The tag is not currently in the dictionary
            if (tag.OriginalTag == null)
            {
                VM.addToDictionary(tag.Category, tag.Data);
                VM.moveTag(tag, tag.generateSon());
            }

            // The tag is currently in the dictionary
            else
            {
                VM.removeFromDictionary(tag.Category, tag.Data);
                VM.bringTagBack(tag, tag.OriginalTag);
            }
        }
    }
}
