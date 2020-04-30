using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.MapDisplay
{
    class MapDisplayUserControlM
    {
        public double[] GetLatLongFromAddress(Address adderss)
        {
            try { return new BLimp().GetLatLongFromAddress(adderss); }
            catch (Exception) { return new double[] { 31.7648563, 35.192225 }; }
        }
    }
}
