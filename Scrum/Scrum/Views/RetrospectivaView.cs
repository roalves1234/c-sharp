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
    public partial class RetrospectivaView : Form
    {
        private RetrospectivaPresenter presenter;

        public RetrospectivaView()
        {
            InitializeComponent();
            pnlRegistro.BorderStyle = BorderStyle.FixedSingle;
        }
        public RetrospectivaView SetPresenter(RetrospectivaPresenter value)
        {
            presenter = value;
            return (this);
        }

        public void DoInicializarVisual()
        {
            Dock = DockStyle.Fill;

            new ManipulacaoGrid(grid)
                .RedimensionarColunas()
                .SetNomeColuna("Descricao")
                .SetTamanho(200);
        }
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
                if (grid.SelectedRows[0].DataBoundItem != null)
                    presenter.SetObjetoAtualGrid(grid.SelectedRows[0].DataBoundItem);
                else if (grid.SelectedRows[0].IsNewRow)
                    presenter.DoNovaRetrospectiva();
        }
        public RetrospectivaView SetBindGrid(object value)
        {
            grid.DataSource = value;
            return (this);
        }
        public RetrospectivaView SetBindDescricao(Binding value)
        {
            txtDescricao.DataBindings.Clear();
            txtDescricao.DataBindings.Add(value);
            return (this);
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            presenter.SalvarRetrospectivaAtual();
        }
        private void pnlRegistro_Enter(object sender, EventArgs e)
        {
            presenter.SetModoPersistencia();
        }
        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.DoNovaRetrospectiva();
        }
        public void ExibirPersistencia(bool sim)
        {
            btnSalvar.Visible = sim;
        }
        public void ExibirConverterTarefa(bool sim)
        {
            btnConverterTarefa.Visible = sim;
        }
        public void GoUltimaLinhaGrid()
        {
            if (grid.Rows.Count > 0)
                grid.CurrentCell = grid.Rows[grid.Rows.Count - 1].Cells[0];
            txtDescricao.Focus();
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a eliminação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                presenter.EliminarRetrospectivaAtual();
        }

        private void btnConverterTarefa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a conversão em tarefa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                presenter.ConverterEmTarefa();
        }
    }
}
