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
    public partial class FormPlanejamentoSprint : Form //## este form trabalha com...
    {
        PartPresenter parteProductBacklog;
        PartPresenter parteSprintBacklog;

        public FormPlanejamentoSprint()
        {
            InitializeComponent();

            parteProductBacklog = new PartPresenter(new PartView(), new PartControl(new PartRegraPlanejamentoSprint(null)), "Product Backlog").SetParent(pnlProductBacklog);
            parteSprintBacklog = new PartPresenter(new PartView(), new PartControl(new PartRegraPlanejamentoSprint(Ambiente.GetInstance().SprintAtual)), "Sprint Backlog").SetParent(pnlSprintBacklog);
        }
        private void btnToSprintBacklog_Click(object sender, EventArgs e)
        {
            parteProductBacklog.TransferirPara(parteSprintBacklog); //## regra vinculada a view
        }
        private void btnToBacklog_Click(object sender, EventArgs e)
        {
            parteSprintBacklog.TransferirPara(parteProductBacklog); 
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
