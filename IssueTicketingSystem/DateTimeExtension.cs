using System;
using System.Globalization;

namespace IssueTicketingSystem
{
    public static class DateTimeExtension
    {
        public static string GetDateString(this DateTime? date)
        {
           var dateString = date == null ? string.Empty : ((DateTime)date).ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            return dateString;
        }

        public static string GetDateString(this DateTime date)
        {
            var dateString = date.Date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            return dateString;
        }
    }
}