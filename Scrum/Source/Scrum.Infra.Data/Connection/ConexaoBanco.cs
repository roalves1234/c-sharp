using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Scrum.Model;

namespace Scrum
{
    public class ConexaoBanco
    {
        private static ConexaoBanco instance = null;
        private ISessionFactory sessionFactory;

        public ConexaoBanco()
        {
            sessionFactory = Fluently
                                  .Configure()
                                  .Database(
                                        MsSqlConfiguration.MsSql2012.ConnectionString("Server=localhost;Database=Scrum;Integrated Security=True"))
                                       .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TarefaMap>())
                                  .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                                  .BuildSessionFactory();
        }
        public ISession NewSession()
        {
            return (sessionFactory.OpenSession());
        }
        public static ConexaoBanco getInstance()
        {
            if (instance == null)
                instance = new ConexaoBanco();
            return instance;
        }
    }
}
