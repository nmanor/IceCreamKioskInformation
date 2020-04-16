using System;
using System.ComponentModel;

namespace BE
{
    public class Address : INotifyPropertyChanged
    {
        private string _street;
        private int _buildingNumber;
        private string _city;

        public string AddressID { get; set; }
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }
        public int BuildingNumber
        {
            get { return _buildingNumber; }
            set
            {
                _buildingNumber = value;
                OnPropertyChanged("BuildingNumber");
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// Simple constractor
        /// </summary>
        /// <param name="_street"></param>
        /// <param name="_building_number"></param>
        /// <param name="_city"></param>
        public Address( string _street, int _building_number, string _city)
        {
            AddressID =  DateTime.Now.Ticks.ToString("X");
            Street = _street;
            BuildingNumber = _building_number;
            City = _city;
        }

        /// <summary>
        /// Empty constractor
        /// </summary>
        public Address()
        {
            AddressID = DateTime.Now.Ticks.ToString("X");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// To String function 
        /// </summary>
        /// <returns>Return the street, number and city in one string</returns>
        public override string ToString() { return Street + " " + BuildingNumber + ", " + City; }
    }
}
