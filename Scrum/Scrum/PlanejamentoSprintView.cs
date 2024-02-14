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
using ScrumComum;
using ScrumNamespace;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using ScrumMap;
using ScrumValidacao;

namespace Scrum
{
    public partial class PlanejamentoSprintView: UserControl
    {
        private ISession session;
        private Sprint sprint;
        private IList<Tarefa> listaTarefa;
        private BindingList<Tarefa> bindGrid;
        private Tarefa tarefaAtual;

        public PlanejamentoSprintView(Sprint sprint, String titulo)
        {
            InitializeComponent();

            lblTitulo.Text = titulo;
            this.sprint = sprint;
            this.session = ConexaoBanco.getInstance().NewSession();
            this.ListarRegistro();
        }

        public Tarefa TarefaAtual {get { return tarefaAtual; }}

        public void AdicionarTarefa(Tarefa tarefa)
        {
            using (ITransaction transacao = session.BeginTransaction())
                try
                {
                    tarefa.Sprint = sprint;
                    session.Update(tarefa);
                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }

            listaTarefa.Add(tarefa);
            bindGrid.ResetBindings();
        }

        public void RemoverTarefaAtual()
        {
            listaTarefa.Remove(tarefaAtual);
            bindGrid.ResetBindings();
        }

        private void ListarRegistro()
        {
            Object idSprint;
            if (sprint != null)
                idSprint = sprint.IdSprint;
            else
                idSprint = null;

            var condicao = Restrictions.Disjunction();
            condicao.Add(Restrictions.Eq(Projections.Property<Tarefa>(t => t.Sprint.IdSprint), idSprint));

            listaTarefa = session
                             .QueryOver<Tarefa>()
                             .Where(condicao)
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
                tarefaAtual = null;
        }
    }
}
