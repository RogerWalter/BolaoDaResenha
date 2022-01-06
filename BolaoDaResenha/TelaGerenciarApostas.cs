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
    public partial class TelaGerenciarApostas : Form
    {
        public TelaGerenciarApostas()
        {
            InitializeComponent();
        }
        int atual = AcessoFB.fb_buscaNumeroConcursoAtual();
        private void preencheGridAtual()
        {
            try
            {
                dataGridView1.DataSource = AcessoFB.fb_PreencheGridConcursoAtual().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
            labelNConc.Text = atual.ToString();
        }

        private void preencheGridAnterior()
        {
            if(Anterior.Text == "")
            {
                MessageBox.Show("O concurso anterior não foi informado", "Erro!", MessageBoxButtons.OK);
                return;
            }
            try
            {
                dataGridView1.DataSource = AcessoFB.fb_PreencheGridConcursoAnterior(Convert.ToInt32(tbNConcurso.Text)).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
            labelNConc.Text = tbNConcurso.Text;
        }

        private void tbApostador_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbApostador_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void limpaCampos()
        {
            dataGridView1.DataSource = null;

            labelNConc.Text = "--";
            labelNApo.Text = "--";
            labelApelido.Text = "--";

            tbNConcurso.Text = "";
            tbQtd.Text = "--";

            tbN1.Text = "--";
            tbN2.Text = "--";
            tbN3.Text = "--";
            tbN4.Text = "--";
            tbN5.Text = "--";
            tbN6.Text = "--";
            tbN7.Text = "--";
            tbN8.Text = "--";
            tbN9.Text = "--";
            tbN10.Text = "--";

            a1.Text = "--";
            a2.Text = "--";
            a3.Text = "--";
            a4.Text = "--";
            a5.Text = "--";
            a6.Text = "--";
            a7.Text = "--";
            a8.Text = "--";
            a9.Text = "--";
            a10.Text = "--";

            r1.Text = "--";
            r2.Text = "--";
            r3.Text = "--";
            r4.Text = "--";
            r5.Text = "--";
            r6.Text = "--";
            r7.Text = "--";
            r8.Text = "--";
            r9.Text = "--";
            r10.Text = "--";

        }


        private void Atual_CheckedChanged(object sender, EventArgs e)
        {
            if(Atual.Checked == true)
            {
                limpaCampos();
                Anterior.Checked = false;
                labelN.Visible = false;
                tbNConcurso.Visible = false;
                preencheGridAtual();
                
            }
            if (Atual.Checked == false)
            {
                limpaCampos();
                Anterior.Checked = true;
                labelN.Visible = true;
                tbNConcurso.Visible = true;
            }

        }

        private void Anterior_CheckedChanged(object sender, EventArgs e)
        {
            if(Anterior.Checked == true)
            {
                limpaCampos();
                Atual.Checked = false;
                labelN.Visible = true;
                tbNConcurso.Visible = true;
                tbNConcurso.Focus();
                tbNConcurso.Select();
            }
            if(Anterior.Checked == false)
            {
                limpaCampos();
                Atual.Checked = true;
                labelN.Visible = false;
                tbNConcurso.Visible = false;
            }
        }

        private void TelaGerenciarApostas_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;
        }

        int nConc = 0;
        private void tbNConcurso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int a = AcessoFB.fb_buscaNumeroConcursoAtual();
                if (tbNConcurso.Text == "")
                {
                    MessageBox.Show("O concurso anterior não foi informado", "Erro!", MessageBoxButtons.OK);
                    return;
                }
                if (Convert.ToInt32(tbNConcurso.Text) == a)
                {
                    Atual.Checked = true;
                    Anterior.Checked = false;
                    tbNConcurso.Text = "";
                    tbNConcurso.Visible = false;
                }
                else
                {
                    labelNConc.Text = tbNConcurso.Text;
                    preencheGridAnterior();
                }
            }
        }
        
        public void preencheTB(String apelido, String numeros, int idAposta, int qtdAcertos)
        {
            TelaCarregandoTelas carregando = new TelaCarregandoTelas();
            carregando.Show();

            int resposta = 0;

            carregando.recebeResposta(resposta);

            if (Anterior.Checked == true)
            {
                labelNConc.Text = nConc.ToString();
               
            }
            if (Atual.Checked == true)
            {
                
                labelNConc.Text = Convert.ToString(AcessoFB.fb_buscaNumeroConcursoAtual());
            }

            labelNApo.Text = idAposta.ToString();
            labelApelido.Text = apelido.ToString();
            tbQtd.Text = qtdAcertos.ToString();

            String acertados = AcessoFB.fb_buscaNumerosAcertadosAnteriormente(idAposta);
            String restantes = AcessoFB.fb_buscaNumerosRestantes(idAposta);
            int verificacao = AcessoFB.fb_verificaSeJaHouvesorteioNoConAtual(atual);

            tbN1.Text = numeros.Substring(0, 2).ToString();
            tbN2.Text = numeros.Substring(3, 2).ToString();
            tbN3.Text = numeros.Substring(6, 2).ToString();
            tbN4.Text = numeros.Substring(9, 2).ToString();
            tbN5.Text = numeros.Substring(12, 2).ToString();
            tbN6.Text = numeros.Substring(15, 2).ToString();
            tbN7.Text = numeros.Substring(18, 2).ToString();
            tbN8.Text = numeros.Substring(21, 2).ToString();
            tbN9.Text = numeros.Substring(24, 2).ToString();
            tbN10.Text = numeros.Substring(27, 2).ToString();

            if(verificacao == 0 || verificacao.ToString() == null)
            {
                a1.Text = "--";
                a2.Text = "--";
                a3.Text = "--";
                a4.Text = "--";
                a5.Text = "--";
                a6.Text = "--";
                a7.Text = "--";
                a8.Text = "--";
                a9.Text = "--";
                a10.Text = "--";

                r1.Text = "--";
                r2.Text = "--";
                r3.Text = "--";
                r4.Text = "--";
                r5.Text = "--";
                r6.Text = "--";
                r7.Text = "--";
                r8.Text = "--";
                r9.Text = "--";
                r10.Text = "--";
            }
            if(verificacao > 0)
            {
                a1.Text = acertados.Substring(0, 2).ToString();
                a2.Text = acertados.Substring(3, 2).ToString();
                a3.Text = acertados.Substring(6, 2).ToString();
                a4.Text = acertados.Substring(9, 2).ToString();
                a5.Text = acertados.Substring(12, 2).ToString();
                a6.Text = acertados.Substring(15, 2).ToString();
                a7.Text = acertados.Substring(18, 2).ToString();
                a8.Text = acertados.Substring(21, 2).ToString();
                a9.Text = acertados.Substring(24, 2).ToString();
                a10.Text = acertados.Substring(27, 2).ToString();

                r1.Text = restantes.Substring(0, 2).ToString();
                r2.Text = restantes.Substring(3, 2).ToString();
                r3.Text = restantes.Substring(6, 2).ToString();
                r4.Text = restantes.Substring(9, 2).ToString();
                r5.Text = restantes.Substring(12, 2).ToString();
                r6.Text = restantes.Substring(15, 2).ToString();
                r7.Text = restantes.Substring(18, 2).ToString();
                r8.Text = restantes.Substring(21, 2).ToString();
                r9.Text = restantes.Substring(24, 2).ToString();
                r10.Text = restantes.Substring(27, 2).ToString();
            }

            resposta = 1;

            carregando.recebeResposta(resposta);

            carregando.Close();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String apelido = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                String numeros = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                int idAposta = AcessoFB.fb_buscaIdApostaComNumerosApelido(apelido, numeros);
                int qtdAcertos = 0;
                try
                {
                    qtdAcertos = AcessoFB.fb_buscaQtdAcertosBaseadoEmIdAposta(idAposta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
                }
                preencheTB(apelido, numeros, idAposta, qtdAcertos);
            }
            
        }

        private void labelApelido_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelNApo_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                String apelido = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                String numeros = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                int idAposta = AcessoFB.fb_buscaIdApostaComNumerosApelido(apelido, numeros);
                int qtdAcertos = 0;
                try
                {
                    qtdAcertos = AcessoFB.fb_buscaQtdAcertosBaseadoEmIdAposta(idAposta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
                }
                preencheTB(apelido, numeros, idAposta, qtdAcertos);
            }
            catch
            {

            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            return;
        }
    }
}
