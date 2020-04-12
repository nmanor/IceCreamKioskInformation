using BE;
using System;

namespace IceCreamKioskInformation.AddReview
{
    class AddReviewUserControlVM
    {
        public Product Product { get; set; }
        public Review Review { get; set; }
        private AddReviewUserControl View;

        public AddReviewUserControlVM(AddReviewUserControl addReviewUserControl, Product product)
        {
            this.View = addReviewUserControl;
            this.Product = new BE.FrozenYogurt() { Name = "פרוזן יוגורט עם חלב נאקות 23% שומן" };
            this.Review = new Review();
        }
    }
}
