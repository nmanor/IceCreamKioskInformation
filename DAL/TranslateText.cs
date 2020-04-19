using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TranslateText
    {
        /// <summary>
        /// A function that receives text in Hebrew and translates it into English
        /// </summary>
        /// <param name="text">The Hebrew content should be translated</param>
        /// <returns>String, translation of the content into English</returns>
        public string TranslateHEtoEN(string text)
        {
            string KEY = @"trnsl.1.1.20200416T150219Z.3a977f0f750cc41c.441c46a02e4cf8c51cf237b60565e23d31b7c678";

            var client = new RestClient("https://translate.yandex.net/api/v1.5/tr.json/translate");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddParameter("key", KEY);
            request.AddParameter("lang", "he-en");
            request.AddParameter("text", text);

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            object deserializeContent = JsonConvert.DeserializeObject<object>(response.Content);
            JObject contentAsJSON = JObject.Parse(deserializeContent.ToString());
            return contentAsJSON["text"][0].ToString();
        }
    }
}
