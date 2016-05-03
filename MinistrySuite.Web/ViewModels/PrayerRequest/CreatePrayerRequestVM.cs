using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinistrySuite.Web.ViewModels.PrayerRequest
{
    public class CreatePrayerRequestVM
    {
        public int ChurchId { get; set; }
        public string Title { get; set; }
        public string Request { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool PermissionGranted { get; set; }
        public List<MinistryBasicInfoVM> Ministries { get; set; }
    }
}