using BE;
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

namespace IceCreamKioskInformation.ProductsManagement
{
    /// <summary>
    /// Interaction logic for ProductsManagementUserControl.xaml
    /// </summary>
    public partial class ProductsManagementUserControl : UserControl
    {
        public ProductsManagementUserControl()
        {
            InitializeComponent();
            DataContext = new ProductsManagementUserControlVM(this);
        }

        public ProductsManagementUserControl(List<Product> products)
        {
            InitializeComponent();
            DataContext = new ProductsManagementUserControlVM(this, products);
        }

        public event EventHandler GoBack;
        /// <summary>
        /// A function that triggers the event of a backward move
        /// </summary>
        public void OnGoBackClicked()
        {
            GoBackEventArgs args;
            string message = "האם אתה בטוח שאתה רוצה לחזור?\nאם לא השינויים האחרונים לא נשמרו הם יאבדו";
            args = new GoBackEventArgs() { IsWorkDone = false, Message = message };
            GoBack?.Invoke(this, args);
        }
    }
}
