using DAL;

namespace BL
{
    public class Tools
    {
        public void tryrepos()
        {
            _ = new GetNutritions().GetProductNutritions(new GetNutritions().GetProductID("waffle"));
            Reposetory reposetory = new Reposetory();
            
        }
    }
}
