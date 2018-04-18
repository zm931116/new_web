using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult map()
        {
            return View();
        }
    }
}