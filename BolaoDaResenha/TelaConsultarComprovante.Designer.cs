namespace BolaoDaResenha
{
    partial class TelaConsultarComprovante
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cOMPROVANTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bDBolaoDaResenha = new BolaoDaResenha.BDBolaoDaResenha();
            this.button1 = new System.Windows.Forms.Button();
            this.cOMPROVANTETableAdapter = new BolaoDaResenha.BDBolaoDaResenhaTableAdapters.COMPROVANTETableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbT = new System.Windows.Forms.RadioButton();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDCONCURSODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMEAPOSTADORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMECAMBISTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMEROSAPOSTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDAPOSTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPROVANTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDBolaoDaResenha)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.iDCONCURSODataGridViewTextBoxColumn,
            this.nOMEAPOSTADORDataGridViewTextBoxColumn,
            this.dATADataGridViewTextBoxColumn,
            this.nOMECAMBISTADataGridViewTextBoxColumn,
            this.nUMEROSAPOSTADataGridViewTextBoxColumn,
            this.iDAPOSTADataGridViewTextBoxColumn});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.DataSource = this.cOMPROVANTEBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(698, 354);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // cOMPROVANTEBindingSource
            // 
            this.cOMPROVANTEBindingSource.DataMember = "COMPROVANTE";
            this.cOMPROVANTEBindingSource.DataSource = this.bDBolaoDaResenha;
            // 
            // bDBolaoDaResenha
            // 
            this.bDBolaoDaResenha.DataSetName = "BDBolaoDaResenha";
            this.bDBolaoDaResenha.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 12F);
            this.button1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(608, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 44);
            this.button1.TabIndex = 28;
            this.button1.Text = "Ok!";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cOMPROVANTETableAdapter
            // 
            this.cOMPROVANTETableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.rbB);
            this.groupBox1.Controls.Add(this.rbA);
            this.groupBox1.Controls.Add(this.rbT);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 46);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parâmetros";
            // 
            // rbT
            // 
            this.rbT.AutoSize = true;
            this.rbT.ForeColor = System.Drawing.Color.Coral;
            this.rbT.Location = new System.Drawing.Point(133, 17);
            this.rbT.Name = "rbT";
            this.rbT.Size = new System.Drawing.Size(68, 22);
            this.rbT.TabIndex = 0;
            this.rbT.Text = "Todos";
            this.rbT.UseVisualStyleBackColor = true;
            this.rbT.CheckedChanged += new System.EventHandler(this.rbT_CheckedChanged);
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Checked = true;
            this.rbA.ForeColor = System.Drawing.Color.Coral;
            this.rbA.Location = new System.Drawing.Point(6, 17);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(61, 22);
            this.rbA.TabIndex = 1;
            this.rbA.TabStop = true;
            this.rbA.Text = "Atual";
            this.rbA.UseVisualStyleBackColor = true;
            this.rbA.CheckedChanged += new System.EventHandler(this.rbA_CheckedChanged);
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.ForeColor = System.Drawing.Color.Coral;
            this.rbB.Location = new System.Drawing.Point(249, 17);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(79, 22);
            this.rbB.TabIndex = 2;
            this.rbB.Text = "Buscar:";
            this.rbB.UseVisualStyleBackColor = true;
            this.rbB.CheckedChanged += new System.EventHandler(this.rbB_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.Color.Coral;
            this.textBox1.Location = new System.Drawing.Point(330, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(98, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.FillWeight = 126.9036F;
            this.iDDataGridViewTextBoxColumn.HeaderText = "NUMERO";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 80;
            // 
            // iDCONCURSODataGridViewTextBoxColumn
            // 
            this.iDCONCURSODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iDCONCURSODataGridViewTextBoxColumn.DataPropertyName = "ID_CONCURSO";
            this.iDCONCURSODataGridViewTextBoxColumn.FillWeight = 93.27411F;
            this.iDCONCURSODataGridViewTextBoxColumn.HeaderText = "CONCURSO";
            this.iDCONCURSODataGridViewTextBoxColumn.MinimumWidth = 50;
            this.iDCONCURSODataGridViewTextBoxColumn.Name = "iDCONCURSODataGridViewTextBoxColumn";
            this.iDCONCURSODataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCONCURSODataGridViewTextBoxColumn.Width = 120;
            // 
            // nOMEAPOSTADORDataGridViewTextBoxColumn
            // 
            this.nOMEAPOSTADORDataGridViewTextBoxColumn.DataPropertyName = "NOME_APOSTADOR";
            this.nOMEAPOSTADORDataGridViewTextBoxColumn.FillWeight = 93.27411F;
            this.nOMEAPOSTADORDataGridViewTextBoxColumn.HeaderText = "APELIDO";
            this.nOMEAPOSTADORDataGridViewTextBoxColumn.Name = "nOMEAPOSTADORDataGridViewTextBoxColumn";
            this.nOMEAPOSTADORDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dATADataGridViewTextBoxColumn
            // 
            this.dATADataGridViewTextBoxColumn.DataPropertyName = "DATA";
            this.dATADataGridViewTextBoxColumn.FillWeight = 93.27411F;
            this.dATADataGridViewTextBoxColumn.HeaderText = "DATA";
            this.dATADataGridViewTextBoxColumn.Name = "dATADataGridViewTextBoxColumn";
            this.dATADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOMECAMBISTADataGridViewTextBoxColumn
            // 
            this.nOMECAMBISTADataGridViewTextBoxColumn.DataPropertyName = "NOME_CAMBISTA";
            this.nOMECAMBISTADataGridViewTextBoxColumn.HeaderText = "NOME_CAMBISTA";
            this.nOMECAMBISTADataGridViewTextBoxColumn.Name = "nOMECAMBISTADataGridViewTextBoxColumn";
            this.nOMECAMBISTADataGridViewTextBoxColumn.ReadOnly = true;
            this.nOMECAMBISTADataGridViewTextBoxColumn.Visible = false;
            // 
            // nUMEROSAPOSTADataGridViewTextBoxColumn
            // 
            this.nUMEROSAPOSTADataGridViewTextBoxColumn.DataPropertyName = "NUMEROS_APOSTA";
            this.nUMEROSAPOSTADataGridViewTextBoxColumn.FillWeight = 93.27411F;
            this.nUMEROSAPOSTADataGridViewTextBoxColumn.HeaderText = "APOSTA";
            this.nUMEROSAPOSTADataGridViewTextBoxColumn.Name = "nUMEROSAPOSTADataGridViewTextBoxColumn";
            this.nUMEROSAPOSTADataGridViewTextBoxColumn.ReadOnly = true;
            this.nUMEROSAPOSTADataGridViewTextBoxColumn.Visible = false;
            // 
            // iDAPOSTADataGridViewTextBoxColumn
            // 
            this.iDAPOSTADataGridViewTextBoxColumn.DataPropertyName = "ID_APOSTA";
            this.iDAPOSTADataGridViewTextBoxColumn.HeaderText = "ID_APOSTA";
            this.iDAPOSTADataGridViewTextBoxColumn.Name = "iDAPOSTADataGridViewTextBoxColumn";
            this.iDAPOSTADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDAPOSTADataGridViewTextBoxColumn.Visible = false;
            // 
            // TelaConsultarComprovante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(722, 430);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TelaConsultarComprovante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprovantes";
            this.Load += new System.EventHandler(this.TelaConsultarComprovante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPROVANTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDBolaoDaResenha)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private BDBolaoDaResenha bDBolaoDaResenha;
        private System.Windows.Forms.BindingSource cOMPROVANTEBindingSource;
        private BDBolaoDaResenhaTableAdapters.COMPROVANTETableAdapter cOMPROVANTETableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.RadioButton rbA;
        private System.Windows.Forms.RadioButton rbT;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCONCURSODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMEAPOSTADORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMECAMBISTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMEROSAPOSTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDAPOSTADataGridViewTextBoxColumn;
    }
}