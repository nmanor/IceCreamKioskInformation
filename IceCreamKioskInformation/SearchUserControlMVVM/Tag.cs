using MaterialDesignThemes.Wpf;
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
            tag.IsDeletable = true;
            tag.Background = Brushes.DarkGray;
            tag.Margin = new Thickness(0, 0, 10, 10);

            Binding binding = new Binding();
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.Self);
            tag.SetBinding(CommandParameterProperty, binding);
            tag.SetBinding(CommandProperty, new Binding("AddFilter"));

            string content = "";
            try
            {
                UIElementCollection collection = ((StackPanel)Content).Children;
                foreach (var item in collection)
                {
                    if (item is TextBlock)
                        content += (item as TextBlock).Text + " ";
                    else if (item is TextBox)
                        content += (item as TextBox).Text + " ";
                    else
                        content += (item as RatingBar).Value + " ";
                }
                content = content.Remove(content.Length - 1);
            }
            catch
            {
                content = Content.ToString();
            }
            tag.Content = content;


            return tag;
        }
    }
}
