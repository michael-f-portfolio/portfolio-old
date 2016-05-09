using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is where all the stuff about me will go.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "This is where all my contact information will go.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "This is where all the random things I decide to do go.";

            return View();
        }
    }
}