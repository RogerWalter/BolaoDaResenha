namespace BolaoDaResenha
{
    partial class TelaAposta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaAposta));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbApostador = new System.Windows.Forms.TextBox();
            this.tbN1 = new System.Windows.Forms.TextBox();
            this.tbCambista = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbN2 = new System.Windows.Forms.TextBox();
            this.tbN3 = new System.Windows.Forms.TextBox();
            this.tbN4 = new System.Windows.Forms.TextBox();
            this.tbN5 = new System.Windows.Forms.TextBox();
            this.tbN6 = new System.Windows.Forms.TextBox();
            this.tbN7 = new System.Windows.Forms.TextBox();
            this.tbN8 = new System.Windows.Forms.TextBox();
            this.tbN9 = new System.Windows.Forms.TextBox();
            this.tbN10 = new System.Windows.Forms.TextBox();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btBuscarCambista = new System.Windows.Forms.Button();
            this.btBuscarApostador = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apostador:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 18F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(8, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 80);
            this.label2.TabIndex = 1;
            this.label2.Text = "Números Apostados:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 18F);
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(15, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cambista:";
            // 
            // tbApostador
            // 
            this.tbApostador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbApostador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbApostador.BackColor = System.Drawing.Color.White;
            this.tbApostador.Font = new System.Drawing.Font("Arial", 20F);
            this.tbApostador.ForeColor = System.Drawing.Color.Coral;
            this.tbApostador.Location = new System.Drawing.Point(149, 52);
            this.tbApostador.MaxLength = 25;
            this.tbApostador.Name = "tbApostador";
            this.tbApostador.Size = new System.Drawing.Size(263, 38);
            this.tbApostador.TabIndex = 3;
            this.tbApostador.TextChanged += new System.EventHandler(this.tbApostador_TextChanged);
            this.tbApostador.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbApostador_KeyUp);
            // 
            // tbN1
            // 
            this.tbN1.BackColor = System.Drawing.Color.White;
            this.tbN1.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN1.ForeColor = System.Drawing.Color.Coral;
            this.tbN1.Location = new System.Drawing.Point(149, 108);
            this.tbN1.MaxLength = 2;
            this.tbN1.Name = "tbN1";
            this.tbN1.Size = new System.Drawing.Size(40, 38);
            this.tbN1.TabIndex = 4;
            this.tbN1.TextChanged += new System.EventHandler(this.tbN1_TextChanged);
            this.tbN1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN1_KeyPress);
            this.tbN1.Leave += new System.EventHandler(this.tbN1_Leave);
            // 
            // tbCambista
            // 
            this.tbCambista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbCambista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbCambista.BackColor = System.Drawing.Color.White;
            this.tbCambista.Font = new System.Drawing.Font("Arial", 20F);
            this.tbCambista.ForeColor = System.Drawing.Color.Coral;
            this.tbCambista.Location = new System.Drawing.Point(149, 204);
            this.tbCambista.MaxLength = 25;
            this.tbCambista.Name = "tbCambista";
            this.tbCambista.Size = new System.Drawing.Size(266, 38);
            this.tbCambista.TabIndex = 5;
            this.tbCambista.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCambista_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 20F);
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(140, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Inserir Nova Aposta";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbN2
            // 
            this.tbN2.BackColor = System.Drawing.Color.White;
            this.tbN2.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN2.ForeColor = System.Drawing.Color.Coral;
            this.tbN2.Location = new System.Drawing.Point(204, 108);
            this.tbN2.MaxLength = 2;
            this.tbN2.Name = "tbN2";
            this.tbN2.Size = new System.Drawing.Size(40, 38);
            this.tbN2.TabIndex = 7;
            this.tbN2.TextChanged += new System.EventHandler(this.tbN2_TextChanged);
            this.tbN2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN2_KeyPress);
            this.tbN2.Leave += new System.EventHandler(this.tbN2_Leave);
            // 
            // tbN3
            // 
            this.tbN3.BackColor = System.Drawing.Color.White;
            this.tbN3.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN3.ForeColor = System.Drawing.Color.Coral;
            this.tbN3.Location = new System.Drawing.Point(259, 108);
            this.tbN3.MaxLength = 2;
            this.tbN3.Name = "tbN3";
            this.tbN3.Size = new System.Drawing.Size(40, 38);
            this.tbN3.TabIndex = 8;
            this.tbN3.TextChanged += new System.EventHandler(this.tbN3_TextChanged);
            this.tbN3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN3_KeyPress);
            this.tbN3.Leave += new System.EventHandler(this.tbN3_Leave);
            // 
            // tbN4
            // 
            this.tbN4.BackColor = System.Drawing.Color.White;
            this.tbN4.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN4.ForeColor = System.Drawing.Color.Coral;
            this.tbN4.Location = new System.Drawing.Point(315, 108);
            this.tbN4.MaxLength = 2;
            this.tbN4.Name = "tbN4";
            this.tbN4.Size = new System.Drawing.Size(40, 38);
            this.tbN4.TabIndex = 9;
            this.tbN4.TextChanged += new System.EventHandler(this.tbN4_TextChanged);
            this.tbN4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN4_KeyPress);
            this.tbN4.Leave += new System.EventHandler(this.tbN4_Leave);
            // 
            // tbN5
            // 
            this.tbN5.BackColor = System.Drawing.Color.White;
            this.tbN5.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN5.ForeColor = System.Drawing.Color.Coral;
            this.tbN5.Location = new System.Drawing.Point(372, 108);
            this.tbN5.MaxLength = 2;
            this.tbN5.Name = "tbN5";
            this.tbN5.Size = new System.Drawing.Size(40, 38);
            this.tbN5.TabIndex = 10;
            this.tbN5.TextChanged += new System.EventHandler(this.tbN5_TextChanged);
            this.tbN5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN5_KeyPress);
            this.tbN5.Leave += new System.EventHandler(this.tbN5_Leave);
            // 
            // tbN6
            // 
            this.tbN6.BackColor = System.Drawing.Color.White;
            this.tbN6.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN6.ForeColor = System.Drawing.Color.Coral;
            this.tbN6.Location = new System.Drawing.Point(149, 150);
            this.tbN6.MaxLength = 2;
            this.tbN6.Name = "tbN6";
            this.tbN6.Size = new System.Drawing.Size(40, 38);
            this.tbN6.TabIndex = 11;
            this.tbN6.TextChanged += new System.EventHandler(this.tbN6_TextChanged);
            this.tbN6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN6_KeyPress);
            this.tbN6.Leave += new System.EventHandler(this.tbN6_Leave);
            // 
            // tbN7
            // 
            this.tbN7.BackColor = System.Drawing.Color.White;
            this.tbN7.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN7.ForeColor = System.Drawing.Color.Coral;
            this.tbN7.Location = new System.Drawing.Point(204, 150);
            this.tbN7.MaxLength = 2;
            this.tbN7.Name = "tbN7";
            this.tbN7.Size = new System.Drawing.Size(40, 38);
            this.tbN7.TabIndex = 12;
            this.tbN7.TextChanged += new System.EventHandler(this.tbN7_TextChanged);
            this.tbN7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN7_KeyPress);
            this.tbN7.Leave += new System.EventHandler(this.tbN7_Leave);
            // 
            // tbN8
            // 
            this.tbN8.BackColor = System.Drawing.Color.White;
            this.tbN8.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN8.ForeColor = System.Drawing.Color.Coral;
            this.tbN8.Location = new System.Drawing.Point(259, 150);
            this.tbN8.MaxLength = 2;
            this.tbN8.Name = "tbN8";
            this.tbN8.Size = new System.Drawing.Size(40, 38);
            this.tbN8.TabIndex = 13;
            this.tbN8.TextChanged += new System.EventHandler(this.tbN8_TextChanged);
            this.tbN8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN8_KeyPress);
            this.tbN8.Leave += new System.EventHandler(this.tbN8_Leave);
            // 
            // tbN9
            // 
            this.tbN9.BackColor = System.Drawing.Color.White;
            this.tbN9.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN9.ForeColor = System.Drawing.Color.Coral;
            this.tbN9.Location = new System.Drawing.Point(315, 150);
            this.tbN9.MaxLength = 2;
            this.tbN9.Name = "tbN9";
            this.tbN9.Size = new System.Drawing.Size(40, 38);
            this.tbN9.TabIndex = 14;
            this.tbN9.TextChanged += new System.EventHandler(this.tbN9_TextChanged);
            this.tbN9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN9_KeyPress);
            this.tbN9.Leave += new System.EventHandler(this.tbN9_Leave);
            // 
            // tbN10
            // 
            this.tbN10.BackColor = System.Drawing.Color.White;
            this.tbN10.Font = new System.Drawing.Font("Arial", 20F);
            this.tbN10.ForeColor = System.Drawing.Color.Coral;
            this.tbN10.Location = new System.Drawing.Point(372, 150);
            this.tbN10.MaxLength = 2;
            this.tbN10.Name = "tbN10";
            this.tbN10.Size = new System.Drawing.Size(40, 38);
            this.tbN10.TabIndex = 15;
            this.tbN10.TextChanged += new System.EventHandler(this.tbN10_TextChanged);
            this.tbN10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN10_KeyPress);
            this.tbN10.Leave += new System.EventHandler(this.tbN10_Leave);
            // 
            // btConfirmar
            // 
            this.btConfirmar.BackColor = System.Drawing.Color.White;
            this.btConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConfirmar.FlatAppearance.BorderSize = 0;
            this.btConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btConfirmar.Font = new System.Drawing.Font("Arial", 18F);
            this.btConfirmar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btConfirmar.Location = new System.Drawing.Point(12, 265);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(131, 54);
            this.btConfirmar.TabIndex = 16;
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.UseVisualStyleBackColor = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.BorderSize = 0;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancelar.Font = new System.Drawing.Font("Arial", 18F);
            this.btCancelar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btCancelar.Location = new System.Drawing.Point(374, 265);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(131, 54);
            this.btCancelar.TabIndex = 17;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btBuscarCambista
            // 
            this.btBuscarCambista.BackColor = System.Drawing.Color.White;
            this.btBuscarCambista.BackgroundImage = global::BolaoDaResenha.Properties.Resources.BuscarIcone;
            this.btBuscarCambista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btBuscarCambista.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarCambista.FlatAppearance.BorderSize = 0;
            this.btBuscarCambista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBuscarCambista.Font = new System.Drawing.Font("Arial", 12F);
            this.btBuscarCambista.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btBuscarCambista.Location = new System.Drawing.Point(421, 204);
            this.btBuscarCambista.Name = "btBuscarCambista";
            this.btBuscarCambista.Size = new System.Drawing.Size(87, 38);
            this.btBuscarCambista.TabIndex = 19;
            this.btBuscarCambista.UseVisualStyleBackColor = false;
            this.btBuscarCambista.Click += new System.EventHandler(this.btBuscarCambista_Click);
            // 
            // btBuscarApostador
            // 
            this.btBuscarApostador.BackColor = System.Drawing.Color.White;
            this.btBuscarApostador.BackgroundImage = global::BolaoDaResenha.Properties.Resources.BuscarIcone;
            this.btBuscarApostador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btBuscarApostador.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarApostador.FlatAppearance.BorderSize = 0;
            this.btBuscarApostador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBuscarApostador.Font = new System.Drawing.Font("Arial", 12F);
            this.btBuscarApostador.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btBuscarApostador.Location = new System.Drawing.Point(418, 52);
            this.btBuscarApostador.Name = "btBuscarApostador";
            this.btBuscarApostador.Size = new System.Drawing.Size(87, 38);
            this.btBuscarApostador.TabIndex = 18;
            this.btBuscarApostador.UseVisualStyleBackColor = false;
            this.btBuscarApostador.Click += new System.EventHandler(this.btBuscarApostador_Click);
            // 
            // TelaAposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(517, 331);
            this.Controls.Add(this.btBuscarCambista);
            this.Controls.Add(this.btBuscarApostador);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.tbN10);
            this.Controls.Add(this.tbN9);
            this.Controls.Add(this.tbN8);
            this.Controls.Add(this.tbN7);
            this.Controls.Add(this.tbN6);
            this.Controls.Add(this.tbN5);
            this.Controls.Add(this.tbN4);
            this.Controls.Add(this.tbN3);
            this.Controls.Add(this.tbN2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCambista);
            this.Controls.Add(this.tbN1);
            this.Controls.Add(this.tbApostador);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaAposta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova Aposta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelaAposta_FormClosed);
            this.Load += new System.EventHandler(this.TelaAposta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbApostador;
        private System.Windows.Forms.TextBox tbN1;
        private System.Windows.Forms.TextBox tbCambista;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbN2;
        private System.Windows.Forms.TextBox tbN3;
        private System.Windows.Forms.TextBox tbN4;
        private System.Windows.Forms.TextBox tbN5;
        private System.Windows.Forms.TextBox tbN6;
        private System.Windows.Forms.TextBox tbN7;
        private System.Windows.Forms.TextBox tbN8;
        private System.Windows.Forms.TextBox tbN9;
        private System.Windows.Forms.TextBox tbN10;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btBuscarApostador;
        private System.Windows.Forms.Button btBuscarCambista;
    }
}