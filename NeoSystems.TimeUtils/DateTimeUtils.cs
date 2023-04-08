
using System;
using System.Text;

namespace NeoSystems.TimeUtils
{
    public static class DateTimeUtils
    {
        /// <summary>
        /// Constant: unix time epoch
        /// </summary>
        public static readonly DateTime UnixEpoch =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Create a DateTime from a string
        /// The string can be in the format:
        ///    -5d
        ///    +5h
        ///    -5m
        ///    +5s
        /// </summary>
        /// <param name="s">String contain a time value</param>
        /// <returns>DateTime</returns>
        public static DateTime FuzzyAdd(this DateTime d, string s)
        {
            if (s == null)
            {
                return d;
            }

            TimeUnitEnum unit = TimeUnitEnum.Years;

            var temp = s.Trim();
            if (temp.EndsWith("Y"))
            {
                unit = TimeUnitEnum.Years;
            }
            if (temp.EndsWith("M"))
            {
                unit = TimeUnitEnum.Months;
            }
            if (temp.EndsWith("D"))
            {
                unit = TimeUnitEnum.Days;
            }
            if (temp.EndsWith("h"))
            {
                unit = TimeUnitEnum.Hours;
            }
            if (temp.EndsWith("m"))
            {
                unit = TimeUnitEnum.Minutes;
            }
            if (temp.EndsWith("s"))
            {
                unit = TimeUnitEnum.Seconds;
            }

            if (unit == TimeUnitEnum.Unknown)
            {
                return d;
            }
            temp = temp.Substring(0, temp.Length - 1);

            int offs = int.Parse(temp);

            switch(unit)
            {
                case TimeUnitEnum.Years:
                    return d.AddYears(offs);

                case TimeUnitEnum.Months:
                    return d.AddMonths(offs);

                case TimeUnitEnum.Days:
                    return d.AddDays(offs);

                case TimeUnitEnum.Hours:
                    return d.AddHours(offs);

                case TimeUnitEnum.Minutes:
                    return d.AddMinutes(offs);

                case TimeUnitEnum.Seconds:
                    return d.AddSeconds(offs);

                default:
                    return d;
            }
        }

        /// <summary>
        /// Create a DateTime struct from a Unix millisecond timestamp
        /// </summary>
        /// <param name="millis">Unix millisecond timestamp</param>
        /// <returns>DateTime struct</returns>
        public static DateTime DateTimeFromUnixTimestampMillis(long millis)
        {
            return UnixEpoch.AddMilliseconds(millis);
        }

        /// <summary>
        /// Create a DateTime struct from a Unix second timestamp
        /// </summary>
        /// <param name="seconds">Unix second timestamp</param>
        /// <returns>DateTime struct</returns>
        public static DateTime DateTimeFromUnixTimestampSeconds(long seconds)
        {
            return UnixEpoch.AddSeconds(seconds);
        }
    }
}

