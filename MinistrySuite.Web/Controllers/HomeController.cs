using System;
using System.Linq;
using EFDataLayer;
using System.Web.Mvc;
using MinistrySuite.Web.ViewModels;
using System.Data.Entity;

namespace MinistrySuite.Web.Controllers
{
    public class HomeController : Controller
    {
        ChurchContext db = new ChurchContext();

        public ActionResult Index()
        {
            var member = db.ChurchMemebrs.Include(cm => cm.Ministries).Where(cm => cm.Id == 1).Single();

            var model = new HomePageVM();
            model.ChurchMember = new ChurchMemberDetailsVM()
            {
                Id = member.Id,
                Name = member.FullName,
                PrimaryAddress = member.GetPrimaryAddress,
                PrimaryEmail = member.GetPrimaryEmailAddress.Email_Address,
                PrimaryPhone = member.GetPrimaryPhoneNumber.GetFormattedNumber
            };
            model.Ministries = member.Ministries.Select(m => new MinistryBasicInfoVM() { Id = m.Id, Name = m.Name }).ToList();
            member.Ministries
                .ToList()
                .ForEach(m => m.PrayerRequests
                .Where(pr=> pr.StartDate.Date.Date <= DateTimeOffset.Now.Date.Date && 
                            pr.EndDate.Date.Date >= DateTimeOffset.Now.Date.Date)
                    .ToList()
                    .ForEach(pr => model.PrayerRequests.Add(new PrayerRequestBasicInfoVM() { Id = pr.Id, Title = pr.Title })));
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}