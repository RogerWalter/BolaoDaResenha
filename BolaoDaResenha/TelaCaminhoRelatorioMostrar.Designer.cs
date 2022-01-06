namespace BolaoDaResenha
{
    partial class TelaCaminhoRelatorioMostrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCaminhoRelatorioMostrar));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rel1 = new System.Windows.Forms.Label();
            this.rel2 = new System.Windows.Forms.Label();
            this.rel3 = new System.Windows.Forms.Label();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.com1 = new System.Windows.Forms.Label();
            this.com2 = new System.Windows.Forms.Label();
            this.labelComps = new System.Windows.Forms.Label();
            this.labelComps1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BolaoDaResenha.Properties.Resources.concluido1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(564, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rel1
            // 
            this.rel1.Font = new System.Drawing.Font("Arial", 16F);
            this.rel1.ForeColor = System.Drawing.Color.Coral;
            this.rel1.Location = new System.Drawing.Point(12, 146);
            this.rel1.Name = "rel1";
            this.rel1.Size = new System.Drawing.Size(564, 35);
            this.rel1.TabIndex = 32;
            this.rel1.Text = "O Relatório do concurso atual foi gerado com sucesso! ";
            this.rel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rel2
            // 
            this.rel2.Font = new System.Drawing.Font("Arial", 12F);
            this.rel2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.rel2.Location = new System.Drawing.Point(12, 181);
            this.rel2.Name = "rel2";
            this.rel2.Size = new System.Drawing.Size(564, 26);
            this.rel2.TabIndex = 33;
            this.rel2.Text = "O arquivo pode ser encontrado no seguinte diretório: ";
            this.rel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rel3
            // 
            this.rel3.Font = new System.Drawing.Font("Arial", 14F);
            this.rel3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.rel3.Location = new System.Drawing.Point(10, 207);
            this.rel3.Name = "rel3";
            this.rel3.Size = new System.Drawing.Size(566, 25);
            this.rel3.TabIndex = 34;
            this.rel3.Text = "C:\\BolaoDaResenha\\Relatorios";
            this.rel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btConfirmar
            // 
            this.btConfirmar.BackColor = System.Drawing.Color.White;
            this.btConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConfirmar.FlatAppearance.BorderSize = 0;
            this.btConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btConfirmar.Font = new System.Drawing.Font("Arial", 12F);
            this.btConfirmar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btConfirmar.Location = new System.Drawing.Point(12, 275);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(102, 37);
            this.btConfirmar.TabIndex = 35;
            this.btConfirmar.Text = "Abrir";
            this.btConfirmar.UseVisualStyleBackColor = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 12F);
            this.button1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(474, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 36;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // com1
            // 
            this.com1.Font = new System.Drawing.Font("Arial", 16F);
            this.com1.ForeColor = System.Drawing.Color.Coral;
            this.com1.Location = new System.Drawing.Point(12, 146);
            this.com1.Name = "com1";
            this.com1.Size = new System.Drawing.Size(564, 35);
            this.com1.TabIndex = 37;
            this.com1.Text = "O Comprovante foi gerado com sucesso! ";
            this.com1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // com2
            // 
            this.com2.Font = new System.Drawing.Font("Arial", 14F);
            this.com2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.com2.Location = new System.Drawing.Point(12, 207);
            this.com2.Name = "com2";
            this.com2.Size = new System.Drawing.Size(564, 25);
            this.com2.TabIndex = 38;
            this.com2.Text = "C:\\BolaoDaResenha\\Comprovantes";
            this.com2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelComps
            // 
            this.labelComps.Font = new System.Drawing.Font("Arial", 16F);
            this.labelComps.ForeColor = System.Drawing.Color.Coral;
            this.labelComps.Location = new System.Drawing.Point(12, 146);
            this.labelComps.Name = "labelComps";
            this.labelComps.Size = new System.Drawing.Size(564, 35);
            this.labelComps.TabIndex = 39;
            this.labelComps.Text = "Todos os Comprovantes foram gerados com sucesso!";
            this.labelComps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelComps1
            // 
            this.labelComps1.Font = new System.Drawing.Font("Arial", 12F);
            this.labelComps1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelComps1.Location = new System.Drawing.Point(14, 181);
            this.labelComps1.Name = "labelComps1";
            this.labelComps1.Size = new System.Drawing.Size(564, 26);
            this.labelComps1.TabIndex = 40;
            this.labelComps1.Text = "Os arquivos podem ser encontrados no seguinte diretório: ";
            this.labelComps1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TelaCaminhoRelatorioMostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(588, 324);
            this.Controls.Add(this.labelComps1);
            this.Controls.Add(this.labelComps);
            this.Controls.Add(this.com2);
            this.Controls.Add(this.com1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.rel3);
            this.Controls.Add(this.rel2);
            this.Controls.Add(this.rel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaCaminhoRelatorioMostrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arquivo Gerado";
            this.Load += new System.EventHandler(this.TelaCaminhoRelatorioMostrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label rel1;
        private System.Windows.Forms.Label rel2;
        private System.Windows.Forms.Label rel3;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label com1;
        private System.Windows.Forms.Label com2;
        private System.Windows.Forms.Label labelComps;
        private System.Windows.Forms.Label labelComps1;
    }
}