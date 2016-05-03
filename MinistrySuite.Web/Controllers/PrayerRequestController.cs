using EFDataLayer;
using System.Linq;
using System.Web.Mvc;
using MinistrySuite.Web.ViewModels;
using MinistrySuite.Util;
using System;
using MinistrySuite.Web.LinqQueries;
using System.Data.Entity;
using MinistrySuite.Web.ViewModels.PrayerRequest;

namespace MinistrySuite.Web.Controllers
{
    public class PrayerRequestController : Controller
    {
        ChurchContext db = new ChurchContext();

        // GET: All PrayerRequests by church member
        public ActionResult Index(int churchMemberId)
        {
            var model = PrayerRequestWeeklyVM.Create(db.GetPrayerRequestsForOneWeek(churchMemberId));
            return View(model);
        }

        public ActionResult ViewSingleRequest(int id)
        {
            var model = db.PrayerRequests.Where(pr => pr.Id == id).Include(pr => pr.Updates).Single();

            return View(model);
        }

        public ActionResult Create(int churchId, int churchMemberId)
        {
            var ministries = db.ChurchMemebrs
                .Where(cm => cm.Id == churchMemberId)
                .Single()
                .Ministries
                .Select(m => new MinistryBasicInfoVM { Id = m.Id, Name = m.Name });
            CreatePrayerRequestVM createPrayerRequestVM = 
                new CreatePrayerRequestVM { ChurchId = churchId, Ministries = ministries.ToList() };
            return View(createPrayerRequestVM);
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