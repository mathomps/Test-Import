using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace MediaLibraryEditor.WPF.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    class TimestampConverter : IValueConverter
    {

        #region IValueConverter Members

        /// <summary>
        /// Convert a string timestamp into equivalent milliseconds.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int timestamp = (int)value;

            // Convert to format of 'hh:mm:ss.ssss'

            TimeSpan ts = new TimeSpan(timestamp);

            return ts.ToString();
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
