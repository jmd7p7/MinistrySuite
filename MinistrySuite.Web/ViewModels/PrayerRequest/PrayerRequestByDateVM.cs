using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinistrySuite.Web.ViewModels.PrayerRequest
{
    public class PrayerRequestByDateVM
    {
        public List<PrayerRequestBasicWithDatesVM> PrayerRequestes { get; set; }
        public DateTimeOffset Date { get; set; }

        public PrayerRequestByDateVM(DateTimeOffset date, List<PrayerRequestBasicWithDatesVM> requests)
        {
            Date = date;
            PrayerRequestes = requests;
        }
    }
}