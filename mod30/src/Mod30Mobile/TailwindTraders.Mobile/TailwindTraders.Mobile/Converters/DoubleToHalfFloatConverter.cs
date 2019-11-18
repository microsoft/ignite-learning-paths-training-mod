﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TailwindTraders.Mobile.Converters
{
    public class DoubleToHalfFloatConverter : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var @double = (double)value;
            var result = (float)@double;

            if (result < 0)
            {
                return 0;
            }

            var half = result / 2;

            return half;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
