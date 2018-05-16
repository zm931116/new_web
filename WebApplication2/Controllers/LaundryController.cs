using System;
using System.Collections;
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
        public ActionResult Laundry()
        {
            return View();
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

        public ActionResult Ajax_SelData(string seaStr, int disStr)
        {
            var entities = new feed_your_soulEntities();
            List<Laundry> L_list = entities.Laundries.ToList();
            if (disStr != 0)
            {
                double lat = double.Parse(Session["lat"].ToString());
                double lng = double.Parse(Session["lng"].ToString());
                PositionModel obj = DistanceHelper.FindNeighPosition(lng, lat, disStr);
                if (L_list != null)
                {
                    L_list = L_list.Where(n => n.Latitude > obj.MinLat && n.Latitude < obj.MaxLat).ToList();
                    L_list = L_list.Where(n => n.Longitude > obj.MinLng && n.Longitude < obj.MaxLng).ToList();
                }
            }
            if (seaStr != null && seaStr != "")
            {
                if (L_list != null)
                {
                    L_list = L_list.Where(n => n.Address.ToLower().Contains(seaStr.ToLower()) || n.Avai_days.ToLower().Contains(seaStr.ToLower()) || n.Name.ToLower().Contains(seaStr.ToLower()) || n.Timings.ToLower().Contains(seaStr.ToLower())).ToList();
                }
            }
            ArrayList list = new ArrayList();
            if (L_list != null)
            {
                foreach (var item in L_list)
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