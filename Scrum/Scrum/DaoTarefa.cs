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
    public class DaoTarefa
    {
        private ISession session;
        public DaoTarefa()
        {
            session = ConexaoBanco.getInstance().NewSession();
        }
        public IList<Tarefa> ObterLista(Junction condicao)
        {
            return (session
                        .QueryOver<Tarefa>()
                        .Where(condicao)
                        .OrderBy(t => t.IdTarefa).Asc
                        .List());
        }
        public void Persistir(Tarefa tarefa)
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.SaveOrUpdate(tarefa);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
        }
        public void Eliminar(Tarefa tarefa)
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.Delete(tarefa);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
        }
        public void Evitar(Tarefa tarefa)
        {
            session.Evict(tarefa);
            session.Evict(tarefa.Sprint);
        }
    }
}