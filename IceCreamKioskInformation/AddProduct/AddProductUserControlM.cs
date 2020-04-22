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
        public void SaveProduct(Product product)
        {
            string text = product.Name;
            text = new BLimp().TranslateHEtoEN(text);
            if(product.SugarFree)
                text += ", sugar free";
            if (product.Vegan)
                text += ", vegan";
            product.NutritionalValues = new BLimp().GetProductIdNutrition(text);
            
            new BLimp().add_Product(product);
        }
    }
}
