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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scrum
{
    public partial class FormRetrospectiva : Form
    {
        private IList<Retrospectiva> listaRetrospectiva;
        private BindingList<Retrospectiva> bindGrid;
        private Retrospectiva retrospectivaAtual;
        private ISession session;
        private Sprint sprint;

        public FormRetrospectiva()
        {
            InitializeComponent();
        
            session = ConexaoBanco.getInstance().NewSession();
            sprint = new SprintMap().GetSprintAtual();
            lblSprint.Text = sprint.Descricao;
            pnlRegistro.BorderStyle = BorderStyle.FixedSingle;

            this.ListarRegistro();
        }

        private void ListarRegistro()
        {
            listaRetrospectiva = session
                                     .QueryOver<Retrospectiva>()
                                     .Where(Restrictions.Disjunction().Add(Restrictions.Eq(Projections.Property<Retrospectiva>(t => t.Sprint.IdSprint), sprint.IdSprint)))
                                     .OrderBy(t => t.IdRetrospectiva).Asc
                                     .List();

            grid.DataSource = (bindGrid = new BindingList<Retrospectiva>(listaRetrospectiva));

            new ManipulacaoGrid(grid)
                .RedimensionarColunas()
                .SetNomeColuna("Descricao")
                .SetTamanho(200);
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if ((grid.SelectedRows.Count > 0) && (grid.SelectedRows[0].DataBoundItem != null) && (grid.SelectedRows[0].DataBoundItem.GetType() == typeof(Retrospectiva)))
                retrospectivaAtual = (grid.SelectedRows[0].DataBoundItem as Retrospectiva);
            else
            {
                retrospectivaAtual = new Retrospectiva();
                retrospectivaAtual.Sprint = this.sprint;
            }

            btnConverterTarefa.Visible = (retrospectivaAtual.IdRetrospectiva != 0);

            if (btnSalvar.Visible)
                DoSalvar();

            DoEditBind();
        }

        private void DoEditBind()
        {
            txtDescricao.DataBindings.Clear();
            txtDescricao.DataBindings.Add("Text", retrospectivaAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void DoSalvar()
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    session.SaveOrUpdate(retrospectivaAtual);
                    transacao.Commit();
                }
                catch 
                {
                    transacao.Rollback();
                    throw;
                }

            btnSalvar.Hide();
            grid.Focus();

            if (!listaRetrospectiva.Contains(retrospectivaAtual))
            {
                listaRetrospectiva.Add(retrospectivaAtual);
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
                    session.Delete(retrospectivaAtual);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }

            listaRetrospectiva.Remove(retrospectivaAtual);
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
                if (retrospectivaAtual.IdRetrospectiva != 0)
                    DoEliminarRegistro();
        }

        private void DoConverterTarefa()
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    var tarefa = new Tarefa();
                    tarefa.Descricao = "Retrospectiva: " + retrospectivaAtual.Descricao;
                    session.Save(tarefa);
                    session.Delete(retrospectivaAtual);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }

            listaRetrospectiva.Remove(retrospectivaAtual);
            bindGrid.ResetBindings();

        }

        private void btnConverterTarefa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a conversão em tarefa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DoConverterTarefa();
        }
    }
}
