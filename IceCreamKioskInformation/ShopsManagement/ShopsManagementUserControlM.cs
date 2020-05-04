﻿using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.ShopsManagement
{
    class ShopsManagementUserControlM
    {
        public List<Shop> GetAllShops()
        {
            return new BLimp().Get_all_Shops();
        }

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

        public void SaveChanges(Shop shop)
        {
            if (shop.Address.BuildingNumber == 0)
                throw new Exception("מספר הבית לא יכול להיות 0");

            if (shop.ShopName.Length < 4)
                throw new Exception("שם החנות חייב להכיל לפחות 3 תווים");

            if (!VerifyStringAs("phone", shop.Phone))
                throw new Exception("מספר טלפון לא תקין");

            if (!VerifyStringAs("website", shop.Website))
                throw new Exception("כתובת אתר לא תקינה");

            if (!VerifyStringAs("facebook", shop.Facebook))
                throw new Exception("כתובת פייסבוק לא תקינה");

            if (!VerifyStringAs("instagram", shop.Instagram))
                throw new Exception("כתובת אינסטגרם לא תקינה");

            if (!new BLimp().VerifyAddress(shop.Address))
                throw new Exception("הכתובת שהזנת לא קיימת");

            try { new BLimp().update_Shop(shop); }
            catch (Exception) { throw new Exception("לא ניתן לשמור כעת את השינויים"); }
        }
    }
}
