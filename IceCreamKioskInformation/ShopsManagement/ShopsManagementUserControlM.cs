using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.ShopsManagement
{
    class ShopsManagementUserControlM
    {
        public List<BE.Shop> GetAllShops()
        {
            return new BLimp().Get_all_Shops();
        }
    }
}
