using BE;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace IceCreamKioskInformation.ProductDisplay
{
    class ProductDisplayUserControlVM : INotifyPropertyChanged
    {
        private ProductDisplayUserControl View;
        public Product _product;
        public Product Product
        {
            get { return _product; }
            set 
            {
                Product p = value;

                _product = p; 

                DataRearrangement();
                OnPropertyChanged("Product");
                OnPropertyChanged("ProductParms");
            }
        }
        public string ProductParms { get { return Product?.GetParms(); } }
        private Review _currentReview;
        public Review CurrentReview 
        {
            get { return _currentReview; }
            set
            {
                _currentReview = value;
                OnPropertyChanged("CurrentReview");
            }
        }
        public ChartValues<ObservableValue> RatingPercentage { get; set; }
        public float RatingAverage { get; set; }
        public SeriesCollection PopularityValues { get; set; }
        public string[] PopularityMonthLabels { get; set; }
        public bool NothingToShow { get; set; }

        /// <summary>
        /// Open URL link
        /// </summary>
        public ICommand OpenURLCMD { get { return new OpenURLCMD(); } }

        /// <summary>
        /// Move to the next / the previous
        /// </summary>
        public ICommand SwitchReviewCMD { get { return new SwitchReviewCMD(this); } }

        /// <summary>
        /// Move to the next / the previous
        /// </summary>
        public ICommand AddReviewCMD { get { return new AddReviewCMD(this); } }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public ProductDisplayUserControlVM(Product p, ProductDisplayUserControl view)
        {
            /*product.AddReview(new Review()
            {
                Rating = 5,
                PublishDate = new DateTime(2020, 2, 3),
                ReviewContent = "טעים ממש, שווה כל שקל",
                ReviwerBirthday = new DateTime(1995, 5, 3),
                ReviewerName = "דני בוזגלו",
                Image = null
            });

            product.Shop.Instagram = "www.www.sdbdgsnh";
            product.Shop.Facebook = "www.www.sdbdgsnh";*/



            this.Product = p;
            this.View = view;

            View.IsVisibleChanged += (sender, args) => { DataRearrangement(); };
        }

        /// <summary>
        /// Recalculate all data and enter it into the appropriate properties
        /// </summary>
        private void DataRearrangement()
        {
            if (Product != null)
            {
                NothingToShow = false;
                ProductDisplayUserControlM model = new ProductDisplayUserControlM();
                RatingPercentage = model.GetRatingPercentage(Product);
                RatingAverage = model.GetAverageRating(Product);

                object[] popularity = model.GetPopularityValues(Product);
                PopularityMonthLabels = popularity[0] as string[];
                PopularityValues = popularity[1] as SeriesCollection;

                CurrentReview = Product.Reviews[0];
            }
            else
            {
                NothingToShow = true;
            }
        }

        public void InvokeAddReview() { View.InvokeAddReview(Product); }
    }
}
