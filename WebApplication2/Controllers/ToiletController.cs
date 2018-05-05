using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ToiletController : Controller
    {
        // GET: Toilet
        public ActionResult public_toilets()
        {
            
           
            return View(get_toilets());
        }

        private Org_viewModel get_toilets()
        {
            var entities = new feed_your_soulEntities();
            var pt_list = entities.Public_toilets.ToList();
            Org_viewModel org_list = new Org_viewModel();
            org_list.Pt = pt_list;
            return org_list;
        }

        public ActionResult toilet_list()
        {
            return PartialView();
        }

        public ActionResult loadAllData()
        {
            Org_viewModel org_list = get_toilets();
            return Json(new { data = org_list.Pt }, JsonRequestBehavior.AllowGet);
        }
    }
}