using Microsoft.Reporting.WebForms.Internal.Soap.ReportingServices2005.Execution;
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
    public partial class TelaRelatorios : Form
    {
        int pontoDeParada = 0;
        int nComprovante = 0;
        TelaCarregandoTelas gerando = new TelaCarregandoTelas();
        public void recebeValorTB(int nComp)
        {
            if(nComp == 0)
            {
                tbNcomprovante.Text = "";
            }
            else
            {
                tbNcomprovante.Text = nComp.ToString();
            }
            nComprovante = nComp;
        }
        public TelaRelatorios()
        {
            InitializeComponent();
        }

        int parametro = 0;
        public void recebeParametro(int para)
        {
            parametro = para;
        }
        public void BotaoGerarRelatorio()
        {
            

            int click = 1;
            int concAtual = AcessoFB.fb_buscaNumeroConcursoAtual();
            AcessoFB.fb_preencheTabelaRelatorio();

            TelaRelatorioAcertosGerado nova = new TelaRelatorioAcertosGerado(parametro);
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

        public void BotaoGerarComprovante()
        {

            int click = 2;

            String numCompOriginais = "";
            String numMostrarComp = "";
            String n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;
            nComprovante = Convert.ToInt32(tbNcomprovante.Text);

            numCompOriginais = AcessoFB.fb_buscaNumerosDoComprovante(nComprovante);

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
            nova.recebeNumComp(nComprovante, numMostrarComp);
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
        int btClicado = 0; // 1 - relatorio | 2 - comp unico | 3 - comp todos
        private void btGerarComp_Click(object sender, EventArgs e)
        {
            if (tbNcomprovante.Text == "")
            {
                MessageBox.Show("Não foi informado o número do comprovante!", "Erro!", MessageBoxButtons.OK);
                return;
            }

            btClicado = 2;

            gerando.Show();
            gerando.BringToFront();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            if (backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void tbN1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            TelaConsultarComprovante nova = new TelaConsultarComprovante();
            nova.ShowDialog();
            recebeValorTB(nova.enviaCodComp());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            btClicado = 1;

            TelaRelatorioParametro par = new TelaRelatorioParametro();
            if (par.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            recebeParametro(par.retornaParametro());
            gerando.Show();
            gerando.BringToFront();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            if (backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (btClicado == 1)
            {
                BotaoGerarRelatorio();
            }
            if (btClicado == 2)
            {
                BotaoGerarComprovante();
            }
            if (btClicado == 3)
            {
                BotaoGerarTodosComprovantes();
            }
        }

        public void fechaCarregamento()
        {
            if (gerando.InvokeRequired)
            {
                gerando.Invoke(new Action(() => gerando.Hide()));
            }
            else
            {
                gerando.Hide();
            }
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

        private void TelaRelatorios_Load(object sender, EventArgs e)
        {
            int concAtual = AcessoFB.fb_verificaConcAberto();
            int vencedor = AcessoFB.fb_verificaSeConcursoJaTemVencedor(concAtual);
            /*
            if (vencedor != 0 || vencedor > 0)
            {
                TelaAvisoGerarRelatorio nova = new TelaAvisoGerarRelatorio();
                nova.ShowDialog();
                this.Close();
            }*/
            int sorteio = AcessoFB.fb_verificaSeJaHouvesorteioNoConAtual(concAtual);
            if (sorteio == 0 || sorteio < 0)
            {
                TelaAvisoRelatorioSemSorteio novo = new TelaAvisoRelatorioSemSorteio();
                novo.ShowDialog();
                button2.Enabled = false;
            }

            int aposta = AcessoFB.fb_verificaSeExisteApostaNoConcursoAtual(concAtual);
            if (aposta == 0 || aposta < 0)
            {
                TelaAvisoRelatorioSemAposta novi = new TelaAvisoRelatorioSemAposta();
                novi.ShowDialog();
                this.Close();
            }
        }
        public void BotaoGerarTodosComprovantes()
        {
            pontoDeParada = 0;
            int click = 3;

            int concAtual = AcessoFB.fb_verificaConcAberto();
            int qtdCompConcAtual = AcessoFB.fb_contarQtdComprovantesNoConc(concAtual);
            int priCompConc = AcessoFB.fb_verificaIdDoPrimCompDoConc(concAtual);

            int i = priCompConc;
            int f = priCompConc + qtdCompConcAtual;

            for(i = priCompConc; i < f; i++)
            {
                String numCompOriginais = "";
                String numMostrarComp = "";
                String n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;
                nComprovante = i;

                numCompOriginais = AcessoFB.fb_buscaNumerosDoComprovante(nComprovante);

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
                nova.recebeNumComp(nComprovante, numMostrarComp);
                nova.ShowDialog();
            }

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


        private void button3_Click(object sender, EventArgs e)
        {
            btClicado = 3;
            gerando.Show();
            gerando.BringToFront();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            if (backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }

    }
}
