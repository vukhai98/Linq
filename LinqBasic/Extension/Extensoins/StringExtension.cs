using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods.Extensoins
{
    public static class StringExtension
    {
        public static double ToDouble(this string data)
        {
            double result = double.Parse(data);
            return result;
        }
    }
}
