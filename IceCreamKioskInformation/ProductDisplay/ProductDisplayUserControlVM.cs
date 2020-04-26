using BE;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace IceCreamKioskInformation.ProductDisplay
{
    class ProductDisplayUserControlVM
    {
        public Product _product;
        public Product Product
        {
            get { return _product; }
            set { _product = value; DataRearrangement(); }
        }
        public ChartValues<ObservableValue> RatingPercentage { get; set; }
        public float RatingAverage { get; set; }

        public SeriesCollection PopularityValues { get; set; }
        public string[] PopularityMonthLabels { get; set; }

        /// <summary>
        /// Open URL link
        /// </summary>
        public ICommand OpenURLCMD { get { return new OpenURLCMD(); } }

        public ProductDisplayUserControlVM(Product product)
        {
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2020, 2, 3) });
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2020, 1, 3) });
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2020, 1, 9) });
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2020, 3, 3) });
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2020, 8, 3) });
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2019, 5, 3) });
            product.AddReview(new Review() { Rating = 4, PublishDate = new DateTime(2019, 12, 3) });
            product.AddReview(new Review() { Rating = 4, PublishDate = new DateTime(2019, 6, 3) });
            product.AddReview(new Review() { Rating = 1, PublishDate = new DateTime(2019, 1, 3) });
            product.AddReview(new Review() { Rating = 3, PublishDate = new DateTime(2020, 1, 7) });
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2020, 4, 7) });
            product.AddReview(new Review() { Rating = 3, PublishDate = new DateTime(2020, 4, 7) });
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2019, 10, 7) });
            product.AddReview(new Review() { Rating = 2, PublishDate = new DateTime(2019, 12, 7) });
            product.AddReview(new Review() { Rating = 5, PublishDate = new DateTime(2019, 11, 7) });
            product.AddReview(new Review() { Rating = 3, PublishDate = new DateTime(2020, 4, 7) });
            product.AddReview(new Review() { Rating = 3, PublishDate = new DateTime(2020, 4, 7) });

            product.Shop.Instagram = "www.www.sdbdgsnh";
            product.Shop.Facebook = "www.www.sdbdgsnh";

            this.Product = product;
        }

        public void DataRearrangement()
        {
            ProductDisplayUserControlM model = new ProductDisplayUserControlM();
            RatingPercentage = model.GetRatingPercentage(Product);
            RatingAverage = model.GetAverageRating(Product);

            object[] popularity = model.GetPopularityValues(Product);
            PopularityMonthLabels = popularity[0] as string[];
            PopularityValues = popularity[1] as SeriesCollection;
        }
    }
}
