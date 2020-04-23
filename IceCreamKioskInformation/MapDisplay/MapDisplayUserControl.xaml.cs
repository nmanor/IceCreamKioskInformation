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

            String HTMLText = @"<html>
                                    <head>
                                        <script src=""https://api.mqcdn.com/sdk/mapquest-js/v1.3.2/mapquest.js""></script>
                                        <link type=""text/css"" rel=""stylesheet"" href=""https://api.mqcdn.com/sdk/mapquest-js/v1.3.2/mapquest.css""/>

                                        <script type=""text/javascript"">
                                            window.onload = function() {
                                                L.mapquest.key = '03jhg7NXBfhDqBHCdDPhM5ywhBiMtn5m';

                                                var map = L.mapquest.map('map', {
                                                center: [37.7749, -122.4194],
                                                layers: L.mapquest.tileLayer('map'),
                                                zoom: 12
                                            });

                                                map.addControl(L.mapquest.control());
                                            }
                                        </script>
                                    </head>

                                    <body style=""border: 0; margin: 0;"">sdfsdfds
                                         <div id=""map"" style=""width: 100%; height: 530px;""></div>
                                    </body>
                                </html>";
            // Web.NavigateToStream(new System.IO.MemoryStream(Encoding.ASCII.GetBytes(HTMLText)));
        }
    }
}
