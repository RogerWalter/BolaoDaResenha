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
    public partial class TelaConsultarCambista : Form
    {
        public TelaConsultarCambista()
        {
            InitializeComponent();
        }

        String nomeCam = "--";
        public String enviaNomeCam()
        {
            return nomeCam;
        }
        private void TelaConsultarCambista_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;

            BindingSource bindingSource1 = new BindingSource();
            DataTable cambistas = new DataTable("Cambistas");
            DataSet dsFinal = new DataSet();
            cambistas = AcessoFB.fb_buscaCambistaFinal();
            dsFinal.Tables.Add(cambistas);
            bindingSource1.DataSource = cambistas;
            dataGridView1.DataSource = bindingSource1;
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                nomeCam = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                nomeCam = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                Console.WriteLine(nomeCam);
            }
            catch
            {

            }
        }
    }
}
