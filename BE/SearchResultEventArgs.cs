﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SearchResultEventArgs : EventArgs
    {
        public List<Product> SearchResult { get; set; }
    }
}
