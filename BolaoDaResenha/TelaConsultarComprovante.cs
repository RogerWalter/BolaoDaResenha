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
    public partial class TelaConsultarComprovante : Form
    {
        int nComprovante = 0;
        public int enviaCodComp()
        {
            return nComprovante;
        }
        public TelaConsultarComprovante()
        {
            InitializeComponent();
        }

        private void TelaConsultarComprovante_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bDBolaoDaResenha.COMPROVANTE'. Você pode movê-la ou removê-la conforme necessário.
            //this.cOMPROVANTETableAdapter.Fill(this.bDBolaoDaResenha.COMPROVANTE);

            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;
            
            BindingSource bindingSource1 = new BindingSource();
            DataTable comprovantes = new DataTable("Comprovantes");
            DataSet dsFinal = new DataSet();
            comprovantes = AcessoFB.fb_buscaComprovantesFinalConcAtual();
            dsFinal.Tables.Add(comprovantes);
            bindingSource1.DataSource = comprovantes;
            dataGridView1.DataSource = bindingSource1;

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                nComprovante = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.DataSource = null;

                BindingSource bindingSource1 = new BindingSource();
                DataTable comprovantes = new DataTable("Comprovantes");
                DataSet dsFinal = new DataSet();
                comprovantes = AcessoFB.fb_buscaComprovantesFinalConcBusca(Convert.ToInt32(textBox1.Text));
                dsFinal.Tables.Add(comprovantes);
                bindingSource1.DataSource = comprovantes;
                dataGridView1.DataSource = bindingSource1;
            }
        }

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            if(rbA.Checked == true)
            {
                rbB.Checked = false;
                rbT.Checked = false;
                textBox1.Text = "";
                textBox1.Enabled = false;
                dataGridView1.DataSource = null;

                BindingSource bindingSource1 = new BindingSource();
                DataTable comprovantes = new DataTable("Comprovantes");
                DataSet dsFinal = new DataSet();
                comprovantes = AcessoFB.fb_buscaComprovantesFinalConcAtual();
                dsFinal.Tables.Add(comprovantes);
                bindingSource1.DataSource = comprovantes;
                dataGridView1.DataSource = bindingSource1;

            }
            
            
        }

        private void rbT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbT.Checked == true)
            {
                rbB.Checked = false;
                rbA.Checked = false;
                textBox1.Text = "";
                textBox1.Enabled = false;

                dataGridView1.DataSource = null;

                BindingSource bindingSource1 = new BindingSource();
                DataTable comprovantes = new DataTable("Comprovantes");
                DataSet dsFinal = new DataSet();
                comprovantes = AcessoFB.fb_buscaComprovantesFinalConcTodos();
                dsFinal.Tables.Add(comprovantes);
                bindingSource1.DataSource = comprovantes;
                dataGridView1.DataSource = bindingSource1;
            }
        }

        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbB.Checked == true)
            {
                rbA.Checked = false;
                rbT.Checked = false;

                dataGridView1.DataSource = null;
                textBox1.Enabled = true;
                textBox1.Focus();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                nComprovante = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {

            }
            
        }
    }
}
