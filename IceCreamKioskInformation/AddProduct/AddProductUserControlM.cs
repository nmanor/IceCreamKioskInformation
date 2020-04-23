using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BL;

namespace IceCreamKioskInformation.AddProduct
{
    public class AddProductUserControlM
    {
        public void SaveProduct(Product product, Shop shop)
        { 
            string parms = new BLimp().TranslateHEtoEN(product.GetParms());
            product.NutritionalValues = new BLimp().GetProductIdNutrition(parms);

            shop.AddProduct(product);
            new BLimp().add_Product(product);
        }
    }
}
