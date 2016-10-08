using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using CharitaPoll.EF;
using CharitaPoll.Models;

namespace CharitaPoll.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
