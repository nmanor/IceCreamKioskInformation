using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BL;

namespace IceCreamKioskInformation.AddShop
{
    class AddShopUserControlM
    {
        public BLimp BlImp { get; set; }

        public AddShopUserControlM() { BlImp = new BLimp(); }

        public async Task<string> getImageFrom(string from, int index = 0) { return await BlImp.getImageFrom(from, index); }

        public bool VerifyImageAsStore(string image) { return BlImp.VerifyImageAsStore(image); }

        /// <summary>
        /// Returns whether the string matches the type of site / phone needed
        /// </summary>
        /// <param name="type">The type it should fit: facebook, instagram, generalWebsite or phone</param>
        /// <param name="uri">The string on it should perform the test</param>
        public bool VerifyStringAs(string type, string uri)
        {
            if (type == null || uri == null || uri == "")
                return true;

            Dictionary<string, Regex> websites = new Dictionary<string, Regex>()
            {
                ["facebook"] = new Regex(@"^(https://)?(www|m)\.facebook\.com/(.+)$"),
                ["instagram"] = new Regex(@"^(https://)?(www|m)\.instagram\.com/(.+)$"),
                ["website"] = new Regex(@"^(http(s?)://)?((www|m)\.)?[0-9a-zA-Z]([0-9a-zA-Z])+(\.[0-9a-zA-Z][0-9a-zA-Z]+)+(/.+)*$"),
                ["phone"] = new Regex(@"^(\+972|972|0)(5\d|\d)\d{7}$")
            };
            return websites[type].IsMatch(uri);
        }
    }
}
