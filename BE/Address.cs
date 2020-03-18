using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    // Test...
    public struct Address
    {
        public string Street { get; set; }
        public int Building_number { get; set; }
        public string City { get; set; }

        /// <summary>
        /// Simple constractor
        /// </summary>
        /// <param name="_street"></param>
        /// <param name="_building_number"></param>
        /// <param name="_city"></param>
        public Address(string _street, int _building_number, string _city)
        {
            Street = _street;
            Building_number = _building_number;
            City = _city;
        }

        /// <summary>
        /// To String function 
        /// </summary>
        /// <returns>Return the street, number and city in one string</returns>
        public override string ToString() { return Street + " " + Building_number + ", " + City; }
    }
