using EFDataLayer;
using MinistrySuite.Util;
using MinistrySuite.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinistrySuite.Web.LinqQueries
{
    public static class PrayerRequestLinqQueries
    {
        public static PrayerRequestWeeklyVM GetPrayerRequestWeeklyVM(this ChurchContext context, int churchMemberId)
        {
            var model = new PrayerRequestWeeklyVM();
            context.ChurchMemebrs
                .Where(cm => cm.Id == churchMemberId)
                .Single()
                .Ministries
                .ToList()
                .ForEach(m => m.PrayerRequests
                    .Where(pr => pr.StartDate.Date.Date < DateTimeOffset.Now.AddDays(DateTimeOffset.Now.GetNumOfDaysUntilSaturday()).Date.Date &&
                                 pr.EndDate.Date.Date < DateTimeOffset.Now.AddDays(-DateTimeOffset.Now.GetNumOfDaysFromSunday()).Date.Date)
                    .ToList()
                    .ForEach
                        (
                            pr => model.prayerRequests.Add
                                (
                                    new ViewModels.PrayerRequest.PrayerRequestBasicWithDatesVM()
                                    {
                                        Id = pr.Id,
                                        Title = pr.Title,
                                        StartDate = pr.StartDate,
                                        EndDate = pr.EndDate
                                    }
                                )
                        )
                    );
            return model;
        }
    }
}