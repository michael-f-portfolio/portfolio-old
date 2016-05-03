using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NHibernate.Linq;
using SimpleBlogB.Models;
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
            // Find user in database or null if not found
            var user = Database.Session.Query<User>().FirstOrDefault(u => u.Username == form.Username);

            // If null, do a fake hash (prevent timing attack)
            if(user == null)
                SimpleBlogB.Models.User.FakeHash();
            
            // If user is not found or password is incorrect, throw error
            if (user == null || !user.CheckPassword(form.Password))
                ModelState.AddModelError("Username", "Username or password is incorrect");

            // If not valid, return form
            if (!ModelState.IsValid)
                return View(form);

            // Set authentication cookie (for login)
            FormsAuthentication.SetAuthCookie(user.Username, true);

            // If returnUrl is set
            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            // Else redirect back to home page
            return RedirectToRoute("home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToRoute("home");
        }
    }
}