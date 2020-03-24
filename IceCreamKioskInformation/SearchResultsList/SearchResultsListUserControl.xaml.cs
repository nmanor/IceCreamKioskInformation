using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;

namespace IceCreamKioskInformation.SearchResultsList
{
    /// <summary>
    /// Interaction logic for SearchResultsListUserControl.xaml
    /// </summary>
    public partial class SearchResultsListUserControl : UserControl
    {
        public SearchResultsListUserControl()
        {
            InitializeComponent();

            // Test only ///////////////////////////////////////////////
            List<string> photos = new List<string>
            {
                "https://images.unsplash.com/photo-1567206563064-6f60f40a2b57?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=967&q=80",
                "https://images.unsplash.com/photo-1505394033641-40c6ad1178d7?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=806&q=80",
                "https://images.unsplash.com/photo-1560008581-09826d1de69e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=682&q=80",
                "https://images.unsplash.com/photo-1556682851-c4580670113a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=706&q=80",
                "https://images.unsplash.com/photo-1576506295286-5cda18df43e7?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=675&q=80"
            };
            List<Product> products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                FrozenYogurt frozenYogurt = new FrozenYogurt();
                frozenYogurt.Name = "מוצר מספר " + i;
                frozenYogurt.Price = i * 10;
                frozenYogurt.Description = "תיאור קצר למוצר מספר " + i + " כי הוא מוצר קצר מידי";

                Review review = new Review("me", new DateTime(1999, 2, 13), "טעים רצח", 5, photos[i%5], new DateTime(2020, 5, 3));
                List<Review> reviews = new List<Review> { review, review };
                frozenYogurt.Review_list = reviews;

                products.Add(frozenYogurt);
            }
            this.DataContext = products;
            ////////////////////////////////////////////////////////////
        }
    }
}
