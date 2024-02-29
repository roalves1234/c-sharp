using System;
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

    public class PartPresenter
    {
        private PartControl control;
        private PartView view;
        private BindingList<Tarefa> bindGrid;

        public PartPresenter(PartView view, PartControl control, string titulo)
        {
            this.control = control;
            this.bindGrid = new BindingList<Tarefa>(control.ListaTarefa);
            this.view = view.SetPresenter(this);
            view.SetTitulo(titulo);
            view.SetBindGrid(bindGrid);
            view.DoInicializarVisual();
            this.DoRefreshView();
        }
        private void DoRefreshView()
        {
            view.SetPontos(control.ListaTarefa.Sum(t => t.Pontuacao));
            bindGrid.ResetBindings();
        }
        private void RemoverTarefaAtual()
        {
            control.RemoverTarefaAtual();
            DoRefreshView();
        }
        public PartPresenter SetParent(Control value)
        {
            view.Parent = value;
            return (this);
        }
        public PartPresenter SetObjetoAtualGrid(object value)
        {
            if ((value != null) && (value.GetType() == typeof(Tarefa)))
                control.SetTarefaAtual(value as Tarefa);
            else
                control.SetTarefaAtual(null);
            return (this);
        }
        public void AdicionarTarefa(Tarefa tarefa)
        {
            control.AdicionarTarefa(tarefa);

            DoRefreshView();
            view.GoUltimaLinhaGrid();
        }
        public void TransferirPara(PartPresenter destino)
        {
            if (control.TarefaAtual != null)
            {
                var tarefa = control.TarefaAtual;
                this.RemoverTarefaAtual();
                destino.AdicionarTarefa(tarefa);
            }
        }
    }
}
