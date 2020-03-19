using System;
namespace BE
{
    public class Review
    {
        private string _reviewerName;
        private DateTime _reviwerBirthday;
        private string _review;
        private int _rating;
        private string _imageURL;
        private DateTime _publishDate;

        public Review(string reviewerName, DateTime reviwerBirthday, string review, int rating, string imageURL, DateTime publishDate)
        {
            _reviewerName = reviewerName;
            _reviwerBirthday = reviwerBirthday;
            _review = review;
            _rating = rating;
            _imageURL = imageURL;
            _publishDate = publishDate;
        }

        public bool Search(string str)
        { return true; }
        public bool Search(DateTime date)
        { return true; }

    }
}
