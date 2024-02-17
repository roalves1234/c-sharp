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
    public class PresenterPart
    {
        private ControlPart control;
        private PartView view;
        private BindingList<Tarefa> bindGrid;
        private Color CorSelecionado = Color.Yellow;
        private Color CorNormal = Color.White;

        public PresenterPart(PartView view, ControlPart control, string titulo)
        {
            this.control = control;
            this.view = view;
            DoInicializarVisual(titulo);
        }
        private void RefreshView()
        {
            view.lblPontos.Text = control.ListaTarefa.Sum(t => t.Pontuacao).ToString();
            bindGrid.ResetBindings();
        }
        private void DoInicializarVisual(string titulo)
        {
            new ManipulacaoGrid(view.grid)
                .RedimensionarColunas()
                .SetNomeColuna("Descricao")
                .SetTamanho(200);

            view.grid.DataSource = (bindGrid = new BindingList<Tarefa>(control.ListaTarefa));
            view.Dock = DockStyle.Fill;
            view.lblTitulo.Text = titulo;

            DoDefinirCorSelecionado(false);
            this.RefreshView();
        }
        private void GoUltimaLinhaGrid()
        {
            view.grid.Focus();
            view.grid.CurrentCell = view.grid[0, view.grid.Rows.Count - 1];
        }

        private void DefinirCorSelecionado(Color cor)
        {
            DataGridViewCellStyle estilo = new DataGridViewCellStyle();
            estilo.SelectionBackColor = cor;
            estilo.SelectionForeColor = Color.Black;
            view.grid.RowTemplate.DefaultCellStyle = estilo;

            foreach (DataGridViewRow row in view.grid.Rows)
                row.DefaultCellStyle = estilo;
        }
        private void RemoverTarefaAtual()
        {
            control.RemoverTarefaAtual();
            this.RefreshView();
        }
        public void SetParent(Control Value)
        {
            view.Parent = Value;
        }
        public void AdicionarTarefa(Tarefa tarefa)
        {
            control.AdicionarTarefa(tarefa);

            this.RefreshView();
            GoUltimaLinhaGrid();
        }
        public void DoDefinirCorSelecionado(Boolean ehSelecionado)
        {
            if (ehSelecionado)
                DefinirCorSelecionado(CorSelecionado);
            else
                DefinirCorSelecionado(CorNormal);
        }
        public void DoGridSelectionChange()
        {
            if ((view.grid.SelectedRows.Count > 0) && (view.grid.SelectedRows[0].DataBoundItem != null) && (view.grid.SelectedRows[0].DataBoundItem.GetType() == typeof(Tarefa)))
                control.TarefaAtual = (view.grid.SelectedRows[0].DataBoundItem as Tarefa);
            else
                control.TarefaAtual = null;
        }
        public void TransferirPara(PresenterPart destino)
        {
            if (control.TarefaAtual != null)
            {
                Tarefa tarefa = control.TarefaAtual;
                this.RemoverTarefaAtual();
                destino.AdicionarTarefa(tarefa);
            }
        }
    }
}
