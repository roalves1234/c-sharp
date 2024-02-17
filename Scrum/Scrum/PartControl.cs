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

namespace Scrum
{
    public class PartControl
    {
        private IPartRegra regra;
        private Tarefa tarefaAtual;
        private IList<Tarefa> listaTarefa;
        private DaoTarefa Dao;
        private void ListarRegistro()
        {
            listaTarefa = Dao.ObterLista(regra.GetCondicaoWhere());
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
        public PartControl(IPartRegra regra)
        {
            this.regra = regra;
            this.Dao = new DaoTarefa();
            this.ListarRegistro();
        }
        public PartControl SetTarefaAtual(Tarefa value)
        {
            tarefaAtual = value;
            return (this);
        }
        public void AdicionarTarefa(Tarefa tarefa)
        {
            regra.Alterar(tarefa);
            Dao.Persistir(tarefa);

            listaTarefa.Add(tarefa);
        }

        public void RemoverTarefaAtual()
        {
            Dao.Evitar(tarefaAtual);
            listaTarefa.Remove(tarefaAtual);
        }
    }
}
