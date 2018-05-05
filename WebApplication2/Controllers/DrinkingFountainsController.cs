using System;
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
    }
}