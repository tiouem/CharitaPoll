using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharitaPoll.EF;
using CharitaPoll.Models;

namespace CharitaPoll.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Model1 = new Model1();
            Model1.Users.AddOrUpdate(
                new User()
                {
                    FirstName = "tomas",
                    LastName = "vit",
                    Username = "tomas",
                    Password = "Password",
                    Country =  "Czech",
                    DateCreated = DateTime.UtcNow,
                    Gender = "male"
                }
                );
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
