﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scrum.Model;

namespace Scrum
{
    public class ProductBacklogPresenter
    {
        private ProductBacklogControl control;
        private ProductBacklogView view;
        private BindingList<Tarefa> bindGrid;
        private Binding bindDescricao;
        private Binding bindPontuacao;

        public ProductBacklogPresenter(ProductBacklogView view, ProductBacklogControl control)
        {
            this.control = control;
            this.view = view.SetPresenter(this);
            view.DoInicializarVisual();
            view.SetModoVisualizacao();
            this.bindGrid = new BindingList<Tarefa>(control.ListaTarefa);
            view.SetBindGrid(bindGrid);
        }
        public void Show()
        {
            view.ShowDialog();
        }
        private void DoGridBind()
        {
            bindGrid.ResetBindings();
        }
        private void DoEditBind()
        {
            if (control.TarefaAtual != null)
            {
                bindDescricao = new Binding("Text", control.TarefaAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged);
                view.SetBindDescricao(bindDescricao);

                bindPontuacao = new Binding("value", control.TarefaAtual, "Pontuacao", false, DataSourceUpdateMode.OnPropertyChanged);
                view.SetBindPontuacao(bindPontuacao);
            }
        }
        public ProductBacklogPresenter SetObjetoAtualGrid(object value)
        {
            if ((view.EhModoPersistencia) && (control.ListaTarefa.Contains(control.TarefaAtual)))
                this.SalvarTarefAtual();
            else
                view.SetModoVisualizacao();

            if ((value != null) && (value.GetType() == typeof(Tarefa)))
                control.SetTarefaAtual(value as Tarefa);
            else
                control.SetTarefaAtual(null);

            DoEditBind();
            return (this);
        }
        public void DoNovaTarefa()
        {
            control.DoNovaTarefa();
            DoEditBind();
            view.GoUltimaLinhaGrid();
        }
        public void SalvarTarefAtual()
        {
            control.SalvarTarefaAtual();
            view.SetModoVisualizacao();
            DoGridBind();
        }
        public void EliminarTarefaAtual()
        {
            if (control.TarefaAtual.IdTarefa != 0)
            {
                control.EliminarTarefaAtual();
                DoGridBind();
            }
        }
    }
}