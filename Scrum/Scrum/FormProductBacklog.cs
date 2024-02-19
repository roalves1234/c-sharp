using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Scrum.Model;
using ScrumValidacao;

namespace Scrum
{
    public partial class FormProductBacklog : Form
    {
        private IList<Tarefa> listaTarefa;
        private BindingList<Tarefa> bindGrid;
        private Tarefa tarefaAtual;
        private ISession session;

        public FormProductBacklog()
        {
            InitializeComponent();
        
            session = ConexaoBanco.getInstance().NewSession();

            this.ListarRegistro();
        }

        private void ListarRegistro()
        {
            listaTarefa = session
                             .QueryOver<Tarefa>()
                             .Where(Restrictions.Disjunction().Add(Restrictions.Eq(Projections.Property<Tarefa>(t => t.Sprint.IdSprint), null)))
                             .OrderBy(t => t.IdTarefa).Asc
                             .List();

            grid.DataSource = (bindGrid = new BindingList<Tarefa>(listaTarefa));

            new ManipulacaoGrid(grid)
                .RedimensionarColunas()
                .SetNomeColuna("Descricao")
                .SetTamanho(200);
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if ((grid.SelectedRows.Count > 0) && (grid.SelectedRows[0].DataBoundItem != null) && (grid.SelectedRows[0].DataBoundItem.GetType() == typeof(Tarefa)))
                tarefaAtual = (grid.SelectedRows[0].DataBoundItem as Tarefa);
            else
                tarefaAtual = new Tarefa();

            if (btnSalvar.Visible)
                DoSalvar();

            DoEditBind();
        }

        private void DoEditBind()
        {
            txtDescricao.DataBindings.Clear();
            numPontuacao.DataBindings.Clear();

            txtDescricao.DataBindings.Add("Text", tarefaAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged);
            numPontuacao.DataBindings.Add("value", tarefaAtual, "Pontuacao", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void DoSalvar()
        {
            new TarefaValidacao(tarefaAtual).Execute();

            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.SaveOrUpdate(tarefaAtual);
                    transacao.Commit();
                }
                catch 
                {
                    transacao.Rollback();
                    throw;
                }

            btnSalvar.Hide();
            grid.Focus();

            if (!listaTarefa.Contains(tarefaAtual))
            {
                listaTarefa.Add(tarefaAtual);
                bindGrid.ResetBindings();
            }
        }
        
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DoSalvar();
        }

        private void pnlRegistro_Enter(object sender, EventArgs e)
        {
            btnSalvar.Show();
        }

        private void DoEliminarRegistro()
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.Delete(tarefaAtual);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }

            listaTarefa.Remove(tarefaAtual);
            bindGrid.ResetBindings();
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
                grid.CurrentCell = grid.Rows[grid.Rows.Count - 1].Cells[0];
            txtDescricao.Focus();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a eliminação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (tarefaAtual.IdTarefa != 0)
                    DoEliminarRegistro();
        }
    }
}
