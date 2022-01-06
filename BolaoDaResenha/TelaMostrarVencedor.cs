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

namespace BolaoDaResenha
{
    public partial class TelaMostrarVencedor : Form
    {
        public TelaMostrarVencedor()
        {
            InitializeComponent();
        }
        
        private void num5_Click(object sender, EventArgs e)
        {

        }

        public void PreencheGrid()
        {
            BindingSource bindingSource1 = new BindingSource();
            DataTable vencedores = new DataTable("Vencedores");
            DataSet dsFinal = new DataSet();
            vencedores = AcessoFB.fb_PreencheGridVencedoresFinal();
            dsFinal.Tables.Add(vencedores);
            bindingSource1.DataSource = vencedores;
            dataGridView1.DataSource = bindingSource1;
        }

        private void TelaMostrarVencedor_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.Coral;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Coral;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.White;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label4.Parent = pictureBox2;
            label4.BackColor = Color.Transparent;
            label4.Left = 218;
            label4.Top = 89;

            PreencheGrid();
        }
        int contador = 0; //usado para ver quantas vezes já foi clicado no botão de fechar
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            contador++;
            if (contador == 1)
            {
                label4.Visible = false;
                label4.Visible = false;
                label4.Visible = false;
                dataGridView1.Visible = false;
                pictureBox1.Visible = false;
                label4.Left = 58;
                label4.Top = 49;
                label4.Visible = true;
                pictureBox2.Visible = true;
                btConfirmar.Text = "Entendi!";
            }
            if (contador == 2)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
