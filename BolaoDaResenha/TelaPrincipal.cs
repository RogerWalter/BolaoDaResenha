using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BolaoDaResenha
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        public void CarregaDados()
        {
            
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

        public void CarregaPlacar()
        {
            int concurso = AcessoFB.fb_buscaNumeroConcursoAtual();
            int verificaConcurso = AcessoFB.fb_verificaSeConcursoJaTemVencedor(concurso);
            int jaTemSorteio = AcessoFB.fb_verificaSeJaHouvesorteioNoConAtual(concurso);
            if ((verificaConcurso != 0 || verificaConcurso > 0) || jaTemSorteio == 0)
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
                

        public void CarregaDadosConcurso()
        {
            int concurso = AcessoFB.fb_buscaNumeroConcursoAtual();

            conc.Text = concurso.ToString();
            qtdpart.Text = AcessoFB.fb_contaQtdApostadoresConcurso(concurso).ToString();
            qtdSort.Text = AcessoFB.fb_contarQtdSorteiosNoConc(concurso).ToString();

            int verificaConcurso = AcessoFB.fb_verificaSeConcursoJaTemVencedor(concurso);
            int sorteioJaOcorreu = AcessoFB.fb_verificaSeJaHouvesorteioNoConAtual(concurso);
            if (sorteioJaOcorreu != 0 || sorteioJaOcorreu > 0)
            {
                labelAberto.Visible = false;
                labelFechado.Visible = false;
                labelEmAndamento.Visible = true;
            }

            if (verificaConcurso != 0 || verificaConcurso > 0)
            {
                labelAberto.Visible = false;
                labelFechado.Visible = true;
                labelEmAndamento.Visible = false;
            }

            if (verificaConcurso == 0 && sorteioJaOcorreu == 0)
            {
                labelAberto.Visible = true;
                labelFechado.Visible = false;
                labelEmAndamento.Visible = false;
            }
        }

        public void CarregaGridApostas()
        {
            dataGridView1.DataSource = null;

            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.Coral;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Coral;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.White;

            BindingSource bindingSource1 = new BindingSource();
            DataTable apostas = new DataTable("Apostas");
            DataSet dsFinal = new DataSet();
            apostas = AcessoFB.fb_buscaApostaPrincipalFinal();
            dsFinal.Tables.Add(apostas);
            bindingSource1.DataSource = apostas;
            dataGridView1.DataSource = bindingSource1;

            if(qtdpart.Text == "0")
            {
                dataGridView1.DataSource = null;
            }

        }

        int verificador = 0;

        public void CarregaDadosPrincipal()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Hide()));
                }
                else
                {
                    this.Hide();
                }
            }
            //verifica se existe algum concurso cadastrado, caso não exista, cria um novo para as apostas serem adicionadas a este
            int verificaConcursoZero = AcessoFB.fb_verificaSeExisteConcursoNaTabela();
            if (verificaConcursoZero.ToString() == null || verificaConcursoZero <= 0)
            {
                AcessoFB.fb_adicionarNovoConcurso(1);
            }

            //CARREGA O PLACAR 
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.CarregaPlacar()));
            }
            else
            {
                this.CarregaPlacar();
            }
            //CARREGA DADOS DO CONCURSO
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.CarregaDadosConcurso()));
            }
            else
            {
                this.CarregaDadosConcurso();
            }
            //PREENCHE GRID APOSTAS
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.CarregaGridApostas()));
            }
            else
            {
                this.CarregaGridApostas();
            }
            verificador = 1;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.Show()));
            }
            else
            {
                this.Show();
            }
            if(this.WindowState == FormWindowState.Minimized)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.WindowState = FormWindowState.Normal));
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }
        public void fechaCarregamento()
        {
            if (carregando.InvokeRequired)
            {
                carregando.Invoke(new Action(() => carregando.Hide()));
            }
            else
            {
                carregando.Hide();
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.BringToFront()));
            }
            else
            {
                this.BringToFront();
            }
        }

        TelaCarregandoTelas carregando = new TelaCarregandoTelas();



        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            CarregaDados();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CarregaDadosPrincipal();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            do
            {
                num = verificador;

            } while (num != 1);
            fechaCarregamento();
        }

        private void novaApostaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(labelEmAndamento.Visible == true)
            {
                TelaAvisoAposta erro = new TelaAvisoAposta();
                erro.ShowDialog();
                erro.BringToFront();
                return;
            }
            else
            {
                if(labelFechado.Visible == true)
                {
                    TelaAvisoApostaConcFechado errado = new TelaAvisoApostaConcFechado();
                    errado.ShowDialog();
                    errado.BringToFront();
                    return;
                }
                else
                {
                    TelaAposta nova = new TelaAposta();
                    nova.ShowDialog();
                }
                
            }
            CarregaDados();
        }

        private void gerenciarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TelaCambista nova = new TelaCambista();
            nova.ShowDialog();
            CarregaDados();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TelaConsultarCambista nova = new TelaConsultarCambista();
            nova.ShowDialog();
            CarregaDados();
        }

        private void apostasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gerenciarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TelaGerenciarApostas nova = new TelaGerenciarApostas();
            nova.ShowDialog();
            CarregaDados();
        }

        private void novoSorteioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (labelFechado.Visible == true)
            {
                TelaAvisoSorteio erro = new TelaAvisoSorteio();
                erro.ShowDialog();
                erro.BringToFront();
            }
            else
            {
                if (qtdpart.Text == "0")
                {
                    TelaAvisoSorteioSemAposta erro = new TelaAvisoSorteioSemAposta();
                    erro.ShowDialog();
                    erro.BringToFront();
                }
                else
                {
                    TelaSorteio nova = new TelaSorteio();
                    nova.ShowDialog();
                }
            }
            CarregaDados();
        }

        private void gerenciarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TelaConcurso nova = new TelaConcurso();
            nova.ShowDialog();
            CarregaDados();
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaStatusConcurso novo = new TelaStatusConcurso();
            novo.ShowDialog();
            CarregaDados();
        }

        private void placarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaPlacar novo = new TelaPlacar();
            novo.ShowDialog();
            CarregaDados();
        }

        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TelaConsultarSorteio novo = new TelaConsultarSorteio();
            novo.ShowDialog();
            CarregaDados();
        }

        private void gerenciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaApostador nova = new TelaApostador();
            nova.ShowDialog();
            CarregaDados();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaConsultarApostadores nova = new TelaConsultarApostadores();
            nova.ShowDialog();
            CarregaDados();
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (labelEmAndamento.Visible == true)
            {
                TelaAvisoAposta erro = new TelaAvisoAposta();
                erro.ShowDialog();
                erro.BringToFront();
            }
            else
            {
                if (labelFechado.Visible == true)
                {
                    TelaAvisoApostaConcFechado errado = new TelaAvisoApostaConcFechado();
                    errado.ShowDialog();
                    errado.BringToFront();
                    return;
                }
                else
                {
                    TelaAposta nova = new TelaAposta();
                    nova.ShowDialog();
                }
            }
            CarregaDados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (labelFechado.Visible == true)
            {
                TelaAvisoSorteio erro = new TelaAvisoSorteio();
                erro.ShowDialog();
                erro.BringToFront();
            }
            else
            {
                if(qtdpart.Text == "0")
                {
                    TelaAvisoSorteioSemAposta erro = new TelaAvisoSorteioSemAposta();
                    erro.ShowDialog();
                    erro.BringToFront();
                }
                else
                {
                    TelaSorteio nova = new TelaSorteio();
                    nova.ShowDialog();
                } 
            }
            CarregaDados();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelaConsultaConcursos nova = new TelaConsultaConcursos();
            nova.ShowDialog();
            CarregaDados();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TelaGerenciarApostas nova = new TelaGerenciarApostas();
            nova.ShowDialog();
            CarregaDados();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TelaConsultarSorteio nova = new TelaConsultarSorteio();
            nova.ShowDialog();
            CarregaDados();
        }

        private void emissõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaRelatorios nova = new TelaRelatorios();
            nova.ShowDialog();
            CarregaDados();
        }

        private void vencedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaVencedores nova = new TelaVencedores();
            nova.ShowDialog();
            CarregaDados();
        }

        private void premiaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void controleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void financeiroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void premiaçãoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TelaFinanceiroPremios nova = new TelaFinanceiroPremios();
            nova.ShowDialog();
            CarregaDados();
        }

        private void controleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TelaFinanceiroControle nova = new TelaFinanceiroControle();
            nova.ShowDialog();
            CarregaDados();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            TelaVersao nova = new TelaVersao();
            nova.Show();
        }
    }
}
