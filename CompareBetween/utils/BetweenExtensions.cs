using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareBetween
{
    public static class BetweenExtensions
    {
        public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T>
        {
            var minGreater = min.CompareTo(max);

            if (minGreater==1)
                return true;

            return (min.CompareTo(value) <= 0) && (value.CompareTo(max) <= 0);

        }

        //public static bool IsBetweenEI<T>(this T value, T min, T max) where T : IComparable<T>
        //{
        //    return (min.CompareTo(value) < 0) && (value.CompareTo(max) <= 0);
        //}
        //public static bool IsBetweenIE<T>(this T value, T min, T max) where T : IComparable<T>
        //{
        //    return (min.CompareTo(value) <= 0) && (value.CompareTo(max) < 0);
        //}
        //public static bool IsBetweenEE<T>(this T value, T min, T max) where T : IComparable<T>
        //{
        //    return (min.CompareTo(value) < 0) && (value.CompareTo(max) < 0);
        //}
    }
}
