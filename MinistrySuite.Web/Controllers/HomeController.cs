using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinistrySuite.Entities;
using EFDataLayer;
using System.Web.Mvc;
using MinistrySuite.Web.ViewModels;

namespace MinistrySuite.Web.Controllers
{
    public class HomeController : Controller
    {
        ChurchContext db = new ChurchContext();

        public ActionResult Index()
        {
            var member = db.ChurchMemebrs.First();

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