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
    public partial class TelaAvisoEncerrarConcurso : Form
    {
        public TelaAvisoEncerrarConcurso()
        {
            InitializeComponent();
        }

        private void labelInfo2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            int atual = AcessoFB.fb_buscaNumeroConcursoAtual();
            AcessoFB.fb_encerrarConcurso(atual);
            AcessoFB.fb_LimpaTabelaAcertos();
            AcessoFB.fb_adicionarNovoConcurso(atual + 1);
            TelaOperacaoConcluida nova = new TelaOperacaoConcluida();
            nova.ShowDialog();
            this.Close();
        }
    }
}
