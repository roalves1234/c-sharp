using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.Criterion;
using Scrum;
using ScrumMap;
using ScrumNamespace;

namespace Scrum
{
    public partial class Form3 : Form
    {
        public IList<Sprint> listaSprint;
        public IList<Tarefa> listaTarefa;

        public Form3()
        {
            InitializeComponent();
            listarRegistro();
        }
        private void listarRegistro()
        {
            using (var session = ConexaoBanco.getInstance().NewSession())
            {
                listaTarefa = session.QueryOver<Tarefa>()
                    .OrderBy(t => t.IdTarefa).Asc
                    .List();

                listaSprint = session.QueryOver<Sprint>()
                    .OrderBy(s => s.IdSprint).Asc
                    .List();

                //var i = listaSprint.Count - 3;
                //MessageBox.Show(listaSprint[i].IdSprint.ToString() + " | " + listaSprint[i].SprintTarefas[0].Tarefa.IdTarefa.ToString());
            }
        }
        private void inserirRegistro()
        {
            using (var session = ConexaoBanco.getInstance().NewSession())
            {
                session.Save(this.Adicionar());
                //ligacao.ResetBindings();
            }
        }
        private Sprint Adicionar()
        {
            var novaSprint = new Sprint 
            {
                Descricao = "Sprint tal",
                Status = "Planejamento"
            };

            //novaSprint.Tarefas.Add(listaTarefa[0]);
            SprintTarefa sprintTarefa = new SprintTarefa();
            sprintTarefa.Sprint = novaSprint;
            sprintTarefa.Tarefa = listaTarefa[1];
            novaSprint.SprintTarefas.Add(sprintTarefa);

            listaSprint.Add(novaSprint);
            //ligacao.ResetBindings();

            return (novaSprint);
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            inserirRegistro();
        }
    }

}