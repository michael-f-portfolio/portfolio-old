using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SimpleBlogB.ViewModels;

namespace SimpleBlogB.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        // POST: Auth
        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            // If not valid
            if (!ModelState.IsValid)
                return View(form);
            
            // Set authentication cookie (for login)
            FormsAuthentication.SetAuthCookie(form.Username, true);

            // If returnUrl is set
            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            // Else redirect back to home page
            else
                return RedirectToRoute("home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToRoute("home");
        }
    }
}