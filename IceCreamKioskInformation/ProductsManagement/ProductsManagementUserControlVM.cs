using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace IceCreamKioskInformation.ProductsManagement
{
    class ProductsManagementUserControlVM : INotifyPropertyChanged
    {
        private List<Product> _productsList;
        public List<Product> ProductsList
        {
            get { return _productsList; }
            set
            {
                _productsList = value;
                OnPropertyChanged("ProductsList");
            }
        }

        private bool _fetchingFromDB;
        public bool FetchingFromDB
        {
            get { return _fetchingFromDB; }
            set
            {
                _fetchingFromDB = value;
                OnPropertyChanged("FetchingFromDB");
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        private Brush _messageColor;
        private Brush MessageColor
        {
            get { return _messageColor; }
            set
            {
                _messageColor = value;
                OnPropertyChanged("MessageColor");
            }
        }

        public ProductsManagementUserControl View;

        public ProductsManagementUserControlVM(ProductsManagementUserControl view, List<Product> products)
        {
            this.View = view;
            new Thread(() =>
            {
                FetchingFromDB = true;
                Initialize(products);
            }).Start();
        }

        public ProductsManagementUserControlVM(ProductsManagementUserControl view)
        {
            this.View = view;
            new Thread(() =>
            {
                FetchingFromDB = true;
                Initialize(new ProductsManagementUserControlM().GetProducts());
            }).Start();
        }

        private void Initialize(List<Product> products)
        {
            Message = "לעריכת מוצר לחץ פעמיים על המאפיין אותו תרצה לערוך";
            MessageColor = Brushes.Black;
            ProductsList = products;
            foreach (var item in ProductsList)
            {
                item.PropertyChanged += (x, y) => { SaveChanges(item); };
            }
            FetchingFromDB = false;
        }

        private void SaveChanges(Product product)
        {
            new Thread(() =>
            {
                Message = "שומר שינויים...";
                try
                {
                    new ProductsManagementUserControlM().SaveChanges(product);
                    Message = "השינויים נשמרו";
                    MessageColor = Brushes.Black;
                }
                catch (Exception ex)
                {
                    Message = ex.Message + ", השינויים שביצעת לא נשמרו";
                    MessageColor = Brushes.Red;
                }
            }).Start();
        }

        /// <summary>
        /// Action for triggering the backward event
        /// </summary>
        public ICommand GoBackCMD { get { return new GoBackCMD(this); } }

        public void OnGoBackClicked() { View.OnGoBackClicked(); }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
