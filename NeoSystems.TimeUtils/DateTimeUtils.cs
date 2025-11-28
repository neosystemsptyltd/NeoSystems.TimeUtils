
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
            if (string.IsNullOrWhiteSpace(s))
            {
                return d;
            }

            var temp = s.Trim();
            var lastChar = temp[temp.Length - 1];

            if (!char.IsLetter(lastChar))
            {
                // No suffix, just a number. Return original DateTime.
                return d;
            }

            var numberPart = temp.Substring(0, temp.Length - 1);
            if (!int.TryParse(numberPart, out var offs))
            {
                // Not a valid integer for the offset.
                return d;
            }

            TimeUnitEnum unit;
            // Suffix is a letter.
            switch (lastChar)
            {
                case 'Y':
                case 'y':
                    unit = TimeUnitEnum.Years;
                    break;

                case 'M':
                    unit = TimeUnitEnum.Months;
                    break;

                case 'W':
                case 'w':
                    unit = TimeUnitEnum.Weeks;
                    break;

                case 'D':
                case 'd':
                    unit = TimeUnitEnum.Days;
                    break;

                case 'H':
                case 'h':
                    unit = TimeUnitEnum.Hours;
                    break;

                case 'm':
                    unit = TimeUnitEnum.Minutes;
                    break;

                case 'S':
                case 's':
                    unit = TimeUnitEnum.Seconds;
                    break;

                default:
                    // Unrecognized suffix.
                    unit = TimeUnitEnum.Unknown;
                    break;
            }

            switch(unit)
            {
                case TimeUnitEnum.Years:
                    return d.AddYears(offs);
                case TimeUnitEnum.Months:
                    return d.AddMonths(offs);
                case TimeUnitEnum.Weeks:
                    return d.AddDays(offs * 7);
                case TimeUnitEnum.Days:
                    return d.AddDays(offs);
                case TimeUnitEnum.Hours:
                    return d.AddHours(offs);
                case TimeUnitEnum.Minutes:
                    return d.AddMinutes(offs);
                case TimeUnitEnum.Seconds:
                    return d.AddSeconds(offs);
                case TimeUnitEnum.Unknown:
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

