using System;

namespace BE
{
    public class AddReviewEvantArgs : EventArgs
    {
        public Product Product { get; set; }
    }
}
