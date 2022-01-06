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
    public partial class TelaSorteio : Form
    {

        public bool MeuProcessoFoiFinalizado { get; set; }

        public int NumeroForAtual = 0;

        

        private void FazMeusProcessos()
        {
            

            int priSortConc = AcessoFB.fb_verificaPrimeiroSorteioDoConcurso(Convert.ToInt32(labelNumConcurso.Text));//verifica se este é o primeiro sorteio do concurso ou não

            Sorteio novo = new Sorteio();
            novo.ID = AcessoFB.fb_verificaUltIdSorteio() + 1;
            novo.Numeros = tbN1.Text.ToString() + "-" + tbN2.Text.ToString() + "-" + tbN3.Text.ToString() + "-" + tbN4.Text.ToString() + "-" + tbN5.Text.ToString();
            novo.Concurso = Convert.ToInt32(labelNumConcurso.Text);
            AcessoFB.fb_InserirNovoSorteio(novo);

            //Verficar os acertos e ja classifica as quantidades de acertos de acordo com as apostas



            int qtdApo = Convert.ToInt32(labelNumApostas.Text);
            int n1 = Convert.ToInt32(tbN1.Text), n2 = Convert.ToInt32(tbN2.Text), n3 = Convert.ToInt32(tbN3.Text), n4 = Convert.ToInt32(tbN4.Text), n5 = Convert.ToInt32(tbN5.Text);
            int priApo = AcessoFB.fb_buscaNumPrimeiraApostaConcursoAtual(Convert.ToInt32(labelNumConcurso.Text));

            for (int i = 0; i < qtdApo; i++)
            {
                
                
                String acertados = "";
                String restantes = "";
                int qtdAcert = 0;

                int nA1 = -1;
                int nA2 = -1;
                int nA3 = -1;
                int nA4 = -1;
                int nA5 = -1;
                int nA6 = -1;
                int nA7 = -1;
                int nA8 = -1;
                int nA9 = -1;
                int nA10 = -1;

                String verificar = "";
                String acertadosRodada = ""; //essa variavel é usada quando não é a primeira rodada do sorteio, daí será somado os acertados de agora com ela, o que ira atualizar o banco para ir adicionando acertos

                if (priSortConc == 0) // se for a primeira rodada do concurso, vai pegar a aposta da tabela de apostas
                {
                    verificar = AcessoFB.fb_buscaNumerosApostados(priApo + i);
                }

                if (priSortConc > 0) // se não for, dá andamento utilizando os restantes e os acertados
                {
                    verificar = AcessoFB.fb_buscaNumerosRestantes(priApo + i);
                    acertadosRodada = AcessoFB.fb_buscaNumerosAcertadosAnteriormente(priApo + i);
                }
                //Verificação para  não crashar caso a substring seja nula. Assim, o programa substitui os nulo por -1

                if (verificar.Substring(0, 2) == "--")
                {
                    nA1 = -1;
                }
                if (verificar.Substring(0, 2) != "--")
                {
                    nA1 = Convert.ToInt32(verificar.Substring(0, 2));
                }

                if (verificar.Substring(3, 2) == "--")
                {
                    nA2 = -1;
                }
                if (verificar.Substring(3, 2) != "--")
                {
                    nA2 = Convert.ToInt32(verificar.Substring(3, 2));
                }

                if (verificar.Substring(6, 2) == "--")
                {
                    nA3 = -1;
                }
                if (verificar.Substring(6, 2) != "--")
                {
                    nA3 = Convert.ToInt32(verificar.Substring(6, 2));
                }

                if (verificar.Substring(9, 2) == "--")
                {
                    nA4 = -1;
                }
                if (verificar.Substring(9, 2) != "--")
                {
                    nA4 = Convert.ToInt32(verificar.Substring(9, 2));
                }

                if (verificar.Substring(12, 2) == "--")
                {
                    nA5 = -1;
                }
                if (verificar.Substring(12, 2) != "--")
                {
                    nA5 = Convert.ToInt32(verificar.Substring(12, 2));
                }

                if (verificar.Substring(15, 2) == "--")
                {
                    nA6 = -1;
                }
                if (verificar.Substring(15, 2) != "--")
                {
                    nA6 = Convert.ToInt32(verificar.Substring(15, 2));
                }

                if (verificar.Substring(18, 2) == "--")
                {
                    nA7 = -1;
                }
                if (verificar.Substring(18, 2) != "--")
                {
                    nA7 = Convert.ToInt32(verificar.Substring(18, 2));
                }

                if (verificar.Substring(21, 2) == "--")
                {
                    nA8 = -1;
                }
                if (verificar.Substring(21, 2) != "--")
                {
                    nA8 = Convert.ToInt32(verificar.Substring(21, 2));
                }

                if (verificar.Substring(24, 2) == "--")
                {
                    nA9 = -1;
                }
                if (verificar.Substring(24, 2) != "--")
                {
                    nA9 = Convert.ToInt32(verificar.Substring(24, 2));
                }

                if (verificar.Substring(27, 2) == "--")
                {
                    nA10 = -1;
                }
                if (verificar.Substring(27, 2) != "--")
                {
                    nA10 = Convert.ToInt32(verificar.Substring(27, 2));
                }


                int[] apostados = new int[10]; //vetor com a aposta do apostador

                apostados[0] = nA1;
                apostados[1] = nA2;
                apostados[2] = nA3;
                apostados[3] = nA4;
                apostados[4] = nA5;
                apostados[5] = nA6;
                apostados[6] = nA7;
                apostados[7] = nA8;
                apostados[8] = nA9;
                apostados[9] = nA10;

                int[] sorteados = new int[5]; // vetor com os numeros sorteados

                sorteados[0] = Convert.ToInt32(tbN1.Text);
                sorteados[1] = Convert.ToInt32(tbN2.Text);
                sorteados[2] = Convert.ToInt32(tbN3.Text);
                sorteados[3] = Convert.ToInt32(tbN4.Text);
                sorteados[4] = Convert.ToInt32(tbN5.Text);

                int[] apostaInicial = new int[10];
                apostaInicial = apostados;

                for (int a = 0; a < 10; a++)
                {
                    int acertouOuNao = 0; // se acertar, é 1, se não acertar, é 0
                    if (apostados[a] == -1)
                    {
                        continue;
                    }
                    for (int b = 0; b < 5; b++)// comparar com os sorteados
                    {
                        if (sorteados[b] == -1)
                        {
                            continue;
                        }
                        if (apostados[a] == sorteados[b])
                        {
                            if (acertados.Length == 27)
                            {
                                acertados = acertados + apostados[a].ToString(); // caso esteja no ultimo numero, então não adiciona o hífen
                            }
                            if (apostados[a].ToString().Length == 1)//ao converter para inteiro, numeros com o 0 na frente perdem esse zero. Esse if coloca o 0 novamente antes de salva a string.
                            {
                                acertados = acertados + "0" + apostados[a].ToString() + "-";
                                apostados[a] = -1;
                                sorteados[b] = -1;
                                acertouOuNao = 1;
                                qtdAcert = qtdAcert + 1;
                                break;
                            }
                            if (apostados[a].ToString().Length > 1)
                            {
                                acertados = acertados + apostados[a].ToString() + "-";
                                apostados[a] = -1;
                                sorteados[b] = -1;
                                acertouOuNao = 1;
                                qtdAcert = qtdAcert + 1;
                                break;
                            }

                        }
                    }
                    if (acertouOuNao == 0)
                    {
                        if (apostados[a].ToString().Length == 1)
                        {
                            if (restantes.Length == 27)
                            {
                                restantes = restantes + "0" + apostados[a].ToString(); // caso esteja no ultimo numero, então não adiciona o hífen
                            }
                            if (restantes.Length < 27)
                            {
                                restantes = restantes + "0" + apostados[a].ToString() + "-";
                            }
                        }

                        if (apostados[a].ToString().Length > 1)
                        {
                            if (restantes.Length == 27)
                            {
                                restantes = restantes + apostados[a].ToString(); // caso esteja no ultimo numero, então não adiciona o hífen
                            }
                            if (restantes.Length < 27)
                            {
                                restantes = restantes + apostados[a].ToString() + "-";
                            }
                        }


                    }
                }
                if (priSortConc == 0)
                {
                    if (acertados.Length < 29)
                    {
                        int faltaPreencherA = 29 - Convert.ToInt32(acertados.Length);
                        for (int z = 0; z < faltaPreencherA; z++)
                        {
                            acertados = acertados + "-";
                        }
                    }
                    if (restantes.Length < 29)
                    {
                        int faltaPreencherR = 29 - Convert.ToInt32(restantes.Length);
                        for (int r = 0; r < faltaPreencherR; r++)
                        {
                            restantes = restantes + "-";
                        }
                    }
                    Acertos adicionar = new Acertos();
                    adicionar.ID = AcessoFB.fb_verificaUltIdAcertos() + 1;
                    adicionar.Aposta = priApo + i;
                    adicionar.NumAcertos = acertados;
                    adicionar.Restantes = restantes;
                    adicionar.QtdAcertos = qtdAcert;
                    AcessoFB.fb_adicionaNovoAcerto(adicionar);
                }

                if (priSortConc > 0)
                {
                    Acertos atualizar = new Acertos();
                    int qtdAcertosRodadaAnterior = AcessoFB.fb_buscaQtdAcertosRodadaAnterior(priApo + i);
                    int idAtualizar = AcessoFB.fb_buscaIdAcertos(priApo + i);
                    String AcertosFinal = acertadosRodada;
                    String preString = ""; // essa string é a primeira parte da composição da string final.

                    if (qtdAcertosRodadaAnterior == 0)
                    {
                        preString = "";
                    }

                    if (qtdAcertosRodadaAnterior == 1)
                    {
                        preString = acertadosRodada.Substring(0, 3);
                    }

                    if (qtdAcertosRodadaAnterior == 2)
                    {
                        preString = acertadosRodada.Substring(0, 6);
                    }

                    if (qtdAcertosRodadaAnterior == 3)
                    {
                        preString = acertadosRodada.Substring(0, 9);
                    }

                    if (qtdAcertosRodadaAnterior == 4)
                    {
                        preString = acertadosRodada.Substring(0, 12);
                    }

                    if (qtdAcertosRodadaAnterior == 5)
                    {
                        preString = acertadosRodada.Substring(0, 15);
                    }

                    if (qtdAcertosRodadaAnterior == 6)
                    {
                        preString = acertadosRodada.Substring(0, 18);
                    }

                    if (qtdAcertosRodadaAnterior == 7)
                    {
                        preString = acertadosRodada.Substring(0, 21);
                    }

                    if (qtdAcertosRodadaAnterior == 8)
                    {
                        preString = acertadosRodada.Substring(0, 24);
                    }

                    if (qtdAcertosRodadaAnterior == 9)
                    {
                        preString = acertadosRodada.Substring(0, 27);
                    }

                    // até aqui, pegou-se os acertos da rodada anterior para compor a string que será atualizada nos ACERTOS

                    // agora, montaremos a segunda metade da string, atualizando a anterior com os novos valores. (acertosAnteriores + acertosAtuais = stringNova) 

                    if (qtdAcert == 0)
                    {
                        AcertosFinal = acertadosRodada;
                    }

                    if (qtdAcert == 1 || qtdAcert == 2 || qtdAcert == 3 || qtdAcert == 4 || qtdAcert == 5 || qtdAcert == 6 || qtdAcert == 7 || qtdAcert == 8 || qtdAcert == 9 || qtdAcert == 10)
                    {
                        AcertosFinal = preString + acertados;
                    }
                    if (AcertosFinal.Length > 29)
                    {
                        AcertosFinal = AcertosFinal.Substring(0, 29);
                    }

                    if (AcertosFinal.Length < 29)
                    {
                        int preenche = 29 - Convert.ToInt32(AcertosFinal.Length);
                        for (int k = 0; k < preenche; k++)
                        {
                            AcertosFinal = AcertosFinal + "-";
                        }

                    }

                    if (restantes.Length < 29)
                    {
                        int faltaPreencherR = 29 - Convert.ToInt32(restantes.Length);
                        for (int r = 0; r < faltaPreencherR; r++)
                        {
                            restantes = restantes + "-";
                        }
                    }

                    atualizar.ID = idAtualizar;
                    atualizar.NumAcertos = AcertosFinal;
                    atualizar.Restantes = restantes;
                    atualizar.QtdAcertos = qtdAcertosRodadaAnterior + qtdAcert;

                    AcessoFB.fb_atualizarAcertos(atualizar);
                }
                
            }

            //carregando.Close();

            //pronto.ShowDialog();



            verificaStatusConcurso();

            NumeroForAtual = 1;
            //this.Close();


        }

        //####################################################


        public TelaSorteio()
        {
            InitializeComponent();
        }

        TelaCarregamentoLoad carregando = new TelaCarregamentoLoad();
        TelaConcluido pronto = new TelaConcluido();

        public void verificaStatusConcurso()
        {
            
            int verificandoAcertos = AcessoFB.fb_buscaMaiorQtdAcertosConcursoAtual();

            if(verificandoAcertos == 10)
            {
                //Aqui o concurso acabou. Precisa ser informado ao usuário.

                fechaCarregamento();

                AcessoFB.fb_insereVencedor();

                TelaFinalConcurso acabou = new TelaFinalConcurso();
                
                acabou.ShowDialog();
                
            }
        }

        
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(tbN1.Text == "" || tbN2.Text == "" || tbN3.Text == "" || tbN4.Text == "" || tbN5.Text == "")
            {
                MessageBox.Show("Existem campos que não foram preenchidos!", "Campo sem preenchimento", MessageBoxButtons.OK);
                return;
            }

            TelaConfirmacaoSorteio confirmar = new TelaConfirmacaoSorteio();
            confirmar.RecebeNumeros(tbN1.Text, tbN2.Text, tbN3.Text, tbN4.Text, tbN5.Text);
            if (confirmar.ShowDialog() == DialogResult.Cancel)
            {
                btConfirmar.Focus();
                return;
            }
            carregando.Show();
            carregando.BringToFront();
            if(backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            if(backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
            }
            //FazMeusProcessos();
            
            //pronto.ShowDialog();
            //this.Close();

            /*
            int priSortConc = AcessoFB.fb_verificaPrimeiroSorteioDoConcurso(Convert.ToInt32(labelNumConcurso.Text));//verifica se este é o primeiro sorteio do concurso ou não
            
            Sorteio novo = new Sorteio();
            novo.ID = AcessoFB.fb_verificaUltIdSorteio() + 1;
            novo.Numeros = tbN1.Text.ToString() + "-" + tbN2.Text.ToString() + "-" + tbN3.Text.ToString() + "-" + tbN4.Text.ToString() + "-" + tbN5.Text.ToString();
            novo.Concurso = Convert.ToInt32(labelNumConcurso.Text);
            AcessoFB.fb_InserirNovoSorteio(novo);

            //Verficar os acertos e ja classifica as quantidades de acertos de acordo com as apostas

            

            int qtdApo = Convert.ToInt32(labelNumApostas.Text);
            int n1 = Convert.ToInt32(tbN1.Text), n2 = Convert.ToInt32(tbN2.Text), n3 = Convert.ToInt32(tbN3.Text), n4 = Convert.ToInt32(tbN4.Text), n5 = Convert.ToInt32(tbN5.Text);
            int priApo = AcessoFB.fb_buscaNumPrimeiraApostaConcursoAtual(Convert.ToInt32(labelNumConcurso.Text));
            
                for (int i = 0; i < qtdApo; i++)
                {
                    String acertados = "";
                    String restantes = "";
                    int qtdAcert = 0;

                    int nA1 = -1;
                    int nA2 = -1;
                    int nA3 = -1;
                    int nA4 = -1;
                    int nA5 = -1;
                    int nA6 = -1;
                    int nA7 = -1;
                    int nA8 = -1;
                    int nA9 = -1;
                    int nA10 = -1;

                    String verificar = "";
                    String acertadosRodada = ""; //essa variavel é usada quando não é a primeira rodada do sorteio, daí será somado os acertados de agora com ela, o que ira atualizar o banco para ir adicionando acertos

                    if (priSortConc == 0) // se for a primeira rodada do concurso, vai pegar a aposta da tabela de apostas
                    {
                        verificar = AcessoFB.fb_buscaNumerosApostados(priApo + i);
                    }
                    
                    if (priSortConc > 0) // se não for, dá andamento utilizando os restantes e os acertados
                    {
                        verificar = AcessoFB.fb_buscaNumerosRestantes(priApo + i);
                        acertadosRodada = AcessoFB.fb_buscaNumerosAcertadosAnteriormente(priApo + i);
                    }
                    //Verificação para  não crashar caso a substring seja nula. Assim, o programa substitui os nulo por -1

                    if(verificar.Substring(0, 2) == "--")
                    {
                        nA1 = -1;
                    }
                    if (verificar.Substring(0, 2) != "--")
                    {
                        nA1 = Convert.ToInt32(verificar.Substring(0, 2));
                    }

                    if (verificar.Substring(3, 2) == "--")
                    {
                        nA2 = -1;
                    }
                    if (verificar.Substring(3, 2) != "--")
                    {
                        nA2 = Convert.ToInt32(verificar.Substring(3, 2));
                    }

                    if (verificar.Substring(6, 2) == "--")
                    {
                        nA3 = -1;
                    }
                    if (verificar.Substring(6, 2) != "--")
                    {
                        nA3 = Convert.ToInt32(verificar.Substring(6, 2));
                    }

                    if (verificar.Substring(9, 2) == "--")
                    {
                        nA4 = -1;
                    }
                    if (verificar.Substring(9, 2) != "--")
                    {
                        nA4 = Convert.ToInt32(verificar.Substring(9, 2));
                    }

                    if (verificar.Substring(12, 2) == "--")
                    {
                        nA5 = -1;
                    }
                    if (verificar.Substring(12, 2) != "--")
                    {
                        nA5 = Convert.ToInt32(verificar.Substring(12, 2));
                    }

                    if (verificar.Substring(15, 2) == "--")
                    {
                        nA6 = -1;
                    }
                    if (verificar.Substring(15, 2) != "--")
                    {
                        nA6 = Convert.ToInt32(verificar.Substring(15, 2));
                    }

                    if (verificar.Substring(18, 2) == "--")
                    {
                        nA7 = -1;
                    }
                    if (verificar.Substring(18, 2) != "--")
                    {
                        nA7 = Convert.ToInt32(verificar.Substring(18, 2));
                    }

                    if (verificar.Substring(21, 2) == "--")
                    {
                        nA8 = -1;
                    }
                    if (verificar.Substring(21, 2) != "--")
                    {
                        nA8 = Convert.ToInt32(verificar.Substring(21, 2));
                    }

                    if (verificar.Substring(24, 2) == "--")
                    {
                        nA9 = -1;
                    }
                    if (verificar.Substring(24, 2) != "--")
                    {
                        nA9 = Convert.ToInt32(verificar.Substring(24, 2));
                    }

                    if (verificar.Substring(27, 2) == "--")
                    {
                        nA10 = -1;
                    }
                    if (verificar.Substring(27, 2) != "--")
                    {
                        nA10 = Convert.ToInt32(verificar.Substring(27, 2));
                    }


                    int[] apostados = new int[10]; //vetor com a aposta do apostador

                    apostados[0] = nA1;
                    apostados[1] = nA2;
                    apostados[2] = nA3;
                    apostados[3] = nA4;
                    apostados[4] = nA5;
                    apostados[5] = nA6;
                    apostados[6] = nA7;
                    apostados[7] = nA8;
                    apostados[8] = nA9;
                    apostados[9] = nA10;

                    int[] sorteados = new int[5]; // vetor com os numeros sorteados

                    sorteados[0] = Convert.ToInt32(tbN1.Text);
                    sorteados[1] = Convert.ToInt32(tbN2.Text);
                    sorteados[2] = Convert.ToInt32(tbN3.Text);
                    sorteados[3] = Convert.ToInt32(tbN4.Text);
                    sorteados[4] = Convert.ToInt32(tbN5.Text);

                    int[] apostaInicial = new int[10];
                    apostaInicial = apostados;

                    for (int a = 0; a < 10; a++)
                    {
                        int acertouOuNao = 0; // se acertar, é 1, se não acertar, é 0
                        if (apostados[a] == -1)
                        {
                            continue;
                        }
                        for (int b = 0; b < 5; b++)// comparar com os sorteados
                        {
                            if (sorteados[b] == -1)
                            {
                                continue;
                            }
                            if (apostados[a] == sorteados[b])
                            {
                                if (acertados.Length == 27)
                                {
                                    acertados = acertados + apostados[a].ToString(); // caso esteja no ultimo numero, então não adiciona o hífen
                                }
                                if(apostados[a].ToString().Length == 1)//ao converter para inteiro, numeros com o 0 na frente perdem esse zero. Esse if coloca o 0 novamente antes de salva a string.
                                {
                                    acertados = acertados + "0" + apostados[a].ToString() + "-";
                                    apostados[a] = -1;
                                    sorteados[b] = -1;
                                    acertouOuNao = 1;
                                    qtdAcert = qtdAcert + 1;
                                    break;
                                }
                                if(apostados[a].ToString().Length > 1)
                                {
                                    acertados = acertados + apostados[a].ToString() + "-";
                                    apostados[a] = -1;
                                    sorteados[b] = -1;
                                    acertouOuNao = 1;
                                    qtdAcert = qtdAcert + 1;
                                    break;
                                }
                                
                            }
                        }
                        if (acertouOuNao == 0)
                        {
                            if(apostados[a].ToString().Length == 1)
                            {
                                if (restantes.Length == 27)
                                {
                                    restantes = restantes + "0" + apostados[a].ToString(); // caso esteja no ultimo numero, então não adiciona o hífen
                                }
                                if (restantes.Length < 27)
                                {
                                    restantes = restantes + "0" + apostados[a].ToString() + "-";
                                }
                            }

                            if (apostados[a].ToString().Length > 1)
                            {
                                if (restantes.Length == 27)
                                {
                                    restantes = restantes + apostados[a].ToString(); // caso esteja no ultimo numero, então não adiciona o hífen
                                }
                                if (restantes.Length < 27)
                                {
                                    restantes = restantes + apostados[a].ToString() + "-";
                                }
                            }
                            
                            
                        }
                    }
                    if(priSortConc == 0)
                    {
                        if (acertados.Length < 29)
                        {
                            int faltaPreencherA = 29 - Convert.ToInt32(acertados.Length);
                            for (int z = 0; z < faltaPreencherA; z++)
                            {
                                acertados = acertados + "-";
                            }
                        }
                        if (restantes.Length < 29)
                        {
                            int faltaPreencherR = 29 - Convert.ToInt32(restantes.Length);
                            for (int r = 0; r < faltaPreencherR; r++)
                            {
                                restantes = restantes + "-";
                            }
                        }
                        Acertos adicionar = new Acertos();
                        adicionar.ID = AcessoFB.fb_verificaUltIdAcertos() + 1;
                        adicionar.Aposta = priApo + i;
                        adicionar.NumAcertos = acertados;
                        adicionar.Restantes = restantes;
                        adicionar.QtdAcertos = qtdAcert;
                        AcessoFB.fb_adicionaNovoAcerto(adicionar);
                    }

                    if(priSortConc > 0)
                    {
                        Acertos atualizar = new Acertos();
                        int qtdAcertosRodadaAnterior = AcessoFB.fb_buscaQtdAcertosRodadaAnterior(priApo + i);
                        int idAtualizar = AcessoFB.fb_buscaIdAcertos(priApo + i);
                        String AcertosFinal = acertadosRodada;
                        String preString = ""; // essa string é a primeira parte da composição da string final.

                        if (qtdAcertosRodadaAnterior == 0)
                        {
                            preString = "";
                        }

                        if(qtdAcertosRodadaAnterior == 1)
                        {
                            preString = acertadosRodada.Substring(0, 3);
                        }

                        if(qtdAcertosRodadaAnterior == 2)
                        {
                            preString = acertadosRodada.Substring(0, 6);
                        }

                        if(qtdAcertosRodadaAnterior == 3)
                        {
                            preString = acertadosRodada.Substring(0, 9);
                        }

                        if (qtdAcertosRodadaAnterior == 4)
                        {
                            preString = acertadosRodada.Substring(0, 12);
                        }

                        if (qtdAcertosRodadaAnterior == 5)
                        {
                            preString = acertadosRodada.Substring(0, 15);
                        }

                        if (qtdAcertosRodadaAnterior == 6)
                        {
                            preString = acertadosRodada.Substring(0, 18);
                        }

                        if (qtdAcertosRodadaAnterior == 7)
                        {
                            preString = acertadosRodada.Substring(0, 21);
                        }

                        if (qtdAcertosRodadaAnterior == 8)
                        {
                            preString = acertadosRodada.Substring(0, 24);
                        }

                        if (qtdAcertosRodadaAnterior == 9)
                        {
                            preString = acertadosRodada.Substring(0, 27);
                        }

                        // até aqui, pegou-se os acertos da rodada anterior para compor a string que será atualizada nos ACERTOS

                        // agora, montaremos a segunda metade da string, atualizando a anterior com os novos valores. (acertosAnteriores + acertosAtuais = stringNova) 

                        if (qtdAcert == 0)
                        {
                            AcertosFinal = acertadosRodada;
                        }

                        if(qtdAcert == 1 || qtdAcert == 2 || qtdAcert == 3 || qtdAcert == 4 || qtdAcert == 5 || qtdAcert == 6 || qtdAcert == 7 || qtdAcert == 8 || qtdAcert == 9 || qtdAcert == 10)
                        {
                            AcertosFinal = preString + acertados;
                        }
                        if(AcertosFinal.Length > 29)
                        {
                            AcertosFinal = AcertosFinal.Substring(0, 29);
                        }

                        if(AcertosFinal.Length < 29)
                        {
                            int preenche = 29 - Convert.ToInt32(AcertosFinal.Length);
                            for(int k = 0; k < preenche; k++)
                            {
                                AcertosFinal = AcertosFinal + "-";
                            }

                        }

                        if (restantes.Length < 29)
                        {
                            int faltaPreencherR = 29 - Convert.ToInt32(restantes.Length);
                            for (int r = 0; r < faltaPreencherR; r++)
                            {
                                restantes = restantes + "-";
                            }
                        }

                        atualizar.ID = idAtualizar;
                        atualizar.NumAcertos = AcertosFinal;
                        atualizar.Restantes = restantes;
                        atualizar.QtdAcertos = qtdAcertosRodadaAnterior + qtdAcert;

                        AcessoFB.fb_atualizarAcertos(atualizar);
                    }
                    
                }

            carregando.Close();

            pronto.ShowDialog();

            verificaStatusConcurso();
                      
            this.Close();
            */
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbOcultar_CheckedChanged(object sender, EventArgs e)
        {
            if(cbOcultar.Checked == true)
            {
                groupBox2.Visible = false;
            }
            if (cbOcultar.Checked == false)
            {
                groupBox2.Visible = true;
            }
        }

        private void TelaSorteio_Load(object sender, EventArgs e)
        {
            int atual = AcessoFB.fb_buscaNumeroConcursoAtual();
            // verificar se o concurso que está aberto no momento possui um vencedor, caso tenha, não deixa inserir um novo sorteio antes de encerrar  o concurso que já acabou          
            int qtd = AcessoFB.fb_contaQtdApostadoresConcurso(atual);
            labelNumConcurso.Text = atual.ToString();
            labelNumApostas.Text = qtd.ToString();
            tbN1.Focus();
            tbN1.Select();
        }

        private void tbN1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN2.Focus();
                tbN2.Select();
            }
        }

        private void tbN2_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN3.Focus();
                tbN3.Select();
            }
        }

        private void tbN3_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN4.Focus();
                tbN4.Select();
            }
        }

        private void tbN4_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 2)
            {
                tbN5.Focus();
                tbN5.Select();
            }
        }

        private void tbN1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbN1_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN1.Text = "0" + tbN1.Text;
            }
        }

        private void tbN2_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN2.Text = "0" + tbN2.Text;
            }
        }

        private void tbN3_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN3.Text = "0" + tbN3.Text;
            }
        }

        private void tbN4_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN4.Text = "0" + tbN4.Text;
            }
        }

        private void tbN5_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
            {
                tbN5.Text = "0" + tbN5.Text;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FazMeusProcessos();
        }

        public void fechaCarregamento()
        {
            if(carregando.InvokeRequired)
            {
                carregando.Invoke(new Action(() => carregando.Close()));
            }
            else
            {
                carregando.Close();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            do
            {
                num = NumeroForAtual;

            } while (num != 1);
            fechaCarregamento();
            int verificandoAcertos = AcessoFB.fb_buscaMaiorQtdAcertosConcursoAtual();
            if (verificandoAcertos < 10)// serve para não abrir a tela de concluído quando existir um vencedor para o concurso.
            {
                pronto.ShowDialog();
                pronto.Close();
                
            }
            
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.Close()));
            }
            else
            {
                this.Close();
            }
        }

        private void tbN5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btConfirmar.PerformClick();
            }
        }
    }
}
