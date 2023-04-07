using System;
using System.Text;

namespace NeoSystems.TimeUtils
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTime(this DateTime d)
        {
            return (long)(d - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static long ToUnixTimeMilliseconds(this DateTime d)
        {
            return (long)(d - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}

