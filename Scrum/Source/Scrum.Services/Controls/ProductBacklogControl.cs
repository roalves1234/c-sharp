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
        }
        public void SalvarTarefaAtual()
        {
            if ((tarefaAtual.Descricao == null) || (tarefaAtual.Descricao.Trim() == ""))
                throw new Exception("A descrição precisa estar preenchida");
            if (tarefaAtual.Pontuacao <= 0)
                throw new Exception("A pontuação precisa ser maior que zero");

            Dao.Persistir(tarefaAtual);

            if ((listaTarefa.Count != 0) && (!listaTarefa.Last().Existe))
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