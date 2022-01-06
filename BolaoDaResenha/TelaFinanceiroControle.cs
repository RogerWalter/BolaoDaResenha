using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BolaoDaResenha
{
    public partial class TelaFinanceiroControle : Form
    {
        public TelaFinanceiroControle()
        {
            InitializeComponent();
        }
        public void limpaCampos()
        {
            loConc.Text = "--";
            loPart.Text = "--";
            loInic.Text = "--";
            loPrem.Text = "--";
            loRec.Text = "--";
            loIns.Text = "--";
            labelNConc.Text = "--";
        }
        private void preencheGridAnterior()
        {
            if (Anterior.Text == "")
            {
                MessageBox.Show("O concurso anterior não foi informado", "Erro!", MessageBoxButtons.OK);
                return;
            }
            BindingSource bindingSource1 = new BindingSource();
            DataTable financeiro = new DataTable("Financeiro");
            DataSet dsFinal = new DataSet();
            financeiro = AcessoFB.fb_PreencheGridFinanceiroAnterior(Convert.ToInt32(tbNConcurso.Text));
            dsFinal.Tables.Add(financeiro);
            bindingSource1.DataSource = financeiro;
            dataGridView1.DataSource = bindingSource1;    
        }
        private void preencheGridAtual()
        {
            BindingSource bindingSource1 = new BindingSource();
            DataTable financeiro = new DataTable("Financeiro");
            DataSet dsFinal = new DataSet();
            financeiro = AcessoFB.fb_PreencheGridFinanceiroAtual();
            dsFinal.Tables.Add(financeiro);
            bindingSource1.DataSource = financeiro;
            dataGridView1.DataSource = bindingSource1;
        }

        private void preencheGridTodos()
        {
            BindingSource bindingSource1 = new BindingSource();
            DataTable financeiro = new DataTable("Financeiro");
            DataSet dsFinal = new DataSet();
            financeiro = AcessoFB.fb_PreencheGridFinanceiroTodos();
            dsFinal.Tables.Add(financeiro);
            bindingSource1.DataSource = financeiro;
            dataGridView1.DataSource = bindingSource1;   
        }

        private void Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (Todos.Checked == true)
            {
                limpaCampos();
                Atual.Checked = false;
                Anterior.Checked = false;
                labelN.Visible = false;
                tbNConcurso.Visible = false;
                preencheGridTodos();
            }
            if (Todos.Checked == false)
            {
                dataGridView1.DataSource = null;
                limpaCampos();
            }
        }

        private void Atual_CheckedChanged(object sender, EventArgs e)
        {
            if (Atual.Checked == true)
            {
                limpaCampos();
                int nAtual = AcessoFB.fb_buscaNumeroConcursoAtual();
                labelNConc.Text = nAtual.ToString();
                Anterior.Checked = false;
                labelN.Visible = false;
                tbNConcurso.Visible = false;
                Todos.Checked = false;
                preencheGridAtual();
            }
            if (Atual.Checked == false)
            {
                dataGridView1.DataSource = null;
                limpaCampos();
            }
        }

        private void Anterior_CheckedChanged(object sender, EventArgs e)
        {
            if (Anterior.Checked == true)
            {
                limpaCampos();
                dataGridView1.DataSource = null;
                labelNConc.Text = "--";
                Atual.Checked = false;
                labelN.Visible = true;
                tbNConcurso.Text = "";
                tbNConcurso.Visible = true;
                Todos.Checked = false;
                tbNConcurso.Focus();
                tbNConcurso.Select();
            }
            if (Anterior.Checked == false)
            {
                dataGridView1.DataSource = null;
                limpaCampos();
            }
        }

        

        private void tbNConcurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbNConcurso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int a = AcessoFB.fb_buscaNumeroConcursoAtual();
                if (tbNConcurso.Text == "")
                {
                    MessageBox.Show("Nenhum valor foi informado", "Erro!", MessageBoxButtons.OK);
                    return;
                }
                if (Convert.ToInt32(tbNConcurso.Text) == a)
                {
                    Atual.Checked = true;
                    Anterior.Checked = false;
                    tbNConcurso.Text = "";
                    tbNConcurso.Visible = false;
                }
                else
                {
                    labelNConc.Text = tbNConcurso.Text;
                    preencheGridAnterior();
                }

            }
        }

        

        public void preencheTB(int con)
        {
            if (Anterior.Checked == true)
            {
                labelNConc.Text = tbNConcurso.Text;

            }
            if (Atual.Checked == true)
            {

                labelNConc.Text = Convert.ToString(AcessoFB.fb_buscaNumeroConcursoAtual());
            }
            if (Todos.Checked == true)
            {
                labelNConc.Text = Convert.ToString(con);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int concurso = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                int participantes = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                String vlrAposta = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                String vlrPremio = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                String vlrTotal = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                String inicio = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                
                preencheTB(concurso);

                loConc.Text = concurso.ToString();
                loPart.Text = participantes.ToString();
                loInic.Text = inicio;
                loPrem.Text = vlrPremio;
                loRec.Text = vlrTotal;
                loIns.Text = vlrAposta;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int concurso = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                int participantes = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                String vlrAposta = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                String vlrPremio = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                String vlrTotal = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                String inicio = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                
                preencheTB(concurso);

                loConc.Text = concurso.ToString();
                loPart.Text = participantes.ToString();
                loInic.Text = inicio;
                loPrem.Text = vlrPremio;
                loRec.Text = vlrTotal;
                loIns.Text = vlrAposta;
            }
            catch
            {

            }
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (btConfirmar.Text == "Editar Informações")
            {
                totalRec.Text = "--";
                if(premio.Text == "--")
                {
                    tbPremio.Text = "";
                    tbInsc.Text = "";
                    tbInicio.Text = "";
                }
                else
                {
                    String lpremio, lins, premAux, insAux;
                    int prC, inC;
                    lpremio = premio.Text;
                    lins = insc.Text;

                    premAux = lpremio.Substring(3, lpremio.Length - 3);
                    premAux = premAux.Replace(".", "");
                    premAux = premAux.Replace(",00", "");
                    prC = Convert.ToInt32(premAux);
                    tbPremio.Text = prC.ToString();

                    insAux = lins.Substring(3, lins.Length - 3);
                    insAux = insAux.Replace(".", "");
                    insAux = insAux.Replace(",00", "");
                    inC = Convert.ToInt32(insAux);
                    tbInsc.Text = inC.ToString();

                    tbInicio.Text = iniciaEm.Text;
                }
                btConfirmar.Text = "Salvar";
                tbPremio.Visible = true;
                tbInsc.Visible = true;
                tbInicio.Visible = true;
                tbPremio.Focus();
                tbPremio.Select();
            }
            else
            {
                
                if(tbPremio.Text == "" || tbInsc.Text == "" || tbInicio.Text == "  /  /    " || tbInicio.Text.Length < 10)
                {
                    MessageBox.Show("Existem campos que não foram preenchidos", "Erro!", MessageBoxButtons.OK);
                    return;
                }
                int atual1 = AcessoFB.fb_verificaConcAberto();
                int verifica = AcessoFB.fb_verificaSeExisteDadosFinanceiroAtual(atual1);
                if(verifica == 0)
                {
                    int idFin = AcessoFB.fb_verificaUltIdFinanceiro() + 1;
                    int atual = AcessoFB.fb_verificaConcAberto();
                    int numPart = AcessoFB.fb_contarQtdApostasNoConc(atual);
                    int valInsc = Convert.ToInt32(tbInsc.Text);
                    int valPremio = Convert.ToInt32(tbPremio.Text);
                    String inicio = tbInicio.Text.ToString();
                    int total = valInsc * numPart;
                    AcessoFB.fb_InserirNovoFinanceiro(idFin, atual, numPart, valInsc, valPremio, total, inicio);
                    btConfirmar.Text = "Editar Informações";
                    tbPremio.Visible = false;
                    tbInsc.Visible = false;
                    tbInicio.Visible = false;
                    premio.Text = valPremio.ToString("C", CultureInfo.CurrentCulture);
                    insc.Text = valInsc.ToString("C", CultureInfo.CurrentCulture);
                    totalRec.Text = total.ToString("C", CultureInfo.CurrentCulture);
                    iniciaEm.Text = inicio;
                    CarregaDados();

                    //RECARREGA O GRID E MARCA O CB ATUAL 

                    dataGridView1.DataSource = null;

                    int nAtual = AcessoFB.fb_buscaNumeroConcursoAtual();
                    Atual.Checked = true;
                    labelNConc.Text = nAtual.ToString();
                    Anterior.Checked = false;
                    labelN.Visible = false;
                    tbNConcurso.Visible = false;
                    Todos.Checked = false;
                    preencheGridAtual();
                }
                else
                {
                    int valInsc = Convert.ToInt32(tbInsc.Text);
                    int valPremio = Convert.ToInt32(tbPremio.Text);
                    String inicio = tbInicio.Text.ToString();
                    int numPart = AcessoFB.fb_contarQtdApostasNoConc(atual1);
                    Financeiro fin = AcessoFB.fb_buscaDadosFinanceiroAtual();  
                    int preco = fin.Insc;
                    int novoTotal = numPart * fin.Insc;
                    AcessoFB.fb_atualizaDadosFinanceiroAtual(valInsc, valPremio, inicio, numPart, novoTotal, atual1);
                    btConfirmar.Text = "Editar Informações";
                    tbPremio.Visible = false;
                    tbInsc.Visible = false;
                    tbInicio.Visible = false;
                    premio.Text = valPremio.ToString("C", CultureInfo.CurrentCulture);
                    insc.Text = valInsc.ToString("C", CultureInfo.CurrentCulture);
                    totalRec.Text = novoTotal.ToString("C", CultureInfo.CurrentCulture);
                    iniciaEm.Text = inicio;
                    CarregaDados();

                    //RECARREGA O GRID E MARCA O CB ATUAL 

                    dataGridView1.DataSource = null;

                    int nAtual = AcessoFB.fb_buscaNumeroConcursoAtual();
                    Atual.Checked = true;
                    labelNConc.Text = nAtual.ToString();
                    Anterior.Checked = false;
                    labelN.Visible = false;
                    tbNConcurso.Visible = false;
                    Todos.Checked = false;
                    preencheGridAtual();
                }  
            }

        }

        public void CarregaDados()
        {
            int atual = AcessoFB.fb_verificaConcAberto();
            Financeiro fin = AcessoFB.fb_buscaDadosFinanceiroAtual();

            //RECALCULA O VALOR TOTAL RECEBIDO
            int numPart = AcessoFB.fb_contarQtdApostasNoConc(atual);
            int preco = fin.Insc;
            int novoTotal = numPart * preco;
            AcessoFB.fb_atualizaTotalFinanceiroAtuala(novoTotal, atual, numPart);

            //PREENCHE LABELS
            int verifica = AcessoFB.fb_verificaSeExisteDadosFinanceiroAtual(atual);
            if (verifica == 0)
            {
                premio.Text = "--";
                insc.Text = "--";
                totalRec.Text = "--";
                iniciaEm.Text = "--";
            }
            else
            {
                premio.Text = fin.Premio.ToString("C", CultureInfo.CurrentCulture);
                insc.Text = fin.Insc.ToString("C", CultureInfo.CurrentCulture);
                totalRec.Text = novoTotal.ToString("C", CultureInfo.CurrentCulture);
                iniciaEm.Text = fin.inicio;
            }
        }

        private void TelaFinanceiroControle_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;
            CarregaDados();
        }

        private void tbPremio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbInsc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbInicio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btConfirmar.PerformClick();
            }
        }
    }
}
