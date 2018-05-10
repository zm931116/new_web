using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DrinkingFountainsController : Controller
    {
        // GET: DrinkingFountains
        public ActionResult Index()
        {
            //initialize the models
            var entities = new feed_your_soulEntities();
            //turn each type of the entities into lists
            
            var df_list = entities.Drinking_fountains.ToList();
           

            //intialize the view_model to load multiple models on the single view
            var org_list = new Org_viewModel();

            //assign the value into lists in org_list
            
            org_list.Df = df_list;
           




            return View("Index", "_Layout", org_list);
        }

        public ActionResult Ajax_SelData( int disStr)
        {
            var entities = new feed_your_soulEntities();
            List<Drinking_fountains> dw_list = entities.Drinking_fountains.ToList();
            if (disStr != 0)
            {
                double lat = double.Parse(Session["lat"].ToString());
                double lng = double.Parse(Session["lng"].ToString());
                PositionModel obj = DistanceHelper.FindNeighPosition(lng, lat, disStr);
                if (dw_list != null)
                {
                    dw_list = dw_list.Where(n => n.latitude > obj.MinLat && n.latitude < obj.MaxLat).ToList();
                    dw_list = dw_list.Where(n => n.longitude > obj.MinLng && n.longitude < obj.MaxLng).ToList();
                }
            }
            ArrayList list = new ArrayList();
            if (dw_list != null)
            {
                foreach (var item in dw_list)
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