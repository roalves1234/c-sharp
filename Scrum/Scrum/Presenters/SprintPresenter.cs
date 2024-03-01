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
    public class SprintPresenter
    {
        private SprintControl control;
        private SprintView view;
        private BindingList<Sprint> bindGrid;
        private bool ehModoPersistencia;
        public SprintPresenter(SprintView view, SprintControl control)
        {
            this.control = control;
            this.view = view.SetPresenter(this);
            view.DoInicializarVisual();
            this.SetModoVisualizacao();
            this.bindGrid = new BindingList<Sprint>(control.ListaSprint);
            view.SetBindGrid(bindGrid);
        }
        public void SetModoPersistencia()
        {
            view.ExibirPersistencia(true);

            ehModoPersistencia = true;
        }
        public void SetModoVisualizacao()
        {
            view.ExibirPersistencia(false);

            ehModoPersistencia = false;
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
            if (control.SprintAtual != null)
                view.SetBindDescricao(new Binding("Text", control.SprintAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged));
        }
        public SprintPresenter SetObjetoAtualGrid(object value)
        {
            if ((ehModoPersistencia) && (control.ListaSprint.Contains(control.SprintAtual)))
                this.SalvarSprintAtual();
            else
                SetModoVisualizacao();

            if ((value != null) && (value.GetType() == typeof(Sprint)))
                control.SetSprintAtual(value as Sprint);
            else
                control.SetSprintAtual(null);

            DoEditBind();
            return (this);
        }
        public void DoNovaSprint()
        {
            control.DoNovaSprint();
            DoEditBind();
            view.GoUltimaLinhaGrid();
        }
        public void SalvarSprintAtual()
        {
            control.SalvarSprintAtual();
            SetModoVisualizacao();
            DoGridBind();
            SprintAtualPresenter.GetInstance().Refresh();
        }
        public void EliminarSprintAtual()
        {
            if (control.SprintAtual.IdSprint != 0)
            {
                control.EliminarSprintAtual();
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