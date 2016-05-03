using System.Collections.Generic;
using SimpleBlogB.Models;

namespace SimpleBlogB.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
        public IEnumerable<User> Users { get; set; }
    }
}