using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamKioskInformation.AddReview
{
    class AddReviewUserControlM
    {
        public BLimp BlImp { get; set; }

        public AddReviewUserControlM() { BlImp = new BLimp(); }

        public async Task<string> getImageFrom(string from, int index = 0) { return await BlImp.GetImageFrom(from, index); }

        public bool VerifyImageAsFood(string image) { return BlImp.VerifyImageAsFood(image); }

        public void AddAndSaveReview(Review review, Product product)
        {
            if (review.Rating < 1 || review.Rating > 5)
                throw new Exception("הדירוג חייב להיות מספר בין 0 ל5");

            double dateRange = DateTime.Now.Subtract(review.ReviwerBirthday).TotalDays;
            if (dateRange > 43800 || dateRange < 3650)
                throw new Exception("תאריך הלידה שלך לא נכון");

            if(!review.ReviewerName.Contains(" "))
                throw new Exception("נא לכתוב גם שם פרטי וגם שם משפחה");

            if(review.ReviewContent.Length < 10)
                throw new Exception("תוכן הביקורת חייב להיות באורך של לפחות 10 תווים");

            review.PublishDate = DateTime.Now;

            product.AddReview(review);
        }
    }
}
