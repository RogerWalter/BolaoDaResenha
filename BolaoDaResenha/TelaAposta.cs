using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace BolaoDaResenha
{
    public partial class TelaAposta : Form
    {

        public TelaAposta()
        {
            InitializeComponent();
        }


        public void recebeValorTBApo(String nome)
        {
            if (nome == "--")
            {
                tbApostador.Text = "";
            }
            else
            {
                tbApostador.Text = nome.ToString();
            }
        }

        public void recebeValorTBCam(String nome)
        {
            if (nome == "--")
            {
                tbCambista.Text = "";
            }
            else
            {
                tbCambista.Text = nome.ToString();
            }
        }

        private void tbN1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }




        private void TelaAposta_Load(object sender, EventArgs e)
        {
            tbApostador.Focus();
            tbApostador.Select();

            List<string> apelidos = new List<string>();
            using (FbConnection conn = new FbConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ConnectionString;
                using (FbCommand cmd = new FbCommand())
                {
                    cmd.CommandText = "SELECT APELIDO FROM APOSTADOR";
                    //cmd.Parameters.AddWithValue("@Texto", prefixo);
                    cmd.Connection = conn;
                    conn.Open();
                    using (FbDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            apelidos.Add(string.Format("{0}", sdr["APELIDO"]));
                        }
                    }
                    conn.Close();
                }
            }

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            foreach (string name in apelidos)
            {
                source.Add(name);
            }

            tbApostador.AutoCompleteCustomSource = source;

            List<string> cambista = new List<string>();
            using (FbConnection conn = new FbConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ConnectionString;
                using (FbCommand cmd = new FbCommand())
                {
                    cmd.CommandText = "SELECT NOME FROM CAMBISTA";
                    //cmd.Parameters.AddWithValue("@Texto", prefixo);
                    cmd.Connection = conn;
                    conn.Open();
                    using (FbDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            cambista.Add(string.Format("{0}", sdr["NOME"]));
                        }
                    }
                    conn.Close();
                }
            }

            AutoCompleteStringCollection source1 = new AutoCompleteStringCollection();

            foreach (string name1 in cambista)
            {
                source1.Add(name1);
            }

            tbCambista.AutoCompleteCustomSource = source1;

        }

        private void tbN1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN2.Focus();
                tbN2.Select();
            }
        }

        private void tbN2_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN3.Focus();
                tbN3.Select();
            }
        }

        private void tbN3_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN4.Focus();
                tbN4.Select();
            }
        }

        private void tbN4_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN5.Focus();
                tbN5.Select();
            }
        }

        private void tbN5_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN6.Focus();
                tbN6.Select();
            }
        }

        private void tbN6_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN7.Focus();
                tbN7.Select();
            }
        }

        private void tbN7_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN8.Focus();
                tbN8.Select();
            }
        }

        private void tbN8_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN9.Focus();
                tbN9.Select();
            }
        }

        private void tbN9_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN10.Focus();
                tbN10.Select();
            }
        }

        private void tbN10_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbCambista.Focus();
                tbCambista.Select();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(tbCambista.Text == "" || tbApostador.Text == "" || tbN1.Text == "" || tbN2.Text == "" || tbN3.Text == "" || tbN4.Text == "" || tbN5.Text == "" || tbN6.Text == "" || tbN7.Text == "" || tbN8.Text == "" || tbN9.Text == "" || tbN10.Text == "")
            {
                MessageBox.Show("Existem campos que não foram preenchidos!", "Campo sem preenchimento", MessageBoxButtons.OK);
                return;
            }

            int idCambista = AcessoFB.fb_verificaIdCambista(tbCambista.Text.ToString());
            if (idCambista == 0 || idCambista.ToString() == "" || idCambista.ToString() == null)//Verifica o Cambista, caso não esteja cadastrado, não deixa prosseguir.
            {
                MessageBox.Show("Por gentileza, acesse o Gerenciamento de Cambistas e cadastre este Cambista", "Cambista não cadastrado", MessageBoxButtons.OK);
                return;
            }
            String numeroSalvar = tbN1.Text + "-" + tbN2.Text + "-" + tbN3.Text + "-" + tbN4.Text + "-" + tbN5.Text + "-" + tbN6.Text + "-" + tbN7.Text + "-" + tbN8.Text + "-" + tbN9.Text + "-" + tbN10.Text;
            String numeroMostrar = tbN1.Text + " - " + tbN2.Text + " - " + tbN3.Text + " - " + tbN4.Text + " - " + tbN5.Text + "\n" + tbN6.Text + " - " + tbN7.Text + " - " + tbN8.Text + " - " + tbN9.Text + " - " + tbN10.Text;
            TelaConfirmacao confirma = new TelaConfirmacao();
            confirma.preencheLabel(tbApostador.Text, numeroSalvar, tbCambista.Text, numeroMostrar);
            

            if(confirma.ShowDialog() == DialogResult.OK)
            {
                tbApostador.Text = "";
                tbCambista.Text = "";
                tbN1.Text = "";
                tbN2.Text = "";
                tbN3.Text = "";
                tbN4.Text = "";
                tbN5.Text = "";
                tbN6.Text = "";
                tbN7.Text = "";
                tbN8.Text = "";
                tbN9.Text = "";
                tbN10.Text = "";
                this.Close();
            }
            else
            {
                btConfirmar.Focus();
                btConfirmar.Select();
            }
            

        }

        private void tbApostador_TextChanged(object sender, EventArgs e)
        {
            /*String resultado = AcessoFB.fb_pesquisaApostadorCOMECA(tbApostador.Text);
            if(resultado == "VAZIA" || resultado == null || resultado == "")
            {
                resultado = AcessoFB.fb_pesquisaApostadorFINAL(tbApostador.Text);
                if (resultado == "VAZIA" || resultado == null || resultado == "")
                {
                    resultado = AcessoFB.fb_pesquisaApostadorCONTENDO(tbApostador.Text);
                    if (resultado == "VAZIA" || resultado == null || resultado == "")
                    {
                        resultado = AcessoFB.fb_pesquisaApostadorCOMPLETO(tbApostador.Text);
                        tbApostador.Text = resultado;
                    }
                    tbApostador.Text = resultado;
                }
                tbApostador.Text = resultado;
            }
            tbApostador.Text = resultado;*/
        }

        private void tbCambista_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btConfirmar.PerformClick();
            }
        }

        private void tbApostador_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbN1.Focus();
                tbN1.Select();
            }
        }

        private void tbN1_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN1.Text = "0" + tbN1.Text;
            }
        }

        private void tbN2_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN2.Text = "0" + tbN2.Text;
            }
        }

        private void tbN3_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN3.Text = "0" + tbN3.Text;
            }
        }

        private void tbN4_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN4.Text = "0" + tbN4.Text;
            }
        }

        private void tbN5_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN5.Text = "0" + tbN5.Text;
            }
        }

        private void tbN6_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN6.Text = "0" + tbN6.Text;
            }
        }

        private void tbN7_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN7.Text = "0" + tbN7.Text;
            }
        }

        private void tbN8_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN8.Text = "0" + tbN8.Text;
            }
        }

        private void tbN9_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN9.Text = "0" + tbN9.Text;
            }
        }

        private void tbN10_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN10.Text = "0" + tbN10.Text;
            }
        }

        private void TelaAposta_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Refresh();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btBuscarApostador_Click(object sender, EventArgs e)
        {
            TelaConsultarApostadores nova = new TelaConsultarApostadores();
            nova.ShowDialog();
            recebeValorTBApo(nova.enviaNomeApo());
        }

        private void btBuscarCambista_Click(object sender, EventArgs e)
        {
            TelaConsultarCambista nova = new TelaConsultarCambista();
            nova.ShowDialog();
            recebeValorTBCam(nova.enviaNomeCam());
        }
    }
}
