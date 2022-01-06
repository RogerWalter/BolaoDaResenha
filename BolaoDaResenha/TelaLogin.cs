using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BolaoDaResenha
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botaoConfirmar_Click(object sender, EventArgs e)
        {
            if((tbUsuario.Text == "")||(tbSenha.Text == ""))
            {
                MessageBox.Show("Existem campos que não foram preenchidos!", "Erro ao efetuar login", MessageBoxButtons.OK);
                return;
            }


            //OPÇÃO DE LOGIN PARA VARIOS USUÁRIOS

            /*
            Usuario usuario = new Usuario(); 
            String login = tbUsuario.Text;
            String senha = tbSenha.Text;
            usuario = AcessoFB.fb_efetuaLogin(login, senha);
            if((usuario.Login == null) || (usuario.Login == "") || (usuario.Senha == null) || (usuario.Senha == ""))
            {
                tbUsuario.Text = "";
                tbSenha.Text = "";
                labelErro.Visible = true;
                return;
            }*/

            if((tbUsuario.Text == "limpar") && (tbSenha.Text == "limpar"))
            {
                AcessoFB.fb_LimpaBanco();
                DialogResult = DialogResult.Cancel;
                return;
            }
                // LOGIN SOMENTE PARA UM USUÁRIO, SEM NECESSIDADE DO BANCO
                if ((tbUsuario.Text != "esquilo") && (tbSenha.Text != "marcio123"))
            {
                tbUsuario.Text = "";
                tbSenha.Text = "";
                labelErro.Visible = true;
                tbUsuario.Focus();
                tbUsuario.Select();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void tbUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.botaoConfirmar.PerformClick();
            }
        }

        private void tbSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.botaoConfirmar.PerformClick();
            }
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {
            tbUsuario.Focus();
            tbUsuario.Select();
        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            labelErro.Visible = false;
        }

        private void tbSenha_Enter(object sender, EventArgs e)
        {
            labelErro.Visible = false;
        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void labelInfos_Click(object sender, EventArgs e)
        {

        }

        private void TelaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
