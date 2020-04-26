using BE;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.ProductDisplay
{
    class ProductDisplayUserControlM
    {
        /// <summary>
        /// Check if the URL starts correctly and return the absolute value of an address
        /// </summary>
        /// <param name="url">The URL that is being checked</param>
        public string ConvertToFullURL(object url)
        {
            string URL = url as string;
            if (!URL.StartsWith("http://") || !URL.StartsWith("https://"))
                URL = "https://" + URL;
            return new Uri(URL).AbsoluteUri;
        }

        /// <summary>
        /// Calculate the percentages of all ratings
        /// </summary>
        /// <param name="product">The product to do the calculation for</param>
        public ChartValues<ObservableValue> GetRatingPercentage(Product product)
        {
            int[] counter = { 0, 0, 0, 0, 0 };
            foreach (Review review in product.Reviews)
                counter[review.Rating - 1]++;

            return new ChartValues<ObservableValue>
                    {
                        new ObservableValue(0),
                        new ObservableValue(counter[0]),
                        new ObservableValue(counter[1]),
                        new ObservableValue(counter[2]),
                        new ObservableValue(counter[3]),
                        new ObservableValue(counter[4]),
                    };
        }

        /// <summary>
        /// Calculate the average of all ratings
        /// </summary>
        /// <param name="product">The product to do the calculation for</param>
        public float GetAverageRating(Product product)
        {
            int sum = 0;
            foreach (Review review in product.Reviews)
                sum += review.Rating;
            return (float)sum / product.Reviews.Count;
        }

        public object[] GetPopularityValues(Product product)
        {
            Dictionary<string, List<int>> pastYear = new Dictionary<string, List<int>>();
            int i;

            // Filling the dictionary in pairs of (month, empty list) for each month in the past year
            DateTime currentMonth = DateTime.Now;
            for (i = 0; i < 15; i++)
            {
                pastYear.Add(currentMonth.ToString("MMMM yy"), new List<int>());
                currentMonth = currentMonth.AddMonths(-1);
            }

            // For each month of the past year, add all the month's ratings to the dictionary
            foreach (Review review in product.Reviews)
            {
                if (DateTime.Now.AddMonths(-15) <= review.PublishDate && review.PublishDate <= DateTime.Now)
                    pastYear[review.PublishDate.ToString("MMMM yy")].Add(review.Rating);
            }

            // Calculate the average ratings for each month and add them to the returned list
            var averages = new double[15];
            i = 0;
            foreach (List<int> month in pastYear.Values)
            {
                double sum = 0;
                foreach (int rate in month) sum += rate;
                if (double.IsNaN(sum / month.Count))
                    averages[i] = 0;
                else
                    averages[i] = sum / month.Count;
                i++;
            }

            // Calculate the rolling average of each month
            var rollingAverages = new ChartValues<double>();
            for (i = 3; i < averages.Length; i++)
            {
                double rollingAverage = (averages[i] + averages[i - 1] + averages[i - 2] + averages[i - 3]) / 4;
                rollingAverages.Add(rollingAverage);
            }

            // Return the month list and the list of values for each month
            return new object[] { pastYear.Keys.Take(12).ToArray(), new SeriesCollection { new LineSeries { Values = rollingAverages } } };
        }
    }
}
