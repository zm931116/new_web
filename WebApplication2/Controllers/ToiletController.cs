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
        public ActionResult Index()
        {
            var entities = new feed_your_soulEntities();
            var pt_list = entities.Public_toilets.ToList();
            var org_list = new Org_viewModel();
            org_list.Pt = pt_list;
            return View();
        }
    }
}