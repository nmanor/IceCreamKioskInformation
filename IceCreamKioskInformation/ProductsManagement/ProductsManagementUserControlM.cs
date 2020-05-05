using BE;
using BL;
using System;
using System.Collections.Generic;

namespace IceCreamKioskInformation.ProductsManagement
{
    class ProductsManagementUserControlM
    {
        public List<Product> GetProducts()
        {
            return new BLimp().Get_all_Products();
        }

        internal void SaveChanges(Product product)
        {
            try
            {
                product.ClearPropertyChanged();
                BLimp bl = new BLimp();
                string parms = bl.TranslateHEtoEN(product.GetParms());
                product.NutritionalValues = bl.GetProductIdNutrition(parms);
                product.NutritinosValuesDictonary = bl.GetProductNutritionByID(product.NutritionalValues);
                bl.update_Product(product);
                product.RestorePropertyChanged();
            }
            catch(Exception)
            { 
                throw new Exception("לא ניתן לבצע שינויים כרגע"); 
            }
        }
    }
}
