using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlogB.Models;

namespace SimpleBlogB
{
    public static class Database
    {

        private const string SessionKey = "SimpleBlogB.Database.SessionKey";

        private static ISessionFactory _sessionFactory;

        public static ISession Session
        {
            get { return (ISession) HttpContext.Current.Items[SessionKey]; }
        }

        public static void Configure()
        {
            var config = new Configuration();

            // Configure the connection string
            // (Automatically found from web.config)
            config.Configure();

            // Add our mappings
            var mapper = new ModelMapper();
            
            // Add UserMap to mapper
            mapper.AddMapping<UserMap>();

            // Add mapper to config
            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            // Create session factory
            _sessionFactory = config.BuildSessionFactory();
        }

        public static void OpenSession()
        {

            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {
            // Get object from Items[SessionKey] that is of type ISession
            var session = HttpContext.Current.Items[SessionKey] as ISession;

            if (session != null)
                session.Close();
            
            // null propagation ??
            // session?.Close();

            // Remove SessionKey from Items[]
            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}