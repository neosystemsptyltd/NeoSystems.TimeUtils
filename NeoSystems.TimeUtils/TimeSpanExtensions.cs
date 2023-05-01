using System;
using System.Text;

namespace NeoSystems.TimeUtils
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Convert a Timespan to a simplified human readable string
        /// Typical responses:
        ///     one second
        ///     45 seconds
        ///     a minute
        ///     a minute
        ///     2 minutes
        ///     an hour
        ///     2 hours
        ///     yesterday
        ///     2 days
        ///     one month
        ///     one year
        ///     2 year

        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <returns>Human readable string</returns>
        public static string ToHumanReadableSimple(this TimeSpan ts)
        {
            var delta = ts.TotalSeconds;

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second" : ts.Seconds + " seconds";
            }

            if (delta < 120)
            {
                return "a minute";
            }

            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes";
            }

            if (delta < 5400) // 90 * 60
            {
                return "an hour";
            }

            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours";
            }

            if (delta < 172800) // 48 * 60 * 60
            {
                return "a day";
                // return "yesterday";
            }

            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days";
            }

            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month" : months + " months";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year" : years + " years";
        }

        /// <summary>
        /// get total years from a timespan
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <returns>double: number of years</returns>
        public static double TotalYears(this TimeSpan ts)
        {
            return ts.TotalDays / 365.25;
        }

        /// <summary>
        /// Convert a Timespan to a human readable string with years, days, hours, minutes, seconds
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string ToHumanReadableExpanded(this TimeSpan ts, TimeUnits tu)
        {
            double ms = ts.TotalMilliseconds;
            StringBuilder sb = new StringBuilder();

            if (ms >= (1000.0*60*60*24*365))
            {
                double years = Math.Floor(ms / (1000.0 * 60 * 60 * 24 * 365));
                ms -= years * (1000.0 * 60 * 60 * 24 * 365);
                sb.Append($"{years:0} {tu.years} ");
            }

            if (ms >= (1000.0 * 60 * 60 * 24))
            {
                double days = Math.Floor(ms / (1000.0 * 60 * 60 * 24));
                ms -= days * (1000.0 * 60 * 60 * 24);
                sb.Append($"{days:0} {tu.days} ");
            }

            if (ms >= (1000.0 * 60 * 60))
            {
                double hours = Math.Floor(ms / (1000.0 * 60 * 60));
                ms -= hours * (1000.0 * 60 * 60);
                sb.Append($"{hours:0} {tu.hours} ");
            }

            if (ms >= (1000.0 * 60))
            {
                double minutes = Math.Floor(ms / (1000.0 * 60));
                ms -= minutes * (1000.0 * 60);
                sb.Append($"{minutes:0} {tu.minutes} ");
            }

            if (ms >= 1000.0)
            {
                double seconds = Math.Floor(ms / (1000.0));
                ms -= seconds * (1000.0);
                sb.Append($"{seconds:0} {tu.seconds} ");
            }

            if (ms > 0.0)
            {
                sb.Append($"{ms:0} {tu.milliseconds} ");
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Convert a Timespan to a human readable string with years, days, hours, minutes, seconds, using default descriptions
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <returns>Human readable string</returns>
        public static string ToHumanReadableExpanded(this TimeSpan ts)
        {
            TimeUnits tu = new TimeUnits();
            return ts.ToHumanReadableExpanded(tu);
        }

        /// <summary>
        /// Add milliseconds to a timespan
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <param name="milliseconds">milliseconds to add to the timespan</param>
        /// <returns>Timespan</returns>
        public static TimeSpan AddMilliseconds(this TimeSpan ts, double milliseconds)
        {
            return ts.Add(TimeSpan.FromMilliseconds(milliseconds));
        }

        /// <summary>
        /// Add seconds to a timespan
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <param name="seconds">Seconds to add</param>
        /// <returns>Timespan</returns>
        public static TimeSpan AddSeconds(this TimeSpan ts, double seconds)
        {
            return ts.Add(TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        /// Add minutes to a timespan
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <param name="minutes">Minutes to add</param>
        /// <returns></returns>
        public static TimeSpan AddMinutes(this TimeSpan ts, double minutes)
        {
            return ts.Add(TimeSpan.FromMinutes(minutes));
        }

        /// <summary>
        /// Add hours to a timespan
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <param name="hours">Hours to add</param>
        /// <returns>Timespan</returns>
        public static TimeSpan AddHours(this TimeSpan ts, double hours)
        {
            return ts.Add(TimeSpan.FromHours(hours));
        }

        /// <summary>
        /// Add days to a timespan
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <param name="days">days to add</param>
        /// <returns>Timespan</returns>
        public static TimeSpan AddDays(this TimeSpan ts, double days)
        {
            return ts.Add(TimeSpan.FromDays(days));
        }

        /// <summary>
        /// Add weeks to a timespan
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <param name="weeks">Number of weeks to add</param>
        /// <returns>Timespan</returns>
        public static TimeSpan AddWeeks(this TimeSpan ts, double weeks)
        {
            return ts.Add(TimeSpan.FromDays(weeks * 7));
        }

        /// <summary>
        /// Add a month to a timespan (30 days)
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <param name="months">number of months (30 day periods)</param>
        /// <returns>Timespan</returns>
        public static TimeSpan AddMonths(this TimeSpan ts, double months)
        {
            return ts.Add(TimeSpan.FromDays(months * 30));
        }

        /// <summary>
        /// Add years to a timespan (365.25 days)
        /// </summary>
        /// <param name="ts">Timespan</param>
        /// <param name="years">number of years to add</param>
        /// <returns>Timespan</returns>
        public static TimeSpan AddYears(this TimeSpan ts, double years)
        {
            return ts.Add(TimeSpan.FromDays(years * 365.25));
        }
    }
}

