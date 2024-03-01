using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrum
{
    public class SprintAtualPresenter
    {
        private static SprintAtualPresenter instance;
        private System.Windows.Forms.Label view;
        public SprintAtualPresenter(System.Windows.Forms.Label view)
        {
            this.view = view;
            this.Refresh();
        }
        public void DoBind()
        {
            view.DataBindings.Clear();
            view.DataBindings.Add(new Binding("Text", Ambiente.GetInstance().SprintAtual, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged));
        }
        public void Refresh()
        {
            Ambiente.ClearInstance();
            DoBind();
        }
        public static SprintAtualPresenter GetInstance()
        {
            return (instance);
        }
        public static void SetInstance(System.Windows.Forms.Label view)
        {
            instance = new SprintAtualPresenter(view);
        }
    }
}
