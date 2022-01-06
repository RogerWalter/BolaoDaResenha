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
    public partial class TelaConsultarApostadores : Form
    {
        public TelaConsultarApostadores()
        {
            InitializeComponent();
        }
        String nomeApo = "--";

        public String enviaNomeApo()
        {
            return nomeApo;
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TelaConsultarApostadores_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;

            BindingSource bindingSource1 = new BindingSource();
            DataTable apostadores = new DataTable("Apostadores");
            DataSet dsFinal = new DataSet();
            apostadores = AcessoFB.fb_buscaApostadoresTeste();
            dsFinal.Tables.Add(apostadores);
            bindingSource1.DataSource = apostadores;
            dataGridView1.DataSource = bindingSource1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                nomeApo = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                nomeApo = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            }
            catch
            {

            }
            
        }
    }
}
