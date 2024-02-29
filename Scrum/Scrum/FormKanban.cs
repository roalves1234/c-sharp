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
        PartPresenter parteAFazer;
        PartPresenter parteFazendo;
        PartPresenter parteFeito;

        public FormKanban()
        {
            InitializeComponent();

            parteAFazer = new PartPresenter(new PartView(), new PartControl(new PartRegraKanban(Ambiente.GetInstance().SprintAtual, "A Fazer")), "A Fazer").SetParent(pnlAFazer);
            parteFazendo = new PartPresenter(new PartView(), new PartControl(new PartRegraKanban(Ambiente.GetInstance().SprintAtual, "Fazendo")), "Fazendo").SetParent(pnlFazendo);
            parteFeito = new PartPresenter(new PartView(), new PartControl(new PartRegraKanban(Ambiente.GetInstance().SprintAtual, "Feito")), "Feito").SetParent(pnlFeito);
        }

        private void btnToFazendo_Click(object sender, EventArgs e) 
        {
            parteAFazer.TransferirPara(parteFazendo);
        }

        private void btnToAFazer_Click(object sender, EventArgs e)
        {
            parteFazendo.TransferirPara(parteAFazer);
        }

        private void btnToFeito_Click(object sender, EventArgs e)
        {
            parteFazendo.TransferirPara(parteFeito);
        }
        private void btnToFazendoB_Click(object sender, EventArgs e)
        {
            parteFeito.TransferirPara(parteFazendo);
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
        public Junction GetCondicaoWhere() //### precisa estar dentro da Dao.GetListaTarefa(sprint, status) | o Control vai fazer a chamada deste método
        {
            var condicao = Restrictions.Conjunction();
            condicao.Add(Restrictions.Eq(Projections.Property<Tarefa>(t => t.Sprint.IdSprint), sprint.IdSprint));
            condicao.Add(Restrictions.Eq(Projections.Property<Tarefa>(t => t.Status), status));
            return (condicao);
        }
    }
}
