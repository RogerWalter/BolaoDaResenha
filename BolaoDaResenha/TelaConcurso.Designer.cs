namespace BolaoDaResenha
{
    partial class TelaConcurso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaConcurso));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEmAndamento = new System.Windows.Forms.Label();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.labelVenc = new System.Windows.Forms.Label();
            this.dgVenc = new System.Windows.Forms.DataGridView();
            this.labelFechado = new System.Windows.Forms.Label();
            this.labelAberto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.qtdSort = new System.Windows.Forms.Label();
            this.qtdpart = new System.Windows.Forms.Label();
            this.part = new System.Windows.Forms.Label();
            this.conc = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btEncerrarConc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVenc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelEmAndamento);
            this.groupBox1.Controls.Add(this.btConfirmar);
            this.groupBox1.Controls.Add(this.labelVenc);
            this.groupBox1.Controls.Add(this.dgVenc);
            this.groupBox1.Controls.Add(this.labelFechado);
            this.groupBox1.Controls.Add(this.labelAberto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.qtdSort);
            this.groupBox1.Controls.Add(this.qtdpart);
            this.groupBox1.Controls.Add(this.part);
            this.groupBox1.Controls.Add(this.conc);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 18F);
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 355);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Concurso Atual";
            // 
            // labelEmAndamento
            // 
            this.labelEmAndamento.Font = new System.Drawing.Font("Arial", 35F);
            this.labelEmAndamento.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelEmAndamento.Location = new System.Drawing.Point(46, 240);
            this.labelEmAndamento.Name = "labelEmAndamento";
            this.labelEmAndamento.Size = new System.Drawing.Size(359, 76);
            this.labelEmAndamento.TabIndex = 42;
            this.labelEmAndamento.Text = "Em Andamento";
            this.labelEmAndamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEmAndamento.Visible = false;
            // 
            // btConfirmar
            // 
            this.btConfirmar.BackColor = System.Drawing.Color.White;
            this.btConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConfirmar.FlatAppearance.BorderSize = 0;
            this.btConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btConfirmar.Font = new System.Drawing.Font("Arial", 20F);
            this.btConfirmar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btConfirmar.Location = new System.Drawing.Point(532, 218);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(158, 75);
            this.btConfirmar.TabIndex = 24;
            this.btConfirmar.Text = "Consultar Placar";
            this.btConfirmar.UseVisualStyleBackColor = false;
            this.btConfirmar.Visible = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // labelVenc
            // 
            this.labelVenc.AutoSize = true;
            this.labelVenc.Font = new System.Drawing.Font("Arial", 30F);
            this.labelVenc.Location = new System.Drawing.Point(478, 192);
            this.labelVenc.Name = "labelVenc";
            this.labelVenc.Size = new System.Drawing.Size(228, 45);
            this.labelVenc.TabIndex = 41;
            this.labelVenc.Text = "Vencedores";
            this.labelVenc.Visible = false;
            // 
            // dgVenc
            // 
            this.dgVenc.AllowUserToAddRows = false;
            this.dgVenc.AllowUserToDeleteRows = false;
            this.dgVenc.AllowUserToResizeColumns = false;
            this.dgVenc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgVenc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVenc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVenc.BackgroundColor = System.Drawing.Color.White;
            this.dgVenc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 18F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVenc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgVenc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVenc.ColumnHeadersVisible = false;
            this.dgVenc.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 18F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVenc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgVenc.EnableHeadersVisualStyles = false;
            this.dgVenc.GridColor = System.Drawing.Color.White;
            this.dgVenc.Location = new System.Drawing.Point(445, 240);
            this.dgVenc.MultiSelect = false;
            this.dgVenc.Name = "dgVenc";
            this.dgVenc.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 18F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVenc.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgVenc.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgVenc.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgVenc.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgVenc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgVenc.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F);
            this.dgVenc.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgVenc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgVenc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgVenc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVenc.Size = new System.Drawing.Size(286, 86);
            this.dgVenc.TabIndex = 40;
            this.dgVenc.Visible = false;
            // 
            // labelFechado
            // 
            this.labelFechado.Font = new System.Drawing.Font("Arial", 50F);
            this.labelFechado.ForeColor = System.Drawing.Color.Firebrick;
            this.labelFechado.Location = new System.Drawing.Point(74, 237);
            this.labelFechado.Name = "labelFechado";
            this.labelFechado.Size = new System.Drawing.Size(299, 83);
            this.labelFechado.TabIndex = 10;
            this.labelFechado.Text = "Fechado";
            this.labelFechado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFechado.Visible = false;
            this.labelFechado.Click += new System.EventHandler(this.labelFechado_Click);
            // 
            // labelAberto
            // 
            this.labelAberto.Font = new System.Drawing.Font("Arial", 50F);
            this.labelAberto.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelAberto.Location = new System.Drawing.Point(98, 237);
            this.labelAberto.Name = "labelAberto";
            this.labelAberto.Size = new System.Drawing.Size(250, 83);
            this.labelAberto.TabIndex = 9;
            this.labelAberto.Text = "Aberto";
            this.labelAberto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAberto.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 30F);
            this.label2.Location = new System.Drawing.Point(153, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 45);
            this.label2.TabIndex = 8;
            this.label2.Text = "Status";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Arial", 20F);
            this.label24.Location = new System.Drawing.Point(517, 22);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(252, 77);
            this.label24.TabIndex = 6;
            this.label24.Text = "Sorteios Realizados";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // qtdSort
            // 
            this.qtdSort.Font = new System.Drawing.Font("Arial", 50F);
            this.qtdSort.ForeColor = System.Drawing.Color.Coral;
            this.qtdSort.Location = new System.Drawing.Point(519, 90);
            this.qtdSort.Name = "qtdSort";
            this.qtdSort.Size = new System.Drawing.Size(250, 83);
            this.qtdSort.TabIndex = 7;
            this.qtdSort.Text = "9";
            this.qtdSort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // qtdpart
            // 
            this.qtdpart.Font = new System.Drawing.Font("Arial", 50F);
            this.qtdpart.ForeColor = System.Drawing.Color.Coral;
            this.qtdpart.Location = new System.Drawing.Point(246, 90);
            this.qtdpart.Name = "qtdpart";
            this.qtdpart.Size = new System.Drawing.Size(250, 83);
            this.qtdpart.TabIndex = 5;
            this.qtdpart.Text = "9";
            this.qtdpart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // part
            // 
            this.part.AutoSize = true;
            this.part.Font = new System.Drawing.Font("Arial", 30F);
            this.part.Location = new System.Drawing.Point(246, 45);
            this.part.Name = "part";
            this.part.Size = new System.Drawing.Size(246, 45);
            this.part.TabIndex = 4;
            this.part.Text = "Participantes";
            // 
            // conc
            // 
            this.conc.Font = new System.Drawing.Font("Arial", 50F);
            this.conc.ForeColor = System.Drawing.Color.Coral;
            this.conc.Location = new System.Drawing.Point(3, 90);
            this.conc.Name = "conc";
            this.conc.Size = new System.Drawing.Size(250, 83);
            this.conc.TabIndex = 3;
            this.conc.Text = "9";
            this.conc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 30F);
            this.label23.Location = new System.Drawing.Point(96, 45);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 45);
            this.label23.TabIndex = 1;
            this.label23.Text = "Nº";
            // 
            // btEncerrarConc
            // 
            this.btEncerrarConc.BackColor = System.Drawing.Color.White;
            this.btEncerrarConc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btEncerrarConc.FlatAppearance.BorderSize = 0;
            this.btEncerrarConc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btEncerrarConc.Font = new System.Drawing.Font("Arial", 20F);
            this.btEncerrarConc.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btEncerrarConc.Location = new System.Drawing.Point(323, 373);
            this.btEncerrarConc.Name = "btEncerrarConc";
            this.btEncerrarConc.Size = new System.Drawing.Size(158, 75);
            this.btEncerrarConc.TabIndex = 25;
            this.btEncerrarConc.Text = "Encerrar Concurso";
            this.btEncerrarConc.UseVisualStyleBackColor = false;
            this.btEncerrarConc.Click += new System.EventHandler(this.btEncerrarConc_Click);
            // 
            // TelaConcurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 456);
            this.Controls.Add(this.btEncerrarConc);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaConcurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Concursos";
            this.Load += new System.EventHandler(this.TelaConcurso_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVenc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelFechado;
        private System.Windows.Forms.Label labelAberto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label qtdSort;
        private System.Windows.Forms.Label qtdpart;
        private System.Windows.Forms.Label part;
        private System.Windows.Forms.Label conc;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label labelVenc;
        private System.Windows.Forms.DataGridView dgVenc;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button btEncerrarConc;
        private System.Windows.Forms.Label labelEmAndamento;
    }
}