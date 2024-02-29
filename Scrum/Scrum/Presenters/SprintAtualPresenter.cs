using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrum
{
    public class SprintAtualPresenter
    {
        public SprintAtualPresenter(System.Windows.Forms.Label view)
        {
            view.DataBindings.Clear();
            view.DataBindings.Add(new Binding("Text", Ambiente.GetInstance().SprintAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}
