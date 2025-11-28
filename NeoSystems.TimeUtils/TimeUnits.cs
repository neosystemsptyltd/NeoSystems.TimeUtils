namespace NeoSystems.TimeUtils
{
    public class TimeUnits
    {
        public string Milliseconds { get; set; }
        public string Seconds { get; set; }
        public string Minutes { get; set; }
        public string Hours { get; set; }
        public string Days { get; set; }
        public string Weeks { get; set; }
        public string Months { get; set; }
        public string Years { get; set; }

        public TimeUnits()
        {
            Milliseconds = "milliseconds";
            Seconds = "seconds";
            Minutes = "minutes";
            Hours = "hours";
            Days = "days";
            Weeks = "weeks";
            Months = "months";
            Years = "years";
        }
    }
}
