using System.Windows.Controls;
using BE;

namespace IceCreamKioskInformation.AddReview
{
    /// <summary>
    /// Interaction logic for AddReviewUserControl.xaml
    /// </summary>
    public partial class AddReviewUserControl : UserControl
    {
        public AddReviewUserControl()
        {
            InitializeComponent();
            DataContext = new AddReviewUserControlVM(this, new BE.IceCream());
        }
    }
}
