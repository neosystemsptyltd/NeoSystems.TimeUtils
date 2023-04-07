
using System;
using System.Text;

namespace NeoSystems.TimeUtils
{
    public static class DateTimeUtils
    {
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
    }
}

