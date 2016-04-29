using MinistrySuite.Entities;
using MinistrySuite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistrySuite.Util
{
    public static class DateHelper
    {
        public static int GetNumOfDaysFromSunday(this DateTimeOffset date)
        {
            return (int)date.DayOfWeek;
        }

        public static int GetNumOfDaysUntilSaturday(this DateTimeOffset date)
        {
            return 6 - (int)date.DayOfWeek;
        }

        public static bool FallsWithinCurrentWeek(this PrayerRequest prayerRequest)
        {
            return (prayerRequest.StartDate.Date.Date <= DateTimeOffset.Now.AddDays(DateTimeOffset.Now.GetNumOfDaysUntilSaturday()).Date.Date &&
                    prayerRequest.EndDate.Date.Date >= DateTimeOffset.Now.AddDays(-DateTimeOffset.Now.GetNumOfDaysFromSunday()).Date.Date);
        }

        public static DateTimeOffset GetNearestDayOfWeek(DaysOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DaysOfWeek.Sunday:
                    return DateTimeOffset.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 0));
                case DaysOfWeek.Monday:
                    return DateTimeOffset.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 1));
                case DaysOfWeek.Tuesday:
                    return DateTimeOffset.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 2));
                case DaysOfWeek.Wednesday:
                    return DateTimeOffset.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 3));
                case DaysOfWeek.Thursday:
                    return DateTimeOffset.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 4));
                case DaysOfWeek.Friday:
                    return DateTimeOffset.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 5));
                case DaysOfWeek.Saturday:
                    return DateTimeOffset.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 6));
                default:
                    throw new ArgumentException("Unable to determine the day of week.");
            }
        }
    }
}
