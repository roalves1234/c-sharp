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
    public partial class FormPlanejamentoSprint : Form
    {
        PartView parteProductBacklog;
        PartView parteSprintBacklog;
        Sprint sprint;

        public FormPlanejamentoSprint()
        {
            InitializeComponent();

            sprint = new SprintMap().GetSprintAtual(); //## criação de model com a chamada a DAO
            lblSprint.Text = sprint.Descricao; //## atribuição do componente visual a partir da model

            parteProductBacklog = new PartView(new PartRegraPlanejamentoSprint(null), "Product Backlog");
            parteProductBacklog.Parent = pnlProductBacklog;

            parteSprintBacklog = new PartView(new PartRegraPlanejamentoSprint(sprint), "Sprint Backlog");
            parteSprintBacklog.Parent = pnlSprintBacklog;
        }

        private void btnToSprintBacklog_Click(object sender, EventArgs e)
        {
            PartView.Transferir(parteProductBacklog, parteSprintBacklog); //## regra vinculada a view
        }

        private void btnToBacklog_Click(object sender, EventArgs e)
        {
            PartView.Transferir(parteSprintBacklog, parteProductBacklog); ç
        }

        private void pnlProductBacklog_Enter(object sender, EventArgs e)
        {
            btnToSprintBacklog.BringToFront();
        }

        private void pnlSprintBacklog_Enter(object sender, EventArgs e)
        {
            btnToBacklog.BringToFront();
        }
    }
    public class PartRegraPlanejamentoSprint : IPartRegra 
    {
        private Sprint sprint;

        public PartRegraPlanejamentoSprint(Sprint sprint)
        {
            this.sprint = sprint;
        }

        public void Alterar(Tarefa tarefa)
        {
            tarefa.Sprint = sprint;
        }

        public Junction GetCondicaoWhere() //### regra de filtro de dataset a partir da model que foi passada
        {
            Object idSprint;
            if (sprint != null)
                idSprint = sprint.IdSprint;
            else
                idSprint = null;

            var condicao = Restrictions.Disjunction();
            condicao.Add(Restrictions.Eq(Projections.Property<Tarefa>(t => t.Sprint.IdSprint), idSprint));

            return (condicao);
        }
    }
}
