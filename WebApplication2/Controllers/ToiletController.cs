using System;
using System.Collections;
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
            //var pt_list = entities.Public_toilets.ToList();
            Org_viewModel org_list = new Org_viewModel();
            //org_list.Pt = pt_list;
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

        public ActionResult Ajax_SelData(string seaStr, int disStr)
        {
            var entities = new feed_your_soulEntities();
            List<Public_toilets> pt_list = entities.Public_toilets.ToList();
            if (disStr != 0)
            {
                double lat = double.Parse(Session["lat"].ToString());
                double lng = double.Parse(Session["lng"].ToString());
                PositionModel obj = DistanceHelper.FindNeighPosition(lng, lat, disStr);
                if (pt_list != null)
                {
                    pt_list = pt_list.Where(n => n.lat > obj.MinLat && n.lat < obj.MaxLat).ToList();
                    pt_list = pt_list.Where(n => n.lon > obj.MinLng && n.lon < obj.MaxLng).ToList();
                }
            }
            if (seaStr != null && seaStr != "")
            {
                if (pt_list != null)
                {
                    pt_list = pt_list.Where(n => n.name.ToLower().Contains(seaStr.ToLower()) || n.male.ToLower().Contains(seaStr.ToLower()) || n.wheelchair.ToLower().Contains(seaStr.ToLower()) || n.baby_facil.ToLower().Contains(seaStr.ToLower()) || n.female.ToLower().Contains(seaStr.ToLower()) || n.@operator.ToLower().Contains(seaStr.ToLower())).ToList();
                }
            }
            ArrayList list = new ArrayList();
            if (pt_list != null)
            {
                foreach (var item in pt_list)
                {
                    list.Add(item);
                }
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ajax_SetMylocation(double lat, double lng)
        {
            Session["lat"] = lat;
            Session["lng"] = lng;
            return Json(true);
        }

    }
}