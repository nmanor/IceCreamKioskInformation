using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace IceCreamKioskInformation
{
    /// <summary>
    /// A representation of a tag inherited from Chip can contain more information about the tag
    /// </summary>
    public class Tag : Chip
    {
        /// <summary>
        /// Specifies the category to which the tag belongs
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Specifies the content of the tag
        /// </summary>
        public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(string), typeof(Tag), new UIPropertyMetadata(null));
        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        /// <summary>
        /// Pointer to the original parent
        /// </summary>
        public Tag OriginalTag { get; set; }

        /// <summary>
        /// Create a new son that fits the filters already selected based on Dad
        /// </summary>
        public Tag generateSon()
        {
            Tag tag = new Tag();

            tag.Category = Category;
            tag.Data = Data;
            tag.OriginalTag = this;
            tag.Content = Content;
            tag.IsDeletable = true;
            tag.Background = Brushes.DarkGray;

            Binding binding = new Binding();
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.Self);
            tag.SetBinding(CommandParameterProperty, binding);
            tag.SetBinding(CommandProperty, new Binding("AddFilter"));

            try
            {
                ((StackPanel)tag.Content).IsEnabled = false;
            }
            catch { }

            return tag;
        }
    }
}
