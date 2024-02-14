using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using ScrumMap;
using ScrumNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Scrum
{
    public partial class Form2 : Form
    {
        public IList<Tarefa> lista;
        public BindingList<Tarefa> ligacao;
        public Tarefa tarefaAtual;

        public Form2()
        {
            InitializeComponent();

            // inserirRegistro();
            listarRegistro();            
        }

        private void listarRegistro()
        {
            using (var session = ConexaoBanco.getInstance().NewSession())
            {
                var disjunction = Restrictions.Disjunction();

                disjunction.Add(Restrictions.Like(Projections.Property<Tarefa>(t => t.Descricao), "D%"));
                disjunction.Add(Restrictions.Like(Projections.Property<Tarefa>(t => t.Descricao), "T%"));

                lista = session.QueryOver<Tarefa>()
                    //.Where(disjunction)
                    .OrderBy(t => t.IdTarefa).Asc
                    .List();

                ligacao = new BindingList<Tarefa>(lista);
                grid.DataSource = ligacao;
            }
        }
        
        private void exibirLista(IList<Tarefa> lista)
        {
            // Iterar sobre as tarefas e fazer algo com elas
            var texto = "";
            foreach (var tarefa in lista)
            {
                texto += $"ID: {tarefa.IdTarefa}, Descrição: {tarefa.Descricao}, Pontuação: {tarefa.Pontuacao}, Status: {tarefa.Status}\r\n";
            }
            MessageBox.Show(texto);
        }
        private void inserirRegistro()
        {
            using (var session = ConexaoBanco.getInstance().NewSession())
            {
                session.Save(this.Adicionar());
                ligacao.ResetBindings();
            }
        }

        private Tarefa Adicionar()
        {
            var novaTarefa = new Tarefa
            {
                Descricao = "Incluído agora",
                Pontuacao = 10,
                Status = "Iniciado"
            };

            lista.Add(novaTarefa);
            ligacao.ResetBindings();

            //grid.DataSource = null;
            //grid.DataSource = listaSprint;
            return (novaTarefa);
        }
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            this.Adicionar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //exibirLista(grid.DataSource as IList<Tarefa>);
            exibirLista(lista);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            inserirRegistro();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tarefaAtual.Status = "Fazendo";

            using (var session = ConexaoBanco.getInstance().NewSession())
            {
                session.Save(tarefaAtual);
                ligacao.ResetBindings();
            }
        }
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if ((grid.SelectedRows.Count > 0) && (grid.SelectedRows[0].DataBoundItem != null))
            {
                tarefaAtual = (grid.SelectedRows[0].DataBoundItem as Tarefa);
                this.Text = tarefaAtual.IdTarefa.ToString();

                txtDescricao.DataBindings.Clear();
                txtDescricao.DataBindings.Add("Text", tarefaAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged);
            }
            else
            {
                this.Text = "--";
            }
        }
    }
}
