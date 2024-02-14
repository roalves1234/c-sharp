namespace Scrum
{
    partial class FormPlanejamentoSprint
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
            this.pnlProductBacklog = new System.Windows.Forms.Panel();
            this.btnToBacklog = new System.Windows.Forms.Button();
            this.pnlSprintBacklog = new System.Windows.Forms.Panel();
            this.btnToSprintBacklog = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(1033, 66);
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
            this.lblSprint.Size = new System.Drawing.Size(1033, 66);
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
            // pnlProductBacklog
            // 
            this.pnlProductBacklog.Location = new System.Drawing.Point(13, 101);
            this.pnlProductBacklog.Name = "pnlProductBacklog";
            this.pnlProductBacklog.Size = new System.Drawing.Size(477, 385);
            this.pnlProductBacklog.TabIndex = 1;
            this.pnlProductBacklog.Enter += new System.EventHandler(this.pnlProductBacklog_Enter);
            // 
            // btnToBacklog
            // 
            this.btnToBacklog.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToBacklog.ForeColor = System.Drawing.Color.Red;
            this.btnToBacklog.Location = new System.Drawing.Point(504, 272);
            this.btnToBacklog.Name = "btnToBacklog";
            this.btnToBacklog.Size = new System.Drawing.Size(49, 44);
            this.btnToBacklog.TabIndex = 2;
            this.btnToBacklog.Text = "<";
            this.btnToBacklog.UseVisualStyleBackColor = true;
            this.btnToBacklog.Click += new System.EventHandler(this.btnToBacklog_Click);
            // 
            // pnlSprintBacklog
            // 
            this.pnlSprintBacklog.Location = new System.Drawing.Point(570, 101);
            this.pnlSprintBacklog.Name = "pnlSprintBacklog";
            this.pnlSprintBacklog.Size = new System.Drawing.Size(477, 385);
            this.pnlSprintBacklog.TabIndex = 3;
            this.pnlSprintBacklog.Enter += new System.EventHandler(this.pnlSprintBacklog_Enter);
            // 
            // btnToSprintBacklog
            // 
            this.btnToSprintBacklog.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToSprintBacklog.Location = new System.Drawing.Point(504, 272);
            this.btnToSprintBacklog.Name = "btnToSprintBacklog";
            this.btnToSprintBacklog.Size = new System.Drawing.Size(49, 44);
            this.btnToSprintBacklog.TabIndex = 4;
            this.btnToSprintBacklog.Text = ">";
            this.btnToSprintBacklog.UseVisualStyleBackColor = true;
            this.btnToSprintBacklog.Click += new System.EventHandler(this.btnToSprintBacklog_Click);
            // 
            // FormPlanejamentoSprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 498);
            this.Controls.Add(this.pnlSprintBacklog);
            this.Controls.Add(this.pnlProductBacklog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnToBacklog);
            this.Controls.Add(this.btnToSprintBacklog);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPlanejamentoSprint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planejamento da Sprint";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSprint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlProductBacklog;
        private System.Windows.Forms.Button btnToBacklog;
        private System.Windows.Forms.Panel pnlSprintBacklog;
        private System.Windows.Forms.Button btnToSprintBacklog;
    }
}