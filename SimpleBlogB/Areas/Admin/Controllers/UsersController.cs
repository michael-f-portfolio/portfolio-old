using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using SimpleBlogB.Areas.Admin.ViewModels;
using SimpleBlogB.Infrastructure;
using SimpleBlogB.Models;

namespace SimpleBlogB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("users")]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(new UsersIndex()
            {
                Users = Database.Session.Query<User>().ToList()
            });
        }

        public ActionResult New()
        {
            return View(new UsersNew()
            {
                // Get all roles from database and place them in a List
                Roles = Database.Session.Query<Role>().Select(role => new RoleCheckbox
                {
                    Id = role.Id,
                    IsChecked = false,
                    Name = role.Name
                }).ToList()
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(UsersNew form)
        {
            var user = new User();

            // 
            SyncRoles(form.Roles, user.Roles);

            // If username is not unique, throw error
            if(Database.Session.Query<User>().Any(u => u.Username == form.Username))
                ModelState.AddModelError("Username", "Username must be unique");

            // If form is invalid, return to form
            if(!ModelState.IsValid)
                return View(form);

            // Instantiate User object based on form
            user.Email = form.Email;
            user.Username = form.Username;

            // Generate password hash
            user.SetPassword(form.Password);

            // Write user to database
            Database.Session.Save(user);

            // Return to index
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            // Get user from database based on ID
            var user = Database.Session.Load<User>(id);

            // If no user found return 404
            if (user == null) return HttpNotFound();

            // Return to View:Edit with form populated based on user
            return View(new UsersEdit
            {
                Username = user.Username,
                Email = user.Email,
                Roles = Database.Session.Query<Role>().Select(role => new RoleCheckbox
                 {
                     Id = role.Id,
                     IsChecked = user.Roles.Contains(role),
                     Name = role.Name
                 }).ToList()
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsersEdit form)
        {
            // Get user from database based on ID
            var user = Database.Session.Load<User>(id);

            // If no user found, return 404
            if (user == null) return HttpNotFound();

            SyncRoles(form.Roles, user.Roles);

            // If username is not unique and has a different ID, throw error
            if(Database.Session.Query<User>().Any(u => u.Username == form.Username && u.Id != id))
                ModelState.AddModelError("Username", "Username must be unique");

            // If form is invalid, return to form
            if (!ModelState.IsValid) return View(form);

            // Set username as new username
            user.Username = form.Username;

            // Set email as new email
            user.Email = form.Email;

            // Update user in database
            Database.Session.Update(user);

            // Return to index
            return RedirectToAction("index");
        }

        public ActionResult ResetPassword(int id)
        {
            // Get user from database based on ID
            var user = Database.Session.Load<User>(id);

            // If user not found, return 404
            if (user == null) return HttpNotFound();

            // Return to View:ResetPassword with username
            return View(new UsersResetPassword
            {
                Username = user.Username
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ResetPassword(int id, UsersResetPassword form)
        {
            // Get user from database based on ID
            var user = Database.Session.Load<User>(id);

            // If user not found, return 404
            if (user == null) return HttpNotFound();

            // Set form username == username of user retrieved from database
            form.Username = user.Username;

            // If form is invalid, return to form
            if (!ModelState.IsValid) return View(form);

            // Hash new password
            user.SetPassword(form.Password);

            // Update user in database
            Database.Session.Update(user);

            // Return to index
            return RedirectToAction("index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            // Get user from database based on ID
            var user = Database.Session.Load<User>(id);

            // If user not found, return 404
            if (user == null) return HttpNotFound();

            // Delete user from database
            Database.Session.Delete(user);

            // Return to index
            return RedirectToAction("index");
        }

        private void SyncRoles(IList<RoleCheckbox> checkboxes, IList<Role> roles)
        {
            var selectedRoles = new List<Role>();

            // For each role within the database
            foreach (var role in Database.Session.Query<Role>())
            {
                // Get the ID and assign it
                var checkbox = checkboxes.Single(c => c.Id == role.Id);
                
                // Assign the name
                checkbox.Name = role.Name;

                // If checked, add to selectedRoles[]
                if(checkbox.IsChecked)
                    selectedRoles.Add(role);
            }

            // Add roles
            foreach (var toAdd in selectedRoles.Where(t => !roles.Contains(t)))
                roles.Add(toAdd);

            // Remove roles
            foreach (var toRemove in roles.Where(t => !selectedRoles.Contains(t)).ToList())
                roles.Remove(toRemove);


        }
    }
}