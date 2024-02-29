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
            this.pnlAFazer = new System.Windows.Forms.Panel();
            this.btnToAFazer = new System.Windows.Forms.Button();
            this.pnlFazendo = new System.Windows.Forms.Panel();
            this.btnToFazendo = new System.Windows.Forms.Button();
            this.pnlFeito = new System.Windows.Forms.Panel();
            this.btnToFazendoB = new System.Windows.Forms.Button();
            this.btnToFeito = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlAFazer
            // 
            this.pnlAFazer.Location = new System.Drawing.Point(12, 12);
            this.pnlAFazer.Name = "pnlAFazer";
            this.pnlAFazer.Size = new System.Drawing.Size(345, 432);
            this.pnlAFazer.TabIndex = 1;
            this.pnlAFazer.Enter += new System.EventHandler(this.pnlAFazer_Enter);
            // 
            // btnToAFazer
            // 
            this.btnToAFazer.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToAFazer.ForeColor = System.Drawing.Color.Red;
            this.btnToAFazer.Location = new System.Drawing.Point(374, 154);
            this.btnToAFazer.Name = "btnToAFazer";
            this.btnToAFazer.Size = new System.Drawing.Size(49, 44);
            this.btnToAFazer.TabIndex = 2;
            this.btnToAFazer.Text = "<";
            this.btnToAFazer.UseVisualStyleBackColor = true;
            this.btnToAFazer.Click += new System.EventHandler(this.btnToAFazer_Click);
            // 
            // pnlFazendo
            // 
            this.pnlFazendo.Location = new System.Drawing.Point(439, 12);
            this.pnlFazendo.Name = "pnlFazendo";
            this.pnlFazendo.Size = new System.Drawing.Size(345, 432);
            this.pnlFazendo.TabIndex = 3;
            this.pnlFazendo.Enter += new System.EventHandler(this.pnlFazendo_Enter);
            // 
            // btnToFazendo
            // 
            this.btnToFazendo.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToFazendo.Location = new System.Drawing.Point(374, 154);
            this.btnToFazendo.Name = "btnToFazendo";
            this.btnToFazendo.Size = new System.Drawing.Size(49, 44);
            this.btnToFazendo.TabIndex = 4;
            this.btnToFazendo.Text = ">";
            this.btnToFazendo.UseVisualStyleBackColor = true;
            this.btnToFazendo.Click += new System.EventHandler(this.btnToFazendo_Click);
            // 
            // pnlFeito
            // 
            this.pnlFeito.Location = new System.Drawing.Point(864, 12);
            this.pnlFeito.Name = "pnlFeito";
            this.pnlFeito.Size = new System.Drawing.Size(345, 432);
            this.pnlFeito.TabIndex = 6;
            this.pnlFeito.Enter += new System.EventHandler(this.pnlFeito_Enter);
            // 
            // btnToFazendoB
            // 
            this.btnToFazendoB.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToFazendoB.ForeColor = System.Drawing.Color.Red;
            this.btnToFazendoB.Location = new System.Drawing.Point(799, 154);
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
            this.btnToFeito.Location = new System.Drawing.Point(799, 154);
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
            this.ClientSize = new System.Drawing.Size(1222, 457);
            this.Controls.Add(this.pnlFeito);
            this.Controls.Add(this.pnlFazendo);
            this.Controls.Add(this.pnlAFazer);
            this.Controls.Add(this.btnToAFazer);
            this.Controls.Add(this.btnToFazendo);
            this.Controls.Add(this.btnToFeito);
            this.Controls.Add(this.btnToFazendoB);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormKanban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kanban";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlAFazer;
        private System.Windows.Forms.Button btnToAFazer;
        private System.Windows.Forms.Panel pnlFazendo;
        private System.Windows.Forms.Button btnToFazendo;
        private System.Windows.Forms.Panel pnlFeito;
        private System.Windows.Forms.Button btnToFazendoB;
        private System.Windows.Forms.Button btnToFeito;
    }
}