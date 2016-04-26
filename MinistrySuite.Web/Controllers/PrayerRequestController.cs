using EFDataLayer;
using System.Linq;
using System.Web.Mvc;
using MinistrySuite.Web.ViewModels;
using MinistrySuite.Util;
using System;

namespace MinistrySuite.Web.Controllers
{
    public class PrayerRequestController : Controller
    {
        ChurchContext db = new ChurchContext();

        // GET: PrayerRequest
        public ActionResult Index(int churchMemberId)
        {
            var model = new PrayerRequestWeeklyVM();
            db.ChurchMemebrs
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
                        ));
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if(db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}