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
using Scrum.Model;

namespace Scrum
{
    public partial class FormKanban : Form
    {
        PartView parteAFazer;
        PartView parteFazendo;
        PartView parteFeito;
        Sprint sprint;

        public FormKanban()
        {
            InitializeComponent();

            sprint = new SprintMap().GetSprintAtual();
            lblSprint.Text = sprint.Descricao;

            parteAFazer = new PartView(new PartRegraKanban(sprint, "A Fazer"), "A Fazer");
            parteAFazer.Parent = pnlAFazer;

            parteFazendo = new PartView(new PartRegraKanban(sprint, "Fazendo"), "Fazendo");
            parteFazendo.Parent = pnlFazendo;

            parteFeito = new PartView(new PartRegraKanban(sprint, "Feito"), "Feito");
            parteFeito.Parent = pnlFeito;
        }

        private void btnToFazendo_Click(object sender, EventArgs e) 
        {
            PartView.Transferir(parteAFazer, parteFazendo);
        }

        private void btnToAFazer_Click(object sender, EventArgs e)
        {
            PartView.Transferir(parteFazendo, parteAFazer);
        }

        private void btnToFeito_Click(object sender, EventArgs e)
        {
            PartView.Transferir(parteFazendo, parteFeito);
        }
        private void btnToFazendoB_Click(object sender, EventArgs e)
        {
            PartView.Transferir(parteFeito, parteFazendo);
        }

        private void pnlAFazer_Enter(object sender, EventArgs e)
        {
            btnToFazendo.BringToFront();
        }

        private void pnlFazendo_Enter(object sender, EventArgs e)
        {
            btnToAFazer.BringToFront();
            btnToFeito.BringToFront();
        }

        private void pnlFeito_Enter(object sender, EventArgs e)
        {
            btnToFazendoB.BringToFront();
        }
    }

    public class PartRegraKanban : IPartRegra
    {
        private Sprint sprint;
        private String status;

        public PartRegraKanban(Sprint sprint, String status)
        {
            this.sprint = sprint;
            this.status = status;
        }

        public void Alterar(Tarefa tarefa)
        {
            tarefa.Status = this.status;
        }

        public Junction GetCondicaoWhere() //### precisa estar dentro da DAO.GetListaTarefa(sprint, status) | o Control vai fazer a chamada deste método
        {
            var condicao = Restrictions.Conjunction();
            condicao.Add(Restrictions.Eq(Projections.Property<Tarefa>(t => t.Sprint.IdSprint), sprint.IdSprint));
            condicao.Add(Restrictions.Eq(Projections.Property<Tarefa>(t => t.Status), status));
            return (condicao);
        }
    }
}
