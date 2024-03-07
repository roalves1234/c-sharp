﻿using System;
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

namespace Scrum
{
    public partial class ProductBacklogView : Form
    {
        private ProductBacklogPresenter presenter;

        public ProductBacklogView()
        {
            InitializeComponent();
        }
        public ProductBacklogView SetPresenter(ProductBacklogPresenter value)
        {
            presenter = value;
            return (this);
        }
        public void ExibirPersistencia(bool sim)
        {
            btnSalvar.Visible = sim;
        }
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
                if (grid.SelectedRows[0].DataBoundItem != null)
                    presenter.SetObjetoAtualGrid(grid.SelectedRows[0].DataBoundItem);
                else if (grid.SelectedRows[0].IsNewRow)
                    presenter.DoNovaTarefa();
        }
        public void DoInicializarVisual()
        {
            Dock = DockStyle.Fill;

            new ManipulacaoGrid(grid)
                .RedimensionarColunas()
                .SetNomeColuna("Descricao")
                .SetTamanho(200);
        }
        public ProductBacklogView SetBindGrid(object value)
        {
            grid.DataSource = value;
            return (this);
        }
        public ProductBacklogView SetBindDescricao(Binding value)
        {
            txtDescricao.DataBindings.Clear();
            txtDescricao.DataBindings.Add(value);
            return (this);
        }
        public ProductBacklogView SetBindPontuacao(Binding value)
        {
            numPontuacao.DataBindings.Clear();
            numPontuacao.DataBindings.Add(value);
            return (this);
        }       
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            presenter.SalvarTarefAtual();
        }
        private void pnlRegistro_Enter(object sender, EventArgs e)
        {
            presenter.SetModoPersistencia();
        }
        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.DoNovaTarefa();
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
                presenter.EliminarTarefaAtual();
        }
    }
}