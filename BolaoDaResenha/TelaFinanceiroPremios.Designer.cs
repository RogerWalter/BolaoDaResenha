namespace BolaoDaResenha
{
    partial class TelaFinanceiroPremios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaFinanceiroPremios));
            this.label24 = new System.Windows.Forms.Label();
            this.insc = new System.Windows.Forms.Label();
            this.part = new System.Windows.Forms.Label();
            this.premio = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.inic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Arial", 20F);
            this.label24.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label24.Location = new System.Drawing.Point(20, 281);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(510, 77);
            this.label24.TabIndex = 12;
            this.label24.Text = "Primeiro sorteio em";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // insc
            // 
            this.insc.Font = new System.Drawing.Font("Arial", 40F);
            this.insc.ForeColor = System.Drawing.Color.Coral;
            this.insc.Location = new System.Drawing.Point(20, 197);
            this.insc.Name = "insc";
            this.insc.Size = new System.Drawing.Size(510, 83);
            this.insc.TabIndex = 11;
            this.insc.Text = "9";
            this.insc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.insc.Click += new System.EventHandler(this.qtdpart_Click);
            // 
            // part
            // 
            this.part.Font = new System.Drawing.Font("Arial", 30F);
            this.part.ForeColor = System.Drawing.Color.DodgerBlue;
            this.part.Location = new System.Drawing.Point(12, 152);
            this.part.Name = "part";
            this.part.Size = new System.Drawing.Size(518, 45);
            this.part.TabIndex = 10;
            this.part.Text = "Valor da inscrição";
            this.part.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // premio
            // 
            this.premio.Font = new System.Drawing.Font("Arial", 45F);
            this.premio.ForeColor = System.Drawing.Color.Coral;
            this.premio.Location = new System.Drawing.Point(20, 54);
            this.premio.Name = "premio";
            this.premio.Size = new System.Drawing.Size(510, 83);
            this.premio.TabIndex = 9;
            this.premio.Text = "9";
            this.premio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Arial", 30F);
            this.label23.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label23.Location = new System.Drawing.Point(12, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(518, 45);
            this.label23.TabIndex = 8;
            this.label23.Text = "Prêmio do Concurso";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inic
            // 
            this.inic.Font = new System.Drawing.Font("Arial", 35F);
            this.inic.ForeColor = System.Drawing.Color.Coral;
            this.inic.Location = new System.Drawing.Point(20, 348);
            this.inic.Name = "inic";
            this.inic.Size = new System.Drawing.Size(510, 83);
            this.inic.TabIndex = 13;
            this.inic.Text = "9";
            this.inic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TelaFinanceiroPremios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 444);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.insc);
            this.Controls.Add(this.part);
            this.Controls.Add(this.premio);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.inic);
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaFinanceiroPremios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Concurso Atual";
            this.Load += new System.EventHandler(this.TelaFinanceiroPremios_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label insc;
        private System.Windows.Forms.Label part;
        private System.Windows.Forms.Label premio;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label inic;
    }
}