using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace IceCreamKioskInformation.MapDisplay
{
    /// <summary>
    /// Interaction logic for MapDisplayUserControl.xaml
    /// </summary>
    public partial class MapDisplayUserControl : UserControl
    {
        public MapDisplayUserControl()
        {
            InitializeComponent();
            this.DataContext = new MapDisplayUserControlVM(new BE.Address("הועד הלאומי", 21, "ירושלים"), this);
        }

        public void LoadLocationIntoMap(Location location) { Map.Center = location; }
    }
}
