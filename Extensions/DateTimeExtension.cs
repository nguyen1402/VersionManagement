using System;

namespace SC.VersionManagement.Extensions
{
    public static class DateTimeExtension
    {
        private static readonly TimeZoneInfo timeZone;

        static DateTimeExtension()
        {
            timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        }
        public static DateTime ConvertUtcToLocalTime(this DateTime t)
        {
            return TimeZoneInfo.ConvertTime(t, timeZone);
        }

        public static DateTime ConvertUtcToLocalByTimeZoneOffset(this DateTime value, double timeZoneOffset = -420)
        {
            return value.AddMinutes(-timeZoneOffset);
        }

        public static DateTime ConvertLocalToUtcByTimeZoneOffset(this DateTime value, double timeZoneOffset = 420)
        {
            return value.AddMinutes(timeZoneOffset);
        }
     
    }
}
