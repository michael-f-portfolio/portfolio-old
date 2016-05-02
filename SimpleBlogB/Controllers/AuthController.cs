using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlogB.ViewModels;

namespace SimpleBlogB.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View(new AuthLogin()
            {
                
            });
        }

        // POST: Auth
        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            if (form.Username == "mike")
                return Content("Valid");

            ModelState.AddModelError("Username", "Username is not correct");

            return View(form);


            
        }
    }
}