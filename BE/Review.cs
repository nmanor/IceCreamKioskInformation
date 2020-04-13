using System;
using System.ComponentModel;

namespace BE
{
    public class Review: INotifyPropertyChanged
    {
        private string _reviewID;
        private string _reviewerName;
        private DateTime _reviwerBirthday;
        private string _reviwerEmail;
        private string _reviewContent;
        private int _rating;
        private string _image;
        private DateTime _publishDate;

        public string ReviewID
        {
            get { return _reviewID; }
            set
            {
                _reviewID = value;
                OnPropertyChanged("ReviewID");
            }
        }
        public string ReviewerName
        {
            get { return _reviewerName; }
            set
            {
                _reviewerName = value;
                OnPropertyChanged("ReviewerName");
            }
        }
        public DateTime ReviwerBirthday
        {
            get { return _reviwerBirthday; }
            set
            {
                _reviwerBirthday = value;
                OnPropertyChanged("ReviwerBirthday");
            }
        }
        public string ReviwerEmail
        {
            get { return _reviwerEmail; }
            set
            {
                _reviwerEmail = value;
                OnPropertyChanged("ReviwerEmail");
            }
        }
        public string ReviewContent
        {
            get { return _reviewContent; }
            set
            {
                _reviewContent = value;
                OnPropertyChanged("ReviewContent");
            }
        }
        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged("Rating");
            }
        }
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set
            {
                _publishDate = value;
                OnPropertyChanged("PublishDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Review()
        {
            ReviewID = DateTime.Now.Ticks.ToString("X");
        }

        public bool Search(string str)
        { return true; }
        public bool Search(DateTime date)
        { return true; }

    }
}
