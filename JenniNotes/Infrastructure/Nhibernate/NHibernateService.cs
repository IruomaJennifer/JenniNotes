using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using JenniNotes.Infrastructure.Nhibernate.Mappings;
using nh = NHibernate;
using System.Reflection;

namespace JenniNotes.Infrastructure.Nhibernate
{
    public class NHibernateService
    {
        public NHibernateService(string connectionString)
        {
            _connectionString = connectionString; 
        }
        public nh.ISessionFactory BuildSessionFactory()
        {
            var fluentConfiguration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ShowSql().DefaultSchema(_schema)
                                                      .ConnectionString(_connectionString))
                .Mappings(m=> m.FluentMappings.AddFromAssembly(typeof(NoteMapping).Assembly))
                .ExposeConfiguration(cfg=> cfg.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "120"))
                .BuildConfiguration();
            return fluentConfiguration.BuildSessionFactory();
        }
        public nh.ISession NewSession()
        {
            return BuildSessionFactory().OpenSession();
        }
        private readonly string _connectionString;
        private readonly string _schema;
    }
}
