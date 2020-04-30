using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using BE;

namespace IceCreamKioskInformation.AddProduct
{
    public class AddProductUserControlVM : INotifyPropertyChanged
    {
        private AddProductUserControl View;
        private Shop _selectedShop;
        public Shop SelectedShop
        {
            get { return _selectedShop; }
            set
            {
                _selectedShop = value;
                OnPropertyChanged("SelectedShop");
            }
        }
        private List<Shop> _allShopes;
        public List<Shop> AllShopes
        {
            get { return _allShopes; }
            set
            {
                _allShopes = value;
                OnPropertyChanged("AllShopes");
            }
        }
        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set
            {
                _textSearch = value;
                CollectionViewSource.GetDefaultView(AllShopes).Refresh();
                OnPropertyChanged("TextSearch");
            }
        }
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                _selectedProduct.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
                {
                    OnPropertyChanged("SelectedProduct");
                };
                OnPropertyChanged("SelectedProduct");
            }
        }
        public Dictionary<string, Product> ProductsOptions { get; set; }

        public Review Review { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public AddProductUserControlVM(AddProductUserControl addProductUserControl)
        {
            this.View = addProductUserControl;

            AllShopes = new BL.BLimp().Get_all_Shops();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AllShopes);
            view.Filter = UserFilter;

            // When you add a new product, it should be added here as well
            ProductsOptions = new Dictionary<string, Product>
            {
                ["גלידה"] = new BE.IceCream(),
                ["פרוזן יוגורט"] = new FrozenYogurt(),
                ["קרפ צרפתי"] = new FrenchCrape(),
                ["שייק"] = new Smoothie(),
                ["וופל בלגי"] = new Waffle()
            };
        }

        /// <summary>
        /// Add review to SelectedProduct
        /// </summary>
        public ICommand AddReviewCMD { get { return new AddReviewCMD(this); } }

        /// <summary>
        /// Save the product to the DB
        /// </summary>
        public ICommand SaveProductCMD { get { return new SaveProductCMD(this); } }

        /// <summary>
        /// Action for triggering the backward event
        /// </summary>
        public ICommand GoBackCMD { get { return new GoBackCMD(this); } }

        /// <summary>
        /// Function for searching a store within the list
        /// </summary>
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(TextSearch))
                return true;
            else
                return ((item as Shop).ShopName.IndexOf(TextSearch, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as Shop).Address.ToString().IndexOf(TextSearch, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void AddReview() { View.AddReview(SelectedProduct); }

        public void CheckingProductData() { View.CheckingProductData(); }
        internal void ProductSaved() { View.ProductSaved(); }
        internal void ProductNotSaved(string error) { View.ProductNotSaved(error); }

        public void OnGoBackClicked() { View.OnGoBackClicked(); }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
