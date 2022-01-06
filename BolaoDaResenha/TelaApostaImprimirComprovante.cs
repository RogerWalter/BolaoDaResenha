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
    public partial class TelaApostaImprimirComprovante : Form
    {
        int numComprovante = 0;
        String numerosComprovante = "";
        int pontoDeParada = 0;
        TelaCarregandoTelas carregando = new TelaCarregandoTelas();
        public void recebeNumComp(int numC, String numComp)
        {
            numComprovante = numC;
            numerosComprovante = numComp;
        }
        public TelaApostaImprimirComprovante()
        {
            InitializeComponent();
        }

        private void TelaApostaImprimirComprovante_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.btConfirmar.PerformClick();
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label4.Visible == true)
            {
                label4.Visible = false;
                LabApo.Visible = false;
                pictureBox1.Visible = false;
                label1.Visible = true;
                pictureBox2.Visible = true;
            }
            else
            {
                label4.Visible = true;
                LabApo.Visible = true;
                pictureBox1.Visible = true;
                label1.Visible = false;
                pictureBox2.Visible = false;
            }
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            /*
            TelaComprovanteGerado novo = new TelaComprovanteGerado();
            novo.recebeNumComp(numComprovante, numerosComprovante);
            novo.Show();
            this.Close();
            */
            carregando.Show();
            carregando.BringToFront();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            if (backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
            }

        }

        private void LabApo_Click(object sender, EventArgs e)
        {

        }

        private void TelaApostaImprimirComprovante_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;
        }

        public void BotaoGerarComprovante()
        {
            int click = 2;

            String numCompOriginais = "";
            String numMostrarComp = "";
            String n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;

            numCompOriginais = AcessoFB.fb_buscaNumerosDoComprovante(numComprovante);

            n1 = numCompOriginais.Substring(0, 2);
            n2 = numCompOriginais.Substring(3, 2);
            n3 = numCompOriginais.Substring(6, 2);
            n4 = numCompOriginais.Substring(9, 2);
            n5 = numCompOriginais.Substring(12, 2);
            n6 = numCompOriginais.Substring(15, 2);
            n7 = numCompOriginais.Substring(18, 2);
            n8 = numCompOriginais.Substring(21, 2);
            n9 = numCompOriginais.Substring(24, 2);
            n10 = numCompOriginais.Substring(27, 2);

            numMostrarComp = n1 + " - " + n2 + " - " + n3 + " - " + n4 + " - " + n5 + "\n" + n6 + " - " + n7 + " - " + n8 + " - " + n9 + " - " + n10;

            TelaComprovanteGerado nova = new TelaComprovanteGerado();
            nova.recebeNumComp(numComprovante, numMostrarComp);
            nova.ShowDialog();

            pontoDeParada = 1;

            TelaCaminhoRelatorioMostrar teste = new TelaCaminhoRelatorioMostrar();
            teste.DeOndeVem(click);
            teste.ShowDialog();

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.Close()));
            }
            else
            {
                this.Close();
            }
        }

        public void fechaCarregamento()
        {
            if (carregando.InvokeRequired)
            {
                carregando.Invoke(new Action(() => carregando.Close()));
            }
            else
            {
                carregando.Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BotaoGerarComprovante();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            do
            {
                num = pontoDeParada;

            } while (num != 1);
            fechaCarregamento();

        }
    }
}
