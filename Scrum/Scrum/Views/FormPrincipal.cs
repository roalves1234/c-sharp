using System;
using System.Windows.Forms;
using Scrum.Model;
using Scrum.Teste;

namespace Scrum
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            SprintAtualPresenter.SetInstance(lblSprint);
        }
        private void productBacklogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProductBacklogPresenter(new ProductBacklogView(), new ProductBacklogControl()).Show();
        }
        private void planejamentoDaSprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormPlanejamentoSprint().ShowDialog();
        }
        private void kanbanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormKanban().ShowDialog();
        }
        private void retrospectivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RetrospectivaPresenter(new RetrospectivaView(), new RetrospectivaControl()).Show();
        }
        private void sprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SprintPresenter(new SprintView(), new SprintControl()).Show();
        }
    }
}
