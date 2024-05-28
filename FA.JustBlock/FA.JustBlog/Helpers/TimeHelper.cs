using System.Security.Policy;
using System.Text;

namespace FA.JustBlog
{
    public static class TimeHelper
    {
        public static string ToTime(this DateTime dateTime)
        {
            var timeSpan = DateTime.UtcNow - dateTime.ToUniversalTime();

            if (timeSpan.TotalMinutes < 1)
                return "just now";
            if (timeSpan.TotalMinutes < 60)
                return $"{timeSpan.Minutes} minute{(timeSpan.Minutes > 1 ? "s" : string.Empty)} ago";
            if (timeSpan.TotalHours < 24)
                return $"{timeSpan.Hours} hour{(timeSpan.Hours > 1 ? "s" : string.Empty)} ago";
            if (timeSpan.TotalDays < 2)
                return $"yesterday at {dateTime.ToShortTimeString()}";
            if (timeSpan.TotalDays < 7)
                return $"{timeSpan.Days} day{(timeSpan.Days > 1 ? "s" : string.Empty)} ago";
            if (timeSpan.TotalDays < 30)
                return $"{Math.Floor(timeSpan.TotalDays / 7)} week{(Math.Floor(timeSpan.TotalDays / 7) > 1 ? "s" : string.Empty)} ago";

            return dateTime.ToString("MMMM dd, yyyy 'at' hh:mm tt");
        }
    }
}



