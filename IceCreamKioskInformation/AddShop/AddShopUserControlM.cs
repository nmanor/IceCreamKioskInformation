using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace IceCreamKioskInformation.AddShop
{
    class AddShopUserControlM
    {
        public BLimp BlImp { get; set; }

        public AddShopUserControlM()
        {
            BlImp = new BLimp();
        }

        public async Task<string> getImageFrom(string from, int index = 0)
        {
            return await BlImp.getImageFrom(from, index);
        }

        public bool VerifyImageAsStore(string image)
        {
            return BlImp.VerifyImageAsStore(image);
        }
    }
}
