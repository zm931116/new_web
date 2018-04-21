using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult getHtmlPage(String path)
        {
            return new FilePathResult(path, "text/html");
        }



    }
}
