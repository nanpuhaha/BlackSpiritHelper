﻿using BlackSpiritHelper.Core;
using Ninject;
using System;
using System.Diagnostics;
using System.Globalization;

namespace BlackSpiritHelper
{
    /// <summary>
    /// Converts a string name to a service pulled from the IoC container.
    /// </summary>
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page.
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Application;

                default:
                    // Log it.
                    IoC.Logger.Log("A selected IoC location convertor value is out of box!", LogLevel.Error);
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
