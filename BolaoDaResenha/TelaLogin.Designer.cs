namespace BolaoDaResenha
{
    partial class TelaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLogin));
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelSenha = new System.Windows.Forms.Label();
            this.labelInfos = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.botaoConfirmar = new System.Windows.Forms.Button();
            this.botaoCancelar = new System.Windows.Forms.Button();
            this.labelErro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.BackColor = System.Drawing.Color.Transparent;
            this.labelUsuario.Font = new System.Drawing.Font("Arial", 12F);
            this.labelUsuario.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelUsuario.Location = new System.Drawing.Point(44, 57);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(66, 18);
            this.labelUsuario.TabIndex = 0;
            this.labelUsuario.Text = "Usuário:";
            this.labelUsuario.Click += new System.EventHandler(this.labelUsuario_Click);
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Font = new System.Drawing.Font("Arial", 12F);
            this.labelSenha.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelSenha.Location = new System.Drawing.Point(44, 102);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(57, 18);
            this.labelSenha.TabIndex = 1;
            this.labelSenha.Text = "Senha:";
            // 
            // labelInfos
            // 
            this.labelInfos.AutoSize = true;
            this.labelInfos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelInfos.Location = new System.Drawing.Point(106, 9);
            this.labelInfos.Name = "labelInfos";
            this.labelInfos.Size = new System.Drawing.Size(185, 18);
            this.labelInfos.TabIndex = 2;
            this.labelInfos.Text = "Informe suas Credenciais";
            this.labelInfos.Click += new System.EventHandler(this.labelInfos_Click);
            // 
            // tbUsuario
            // 
            this.tbUsuario.BackColor = System.Drawing.Color.White;
            this.tbUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsuario.Font = new System.Drawing.Font("Arial", 12F);
            this.tbUsuario.ForeColor = System.Drawing.Color.Coral;
            this.tbUsuario.Location = new System.Drawing.Point(133, 54);
            this.tbUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.tbUsuario.MaxLength = 10;
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(147, 26);
            this.tbUsuario.TabIndex = 3;
            this.tbUsuario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbUsuario_KeyUp);
            // 
            // tbSenha
            // 
            this.tbSenha.BackColor = System.Drawing.Color.White;
            this.tbSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSenha.Font = new System.Drawing.Font("Arial", 12F);
            this.tbSenha.ForeColor = System.Drawing.Color.Coral;
            this.tbSenha.Location = new System.Drawing.Point(133, 99);
            this.tbSenha.MaxLength = 10;
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.Size = new System.Drawing.Size(147, 26);
            this.tbSenha.TabIndex = 4;
            this.tbSenha.UseSystemPasswordChar = true;
            this.tbSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSenha_KeyUp);
            // 
            // botaoConfirmar
            // 
            this.botaoConfirmar.BackColor = System.Drawing.Color.White;
            this.botaoConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botaoConfirmar.Font = new System.Drawing.Font("Arial", 12F);
            this.botaoConfirmar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.botaoConfirmar.Location = new System.Drawing.Point(17, 169);
            this.botaoConfirmar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoConfirmar.Name = "botaoConfirmar";
            this.botaoConfirmar.Size = new System.Drawing.Size(93, 36);
            this.botaoConfirmar.TabIndex = 5;
            this.botaoConfirmar.Text = "Confirmar";
            this.botaoConfirmar.UseVisualStyleBackColor = false;
            this.botaoConfirmar.Click += new System.EventHandler(this.botaoConfirmar_Click);
            // 
            // botaoCancelar
            // 
            this.botaoCancelar.BackColor = System.Drawing.Color.White;
            this.botaoCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botaoCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.botaoCancelar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.botaoCancelar.Location = new System.Drawing.Point(285, 169);
            this.botaoCancelar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoCancelar.Name = "botaoCancelar";
            this.botaoCancelar.Size = new System.Drawing.Size(93, 36);
            this.botaoCancelar.TabIndex = 6;
            this.botaoCancelar.Text = "Cancelar";
            this.botaoCancelar.UseVisualStyleBackColor = false;
            this.botaoCancelar.Click += new System.EventHandler(this.botaoCancelar_Click);
            // 
            // labelErro
            // 
            this.labelErro.AutoSize = true;
            this.labelErro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErro.ForeColor = System.Drawing.Color.Red;
            this.labelErro.Location = new System.Drawing.Point(106, 138);
            this.labelErro.Name = "labelErro";
            this.labelErro.Size = new System.Drawing.Size(210, 18);
            this.labelErro.TabIndex = 7;
            this.labelErro.Text = "Usuário ou Senha incorretos!";
            this.labelErro.Visible = false;
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(390, 217);
            this.Controls.Add(this.labelErro);
            this.Controls.Add(this.botaoCancelar);
            this.Controls.Add(this.botaoConfirmar);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.labelInfos);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.labelUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelaLogin_FormClosed);
            this.Load += new System.EventHandler(this.TelaLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.Label labelInfos;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.Button botaoConfirmar;
        private System.Windows.Forms.Button botaoCancelar;
        private System.Windows.Forms.Label labelErro;
    }
}