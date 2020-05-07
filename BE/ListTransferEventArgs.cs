using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ListTransferEventArgs : EventArgs
    {
        public List<Product> Products { get; set; }
    }
}
