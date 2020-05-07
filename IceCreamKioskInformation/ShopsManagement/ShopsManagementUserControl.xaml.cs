using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IceCreamKioskInformation.ShopsManagement
{
    /// <summary>
    /// Interaction logic for ShopsManagementUserControl.xaml
    /// </summary>
    public partial class ShopsManagementUserControl : UserControl
    {
        public ShopsManagementUserControl()
        {
            InitializeComponent();
            this.DataContext = new ShopsManagementUserControlVM(this);
        }

        public event EventHandler GoBack;
        public void OnGoBackClicked()
        {
            GoBackEventArgs args;
            string message = "האם אתה בטוח שאתה רוצה לחזור?\nאם לא השינויים האחרונים לא נשמרו הם יאבדו";
            args = new GoBackEventArgs() { IsWorkDone = false, Message = message };
            GoBack?.Invoke(this, args);
        }

        public event EventHandler LoadProducts;
        public void LoadProductsManagement(List<Product> products)
        {
            ListTransferEventArgs args = new ListTransferEventArgs() { Products = products };
            LoadProducts?.Invoke(this, args);
        }
    }
}
