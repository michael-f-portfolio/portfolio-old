using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleBlogB.Models;

namespace SimpleBlogB.Areas.Admin.ViewModels
{

    // These are the ViewModels associated with the Admin:User CRUD
    
    /// <summary>
    /// UsersIndex
    /// ViewModel for with displaying all users to the screen.
    /// </summary>
    public class UsersIndex
    {   
        // Make Users : IEnumerable so that it acts as a collection
        public IEnumerable<User> Users { get; set; }
    }

    /// <summary>
    /// UsersNew
    /// ViewModel for creating a new user.
    /// </summary>
    public class UsersNew
    {
        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    /// <summary>
    /// UsersEdit
    /// ViewModel for editing a user.
    /// </summary>
    public class UsersEdit
    {
        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    /// <summary>
    /// UsersResetPassword
    /// ViewModel for resetting a user's password.
    /// </summary>
    public class UsersResetPassword
    {
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}