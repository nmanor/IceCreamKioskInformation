using BE;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.MapDisplay
{
    class MapDisplayUserControlVM : INotifyPropertyChanged
    {
        private Location _location;
        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                View.LoadLocationIntoMap(_location);
                OnPropertyChanged("Location");
            }
        }

        private MapDisplayUserControl View;

        public MapDisplayUserControlVM(Address address, MapDisplayUserControl view)
        {
            this.View = view;
            ReloadLoaction(address);
        }

        private void ReloadLoaction(Address address)
        {
            double[] LatLong = new MapDisplayUserControlM().GetLatLongFromAddress(address);
            Location = new Location(LatLong[0], LatLong[1]);
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
