using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class FrozenYogurt : Product
    {
        private double _fat;
        private MILKTYPE _milkType;


        public override bool Search(Dictionary<string, List<object>> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
