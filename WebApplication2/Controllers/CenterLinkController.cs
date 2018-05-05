using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CenterLinkController : Controller
    {
        // GET: CenterLink
        public ActionResult CenterLink_page()
        {
            var entities = new feed_your_soulEntities();
            var cl_list = entities.Centrelink_Data.ToList();
            Org_viewModel org_list = new Org_viewModel();
            org_list.Cl = cl_list;
            return View(org_list);
        }
    }
}