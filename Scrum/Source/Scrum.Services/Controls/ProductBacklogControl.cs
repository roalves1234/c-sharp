using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Scrum.Model;
using Scrum;
using System.ComponentModel;
using System.Windows.Forms;
using NHibernate.Criterion;

namespace Scrum
{
    public class ProductBacklogControl
    {
        private Tarefa tarefaAtual;
        private IList<Tarefa> listaTarefa;
        private DaoTarefa Dao;
        public ProductBacklogControl()
        {
            this.Dao = new DaoTarefa();
            this.ListarRegistro();
        }
        private void ListarRegistro()
        {
            listaTarefa = Dao.ObterLista(Restrictions.Disjunction().Add(Restrictions.Eq(Projections.Property<Tarefa>(t => t.Sprint.IdSprint), null)));
        }
        public IList<Tarefa> ListaTarefa
        {
            get { return listaTarefa; }
        }
        public Tarefa TarefaAtual
        {
            get { return (tarefaAtual); }
            private set { tarefaAtual = value; }
        }
        public void SalvarTarefaAtual()
        {
            Dao.Persistir(tarefaAtual);

            if ((listaTarefa.Last() != null) && (!listaTarefa.Last().Existe))
                listaTarefa.Remove(listaTarefa.Last());

            if (!listaTarefa.Contains(tarefaAtual))
                listaTarefa.Add(tarefaAtual);
        }
        public void EliminarTarefaAtual()
        {
            Dao.Eliminar(tarefaAtual);
            listaTarefa.Remove(tarefaAtual);
        }
        public ProductBacklogControl SetTarefaAtual(Tarefa value)
        {
            tarefaAtual = value;
            return (this);
        }
        public void DoNovaTarefa()
        {
            SetTarefaAtual(new Tarefa());
        }
    }
}