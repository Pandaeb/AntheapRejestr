using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntheapRejestr.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace AntheapRejestr.DBHelper
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        const string ConnectionString = @"data source=T430S\SQLEXPRESS; Initial Catalog=Antheap; Integrated Security=True;";
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()

             .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString).ShowSql())

             .Mappings(m => m.FluentMappings
             .AddFromAssemblyOf<Startup>())
             .ExposeConfiguration(cfg => new SchemaExport(cfg)
             .Create(false, false))
             .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
