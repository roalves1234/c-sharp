using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Scrum.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scrum
{
    public partial class SprintView : Form
    {
        private SprintPresenter presenter;

        public SprintView()
        {
            InitializeComponent();
            pnlRegistro.BorderStyle = BorderStyle.FixedSingle;
        }
        public SprintView SetPresenter(SprintPresenter value)
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
                    presenter.DoNovaSprint();
        }
        public SprintView SetBindGrid(object value)
        {
            grid.DataSource = value;
            return (this);
        }
        public SprintView SetBindDescricao(Binding value)
        {
            txtDescricao.DataBindings.Clear();
            txtDescricao.DataBindings.Add(value);
            return (this);
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            presenter.SalvarSprintAtual();
        }
        private void pnlRegistro_Enter(object sender, EventArgs e)
        {
            presenter.SetModoPersistencia();
        }
        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.DoNovaSprint();
        }
        public void ExibirPersistencia(bool sim)
        {
            btnSalvar.Visible = sim;
        }
        public void GoUltimaLinhaGrid()
        {
            if (grid.Rows.Count > 0)
                grid.CurrentCell = grid.Rows[grid.Rows.Count - 1].Cells[0];
            txtDescricao.Focus();
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não é possível eliminar uma Sprint ativa");
        }
    }
}
