using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocoding.MapQuest;
using Geocoding;
using System.Net;
using System.IO;
using System.Xml;
using System.Drawing;

namespace DAL
{
    public class GetLocationMap
    {

        public Bitmap DownloadMap(BE.Address address)
        {
            string key = "03jhg7NXBfhDqBHCdDPhM5ywhBiMtn5m";
            //IGeocoder geocoder = new MapQuestGeocoder(key);
            //IEnumerable<Geocoding.Address> addresses = await geocoder.GeocodeAsync(address.ToString());
            //string latlng = addresses.First().Coordinates.Latitude + "," + addresses.First().Coordinates.Longitude;
            


            // location url 
            string url = @"https://www.mapquestapi.com/staticmap/v5/map" +
             @"?key=" + key +
             @"&locations=" + address.ToString() +
             @"&size=500,500@2x";

            //daonload static map as Image to filname loction
            string fileName = Directory.GetCurrentDirectory() + @"\images\img.jpeg";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(url, fileName);
            }

            //open and convert image to bitmap
            Bitmap bitmap;
            using (Stream bmpStream = File.Open(fileName, FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            //return image as bitmap
            return bitmap;
            


        }
    }
}
