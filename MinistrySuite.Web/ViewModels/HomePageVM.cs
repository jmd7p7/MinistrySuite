using MinistrySuite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinistrySuite.Web.ViewModels
{
    public class HomePageVM
    {
        public HomePageVM()
        {
            PrayerRequests = new List<PrayerRequestBasicInfoVM>();
            Ministries = new List<MinistryBasicInfoVM>();
        }
        public List<PrayerRequestBasicInfoVM> PrayerRequests { get; set; }
        public List<MinistryBasicInfoVM> Ministries { get; set; }
        public ChurchMemberDetailsVM ChurchMember { get; set; }

    }
}