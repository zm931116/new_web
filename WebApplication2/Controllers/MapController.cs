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

        public ActionResult Ajax_SelData(string str)
        {
            if (str != "0")
            {
                var entities = new feed_your_soulEntities();

                var ac_list = entities.ac_org.Where(n => n.org_name.Contains(str) || n.org_address.Contains(str) || n.org_condition.Contains(str) || n.available_time.Contains(str)).ToList();
                var fd_list = entities.food_org.Where(n => n.org_name.Contains(str) || n.org_address.Contains(str) || n.org_condition.Contains(str) || n.available_time.Contains(str)).ToList();

                /*if (str == "Free Meals")
                {
                    ac_list = null;
                    fd_list = entities.food_org.ToList();
                }
                if (str == "Accommodation")
                {
                    ac_list = entities.ac_org.ToList();
                    fd_list = null;
                }*/
                if (str == "1")
                {
                    ac_list = null;
                    fd_list = entities.food_org.ToList();
                }
                if (str == "2")
                {
                    fd_list = null;
                    ac_list = entities.ac_org.ToList();
                }
                if (str == "3")
                {
                    ac_list = entities.ac_org.ToList();
                    fd_list = entities.food_org.ToList();
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

                String acStr = GenerateJson(ac_list);
                String fdStr = GenerateJson(fd_list);
                return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var entities = new feed_your_soulEntities();
                ArrayList list = new ArrayList();
                var ac_list = entities.ac_org.ToList();
                var fd_list = entities.food_org.ToList();
                foreach (var item in ac_list)
                {
                    item.Type = "Accommodation";
                    list.Add(item);
                }
                foreach (var item in fd_list)
                {
                    item.Type = "Food";
                    list.Add(item);
                }
                return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}