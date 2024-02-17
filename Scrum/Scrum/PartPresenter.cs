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
        private Color CorSelecionado = Color.Yellow;
        private Color CorNormal = Color.White;

        ç // REVISAR
          // O PRESENTER FAZ CHAMADAS A VIEW E ESTA REALIZA A AÇÃO.
          // COLOCAR TODA A MANIPULAÇÃO DA VIEW NA PRÓPRIA VIEW - EM FORMA DE PROCEDIMENTOS
          // FAZER CHAMADAS A ESSES PROCEDIMENTOS OU CHAMADAS DIRETAS DA VIEW COM NO MÁXIMO 1 LINHA


        public PartPresenter(PartView view, PartControl control, string titulo)
        {
            this.control = control;
            this.view = view.SetPresenter(this);
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
            this.DoDefinirCorSelecionado(false);
            this.RefreshView();
        }
        private void GoUltimaLinhaGrid()
        {
            view.grid.Focus();
            view.grid.CurrentCell = view.grid[0, view.grid.Rows.Count - 1];
        }
        private void RemoverTarefaAtual()
        {
            control.RemoverTarefaAtual();
            this.RefreshView();
        }
        public PartPresenter SetParent(Control Value)
        {
            view.Parent = Value;
            return (this);
        }
        public PartPresenter SetTarefaAtual(Tarefa Value)
        {
            control.SetTarefaAtual(Value);
            return (this);
        }
        public void AdicionarTarefa(Tarefa tarefa)
        {
            control.AdicionarTarefa(tarefa);

            this.RefreshView();
            GoUltimaLinhaGrid();
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
        public void DoDefinirCorSelecionado(Boolean ehSelecionado)
        {
            if (ehSelecionado)
                DefinirCorSelecionado(CorSelecionado);
            else
                DefinirCorSelecionado(CorNormal);
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
