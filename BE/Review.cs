using System;
namespace BE
{
    public class Review
    {
        public string ReviewID { get; set; }
        public string ReviewerName { get; set; }
        private DateTime _reviwerBirthday;
        private string _review;
        private int _rating;
        public string ImageURL { get; set; }
        private DateTime _publishDate;

        public Review(string reviewerName, DateTime reviwerBirthday, string review, int rating, string imageURL, DateTime publishDate, string reviewID = null)
        {
            ReviewID = reviewID;
            ReviewerName = reviewerName;
            _reviwerBirthday = reviwerBirthday;
            _review = review;
            _rating = rating;
            ImageURL = imageURL;
            _publishDate = publishDate;
        }

        public bool Search(string str)
        { return true; }
        public bool Search(DateTime date)
        { return true; }

    }
}
