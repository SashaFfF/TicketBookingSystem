using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.UI.Converter
{
    public class DateTimeAndLocationConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is IList<DateTime> dateTimes && parameter is Location location)
            {
                return dateTimes.Select(dateTime => Tuple.Create(dateTime, location));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
