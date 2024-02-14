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
using ScrumMap;
using ScrumNamespace;
using ScrumValidacao;
using ScrumComum;

//## renomear o form

namespace Scrum
{
    public partial class FormTarefa : Form
    {
        public IList<Tarefa> listaTarefa;
        public BindingList<Tarefa> ligacao;
        public Tarefa tarefaAtual;
        public ISession session;

        public FormTarefa()
        {
            InitializeComponent();
        
            session = ConexaoBanco.getInstance().NewSession();

            this.ListarRegistro();
        }

        private void ListarRegistro()
        {
            listaTarefa = session
                             .QueryOver<Tarefa>()
                             .OrderBy(t => t.IdTarefa).Asc
                             .List();

            grid.DataSource = (ligacao = new BindingList<Tarefa>(listaTarefa));

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

            //## colorir a linha que tiver com tarefa com sprints - para não permitir a edição.
            this.Text = tarefaAtual.IdTarefa.ToString();

            if (btnSalvar.Visible)
                DoSalvar();

            DoBind();
        }

        private void DoBind()
        {
            txtDescricao.DataBindings.Clear();
            numPontuacao.DataBindings.Clear();

            txtDescricao.DataBindings.Add("Text", tarefaAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged);
            numPontuacao.DataBindings.Add("Value", tarefaAtual, "Pontuacao", false, DataSourceUpdateMode.OnPropertyChanged);
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

            if (!listaTarefa.Contains(tarefaAtual))
            {
                listaTarefa.Add(tarefaAtual);
                ligacao.ResetBindings();
            }

            btnSalvar.Hide();
            grid.Focus();
        }
        
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DoSalvar();
        }

        private void pnlRegistro_Enter(object sender, EventArgs e)
        {
            btnSalvar.Show();

        }
        private void FormTarefa_Click(object sender, EventArgs e)
        {

        }
    }
}
