using System;
using System.Collections;
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

        public ActionResult Ajax_SelData(int disStr)
        {
            var entities = new feed_your_soulEntities();
            List<Centrelink_Data> cl_list = entities.Centrelink_Data.ToList();
            if (disStr != 0)
            {
                double lat = double.Parse(Session["lat"].ToString());
                double lng = double.Parse(Session["lng"].ToString());
                PositionModel obj = DistanceHelper.FindNeighPosition(lng, lat, disStr);
                if (cl_list != null)
                {
                    cl_list = cl_list.Where(n => n.Latitude > obj.MinLat && n.Latitude < obj.MaxLat).ToList();
                    cl_list = cl_list.Where(n => n.Longitude > obj.MinLng && n.Longitude < obj.MaxLng).ToList();
                }
            }
            ArrayList list = new ArrayList();
            if (cl_list != null)
            {
                foreach (var item in cl_list)
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