using System;
using System.Windows.Forms;
using Scrum.Model;

namespace Scrum
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void productBacklogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormProductBacklog().ShowDialog();
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
            new FormRetrospectiva().ShowDialog();
        }
    }
}
