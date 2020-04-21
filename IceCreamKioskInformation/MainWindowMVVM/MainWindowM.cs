using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.MainWindowMVVM
{
    public class MainWindowM
    {
        public bool AdminPasswordVerification(string password)
        {
            return password == "סיסמה";
        }
    }
}
