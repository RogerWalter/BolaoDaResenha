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
    public partial class TelaPlacar : Form
    {
        public TelaPlacar()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TelaPlacar_Load(object sender, EventArgs e)
        {
            int concurso = AcessoFB.fb_buscaNumeroConcursoAtual();
            int verificaConcurso = AcessoFB.fb_verificaSeConcursoJaTemVencedor(concurso);
            int jaTemSorteio = AcessoFB.fb_verificaSeJaHouvesorteioNoConAtual(concurso);
            if (verificaConcurso != 0 || verificaConcurso > 0 || jaTemSorteio == 0)
            {
                l0.Text = "--";
                l1.Text = "--";
                l2.Text = "--";
                l3.Text = "--";
                l4.Text = "--";
                l5.Text = "--";
                l6.Text = "--";
                l7.Text = "--";
                l8.Text = "--";
                l9.Text = "--";
            }
            else
            {
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
            }  
        }
    }
}
