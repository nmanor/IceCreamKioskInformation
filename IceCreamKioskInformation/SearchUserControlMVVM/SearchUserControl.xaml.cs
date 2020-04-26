using BE;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace IceCreamKioskInformation
{
    /// <summary>
    /// Interaction logic for SearchUserControl.xaml
    /// </summary>
    public partial class SearchUserControl : UserControl
    {
        public event EventHandler SerachDone;

        public SearchUserControl()
        {
            InitializeComponent();
            this.DataContext = new SearchUserControlVM(this);
        }

        public void moveTag(Tag tag, Tag newTag)
        {
            tag.Visibility = Visibility.Collapsed;
            Filters.Children.Add(newTag);
            TagsDescription.Visibility = Visibility.Collapsed;
        }

        public void bringTagBack(Tag tag, Tag originalTag)
        {
            Filters.Children.Remove(tag);
            originalTag.Visibility = Visibility.Visible;
            if (Filters.Children.Count == 1)
                TagsDescription.Visibility = Visibility.Visible;
        }

        public void InvokeSerachDone(List<Product> results)
        {
            SerachDone?.Invoke(this, new SearchResultEventArgs { SearchResult = results });
        }
    }
}