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
            var entities = new org_info_connection1();
            var ac_list = entities.ac_org.ToList();
            var fd_list = entities.food_org.ToList();
            var org_list = new Org_viewModel();
            org_list.Ac = ac_list;
            org_list.Fd = fd_list;
            GenerateJson(ac_list);

            return View("Map","mapLayout",org_list);
        }

        public void GenerateJson(List<ac_org> aList)
        {
            String json = JsonConvert.SerializeObject(aList.ToArray());
            System.IO.File.WriteAllText(@"F:\ac_location.txt", json);
        }
    }
}