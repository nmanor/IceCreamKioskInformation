using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.ShopsManagement
{
    class ShopsManagementUserControlVM: INotifyPropertyChanged
    {
        private List<Shop> _shops;
        public List<Shop> ShopsList
        {
            get { return _shops; }
            set
            {
                _shops = value;
                OnPropertyChanged("Shops");
            }
        }

        public ShopsManagementUserControlVM()
        {
            ShopsList = new ShopsManagementUserControlM().GetAllShops();
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
