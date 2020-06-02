using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using XFTest.ViewModels;

namespace XFTest.Converters
{
    public class TaskStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object taskStatus = value as String;

            switch (taskStatus)
            {
                case "InProgress": return Color.FromHex("f5c709");
                case "Done": return Color.FromHex("25a87b");
                case "Rejected": return Color.FromHex("ef6565");
                default: return Color.FromHex("4e77d6");
            }


            //if (valueDateTime == baseDateTime)
            //    return Color.FromHex("368268");
            //else
            //    return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
