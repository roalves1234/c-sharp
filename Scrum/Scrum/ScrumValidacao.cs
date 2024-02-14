using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions;
using Scrum.Model;

namespace ScrumValidacao
{
    public class TarefaValidacao
    {
        private Tarefa tarefa;
        public TarefaValidacao(Tarefa tarefa) 
        {
            this.tarefa = tarefa;
        }
        public void Execute()
        {
            // informar validações aqui
        }

    }
}
