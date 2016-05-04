using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using SimpleBlogB.Areas.Admin.ViewModels;
using SimpleBlogB.Infrastructure;
using SimpleBlogB.Infrastructure.Extensions;
using SimpleBlogB.Models;

namespace SimpleBlogB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("posts")]
    public class PostsController : Controller
    {
        private const int PostsPerPage = 10;

        // GET: Admin/Posts
        public ActionResult Index(int page = 1)
        {
            // SELECT COUNT(*) FROM posts;
            var totalPostCount = Database.Session.Query<Post>().Count();

            var baseQuery = Database.Session.Query<Post>().OrderByDescending(f => f.CreatedAt);

            var postIds = baseQuery
                .Skip((page - 1) * PostsPerPage)
                .Take(PostsPerPage)
                .Select(p => p.Id)
                .ToArray();

            // SELECT * FROM posts
            // ORDER BY created_at DESC;
            // Skip all previous pages * # posts per page
            // Take all posts based on PostsPerPage const
            var currentPostPage = baseQuery
                .Where(p => postIds.Contains(p.Id))
                .FetchMany(f => f.Tags)
                .Fetch(f => f.User)
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
                IsNew = true, 
                Tags = Database.Session.Query<Tag>().Select(tag => new TagCheckbox
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    IsChecked = false
                }).ToList()
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
                Title =  post.Title,
                Tags = Database.Session.Query<Tag>().Select(tag => new TagCheckbox
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    IsChecked = post.Tags.Contains(tag)
                }).ToList()
            });
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Form(PostsForm form)
        {
            // If form doesn't have a PostId it is new
            form.IsNew = form.PostId == null;

            // If form is invalid, return to form
            if (!ModelState.IsValid)
                return View(form);

            // Get all tags selected from the form
            var selectedTags = ReconsileTags(form.Tags).ToList();

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

                // Foreach tag that has been selected, add it to the Tags within the Post
                foreach (var tag in selectedTags)
                    post.Tags.Add(tag);
            }
            // Else get post based on PostId from database (Editing)
            else
            {
                post = Database.Session.Load<Post>(form.PostId);

                // If not found, return 404
                if (post == null)
                    return HttpNotFound();

                // Set UpdatedAt as current time
                post.UpdatedAt = DateTime.UtcNow;

                // Foreach new tag added to the edited post, add it to the Tags within the Post
                foreach (var toAdd in selectedTags.Where(t => !post.Tags.Contains(t)))
                    post.Tags.Add(toAdd);

                // Foreach tag removed from the edited post, remove it from the Tags within the Post
                foreach (var toRemove in post.Tags.Where(t => !selectedTags.Contains(t)).ToList())
                    post.Tags.Remove(toRemove);
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

        private IEnumerable<Tag> ReconsileTags(IEnumerable<TagCheckbox> tags)
        {
            // Foreach tag that is checked
            foreach (var tag in tags.Where(t => t.IsChecked))
            {
                // If the tag has an ID
                if (tag.Id != null)
                {
                    // Find it in the database, then yield return
                    yield return Database.Session.Load<Tag>(tag.Id);
                    continue;   
                }

                // Else find a tag in the database with the same name
                var existingTag = Database.Session.Query<Tag>().FirstOrDefault(t => t.Name == tag.Name);

                // If found, yield return
                if (existingTag != null)
                {
                    yield return existingTag;
                    continue;
                }

                // No matching tags have been found, create a new tag
                var newTag = new Tag
                {
                    Name = tag.Name,
                    // Slugify the tag name
                    Slug = tag.Name.Slugify()
                };

                // Persist to the database
                Database.Session.Save(newTag);

                // yield return the newly created tag
                yield return newTag;
            }
        }
    }
}