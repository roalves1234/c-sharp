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
            this.pnlProductBacklog = new System.Windows.Forms.Panel();
            this.btnToBacklog = new System.Windows.Forms.Button();
            this.pnlSprintBacklog = new System.Windows.Forms.Panel();
            this.btnToSprintBacklog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlProductBacklog
            // 
            this.pnlProductBacklog.Location = new System.Drawing.Point(12, 12);
            this.pnlProductBacklog.Name = "pnlProductBacklog";
            this.pnlProductBacklog.Size = new System.Drawing.Size(477, 385);
            this.pnlProductBacklog.TabIndex = 1;
            this.pnlProductBacklog.Enter += new System.EventHandler(this.pnlProductBacklog_Enter);
            // 
            // btnToBacklog
            // 
            this.btnToBacklog.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToBacklog.ForeColor = System.Drawing.Color.Red;
            this.btnToBacklog.Location = new System.Drawing.Point(503, 183);
            this.btnToBacklog.Name = "btnToBacklog";
            this.btnToBacklog.Size = new System.Drawing.Size(49, 44);
            this.btnToBacklog.TabIndex = 2;
            this.btnToBacklog.Text = "<";
            this.btnToBacklog.UseVisualStyleBackColor = true;
            this.btnToBacklog.Click += new System.EventHandler(this.btnToBacklog_Click);
            // 
            // pnlSprintBacklog
            // 
            this.pnlSprintBacklog.Location = new System.Drawing.Point(569, 12);
            this.pnlSprintBacklog.Name = "pnlSprintBacklog";
            this.pnlSprintBacklog.Size = new System.Drawing.Size(477, 385);
            this.pnlSprintBacklog.TabIndex = 3;
            this.pnlSprintBacklog.Enter += new System.EventHandler(this.pnlSprintBacklog_Enter);
            // 
            // btnToSprintBacklog
            // 
            this.btnToSprintBacklog.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.btnToSprintBacklog.Location = new System.Drawing.Point(503, 183);
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
            this.ClientSize = new System.Drawing.Size(1059, 410);
            this.Controls.Add(this.pnlSprintBacklog);
            this.Controls.Add(this.pnlProductBacklog);
            this.Controls.Add(this.btnToBacklog);
            this.Controls.Add(this.btnToSprintBacklog);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPlanejamentoSprint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planejamento da Sprint";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlProductBacklog;
        private System.Windows.Forms.Button btnToBacklog;
        private System.Windows.Forms.Panel pnlSprintBacklog;
        private System.Windows.Forms.Button btnToSprintBacklog;
    }
}