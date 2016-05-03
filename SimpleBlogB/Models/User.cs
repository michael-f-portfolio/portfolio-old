using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlogB.Models
{
    public class User
    {
        // Must be virtual for nHibernate to use class
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }
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
        }
    }
}