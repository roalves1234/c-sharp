using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.Loader.Entity;
using Scrum.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using ScrumValidacao;
using System.Runtime.ConstrainedExecution;

namespace Scrum
{
    public partial class PartView : UserControl
    {
        private PartPresenter presenter;
        private Color CorSelecionado = Color.Yellow;
        private Color CorNormal = Color.White;
        public PartView()
        {
            InitializeComponent();
        }

        public PartView SetPresenter(PartPresenter value)
        {
            presenter = value;
            return (this);
        }
        public PartView SetTitulo(string value)
        {
            lblTitulo.Text = value;
            return (this);
        }
        public PartView SetPontos(int value)
        {
            lblPontos.Text = value.ToString();
            return (this);
        }
        public PartView SetBindGrid(object value)
        {
            grid.DataSource = value;
            return (this);
        }
        public void DoInicializarVisual()
        {
            Dock = DockStyle.Fill;

            new ManipulacaoGrid(grid)
                .RedimensionarColunas()
                .SetNomeColuna("Descricao")
                .SetTamanho(200);

            DoDefinirCorSelecionado(false);
        }
        public void GoUltimaLinhaGrid()
        {
            grid.Focus();
            grid.CurrentCell = grid[0, grid.Rows.Count - 1];
        }
        public void DefinirCorSelecionado(Color cor)
        {
            DataGridViewCellStyle estilo = new DataGridViewCellStyle();
            estilo.SelectionBackColor = cor;
            estilo.SelectionForeColor = Color.Black;
            grid.RowTemplate.DefaultCellStyle = estilo;

            foreach (DataGridViewRow row in grid.Rows)
                row.DefaultCellStyle = estilo;
        }
        public void DoDefinirCorSelecionado(Boolean ehSelecionado)
        {
            if (ehSelecionado)
                DefinirCorSelecionado(CorSelecionado);
            else
                DefinirCorSelecionado(CorNormal);
        }
        private void grid_SelectionChanged(object sender, EventArgs e)
        {          
            if ((grid.SelectedRows.Count > 0) && (grid.SelectedRows[0].DataBoundItem != null))
                presenter.SetObjetoAtualGrid(grid.SelectedRows[0].DataBoundItem);
            else
                presenter.SetObjetoAtualGrid(null);
        }

        private void grid_Enter(object sender, EventArgs e)
        {
            DoDefinirCorSelecionado(true);
        }

        private void grid_Leave(object sender, EventArgs e)
        {
            DoDefinirCorSelecionado(false);
        }
    }
}
