using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// File: Converters/TriStateLabelConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;

// Use a dedicated converters namespace - NOT the same as your views
namespace NaixxGithub.NINA.Fasterflats.Converters {
    public class TriStateLabelConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            // Get NINA's resource strings (safe fallback)
            string onText = "ON";
            string offText = "OFF";

            return value switch {
                true => onText,
                false => offText,
                null => "Not Changed",
                _ => "Not Changed"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}