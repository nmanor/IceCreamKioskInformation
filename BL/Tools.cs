using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class Tools
    {
        public void tryrepos()
        {
            Reposetory reposetory = new Reposetory();
            new GetLocationMap().DownloadMap(new BE.Address("123", "יפו", 12, "ירושלים"));
        }
    }
}
