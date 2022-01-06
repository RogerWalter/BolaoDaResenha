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
    public partial class TelaConcurso : Form
    {
        public TelaConcurso()
        {
            InitializeComponent();
        }

        private void labelFechado_Click(object sender, EventArgs e)
        {

        }

        private void TelaConcurso_Load(object sender, EventArgs e)
        {
            this.dgVenc.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dgVenc.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dgVenc.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dgVenc.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.DodgerBlue;
            this.dgVenc.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.White;

            BindingSource bindingSource1 = new BindingSource();
            DataTable vencedores = new DataTable("Vencedores");
            DataSet dsFinal = new DataSet();
            vencedores = AcessoFB.fb_buscaVencedoresFinal();
            dsFinal.Tables.Add(vencedores);
            bindingSource1.DataSource = vencedores;
            dgVenc.DataSource = bindingSource1;

            this.dgVenc.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgVenc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgVenc.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            int atual = AcessoFB.fb_buscaNumeroConcursoAtual();
            // verificar se o concurso que está aberto no momento possui um vencedor, caso tenha, não deixa inserir um novo sorteio antes de encerrar  o concurso que já acabou
            int verificaConcurso = AcessoFB.fb_verificaSeConcursoJaTemVencedor(atual);
            int sorteioJaOcorreu = AcessoFB.fb_verificaSeJaHouvesorteioNoConAtual(atual);

            if (verificaConcurso != 0 || verificaConcurso > 0)
            {
                labelAberto.Visible = false;
                labelFechado.Visible = true;
                labelVenc.Visible = true;
                dgVenc.Visible = true;
                btConfirmar.Visible = false;
                labelEmAndamento.Visible = false;
            }

            if((sorteioJaOcorreu != 0 || sorteioJaOcorreu > 0) && (verificaConcurso == 0))
            {
                labelAberto.Visible = false;
                labelFechado.Visible = false;
                labelVenc.Visible = false;
                dgVenc.Visible = false;
                btConfirmar.Visible = true;
                labelEmAndamento.Visible = true;
            }

            if (verificaConcurso == 0 && sorteioJaOcorreu == 0)
            {
                labelAberto.Visible = true;
                labelFechado.Visible = false;
                labelVenc.Visible = false;
                dgVenc.Visible = false;
                btConfirmar.Visible = true;
                labelEmAndamento.Visible = false;
            }

            int concurso = AcessoFB.fb_buscaNumeroConcursoAtual();
            conc.Text = concurso.ToString();
            qtdpart.Text = AcessoFB.fb_contaQtdApostadoresConcurso(concurso).ToString();
            qtdSort.Text = AcessoFB.fb_contarQtdSorteiosNoConc(concurso).ToString();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            TelaPlacar placar = new TelaPlacar();
            placar.Show();
        }

        private void btEncerrarConc_Click(object sender, EventArgs e)
        {
            TelaAvisoEncerrarConcurso nova = new TelaAvisoEncerrarConcurso();
            nova.ShowDialog();
            this.Close();
        }
    }
}
