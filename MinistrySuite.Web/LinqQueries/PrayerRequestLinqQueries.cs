using EFDataLayer;
using MinistrySuite.Util;
using MinistrySuite.Web.ViewModels;
using MinistrySuite.Web.ViewModels.PrayerRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinistrySuite.Web.LinqQueries
{
    public static class PrayerRequestLinqQueries
    {
        public static List<PrayerRequestBasicWithDatesVM> GetPrayerRequestsForOneWeek(this ChurchContext context, int churchMemberId)
        {
            var requests = new List<PrayerRequestBasicWithDatesVM>();
            context.ChurchMemebrs
                .Where(cm => cm.Id == churchMemberId)
                .Single()
                .Ministries
                .ToList()
                .ForEach(m => m.PrayerRequests
                    .Where(pr => pr.FallsWithinCurrentWeek())
                    .ToList()
                    .ForEach
                        (
                            pr => requests.Add
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
            return requests;
        }
    }
}