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
    public partial class TelaApostador : Form
    {
        public TelaApostador()
        {
            InitializeComponent();
        }

        private void TelaApostador_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;  
                
            BindingSource bindingSource1 = new BindingSource();
            // TODO: esta linha de código carrega dados na tabela 'bDBolaoDaResenha.APOSTADOR'. Você pode movê-la ou removê-la conforme necessário.
            //this.aPOSTADORTableAdapter.Fill(this.bDBolaoDaResenha.APOSTADOR);
            DataTable apostadores = new DataTable("Apostadores");
            DataSet teste = new DataSet();
            apostadores= AcessoFB.fb_buscaApostadoresTeste();
            teste.Tables.Add(apostadores);
            //dataGridView1.SetDataBinding(teste, "Apostadores");
            bindingSource1.DataSource = apostadores;
            dataGridView1.DataSource = bindingSource1;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            TelaAvisoApagarApostadores nova = new TelaAvisoApagarApostadores();
            nova.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
