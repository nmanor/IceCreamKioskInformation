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

namespace IceCreamKioskInformation
{
    /// <summary>
    /// Interaction logic for SearchUserControl.xaml
    /// </summary>
    public partial class SearchUserControl : UserControl
    {
        public SearchUserControl()
        {
            InitializeComponent();
            this.DataContext = new SearchUserControlVM(this);
        }

        public void moveTag(Tag tag, Tag newTag)
        {
            tag.Visibility = Visibility.Collapsed;
            Filters.Children.Add(newTag);
            this.DataContext = new SearchUserControlVM(this);
        }

        public void bringTagBack(Tag tag, Tag originalTag)
        {
            Filters.Children.Remove(tag);
            originalTag.Visibility = Visibility.Visible;
        }
    }
}
