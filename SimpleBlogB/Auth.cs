using System.Dynamic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using SimpleBlogB.Models;

namespace SimpleBlogB
{
    public static class Auth
    {
        private const string UserKey = "SimpleBlogB.Auth.UserKey";

        // Gets the currently l
        public static User User
        {
            get
            {
                // If user is not logged in, return null;
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    return null;

                // Get a user from Items[UserKey]
                var user = HttpContext.Current.Items[UserKey] as User;

                // If user is null
                if (user == null)
                {
                    // Get user from database matching HttpContext.Current.User.Identity.Name
                    user = Database.Session.Query<User>()
                        .FirstOrDefault(u => u.Username == HttpContext.Current.User.Identity.Name);

                    // If user is still null, return null
                    if (user == null)
                        return null;

                    // Set Items[UserKey] as retrived user
                    HttpContext.Current.Items[UserKey] = user;
                }

                return user;
            }
        }
    }
}