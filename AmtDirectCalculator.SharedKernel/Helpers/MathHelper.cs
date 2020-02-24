using System;
using System.Globalization;

namespace AmtDirectCalculator.SharedKernel.Helpers
{
    public static class MathHelper
    {
        public static decimal SetPrecision(decimal number, int precision)
        {
            NumberFormatInfo setPrecision = new NumberFormatInfo
            {
                NumberDecimalDigits = precision
            };
            return Convert.ToDecimal(number.ToString("N", setPrecision));
        }
    }
}
