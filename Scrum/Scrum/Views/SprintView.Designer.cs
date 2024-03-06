namespace Scrum
{
    partial class SprintView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.inserirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRegistro = new System.Windows.Forms.Panel();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlRegistro.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToDeleteRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.ContextMenuStrip = this.contextMenuStrip1;
            this.grid.Location = new System.Drawing.Point(13, 14);
            this.grid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(793, 267);
            this.grid.TabIndex = 0;
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inserirToolStripMenuItem,
            this.toolStripSeparator1,
            this.eliminarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 54);
            // 
            // inserirToolStripMenuItem
            // 
            this.inserirToolStripMenuItem.Name = "inserirToolStripMenuItem";
            this.inserirToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.inserirToolStripMenuItem.Text = "Inserir";
            this.inserirToolStripMenuItem.Click += new System.EventHandler(this.inserirToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // pnlRegistro
            // 
            this.pnlRegistro.Controls.Add(this.txtDescricao);
            this.pnlRegistro.Controls.Add(this.label1);
            this.pnlRegistro.Location = new System.Drawing.Point(13, 301);
            this.pnlRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlRegistro.Name = "pnlRegistro";
            this.pnlRegistro.Size = new System.Drawing.Size(793, 119);
            this.pnlRegistro.TabIndex = 1;
            this.pnlRegistro.Enter += new System.EventHandler(this.pnlRegistro_Enter);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(14, 51);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(766, 27);
            this.txtDescricao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(722, 428);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(85, 32);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Visible = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // SprintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 470);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.pnlRegistro);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SprintView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprint da Sprint";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlRegistro.ResumeLayout(false);
            this.pnlRegistro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel pnlRegistro;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inserirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}