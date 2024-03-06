using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernate;
using Scrum.Model;
using FluentNHibernate.Conventions;

namespace Scrum
{
    public class DaoSprint
    {
        private ISession session;
        public DaoSprint()
        {
            session = ConexaoBanco.getInstance().NewSession();
        }
        public IList<Sprint> ObterLista(Junction condicao)
        {
            return (session
                        .QueryOver<Sprint>()
                        .Where(condicao)
                        .OrderBy(t => t.IdSprint).Asc
                        .List());
        }
        public void Persistir(Sprint sprint)
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.SaveOrUpdate(sprint);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
        }
        public void Eliminar(Sprint sprint)
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.Delete(sprint);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
        }
        public void Evitar(Sprint sprint)
        {
            session.Evict(sprint);
        }
        public Sprint GetAtual()
        {
            string[] listaStatus = { "Planejamento", "Execucao" };
            Sprint sprint;
            var lista = this.ObterLista(Restrictions.Disjunction().Add(Restrictions.In(Projections.Property<Tarefa>(t => t.Status), listaStatus)));
            if (!lista.IsEmpty())
                sprint = lista.First();
            else
                sprint = new Sprint();

            return (sprint);
        }
    }
}
