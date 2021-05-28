using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDynamic.util
{
    public static class DecimalExtension
    {
        public static string ToDecimalFormat(this decimal value)
        {
            return value.ToString(CultureInfo.CreateSpecificCulture("en-US"));
        }
        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }
        public static decimal ToDecimal(this double value)
        {
            return decimal.Parse(value.ToString());
        }
        public static string toReplaceFormatPoint(this string value)
        {
            var retorno = value.Replace(",", ".");
            return retorno;
        }
    }
}
