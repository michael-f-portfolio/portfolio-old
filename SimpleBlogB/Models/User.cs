using System.Collections.Generic;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlogB.Models
{
    public class User
    {
        private const int WorkFactor = 13;

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", WorkFactor);
        }

        // Must be virtual for nHibernate to use class
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }

        public virtual IList<Role> Roles { get; set; }

        public User()
        {
            // Instantiate to prevent NullReferenceException
            Roles = new List<Role>();
        }

        public virtual void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }

    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            // Declare table in database
            Table("users");

            // Declare the primary key, declare auto increment
            Id(x => x.Id, x => x.Generator(Generators.Identity));

            // Declare username column, declare not nullable
            Property(x => x.Username, x => x.NotNullable(true));

            // Declare email column, declare not nullable
            Property(x => x.Email, x => x.NotNullable(true));

            // Declare password column
            // Overwrite property name, declare NotNullable
            Property(x => x.PasswordHash, x =>
            {
                x.Column("password_hash");
                x.NotNullable(true);
            });

            Bag(x => x.Roles, x =>
            {
                // Tell nHibernate table name
                x.Table("role_users");
                // Tell nHibernate id of user
                x.Key(k => k.Column("user_id"));
                // Tell nHibernate role 
            }, x => x.ManyToMany(k => k.Column("role_id")));
        }
    }
}