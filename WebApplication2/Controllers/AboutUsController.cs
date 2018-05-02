using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        [Authorize]
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