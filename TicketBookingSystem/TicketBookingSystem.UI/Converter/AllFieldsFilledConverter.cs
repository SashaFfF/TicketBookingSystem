using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.UI.ViewModels;
using static iText.Svg.SvgConstants;

namespace TicketBookingSystem.UI.Converter
{
    public class AllFieldsFilledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value?.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
