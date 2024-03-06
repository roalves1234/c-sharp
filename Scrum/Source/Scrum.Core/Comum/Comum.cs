using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.Criterion;
using Scrum.Model;

namespace Scrum
{
    public class ManipulacaoGrid
    {
        private DataGridView grid;
        private string nomeColuna;

        public ManipulacaoGrid(DataGridView grid)
        {
            this.grid = grid;
        }

        public ManipulacaoGrid RedimensionarColunas()
        {
            foreach (DataGridViewColumn column in grid.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            return this; 
        }
        public ManipulacaoGrid SetNomeColuna(string nomeColuna)
        {
            this.nomeColuna = nomeColuna;
            return this;
        }
        public ManipulacaoGrid SetTamanho(int tamanho)
        {
            foreach (DataGridViewColumn column in grid.Columns)
                if (column.DataPropertyName == nomeColuna)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                    column.Width = tamanho;
                    break;
                }
            return this; 
        }
    }
}
