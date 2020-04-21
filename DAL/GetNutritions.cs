using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DAL
{
    public class GetNutritions
    {



        public string GetProductID(string foodParms)
        {
            string KEY = "qdTGw0ZhCUPf9lGWLnF7TLxZIia5qe3hKCPSxpbC";

            var client = new RestClient("https://api.nal.usda.gov/fdc/v1/foods/search?api_key=" + KEY + "&pageSize=1&pageNumber=1&query=" + foodParms);
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            object deserializeContent = JsonConvert.DeserializeObject<object>(response.Content);
            JObject contentAsJSON = JObject.Parse(deserializeContent.ToString());

            return contentAsJSON["foods"][0]["fdcId"].ToString();
        }


        public Dictionary<string,double> GetProductNutritions(string id)
        {
            string KEY = "qdTGw0ZhCUPf9lGWLnF7TLxZIia5qe3hKCPSxpbC";

            var client = new RestClient("https://api.nal.usda.gov/fdc/v1/food/"+id+"?api_key=" + KEY);
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            object deserializeContent = JsonConvert.DeserializeObject<object>(response.Content);
            JObject contentAsJSON = JObject.Parse(deserializeContent.ToString());

            Dictionary<string, double> nutritions = new Dictionary<string, double>();
            foreach (var item in contentAsJSON["foodNutrients"].ToList())
            {
                string name = item["nutrient"]["name"].ToString();
                double amount = item["amount"].ToObject<double>();
                nutritions.Add(name, amount);
            }

                //return contentAsJSON["foods"][0]["fdcId"].ToString();
             return nutritions;
        }




    }
}
