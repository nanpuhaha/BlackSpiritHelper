﻿using System.Globalization;
using System.Windows.Controls;

namespace BlackSpiritHelper.Core
{
    /// <summary>
    /// Rule to validate input as minutes.
    /// </summary>
    public class TimeMinutesRule : BaseRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Minimal possible value.
            int minVal = 0;
            // Maximal possible value.
            int maxVal = 59;

            int val;
            object oVal = GetBoundValue(value);

            // Check data type.
            if (oVal.GetType() == typeof(int))
                val = (int)oVal;
            else
                return new ValidationResult(false, "Not a number.");

            // Check conditions.
            if (val < minVal || val > maxVal)
                return new ValidationResult(false, $"Please enter a minutes in the correct range: {minVal} - {maxVal}.");

            return ValidationResult.ValidResult;
        }
    }
}
