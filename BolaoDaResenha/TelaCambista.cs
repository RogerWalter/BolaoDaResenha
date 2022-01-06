using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BolaoDaResenha
{
    public partial class TelaCambista : Form
    {
        int ultBotPress = 0; //ver o botao que foi pressionado por ultimo -> 1-Novo,2-Editar,3-Confirmar,4-Excluir,5-Procurar
        String qualCambistaAtualizar = ""; // variavel que guarda quem iremos atualizar
        public void RecarregaDados()
        {
            dataGridView1.DataSource = null;

            BindingSource bindingSource1 = new BindingSource();
            DataTable cambistas = new DataTable("Cambistas");
            DataSet dsFinal = new DataSet();
            cambistas = AcessoFB.fb_buscaCambistaFinal();
            dsFinal.Tables.Add(cambistas);
            bindingSource1.DataSource = cambistas;

            dataGridView1.DataSource = bindingSource1;

        }
        public TelaCambista()
        {
            InitializeComponent();
        }

        private void TelaCambista_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Coral;

            BindingSource bindingSource1 = new BindingSource();
            DataTable cambistas = new DataTable("Cambistas");
            DataSet dsFinal = new DataSet();
            cambistas = AcessoFB.fb_buscaCambistaFinal();
            dsFinal.Tables.Add(cambistas);
            bindingSource1.DataSource = cambistas;
            dataGridView1.DataSource = bindingSource1;

            List<string> nomes = new List<string>();
            using (FbConnection conn = new FbConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ConnectionString;
                using (FbCommand cmd = new FbCommand())
                {
                    cmd.CommandText = "SELECT NOME FROM CAMBISTA";
                    //cmd.Parameters.AddWithValue("@Texto", prefixo);
                    cmd.Connection = conn;
                    conn.Open();
                    using (FbDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            nomes.Add(string.Format("{0}", sdr["NOME"]));
                        }
                    }
                    conn.Close();
                }
            }
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            foreach (string name in nomes)
            {
                source.Add(name);
            }

            tbNome.AutoCompleteCustomSource = source;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                tbNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbCidade.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {

            }
            
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            ultBotPress = 1;
            tbNome.Text = "";
            tbCidade.Text = "";
            tbNome.Enabled = true;
            tbCidade.Enabled = true;
            tbNome.Focus();
            tbNome.Select();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            if(tbNome.Text == "" || tbNome.Text == null)
            {
                MessageBox.Show("Nenhum registro foi selecionado", "Erro ao alterar!", MessageBoxButtons.OK);
                return;
            }
            ultBotPress = 2;
            qualCambistaAtualizar = tbNome.Text.ToString();
            tbNome.Enabled = true;
            tbCidade.Enabled = true;
            tbNome.Focus();
            tbNome.Select();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (ultBotPress == 0)
            {
                return;
            }
            Cambista alterado = new Cambista();

            if (tbNome.Text.ToString() == "" || tbCidade.Text.ToString() == "")
            {
                MessageBox.Show("Os campos não foram preenchidos", "Erro ao salvar!", MessageBoxButtons.OK);
                return;
            }
            if(ultBotPress == 1)
            {
                alterado.ID = AcessoFB.fb_verificaUltIdCambista() + 1;
                alterado.Nome = tbNome.Text.ToString();
                alterado.Cidade = tbCidade.Text.ToString();
                AcessoFB.fb_InserirNovoCambista(alterado);
            }
            if(ultBotPress == 2)
            {
                int id = AcessoFB.fb_verificaIdCambista(qualCambistaAtualizar);
                if (id == 0 || id.ToString() == null || id.ToString() == "")//caso ao salvar a edição, o sistema nao encontre o ID do cambista que esta sendo alterado
                {
                    MessageBox.Show("O sistema não pôde encontrar o cambista que está sendo alterado", "Erro!", MessageBoxButtons.OK);
                    return;
                }
                alterado.ID = id;
                alterado.Nome = tbNome.Text.ToString();
                alterado.Cidade = tbCidade.Text.ToString();
                AcessoFB.fb_alterarCambista(alterado);
            }

            ultBotPress = 0;

            tbNome.Enabled = false;
            tbCidade.Enabled = false;

            RecarregaDados();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if(ultBotPress == 1 || ultBotPress == 2 || ultBotPress == 5)
            {
                return;
            }
            if(tbNome.Text == "" || tbNome.Text == null)
            {
                MessageBox.Show("Nenhum registro foi selecionado", "Erro ao excluir!", MessageBoxButtons.OK);
                return;
            }
            int id = AcessoFB.fb_verificaIdCambista(tbNome.Text.ToString());
            if (id == 0 || id.ToString() == "" || id.ToString() == null)
            {
                MessageBox.Show("Ocorreu um problema ao excluir este cambista", "Erro ao excluir!", MessageBoxButtons.OK); // quando a consulta ao banco não encontrar o id do cambista selecionado, ocorrerá este erro
                return;
            }
            AcessoFB.fb_excluirCambista(id);
            
            tbNome.Enabled = false;
            tbCidade.Enabled = false;

            RecarregaDados();
        }

        private void btProcurar_Click(object sender, EventArgs e)
        {
            if(ultBotPress == 1 || ultBotPress == 2)
            {
                MessageBox.Show("É necessário finalizar a operação de inserção ou alteração antes de realizar um pesquisa \n Utilize o botão de pesquisa somente se não estive inserindo ou alterando cadastro", "Sequência incorreta!", MessageBoxButtons.OK); // quando a consulta ao banco não encontrar o id do cambista selecionado, ocorrerá este erro
                return;
            }
            if(ultBotPress == 5)
            {
                String procurar = tbNome.Text.ToString();
                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains(procurar) || row.Cells[1].Value.ToString().Equals(procurar))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if(rowIndex == -1)
                {
                    MessageBox.Show("Não foram encontrados resultados para o termo pesquisado", "Pesquisa!", MessageBoxButtons.OK);
                    return;
                }
                dataGridView1.Rows[rowIndex].Selected = true;

                tbNome.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                tbCidade.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();               

                ultBotPress = 0;
                tbNome.Enabled = false;
                tbCidade.Enabled = false;
                
                return;

            }
            ultBotPress = 5;
            tbNome.Enabled = true;
            tbCidade.Enabled = false;
            tbNome.Text = "";
            tbCidade.Text = "";
            tbNome.Focus();
            tbNome.Select();

        }

        private void tbNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
