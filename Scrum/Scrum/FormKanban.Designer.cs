namespace Scrum
{
    partial class FormKanban
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSprint = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAFazer = new System.Windows.Forms.Panel();
            this.btnToAFazer = new System.Windows.Forms.Button();
            this.pnlFazendo = new System.Windows.Forms.Panel();
            this.btnToFazendo = new System.Windows.Forms.Button();
            this.pnlFeito = new System.Windows.Forms.Panel();
            this.btnToFazendoB = new System.Windows.Forms.Button();
            this.btnToFeito = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSprint);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 66);
            this.panel1.TabIndex = 0;
            // 
            // lblSprint
            // 
            this.lblSprint.BackColor = System.Drawing.Color.Silver;
            this.lblSprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSprint.Font = new System.Drawing.Font("Calibri", 20F);
            this.lblSprint.Location = new System.Drawing.Point(0, 0);
            this.lblSprint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSprint.Name = "lblSprint";
            this.lblSprint.Size = new System.Drawing.Size(1196, 66);
            this.lblSprint.TabIndex = 1;
            this.lblSprint.Text = "lblSprint";
            this.lblSprint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1080, 37);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(267, 146);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pnlAFazer
            // 
            this.pnlAFazer.Location = new System.Drawing.Point(13, 101);
            this.pnlAFazer.Name = "pnlAFazer";
            this.pnlAFazer.Size = new System.Drawing.Size(345, 432);
            this.pnlAFazer.TabIndex = 1;
            this.pnlAFazer.Enter += new System.EventHandler(this.pnlAFazer_Enter);
            // 
            // btnToAFazer
            // 
            this.btnToAFazer.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToAFazer.ForeColor = System.Drawing.Color.Red;
            this.btnToAFazer.Location = new System.Drawing.Point(375, 243);
            this.btnToAFazer.Name = "btnToAFazer";
            this.btnToAFazer.Size = new System.Drawing.Size(49, 44);
            this.btnToAFazer.TabIndex = 2;
            this.btnToAFazer.Text = "<";
            this.btnToAFazer.UseVisualStyleBackColor = true;
            this.btnToAFazer.Click += new System.EventHandler(this.btnToAFazer_Click);
            // 
            // pnlFazendo
            // 
            this.pnlFazendo.Location = new System.Drawing.Point(440, 101);
            this.pnlFazendo.Name = "pnlFazendo";
            this.pnlFazendo.Size = new System.Drawing.Size(345, 432);
            this.pnlFazendo.TabIndex = 3;
            this.pnlFazendo.Enter += new System.EventHandler(this.pnlFazendo_Enter);
            // 
            // btnToFazendo
            // 
            this.btnToFazendo.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToFazendo.Location = new System.Drawing.Point(375, 243);
            this.btnToFazendo.Name = "btnToFazendo";
            this.btnToFazendo.Size = new System.Drawing.Size(49, 44);
            this.btnToFazendo.TabIndex = 4;
            this.btnToFazendo.Text = ">";
            this.btnToFazendo.UseVisualStyleBackColor = true;
            this.btnToFazendo.Click += new System.EventHandler(this.btnToFazendo_Click);
            // 
            // pnlFeito
            // 
            this.pnlFeito.Location = new System.Drawing.Point(865, 101);
            this.pnlFeito.Name = "pnlFeito";
            this.pnlFeito.Size = new System.Drawing.Size(345, 432);
            this.pnlFeito.TabIndex = 6;
            this.pnlFeito.Enter += new System.EventHandler(this.pnlFeito_Enter);
            // 
            // btnToFazendoB
            // 
            this.btnToFazendoB.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToFazendoB.ForeColor = System.Drawing.Color.Red;
            this.btnToFazendoB.Location = new System.Drawing.Point(800, 243);
            this.btnToFazendoB.Name = "btnToFazendoB";
            this.btnToFazendoB.Size = new System.Drawing.Size(49, 44);
            this.btnToFazendoB.TabIndex = 5;
            this.btnToFazendoB.Text = "<";
            this.btnToFazendoB.UseVisualStyleBackColor = true;
            this.btnToFazendoB.Click += new System.EventHandler(this.btnToFazendoB_Click);
            // 
            // btnToFeito
            // 
            this.btnToFeito.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToFeito.Location = new System.Drawing.Point(800, 243);
            this.btnToFeito.Name = "btnToFeito";
            this.btnToFeito.Size = new System.Drawing.Size(49, 44);
            this.btnToFeito.TabIndex = 7;
            this.btnToFeito.Text = ">";
            this.btnToFeito.UseVisualStyleBackColor = true;
            this.btnToFeito.Click += new System.EventHandler(this.btnToFeito_Click);
            // 
            // FormKanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 561);
            this.Controls.Add(this.pnlFeito);
            this.Controls.Add(this.pnlFazendo);
            this.Controls.Add(this.pnlAFazer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnToAFazer);
            this.Controls.Add(this.btnToFazendo);
            this.Controls.Add(this.btnToFeito);
            this.Controls.Add(this.btnToFazendoB);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormKanban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kanban";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSprint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlAFazer;
        private System.Windows.Forms.Button btnToAFazer;
        private System.Windows.Forms.Panel pnlFazendo;
        private System.Windows.Forms.Button btnToFazendo;
        private System.Windows.Forms.Panel pnlFeito;
        private System.Windows.Forms.Button btnToFazendoB;
        private System.Windows.Forms.Button btnToFeito;
    }
}