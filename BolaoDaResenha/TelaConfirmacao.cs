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
    public partial class TelaConfirmacao : Form
    {
        String salvar, mostrarComp;
        public void preencheLabel(String apos, String num, String camb, String mostrar)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            LabCamb.Parent = pictureBox1;
            LabCamb.BackColor = Color.Transparent;
            LabNum.Parent = pictureBox1;
            LabNum.BackColor = Color.Transparent;
            LabApo.Parent = pictureBox1;
            LabApo.BackColor = Color.Transparent;
            salvar = num;
            LabApo.Text = apos.ToString();
            LabNum.Text = mostrar;
            LabCamb.Text = camb.ToString();
            mostrarComp = mostrar;
        }
        public TelaConfirmacao()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TelaConfirmacao_Load(object sender, EventArgs e)
        {
            
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            Aposta nova = new Aposta();
            int teste = 0; //verifica se inseriu um novo apostador ou se já exisitia dentro da base

            int idAtual = AcessoFB.fb_verificaUltIdAposta();
            int idApostador = AcessoFB.fb_verificaIdApostador(LabApo.Text.ToString());
            int idCambista = AcessoFB.fb_verificaIdCambista(LabCamb.Text.ToString());
            int idConcurso = AcessoFB.fb_verificaConcAberto();

            Apostador novo = new Apostador();

            if (idApostador == 0 || idApostador.ToString() == "" || idApostador.ToString() == null)
            {
                //Adiciona o novo apostador no banco
                int buscaIdUltApostador = AcessoFB.fb_verificaUltIdApostador();
                

                novo.ID = buscaIdUltApostador + 1;
                novo.Apelido = LabApo.Text.ToString();

                AcessoFB.fb_InserirNovoApostador(novo);
                teste = 1;
            }
                       
            nova.ID = idAtual + 1;
            nova.Numeros = salvar;
            nova.Cambista = idCambista;

            if(teste == 0)
            {
                nova.Apostador = idApostador;
            }
            if(teste == 1)
            {
                nova.Apostador = novo.ID;
            }
            nova.Concurso = idConcurso;
            AcessoFB.fb_InserirNovaAposta(nova);

            Comprovante comprovante = new Comprovante();

            comprovante.ID = AcessoFB.fb_verificaUltIdComprovante() + 1;
            comprovante.Data = DateTime.Now.ToString();
            comprovante.Concurso = idConcurso;
            comprovante.Aposta = nova.ID;
            comprovante.Cambista = LabCamb.Text.ToString();
            comprovante.Numeros = nova.Numeros;
            comprovante.NomeApostador = LabApo.Text.ToString();

            AcessoFB.fb_InserirNovoComprovante(comprovante);

            TelaApostaImprimirComprovante confirmado = new TelaApostaImprimirComprovante();
            confirmado.recebeNumComp(comprovante.ID, mostrarComp);
            confirmado.ShowDialog();

            DialogResult = DialogResult.OK;
        }
    }
}
