using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Scrum.Model;
using Scrum;
using System.ComponentModel;
using NHibernate.Criterion;

namespace Scrum
{
    public class SprintControl
    {
        private Sprint sprintAtual;
        private IList<Sprint> listaSprint;
        private DaoSprint Dao;
        public SprintControl()
        {
            this.Dao = new DaoSprint();
            this.ListarRegistro();
        }
        private void ListarRegistro()
        {
            listaSprint = Dao.ObterLista(Restrictions.Disjunction().Add(Restrictions.Eq(Projections.Property<Sprint>(t => t.IdSprint), Ambiente.GetInstance().SprintAtual.IdSprint)));
        }
        public IList<Sprint> ListaSprint
        {
            get { return listaSprint; }
        }
        public Sprint SprintAtual
        {
            get { return (sprintAtual); }
        }
        public void SalvarSprintAtual()
        {
            Dao.Persistir(sprintAtual);

            if ((listaSprint.Last() != null) && (!listaSprint.Last().Existe))
                listaSprint.Remove(listaSprint.Last());

            if (!listaSprint.Contains(sprintAtual))
                listaSprint.Add(sprintAtual);
        }
        public void EliminarSprintAtual()
        {
            Dao.Eliminar(sprintAtual);
            listaSprint.Remove(sprintAtual);
        }
        public void ConverterEmTarefa()
        {
            new DaoTarefa().Persistir(new Tarefa("Sprint: " + sprintAtual.Descricao));
            this.EliminarSprintAtual();
        }
        public SprintControl SetSprintAtual(Sprint value)
        {
            sprintAtual = value;
            return (this);
        }
        public void DoNovaSprint()
        {
            var sprint = new Sprint();
            SetSprintAtual(sprint);
        }
    }
}