using MinistrySuite.Web.ViewModels.PrayerRequest;
using System.Collections.Generic;

namespace MinistrySuite.Web.ViewModels
{
    public class PrayerRequestWeeklyVM
    {
        public List<PrayerRequestBasicWithDatesVM> prayerRequests { get; set; }
        public PrayerRequestWeeklyVM()
        {
            prayerRequests = new List<PrayerRequestBasicWithDatesVM>();
        }
    }
}