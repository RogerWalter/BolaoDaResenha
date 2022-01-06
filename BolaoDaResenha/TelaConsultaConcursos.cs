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
    public partial class TelaConsultaConcursos : Form
    {
        public TelaConsultaConcursos()
        {
            InitializeComponent();
        }

        private void preencheGrid()
        {
            try
            {
                dataGridView1.DataSource = AcessoFB.fb_PreencheGridConsultaConcursoAtual().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }


        private void part_Click(object sender, EventArgs e)
        {

        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            TelaConcurso nova = new TelaConcurso();
            nova.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int nConc = 0;
        private void tbNConcurso_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void TelaConsultaConcursos_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;

            preencheGrid();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int numConc = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                String status = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                int qtdSorte = Convert.ToInt32(AcessoFB.fb_contarQtdSorteiosNoConc(numConc));
                int qtdParti = Convert.ToInt32(AcessoFB.fb_contarQtdApostasNoConc(numConc));

                labelNConc.Text = numConc.ToString();
                qtdpart.Text = qtdParti.ToString();
                qtdSort.Text = qtdSorte.ToString();

                if (status == "Atual")
                {
                    qtdpart.ForeColor = Color.LimeGreen;
                    qtdSort.ForeColor = Color.LimeGreen;
                    labelNConc.ForeColor = Color.LimeGreen;
                }
            }
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                qtdpart.ForeColor = Color.Coral;
                qtdSort.ForeColor = Color.Coral;
                labelNConc.ForeColor = Color.Coral;

                int numConc = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                String status = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                int qtdSorte = Convert.ToInt32(AcessoFB.fb_contarQtdSorteiosNoConc(numConc));
                int qtdParti = Convert.ToInt32(AcessoFB.fb_contarQtdApostasNoConc(numConc));

                labelNConc.Text = numConc.ToString();
                qtdpart.Text = qtdParti.ToString();
                qtdSort.Text = qtdSorte.ToString();

                if (status != "Fechado")
                {
                    qtdpart.ForeColor = Color.LimeGreen;
                    qtdSort.ForeColor = Color.LimeGreen;
                    labelNConc.ForeColor = Color.LimeGreen;
                }
            }
            catch
            {

            }

        }
    }
}
