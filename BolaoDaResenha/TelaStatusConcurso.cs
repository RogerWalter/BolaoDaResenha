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
    public partial class TelaStatusConcurso : Form
    {
        int visivel = 0; // 1 = visível | 2 = não visível       
        public TelaStatusConcurso()
        {
            InitializeComponent();
        }

        private void TelaStatusConcurso_Load(object sender, EventArgs e)
        {
            int atual = AcessoFB.fb_buscaNumeroConcursoAtual();
            // verificar se o concurso que está aberto no momento possui um vencedor, caso tenha, não deixa inserir um novo sorteio antes de encerrar  o concurso que já acabou
            int verificaConcurso = AcessoFB.fb_verificaSeConcursoJaTemVencedor(atual);
            if (verificaConcurso != 0 || verificaConcurso > 0)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;

                pictureBox1.Visible = true;
                fim.Visible = true;
            }

            if (verificaConcurso == 0)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;

                pictureBox1.Visible = false;
                fim.Visible = false;
            }

            //ajustando o status do concurso, primeiramente, verificando o pódium...
            int[] quantidadesAcertos = new int[10];// esse vetor irá possuir a quantidade de apostadores com a determinada qtd de acertos. Ex: 23 apostadores com 3 acertos. O vetor, na posição 3 terá o 23.
            for (int q = 0; q < 10; q++)
            {
                quantidadesAcertos[q] = AcessoFB.fb_buscaQuantidadesDeAcertosParaStatus(q);
            }

            l0.Text = quantidadesAcertos[0].ToString();
            l1.Text = quantidadesAcertos[1].ToString();
            l2.Text = quantidadesAcertos[2].ToString();
            l3.Text = quantidadesAcertos[3].ToString();
            l4.Text = quantidadesAcertos[4].ToString();
            l5.Text = quantidadesAcertos[5].ToString();
            l6.Text = quantidadesAcertos[6].ToString();
            l7.Text = quantidadesAcertos[7].ToString();
            l8.Text = quantidadesAcertos[8].ToString();
            l9.Text = quantidadesAcertos[9].ToString();

            int concurso = AcessoFB.fb_buscaNumeroConcursoAtual();

            conc.Text = concurso.ToString();
            qtdpart.Text = AcessoFB.fb_contaQtdApostadoresConcurso(concurso).ToString();
            qtdSort.Text = AcessoFB.fb_contarQtdSorteiosNoConc(concurso).ToString();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void qtdpart_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

         

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (visivel == 0)
            {
                labelInfo1.Visible = false;
                labelInfo2.Visible = false;
                labelInfo3.Visible = false;
                labelInfo4.Visible = false;
                visivel = 1;
                return;
            }
            if (visivel == 1)
            {
                labelInfo1.Visible = true;
                labelInfo2.Visible = true;
                labelInfo3.Visible = true;
                labelInfo4.Visible = true;
                visivel = 0;
                return;
            }
        }
    }
}
