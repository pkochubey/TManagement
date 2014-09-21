using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using TManagement.Models;

namespace TManagement.Converters
{
    public class GroupHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (null == value)
                return "null";

            var items = (ReadOnlyObservableCollection<object>) value;

            long hours = (from i in items select ((Week) i).Tick).Sum();

            var timeSpan = new TimeSpan(hours);

            return timeSpan.Hours + "ч. " + timeSpan.Minutes + " м.";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}