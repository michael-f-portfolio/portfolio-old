using SimpleBlogB.Infrastructure;
using SimpleBlogB.Models;

namespace SimpleBlogB.Areas.Admin.ViewModels
{
    // {controller}{action}
    public class PostsIndex
    {
        public PagedData<Post> Posts { get; set; }
    }
}