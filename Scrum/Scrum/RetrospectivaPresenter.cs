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
    public class RetrospectivaPresenter
    {
        private RetrospectivaControl control;
        private RetrospectivaView view;
        private BindingList<Retrospectiva> bindGrid;
        private bool ehModoPersistencia;
        private bool ehModoVisualizacao;
        public RetrospectivaPresenter(RetrospectivaView view, RetrospectivaControl control)
        {
            this.control = control;
            this.view = view.SetPresenter(this);
            view.DoInicializarVisual();
            this.SetModoVisualizacao();
            this.bindGrid = new BindingList<Retrospectiva>(control.ListaRetrospectiva);
            view.SetBindGrid(bindGrid);
        }
        public void SetModoPersistencia()
        {
            view.ExibirPersistencia(true);

            ehModoPersistencia = true;
            ehModoVisualizacao = false;
        }
        public void SetModoVisualizacao()
        {
            view.ExibirPersistencia(false);

            ehModoPersistencia = false;
            ehModoVisualizacao = true;
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
            if (control.RetrospectivaAtual != null)
                view.SetBindDescricao(new Binding("Text", control.RetrospectivaAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged));
            if (control.SprintAtual != null)
                view.SetBindSprint(new Binding("Text", control.SprintAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged));
        }
        public RetrospectivaPresenter SetObjetoAtualGrid(object value)
        {
            if ((ehModoPersistencia) && (control.ListaRetrospectiva.Contains(control.RetrospectivaAtual)))
                this.SalvarRetrospectivaAtual();
            else
                SetModoVisualizacao();

            if ((value != null) && (value.GetType() == typeof(Retrospectiva)))
                control.SetRetrospectivaAtual(value as Retrospectiva);
            else
                control.SetRetrospectivaAtual(null);

            view.ExibirConverterTarefa(true);

            DoEditBind();
            return (this);
        }
        public void DoNovaRetrospectiva()
        {
            control.DoNovaRetrospectiva();
            DoEditBind();
            view.GoUltimaLinhaGrid();
            view.ExibirConverterTarefa(false);
        }
        public void SalvarRetrospectivaAtual()
        {
            control.SalvarRetrospectivaAtual();
            SetModoVisualizacao();
            DoGridBind();
        }
        public void EliminarRetrospectivaAtual()
        {
            if (control.RetrospectivaAtual.IdRetrospectiva != 0)
            {
                control.EliminarRetrospectivaAtual();
                DoGridBind();
            }
        }
        public void ConverterEmTarefa()
        {
            control.ConverterEmTarefa();
            DoGridBind();
        }
    }
}