using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LaundryController : Controller
    {
        // GET: Laundry
        public ActionResult Index()
        {
            return View(getLaundries());
        }

        public ActionResult loadAllData()
        {
            Org_viewModel org_list = getLaundries();
            return Json(new { data = org_list.Ld }, JsonRequestBehavior.AllowGet);
        }

        private Org_viewModel getLaundries()
        {
            var entities = new feed_your_soulEntities();
            var laundry_list = entities.Laundries.ToList();
            Org_viewModel org_list = new Org_viewModel();
            org_list.Ld = laundry_list;
            return org_list;
        }

        public ActionResult laundry_list()
        {
            return PartialView();
        }
    }
}