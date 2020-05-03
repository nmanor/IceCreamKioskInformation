using BE;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

        private MapDisplayUserControl View;

        public MapDisplayUserControlVM(Address address, MapDisplayUserControl view)
        {
            this.View = view;
            ReloadLoaction(address);
        }

        private void ReloadLoaction(Address address)
        {
            if (address != null)
            {
                double[] LatLong = new double[2];
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (x, y) =>
                {
                    Working = true;
                    LatLong = new MapDisplayUserControlM().GetLatLongFromAddress(address);
                };
                worker.RunWorkerCompleted += (x, y) =>
                {
                    Working = false;
                    Location = new Location(LatLong[0], LatLong[1]);
                };
                worker.RunWorkerAsync();
            }
            else
            {
                Working = false;
                Location = new Location(-81.3953168, 76.9135565);
            }
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
