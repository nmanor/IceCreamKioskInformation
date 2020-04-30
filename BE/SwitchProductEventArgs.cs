using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SwitchProductEventArgs : EventArgs
    {
        public Product Product { get; set; } 
    }
}
