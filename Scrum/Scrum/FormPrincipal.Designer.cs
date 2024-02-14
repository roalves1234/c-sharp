namespace Scrum
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.productBacklogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planejamentoDaSprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kanbanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrospectivaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productBacklogToolStripMenuItem,
            this.planejamentoDaSprintToolStripMenuItem,
            this.kanbanToolStripMenuItem,
            this.retrospectivaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // productBacklogToolStripMenuItem
            // 
            this.productBacklogToolStripMenuItem.Name = "productBacklogToolStripMenuItem";
            this.productBacklogToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.productBacklogToolStripMenuItem.Text = "Product Backlog";
            this.productBacklogToolStripMenuItem.Click += new System.EventHandler(this.productBacklogToolStripMenuItem_Click);
            // 
            // planejamentoDaSprintToolStripMenuItem
            // 
            this.planejamentoDaSprintToolStripMenuItem.Name = "planejamentoDaSprintToolStripMenuItem";
            this.planejamentoDaSprintToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.planejamentoDaSprintToolStripMenuItem.Text = "Planejamento da Sprint";
            this.planejamentoDaSprintToolStripMenuItem.Click += new System.EventHandler(this.planejamentoDaSprintToolStripMenuItem_Click);
            // 
            // kanbanToolStripMenuItem
            // 
            this.kanbanToolStripMenuItem.Name = "kanbanToolStripMenuItem";
            this.kanbanToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.kanbanToolStripMenuItem.Text = "Kanban";
            this.kanbanToolStripMenuItem.Click += new System.EventHandler(this.kanbanToolStripMenuItem_Click);
            // 
            // retrospectivaToolStripMenuItem
            // 
            this.retrospectivaToolStripMenuItem.Name = "retrospectivaToolStripMenuItem";
            this.retrospectivaToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.retrospectivaToolStripMenuItem.Text = "Retrospectiva";
            this.retrospectivaToolStripMenuItem.Click += new System.EventHandler(this.retrospectivaToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Scrum";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productBacklogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planejamentoDaSprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kanbanToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem retrospectivaToolStripMenuItem;
    }
}

