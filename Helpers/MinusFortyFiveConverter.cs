using System.Globalization;
using System.Windows.Data;

namespace QD_Checklists.Converters
{
    public class MinusFortyFiveConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value - 45;
        }

        /// <inheritdoc/>
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
