using System;

namespace CesarBmx.Shared.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static string DaysHoursMinutesAndSecondsSinceDate(this DateTime dateTime)
        {
            var span = (DateTime.UtcNow - dateTime);
            return $"{(span.Days > 1 ? span.Days + " days, " : span.Days == 1 ? "1 day, " : "")}" +
                   $"{(span.Hours > 1 ? span.Hours + " hours, " : span.Hours == 1 ? "1 hour, " : "")}" +
                   $"{(span.Minutes > 1 ? span.Minutes + " minutes and " : span.Minutes == 1 ? "1 minute and " : "")}" +
                   $"{(span.Seconds > 1 ? span.Seconds + " seconds " : span.Seconds == 1 ? "1 second " : "0 second ")}ago";
        }
        public static DateTime StripSeconds(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, DateTimeKind.Utc);
        }
    }
}
