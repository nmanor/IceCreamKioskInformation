﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace DAL
{
    public class ImageVerification
    {
        /// <summary>
        /// A function that checks whether an image is an ice cream shop image or not
        /// </summary>
        /// <param name="image">Picture of a store in Base64 coding</param>
        public bool IsShop(string image)
        {
            // Check if the image matches one of the tags
            List<string> possibleTags = new List<string> { "home", "table", "room", "food", "shop", "confectionery", "interior", "cake", "meal", "chair", "ice cream", "dessert", "house", "chairs", "building", "bakery", "dining", "cafeteria", "restaurant" };
            foreach (string tag in GetVisualAnalysis(image))
                if (possibleTags.Contains(tag))
                    return true;

            return false;
        }

        /// <summary>
        /// A function that checks whether an image is an food image or not
        /// </summary>
        /// <param name="image">Picture of a food in Base64 coding</param>
        public bool IsFood(string image)
        {
            // Check if the image matches one of the tags
            List<string> possibleTags = new List<string> { "dinner", "glass", "healthy", "juice", "cheese", "sweet", "lunch", "cocktail", "plate", "milk", "pastry", "bakery", "frozen dessert", "edible fruit", "gourmet", "ice", "ice cream", "refreshment", "dessert", "meal", "snack", "drink", "confectionery", "beverage", "food", "cream", "dairy product", "yogurt", "cake", "fruit", "breakfast", "cold" };
            foreach (string tag in GetVisualAnalysis(image))
                if (possibleTags.Contains(tag))
                    return true;

            return false;
        }

        /// <summary>
        /// A function that receives an image and returns the tags obtained by image analysis
        /// </summary>
        /// <param name="image">Picture of a store in Base64 coding</param>
        private List<string> GetVisualAnalysis(string image)
        {
            string apiKey = "acc_09a82d2eff8b994";
            string apiSecret = "c770b02d878d852231623d9cc0c82199";

            string basicAuthValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            //Save Base64 Encoded string as Image File
            byte[] imageBytes = Convert.FromBase64String(image);
            string filePath = @"TempImg.jpg";
            MemoryStream stream = new MemoryStream(imageBytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(filePath, ImageFormat.Jpeg);

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", filePath);

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // disassemble the tags in the JSON file into "tags"
            object deserializeContent = JsonConvert.DeserializeObject<object>(response.Content);
            JObject contentAsJSON = JObject.Parse(deserializeContent.ToString());
            List<string> tags = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                tags.Add(contentAsJSON["result"]["tags"][i]["tag"]["en"].ToString());
            }

            return tags;
        }
    }
}
