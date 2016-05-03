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
    [SelectedTab("posts")]
    public class PostsController : Controller
    {
        private const int PostsPerPage = 5;

        // GET: Admin/Posts
        public ActionResult Index(int page = 1)
        {
            // SELECT COUNT(*) FROM posts;
            var totalPostCount = Database.Session.Query<Post>().Count();

            // SELECT * FROM posts
            // ORDER BY created_at DESC;
            // Skip all previous pages * # posts per page
            // Take all posts based on PostsPerPage const
            var currentPostPage = Database.Session.Query<Post>()
                .OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * PostsPerPage)
                .Take(PostsPerPage)
                .ToList();

            return View(new PostsIndex
            {
                Posts = new PagedData<Post>(currentPostPage, totalPostCount, page, PostsPerPage)
            });
        }

        public ActionResult New()
        {
            return View("Form", new PostsForm
            {
                IsNew = true
            });
        }

        public ActionResult Edit(int id)
        {
            // Get post based on ID
            var post = Database.Session.Load<Post>(id);
            
            // If not found, return 404
            if (post == null)
                return HttpNotFound();

            // Return to view with populated PostsForm
            return View("Form", new PostsForm
            {
                IsNew = false,
                PostId = id,
                Content = post.Content,
                Slug = post.Slug,
                Title =  post.Title
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Form(PostsForm form)
        {
            // If form doesn't have a PostId it is new
            form.IsNew = form.PostId == null;

            // If form is invalid, return to form
            if (!ModelState.IsValid)
                return View(form);

            Post post;

            // If form is creating a new post
            if (form.IsNew)
            {
                // Assign the CreatedAt and User properties
                post = new Post()
                {
                    CreatedAt = DateTime.UtcNow,
                    User = Auth.User
                };
            }
            // Else get post based on PostId from database
            else
            {
                post = Database.Session.Load<Post>(form.PostId);

                // If not found, return 404
                if (post == null)
                    return HttpNotFound();

                // Set UpdatedAt as current time
                post.UpdatedAt = DateTime.UtcNow;
            }

            // Set properties based on form 
            post.Title = form.Title;
            post.Slug = form.Slug;
            post.Content = form.Content;

            // If entry exists update it, else create new entry
            Database.Session.SaveOrUpdate(post);

            // Return to index
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Trash(int id)
        {
            var post = Database.Session.Load<Post>(id);

            if(post == null)
                return HttpNotFound();

            post.DeletedAt = DateTime.UtcNow;
            Database.Session.Update(post);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var post = Database.Session.Load<Post>(id);

            if (post == null)
                return HttpNotFound();

            Database.Session.Delete(post);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Restore(int id)
        {
            var post = Database.Session.Load<Post>(id);

            if (post == null)
                return HttpNotFound();

            post.DeletedAt = null;
            Database.Session.Update(post);
            return RedirectToAction("Index");
        }
    }
}