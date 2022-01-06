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
    public partial class TelaRelatorioParametro : Form
    {
        public TelaRelatorioParametro()
        {
            InitializeComponent();
        }

        int parametro = 1; // 1 - Sequencia | 2 - Qtd de acertos

        public int retornaParametro()
        {
            return parametro;
        }
        private void TelaRelatorioParametro_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;
            parametro = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label1.Visible = false;
            parametro = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
