using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
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
            
            //intialize the view_model to load multiple models on the single view
            var org_list = new Org_viewModel();

            //assign the value into lists in org_list
            org_list.Ac = ac_list;
            org_list.Fd = fd_list;
            org_list.Pt = pt_list;
            org_list.Df = df_list;



            
            return View("Map","_Layout",org_list);
        }

        public String GenerateJson(List<ac_org> aList)
        {
            return JsonConvert.SerializeObject(aList.ToArray());
            /*String path = System.Web.Hosting.HostingEnvironment.MapPath("~/") + "Scripts/map/" + fileName;
            System.IO.File.WriteAllText(path, json);*/
        }

        public String GenerateJson(List<food_org> aList)
        {
            return JsonConvert.SerializeObject(aList.ToArray());
        }
    }
}