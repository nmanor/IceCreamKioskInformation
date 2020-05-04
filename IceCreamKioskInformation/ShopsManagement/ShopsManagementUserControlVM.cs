using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace IceCreamKioskInformation.ShopsManagement
{
    class ShopsManagementUserControlVM : INotifyPropertyChanged
    {
        private List<Shop> _shopsList;
        public List<Shop> ShopsList
        {
            get { return _shopsList; }
            set
            {
                _shopsList = value;
                OnPropertyChanged("ShopsList");
            }
        }

        private bool _fetchingFromDB;
        public bool FetchingFromDB
        {
            get { return _fetchingFromDB; }
            set
            {
                _fetchingFromDB = value;
                OnPropertyChanged("FetchingFromDB");
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        private Brush _messageColor;
        private Brush MessageColor
        {
            get { return _messageColor; }
            set
            {
                _messageColor = value;
                OnPropertyChanged("MessageColor");
            }
        }

        public ShopsManagementUserControlVM()
        {
            Message = "לעריכה של חנות לחץ פעמיים על המאפיין אותו תרצה לערוך";
            MessageColor = Brushes.Black;
            new Thread(() =>
            {
                FetchingFromDB = true;
                ShopsList = new ShopsManagementUserControlM().GetAllShops();
                foreach (var item in ShopsList)
                {
                    item.PropertyChanged += (x, y) => { SaveChanges(item); };
                    item.Address.PropertyChanged += (x, y) => { SaveChanges(item); };
                }
                FetchingFromDB = false;
            }).Start();
        }

        private void SaveChanges(Shop shop)
        {
            new Thread(() =>
            {
                Message = "שומר שינויים...";
                try
                {
                    new ShopsManagementUserControlM().SaveChanges(shop);
                    Message = "השינויים נשמרו";
                    MessageColor = Brushes.Black;
                }
                catch (Exception ex)
                {
                    Message = ex.Message + ", השינויים שבצעת לא נשמרו";
                    MessageColor = Brushes.Red;
                }
            }).Start();
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
