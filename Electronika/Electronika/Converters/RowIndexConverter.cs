using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Electronika.Converters
{
    public class RowIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            ListBoxItem item = value as ListBoxItem;
            ListBox view = ItemsControl.ItemsControlFromItemContainer(item) as ListBox;
            int index = view.ItemContainerGenerator.IndexFromContainer(item);
            return (index + 1).ToString() + ".";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
