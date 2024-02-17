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
    public interface IPartRegra
    {
        void Alterar(Tarefa tarefa);
        Junction GetCondicaoWhere();
    }

    public partial class PartView : UserControl
    {
        private Color CorSelecionado = Color.Yellow;
        private Color CorNormal = Color.White;
        private ISession session;
        private IList<Tarefa> listaTarefa;
        private IPartRegra regra;
        private BindingList<Tarefa> bindGrid;
        private Tarefa tarefaAtual;

        public PartView(IPartRegra regra, String titulo)
        {
            InitializeComponent();

            this.regra = regra;
            this.session = ConexaoBanco.getInstance().NewSession();
            this.ListarRegistro();
            this.Dock = DockStyle.Fill;
            lblTitulo.Text = titulo;
        }

        public Tarefa TarefaAtual { get { return tarefaAtual; } }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    regra.Alterar(tarefa);
                    session.Update(tarefa);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }

            listaTarefa.Add(tarefa);
            this.RefreshView();
            grid.Focus();
            grid.CurrentCell = grid[0, grid.Rows.Count - 1];
        }

        public void RemoverTarefaAtual()
        {
            session.Evict(tarefaAtual);
            listaTarefa.Remove(tarefaAtual);
            this.RefreshView();
        }

        private void RefreshView()
        {
            lblPontos.Text = listaTarefa.Sum(t => t.Pontuacao).ToString();
            bindGrid.ResetBindings();
        }

        private void ListarRegistro()
        {
            listaTarefa = session
                             .QueryOver<Tarefa>()
                             .Where(regra.GetCondicaoWhere())
                             .OrderBy(t => t.IdTarefa).Asc
                             .List();
            grid.DataSource = (bindGrid = new BindingList<Tarefa>(listaTarefa));

            new ManipulacaoGrid(grid)
                .RedimensionarColunas()
                .SetNomeColuna("Descricao")
                .SetTamanho(200);
            DoDefinirCorSelecionado(false);
            this.RefreshView();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if ((grid.SelectedRows.Count > 0) && (grid.SelectedRows[0].DataBoundItem != null) && (grid.SelectedRows[0].DataBoundItem.GetType() == typeof(Tarefa)))
                tarefaAtual = (grid.SelectedRows[0].DataBoundItem as Tarefa);
            else
                tarefaAtual = null;
        }

        private void DefinirCorSelecionado(Color cor)
        {
            DataGridViewCellStyle estilo = new DataGridViewCellStyle();
            estilo.SelectionBackColor = cor;
            estilo.SelectionForeColor = Color.Black;
            grid.RowTemplate.DefaultCellStyle = estilo;

            foreach (DataGridViewRow row in grid.Rows)
                row.DefaultCellStyle = estilo;
        }
        private void DoDefinirCorSelecionado(Boolean ehSelecionado)
        {
            if (ehSelecionado)
                DefinirCorSelecionado(CorSelecionado);
            else
                DefinirCorSelecionado(CorNormal);
        }

        private void grid_Enter(object sender, EventArgs e)
        {
            DoDefinirCorSelecionado(true);
        }

        private void grid_Leave(object sender, EventArgs e)
        {
            DoDefinirCorSelecionado(false);
        }
        public static void Transferir(PartView origem, PartView destino)
        {
            if (origem.TarefaAtual != null)
            {
                Tarefa tarefa = origem.TarefaAtual;
                origem.RemoverTarefaAtual();
                destino.AdicionarTarefa(tarefa);
            }
        }
    }
}
