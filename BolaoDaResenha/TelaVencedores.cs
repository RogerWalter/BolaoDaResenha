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
    public partial class TelaVencedores : Form
    {
        public TelaVencedores()
        {
            InitializeComponent();
        }

        private void preencheGridTodos()
        {
            try
            {
                dataGridView1.DataSource = AcessoFB.fb_PreencheGridVencedoresTodos().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void preencheGridAtual()
        {
            try
            {
                dataGridView1.DataSource = AcessoFB.fb_PreencheGridVencedoresAtual().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        public void limpaCampos()
        {
            
            labelNConc.Text = "--";
            tbNConcurso.Text = "";
            label1.Text = "--";
            label2.Text = "--";
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
                dataGridView1.DataSource = AcessoFB.fb_PreencheGridVencedoresAnterior(Convert.ToInt32(tbNConcurso.Text)).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }

        private void TelaVencedores_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;
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

        public void preencheTB(String nome, String numeros, int con)
        {
            if (Anterior.Checked == true)
            {
                labelNConc.Text = tbNConcurso.Text;

            }
            if (Atual.Checked == true)
            {

                labelNConc.Text = Convert.ToString(AcessoFB.fb_buscaNumeroConcursoAtual());
            }
            if (Todos.Checked == true)
            {
                labelNConc.Text = Convert.ToString(con);
            }
            label1.Text = nome.ToString();
            label2.Text = numeros.ToString();

        }

        
        private void Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (Todos.Checked == true)
            {
                limpaCampos();
                Atual.Checked = false;
                Anterior.Checked = false;
                labelN.Visible = false;
                tbNConcurso.Visible = false;
                preencheGridTodos();
            }
            if (Todos.Checked == false)
            {
                limpaCampos();
                dataGridView1.DataSource = null;
            }
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
                Todos.Checked = false;
                preencheGridAtual();
            }
            if (Atual.Checked == false)
            {
                limpaCampos();
                dataGridView1.DataSource = null;
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
                Todos.Checked = false;
                tbNConcurso.Focus();
                tbNConcurso.Select();
            }
            if (Anterior.Checked == false)
            {
                limpaCampos();
                dataGridView1.DataSource = null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int num = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                String nome = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                String aposta = AcessoFB.fb_PreencheLabelNumerosVencedores(num, nome);
                preencheTB(nome, aposta, num);
            }

        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                String nome = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                String aposta = AcessoFB.fb_PreencheLabelNumerosVencedores(num, nome);
                preencheTB(nome, aposta, num);
            }
            catch
            {

            }
            
        }
    }
}
