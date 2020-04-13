using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GoBackEventArgs : EventArgs
    {
        public bool IsWorkDone { get; set; }
        public string Message { get; set; }
    }
}
