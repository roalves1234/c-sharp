using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernate;
using Scrum.Model;

namespace Scrum
{
    public class DaoRetrospectiva
    {
        private ISession session;
        public DaoRetrospectiva()
        {
            session = ConexaoBanco.getInstance().NewSession();
        }
        public IList<Retrospectiva> ObterLista(Junction condicao)
        {
            return (session
                        .QueryOver<Retrospectiva>()
                        .Where(condicao)
                        .OrderBy(t => t.IdRetrospectiva).Asc
                        .List());
        }
        public void Persistir(Retrospectiva retrospectiva)
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.SaveOrUpdate(retrospectiva);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
        }
        public void Eliminar(Retrospectiva retrospectiva)
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.Delete(retrospectiva);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
        }
        public void Evitar(Retrospectiva retrospectiva)
        {
            session.Evict(retrospectiva);
            session.Evict(retrospectiva.Sprint);
        }
    }
}