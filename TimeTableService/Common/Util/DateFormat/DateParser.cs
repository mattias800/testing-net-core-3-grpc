using System;
using System.Globalization;

namespace TimeTableEventConsumer.Common.Util.DateFormat
{
    public class DateParser
    {
        public static DateTime ParseDate(string dateString)
        {
            const string expectedFormat = "yyyy-MM-dd";
            var result = DateTime.TryParseExact(
                dateString,
                expectedFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var theDate);
            if (result)
            {
                return theDate;
            }
            else
            {
                throw new FormatException("Invalid date format.");
            }
        }
    }
}