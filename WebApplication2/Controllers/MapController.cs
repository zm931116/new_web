using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Map()
        {
            //initialize the models
            var entities = new feed_your_soulEntities();
            //turn each type of the entities into lists
            var ac_list = entities.ac_org.ToList();
            var fd_list = entities.food_org.ToList();
            var pt_list = entities.Public_toilets.ToList();
            var df_list = entities.Drinking_fountains.ToList();
            var cl_list = entities.Centrelink_Data.ToList();

            //intialize the view_model to load multiple models on the single view
            var org_list = new Org_viewModel();

            //assign the value into lists in org_list
            org_list.Ac = ac_list;
            org_list.Fd = fd_list;
            org_list.Pt = pt_list;
            org_list.Df = df_list;
            org_list.Cl = cl_list;




            return View("Map", "_Layout", org_list);
        }


        public ActionResult ac_list()
        {
            ViewData["alls"] = Session["all"];
            return PartialView();
        }

        public String GenerateJson(List<ac_org> aList)
        {
            if (aList == null)
            {
                return null;
            }
            else
            {
                return JsonConvert.SerializeObject(aList.ToArray());
            }
            /*String path = System.Web.Hosting.HostingEnvironment.MapPath("~/") + "Scripts/map/" + fileName;
            System.IO.File.WriteAllText(path, json);*/
        }

        public String GenerateJson(List<food_org> aList)
        {
            if (aList == null)
            {
                return null;
            }
            else
            {
                return JsonConvert.SerializeObject(aList.ToArray());
            }

        }

        public ActionResult Ajax_SelData(string seaStr, string cheStr, int disStr, string conStr, string dateStr)
        {
            var entities = new feed_your_soulEntities();
            List<ac_org> ac_list = entities.ac_org.ToList();
            List<food_org> fd_list = entities.food_org.ToList();
            if (cheStr != "0")
            {
                if (cheStr == "1")
                {
                    ac_list = null;
                    fd_list = entities.food_org.ToList();
                }
                if (cheStr == "2")
                {
                    fd_list = null;
                    ac_list = entities.ac_org.ToList();
                }
            }
            if (conStr != "0")
            {
                if (ac_list != null)
                {
                    ac_list = ac_list.Where(n => n.org_condition.ToLower().Contains(conStr.ToLower())).ToList();
                }
                if (fd_list != null)
                {
                    fd_list = fd_list.Where(n => n.org_condition.ToLower().Contains(conStr.ToLower())).ToList();
                }
            }
            if (dateStr != "0")
            {
                if (ac_list != null)
                {
                    var lists = ac_list.Where(n => n.available_time != null);
                    if (dateStr == "weekday")
                    {
                        ac_list = lists.Where(n => n.available_time.ToLower().Contains("mon") || n.available_time.ToLower().Contains("tues") || n.available_time.ToLower().Contains("wed") || n.available_time.ToLower().Contains("thur") || n.available_time.ToLower().Contains("fri")).ToList();
                    }
                    if (dateStr == "weekend")
                    {
                        ac_list = lists.Where(n => n.available_time.ToLower().Contains("sat") || n.available_time.ToLower().Contains("sun")).ToList();
                    }
                }
                if (fd_list != null)
                {
                    var lists = fd_list.Where(n => n.available_time != null);
                    if (dateStr == "weekday")
                    {
                        fd_list = lists.Where(n => n.available_time.ToLower().Contains("mon") || n.available_time.ToLower().Contains("tues") || n.available_time.ToLower().Contains("wed") || n.available_time.ToLower().Contains("thur") || n.available_time.ToLower().Contains("fri")).ToList();
                    }
                    if (dateStr == "weekend")
                    {
                        fd_list = lists.Where(n => n.available_time.ToLower().Contains("sat") || n.available_time.ToLower().Contains("sun")).ToList();
                    }
                }
            }
            if (disStr != 0)
            {
                double lat = double.Parse(Session["lat"].ToString());
                double lng = double.Parse(Session["lng"].ToString());
                PositionModel obj = DistanceHelper.FindNeighPosition(lng, lat, disStr);
                if (ac_list != null)
                {
                    ac_list = ac_list.Where(n => n.latitude > obj.MinLat && n.latitude < obj.MaxLat).ToList();
                    ac_list = ac_list.Where(n => n.longitude > obj.MinLng && n.longitude < obj.MaxLng).ToList();
                }
                if (fd_list != null)
                {
                    fd_list = fd_list.Where(n => n.latitude > obj.MinLat && n.latitude < obj.MaxLat).ToList();
                    fd_list = fd_list.Where(n => n.longitude > obj.MinLng && n.longitude < obj.MaxLng).ToList();
                }
            }
            if (seaStr != null && seaStr != "")
            {
                if (ac_list != null)
                {
                    var lists = ac_list.Where(n => n.org_name.ToLower().Contains(seaStr.ToLower()) || n.org_address.ToLower().Contains(seaStr.ToLower()) || n.org_condition.ToLower().Contains(seaStr.ToLower()));

                    if (lists != null)
                    {
                        var lis = lists.ToList();
                        var listss = ac_list.Where(n => n.available_time != null && n.available_time.ToLower().Contains(seaStr.ToLower()));
                        if (listss != null)
                        {
                            foreach (var item in listss)
                            {
                                lis.Add(item);
                            }

                        }
                        ac_list = lis.ToList();
                    }
                    else
                    {
                        ac_list = null;
                    }
                }
                if (fd_list != null)
                {
                    var lists = fd_list.Where(n => n.org_name.ToLower().Contains(seaStr.ToLower()) || n.org_address.ToLower().Contains(seaStr.ToLower()) || n.org_condition.ToLower().Contains(seaStr.ToLower()));
                    if (lists != null)
                    {
                        var lis = lists.ToList();
                        var listss = fd_list.Where(n => n.available_time != null && n.available_time.ToLower().Contains(seaStr.ToLower()));
                        if (listss != null)
                        {
                            foreach (var item in listss)
                            {
                                lis.Add(item);
                            }

                        }
                        fd_list = lis.ToList();
                    }
                    else
                    {
                        fd_list = null;
                    }
                }
            }
            ArrayList list = new ArrayList();
            if (ac_list != null)
            {
                foreach (var item in ac_list)
                {
                    item.Type = "Accommodation";
                    list.Add(item);
                }
            }
            if (fd_list != null)
            {
                foreach (var item in fd_list)
                {
                    item.Type = "Food";
                    list.Add(item);
                }
            }
            Session["all"] = list;
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