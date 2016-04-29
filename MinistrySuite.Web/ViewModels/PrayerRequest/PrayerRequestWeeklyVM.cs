using MinistrySuite.Enums;
using MinistrySuite.Util;
using MinistrySuite.Web.ViewModels.PrayerRequest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinistrySuite.Web.ViewModels
{
    public class PrayerRequestWeeklyVM
    {
        public List<PrayerRequestByDateVM> WeeklyPrayerRequests { get; set; }

        private PrayerRequestWeeklyVM()
        {
            WeeklyPrayerRequests = new List<PrayerRequestByDateVM>();

        }

        public static PrayerRequestWeeklyVM Create(List<PrayerRequestBasicWithDatesVM> requests)
        {
            var newPrayerRequestWeeklyVM = new PrayerRequestWeeklyVM();
            foreach (var day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                DateTimeOffset currentDay = DateHelper.GetNearestDayOfWeek((DaysOfWeek)day);
                List<PrayerRequestBasicWithDatesVM> requestsForCurrentDay =
                    requests.Where(r => r.StartDate.Date.Date <= currentDay.Date.Date &&
                                       r.EndDate.Date.Date >= currentDay.Date.Date).ToList();

                newPrayerRequestWeeklyVM.WeeklyPrayerRequests.Add(new PrayerRequestByDateVM(currentDay, requestsForCurrentDay));
            }
            return newPrayerRequestWeeklyVM;
        }
    }
}