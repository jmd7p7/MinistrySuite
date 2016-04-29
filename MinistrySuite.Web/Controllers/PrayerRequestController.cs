using EFDataLayer;
using System.Linq;
using System.Web.Mvc;
using MinistrySuite.Web.ViewModels;
using MinistrySuite.Util;
using System;
using MinistrySuite.Web.LinqQueries;

namespace MinistrySuite.Web.Controllers
{
    public class PrayerRequestController : Controller
    {
        ChurchContext db = new ChurchContext();

        // GET: PrayerRequest
        public ActionResult Index(int churchMemberId)
        {
            var model = PrayerRequestWeeklyVM.Create(db.GetPrayerRequestsForOneWeek(churchMemberId));
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