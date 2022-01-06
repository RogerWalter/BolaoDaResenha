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
    public partial class TelaConsultarSorteio : Form
    {
        int nConc = 0;
        public TelaConsultarSorteio()
        {
            InitializeComponent();
        }

        private void preencheGridAtual()
        {
            try
            {
                dataGridView1.DataSource = AcessoFB.fb_PreencheGridSorteioAtual().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }


        public void limpaCampos()
        {
            tbN1.Text = "";
            tbN2.Text = "";
            tbN3.Text = "";
            tbN4.Text = "";
            tbN5.Text = "";
            labelNConc.Text = "--";
            tbNConcurso.Text = "";
        }
        private void preencheGridAnterior()
        {
            
            if (Anterior.Text == "")
            {
                MessageBox.Show("O concurso anterior não foi informado", "Erro!", MessageBoxButtons.OK);
                return;
            }
            try
            {
                dataGridView1.DataSource = AcessoFB.fb_PreencheGridSorteioAnterior(Convert.ToInt32(tbNConcurso.Text)).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }

        private void TelaConsultarSorteio_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;
        }

        private void Atual_CheckedChanged(object sender, EventArgs e)
        {
            if (Atual.Checked == true)
            {
                limpaCampos();
                int nAtual = AcessoFB.fb_buscaNumeroConcursoAtual();
                labelNConc.Text = nAtual.ToString();
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
            if (Anterior.Checked == true)
            {
                limpaCampos(); 
                dataGridView1.DataSource = null;
                Atual.Checked = false;
                labelN.Visible = true;
                tbNConcurso.Visible = true;
                tbNConcurso.Focus();
                tbNConcurso.Select();
            }
            if (Anterior.Checked == false)
            {
                limpaCampos();
                Atual.Checked = true;
                labelN.Visible = false;
                tbNConcurso.Visible = false;
            }
        }

        public void preencheTB(String numeros)
        {
            if (Anterior.Checked == true)
            {
                labelNConc.Text = tbNConcurso.Text;

            }
            if (Atual.Checked == true)
            {

                labelNConc.Text = Convert.ToString(AcessoFB.fb_buscaNumeroConcursoAtual());
            }
            tbN1.Text = numeros.Substring(0, 2).ToString(); // 12-23-32-45-34
            tbN2.Text = numeros.Substring(3, 2).ToString();
            tbN3.Text = numeros.Substring(6, 2).ToString();
            tbN4.Text = numeros.Substring(9, 2).ToString();
            tbN5.Text = numeros.Substring(12, 2).ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String numeros = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                preencheTB(numeros);
            }
            
        }

        private void tbNConcurso_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbNConcurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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
                if(Convert.ToInt32(tbNConcurso.Text) == a)
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                String numeros = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                preencheTB(numeros);
            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
