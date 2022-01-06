using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace BolaoDaResenha
{
    public class AcessoFB
    {
        private static readonly AcessoFB instanciaFireBird = new AcessoFB();
        private AcessoFB() { }

        public static AcessoFB getInstancia()
        {
            return instanciaFireBird;
        }

        public FbConnection getConexao()
        {
            string conn = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();
            return new FbConnection(conn);
        }




        public static DataTable fb_PreencheGridSorteioAnterior(int conc)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID as CODIGO, NUMEROS from SORTEIO where CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridVencedoresAnterior(int conc)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select a.id_concurso as CONCURSO, b.apelido as APELIDO FROM vencedor a join apostador b on a.id_apostador = b.id where a.id_concurso = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static DataTable fb_PreencheGridFinanceiroAnterior(int concu)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int atual = fb_buscaNumeroConcursoAtual();
                    conexaoFireBird.Open();
                    string mSQL = "select ID_CONCURSO as CONCURSO, PARTICIPANTES as INSCRITOS, VALOR_INSC as APOSTA, VALOR_PREMIO as PREMIO, VALOR_TOTAL_REC as RECEITA, DATA_INICIO as INICIO from FINANCEIRO WHERE ID_CONCURSO = " + concu;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int conc = 0, part = 0;
                    String ins = "VAZIA", prem = "VAZIA", tot = "VAZIA", inic = "VAZIA";

                    DataTable dt = new DataTable("Financeiro");
                    DataColumn coluna, coluna1, coluna2, coluna3, coluna4, coluna5;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "CONCURSO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "INSCRITOS";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "APOSTA";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "PREMIO";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    coluna4 = new DataColumn();
                    coluna4.DataType = System.Type.GetType("System.String");
                    coluna4.ColumnName = "RECEITA";
                    coluna4.ReadOnly = false;
                    coluna4.Unique = false;
                    dt.Columns.Add(coluna4);

                    coluna5 = new DataColumn();
                    coluna5.DataType = System.Type.GetType("System.String");
                    coluna5.ColumnName = "INICIO";
                    coluna5.ReadOnly = false;
                    coluna5.Unique = false;
                    dt.Columns.Add(coluna5);
                    while (dr.Read())
                    {
                        int aux1, aux2, aux3;
                        DataRow linha;
                        linha = dt.NewRow();

                        conc = Convert.ToInt32(dr[0]);
                        part = Convert.ToInt32(dr[1]);
                        aux1 = Convert.ToInt32(dr[2]);
                        ins = aux1.ToString("C", CultureInfo.CurrentCulture);
                        aux2 = Convert.ToInt32(dr[3]);
                        prem = aux2.ToString("C", CultureInfo.CurrentCulture);
                        aux3 = Convert.ToInt32(dr[4]);
                        tot = aux3.ToString("C", CultureInfo.CurrentCulture);
                        inic = dr[5].ToString();

                        linha["CONCURSO"] = conc;
                        linha["INSCRITOS"] = part;
                        linha["APOSTA"] = ins;
                        linha["PREMIO"] = prem;
                        linha["RECEITA"] = tot;
                        linha["INICIO"] = inic;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static String fb_PreencheLabelNumerosVencedores(int conc, String apel)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select b.numeros from vencedor a join aposta b on a.id_aposta = b.id join apostador c on b.id_apostador = c.id where a.id_concurso = " + conc + " and c.apelido = '" + apel + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "--";
                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        
        public static DataTable fb_PreencheGridConcursoAnterior(int conc)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select b.apelido as APELIDO, a.NUMEROS, c.nome as CAMBISTA from APOSTA a join APOSTADOR b on a.id_apostador = b.id join CAMBISTA c on a.id_cambista = c.id where a.concurso = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridVencedoresTodos()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select a.id_concurso as CONCURSO, b.apelido as APELIDO FROM vencedor a join apostador b on a.id_apostador = b.id order by a.id_concurso";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridFinanceiroTodos()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int atual = fb_buscaNumeroConcursoAtual();
                    conexaoFireBird.Open();
                    string mSQL = "select ID_CONCURSO as CONCURSO, PARTICIPANTES as INSCRITOS, VALOR_INSC as APOSTA, VALOR_PREMIO as PREMIO, VALOR_TOTAL_REC as RECEITA, DATA_INICIO as INICIO from FINANCEIRO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int conc = 0, part = 0;
                    String ins = "VAZIA", prem = "VAZIA", tot = "VAZIA", inic = "VAZIA";

                    DataTable dt = new DataTable("Financeiro");
                    DataColumn coluna, coluna1, coluna2, coluna3, coluna4, coluna5;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "CONCURSO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "INSCRITOS";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "APOSTA";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "PREMIO";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    coluna4 = new DataColumn();
                    coluna4.DataType = System.Type.GetType("System.String");
                    coluna4.ColumnName = "RECEITA";
                    coluna4.ReadOnly = false;
                    coluna4.Unique = false;
                    dt.Columns.Add(coluna4);

                    coluna5 = new DataColumn();
                    coluna5.DataType = System.Type.GetType("System.String");
                    coluna5.ColumnName = "INICIO";
                    coluna5.ReadOnly = false;
                    coluna5.Unique = false;
                    dt.Columns.Add(coluna5);
                    while (dr.Read())
                    {
                        int aux1, aux2, aux3;
                        DataRow linha;
                        linha = dt.NewRow();

                        conc = Convert.ToInt32(dr[0]);
                        part = Convert.ToInt32(dr[1]);
                        aux1 = Convert.ToInt32(dr[2]);
                        ins = aux1.ToString("C", CultureInfo.CurrentCulture);
                        aux2 = Convert.ToInt32(dr[3]);
                        prem = aux2.ToString("C", CultureInfo.CurrentCulture);
                        aux3 = Convert.ToInt32(dr[4]);
                        tot = aux3.ToString("C", CultureInfo.CurrentCulture);
                        inic = dr[5].ToString();

                        linha["CONCURSO"] = conc;
                        linha["INSCRITOS"] = part;
                        linha["APOSTA"] = ins;
                        linha["PREMIO"] = prem;
                        linha["RECEITA"] = tot;
                        linha["INICIO"] = inic;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridVencedoresAtual()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int atual = fb_buscaNumeroConcursoAtual();

                    conexaoFireBird.Open();
                    string mSQL = "select a.id_concurso as CONCURSO, b.apelido as APELIDO FROM vencedor a join apostador b on a.id_apostador = b.id where a.id_concurso = " + atual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridFinanceiroAtual()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int atual = fb_buscaNumeroConcursoAtual();
                    conexaoFireBird.Open();
                    string mSQL = "select ID_CONCURSO as CONCURSO, PARTICIPANTES as INSCRITOS, VALOR_INSC as APOSTA, VALOR_PREMIO as PREMIO, VALOR_TOTAL_REC as RECEITA, DATA_INICIO as INICIO from FINANCEIRO WHERE ID_CONCURSO = " + atual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int conc = 0, part = 0;
                    String ins = "VAZIA", prem = "VAZIA", tot = "VAZIA", inic = "VAZIA"; 

                    DataTable dt = new DataTable("Financeiro");
                    DataColumn coluna, coluna1, coluna2, coluna3, coluna4, coluna5;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "CONCURSO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "INSCRITOS";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "APOSTA";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "PREMIO";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    coluna4 = new DataColumn();
                    coluna4.DataType = System.Type.GetType("System.String");
                    coluna4.ColumnName = "RECEITA";
                    coluna4.ReadOnly = false;
                    coluna4.Unique = false;
                    dt.Columns.Add(coluna4);

                    coluna5 = new DataColumn();
                    coluna5.DataType = System.Type.GetType("System.String");
                    coluna5.ColumnName = "INICIO";
                    coluna5.ReadOnly = false;
                    coluna5.Unique = false;
                    dt.Columns.Add(coluna5);
                    while (dr.Read())
                    {
                        int aux1, aux2, aux3;
                        DataRow linha;
                        linha = dt.NewRow();

                        conc = Convert.ToInt32(dr[0]);
                        part = Convert.ToInt32(dr[1]);
                        aux1 = Convert.ToInt32(dr[2]);
                        ins = aux1.ToString("C", CultureInfo.CurrentCulture);
                        aux2 = Convert.ToInt32(dr[3]);
                        prem = aux2.ToString("C", CultureInfo.CurrentCulture);
                        aux3 = Convert.ToInt32(dr[4]);
                        tot = aux3.ToString("C", CultureInfo.CurrentCulture);
                        inic = dr[5].ToString();

                        linha["CONCURSO"] = conc;
                        linha["INSCRITOS"] = part;
                        linha["APOSTA"] = ins;
                        linha["PREMIO"] = prem;
                        linha["RECEITA"] = tot;
                        linha["INICIO"] = inic;
                        
                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        
        public static DataTable fb_PreencheGridSorteioAtual()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int atual = fb_buscaNumeroConcursoAtual();

                    conexaoFireBird.Open();
                    string mSQL = "select ID as CODIGO, NUMEROS from SORTEIO where CONCURSO = " + atual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridConcursoAtual()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select b.apelido as APELIDO, a.NUMEROS from APOSTA a join APOSTADOR b on a.id_apostador = b.id join CONCURSO d on a.concurso = d.id where d.status = 'A'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaApostaPrincipalFinal()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select b.apelido as APELIDO, a.NUMEROS from APOSTA a join APOSTADOR b on a.id_apostador = b.id join CONCURSO d on a.concurso = d.id where d.status = 'A'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA", resultado1 = "VAZIA";

                    DataTable dt = new DataTable("Apostas");
                    DataColumn coluna, coluna1;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "APELIDO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "NUMEROS";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = dr[0].ToString();
                        resultado1 = dr[1].ToString();

                        linha["APELIDO"] = resultado;
                        linha["NUMEROS"] = resultado1;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridConsultaConcursoAtual()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select id as Numero, iif(status = 'A', 'Atual', 'Fechado') as Status from CONCURSO order by id";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


            public static DataTable fb_PreencheGridConsultarCambista()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select NOME, CIDADE from CAMBISTA";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static Usuario fb_efetuaLogin (String login, String senha)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from USUARIO Where LOGIN = " + login + " and SENHA = " + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Usuario user = new Usuario();
                    while (dr.Read())
                    {
                        user.ID = Convert.ToInt32(dr[0]);
                        user.Login = dr[1].ToString();
                        user.Senha = dr[2].ToString();
                    }
                    return user;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaApostadores()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select APELIDO from APOSTADOR";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable("Apostadores");
                    DataColumn coluna;
                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("String");
                    coluna.ColumnName = "APELIDO";
                    coluna.ReadOnly = true;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaApostadoresTeste()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select APELIDO from APOSTADOR order by APELIDO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";

                    DataTable dt = new DataTable("Apostadores");
                    DataColumn coluna;
                    DataRow linha;
                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "APELIDO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);
                    linha = dt.NewRow();

                    while (dr.Read())
                    {
                        resultado = dr[0].ToString();
                        linha["APELIDO"] = resultado;
                        dt.Rows.Add(linha["APELIDO"]);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaCambistaFinal()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select NOME, CIDADE from CAMBISTA order by NOME";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA", resultado1 = "VAZIA";

                    DataTable dt = new DataTable("Cambistas");
                    DataColumn coluna, coluna1;
                    

                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "NOME";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "CIDADE";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = dr[0].ToString();
                        resultado1 = dr[1].ToString();

                        linha["NOME"] = resultado;
                        linha["CIDADE"] = resultado1;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaComprovantesFinalConcAtual()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int atual = fb_verificaConcAberto();
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, ID_CONCURSO as CONCURSO, NOME_APOSTADOR as APELIDO, DATA from COMPROVANTE where ID_CONCURSO = " + atual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0, resultado1 = 0;
                    String resultado2 = "VAZIA", resultado3 = "VAZIA";

                    DataTable dt = new DataTable("Comprovantes");
                    DataColumn coluna, coluna1, coluna2, coluna3;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "ID";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "ID_CONCURSO";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "NOME_APOSTADOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "DATA";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = Convert.ToInt32(dr[1]);
                        resultado2 = Convert.ToString(dr[2]);
                        resultado3 = Convert.ToString(dr[3]);

                        linha["ID"] = resultado;
                        linha["ID_CONCURSO"] = resultado1;
                        linha["NOME_APOSTADOR"] = resultado2;
                        linha["DATA"] = resultado3;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static DataTable fb_buscaComprovantesFinalConcTodos()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, ID_CONCURSO as CONCURSO, NOME_APOSTADOR as APELIDO, DATA from COMPROVANTE";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0, resultado1 = 0;
                    String resultado2 = "VAZIA", resultado3 = "VAZIA";

                    DataTable dt = new DataTable("Comprovantes");
                    DataColumn coluna, coluna1, coluna2, coluna3;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "ID";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "ID_CONCURSO";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "NOME_APOSTADOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "DATA";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = Convert.ToInt32(dr[1]);
                        resultado2 = Convert.ToString(dr[2]);
                        resultado3 = Convert.ToString(dr[3]);

                        linha["ID"] = resultado;
                        linha["ID_CONCURSO"] = resultado1;
                        linha["NOME_APOSTADOR"] = resultado2;
                        linha["DATA"] = resultado3;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaComprovantesFinalConcBusca(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, ID_CONCURSO as CONCURSO, NOME_APOSTADOR as APELIDO, DATA from COMPROVANTE WHERE ID_CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0, resultado1 = 0;
                    String resultado2 = "VAZIA", resultado3 = "VAZIA";

                    DataTable dt = new DataTable("Comprovantes");
                    DataColumn coluna, coluna1, coluna2, coluna3;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "ID";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "ID_CONCURSO";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "NOME_APOSTADOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "DATA";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = Convert.ToInt32(dr[1]);
                        resultado2 = Convert.ToString(dr[2]);
                        resultado3 = Convert.ToString(dr[3]);

                        linha["ID"] = resultado;
                        linha["ID_CONCURSO"] = resultado1;
                        linha["NOME_APOSTADOR"] = resultado2;
                        linha["DATA"] = resultado3;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaVencedoresFinal()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int concAtual = fb_verificaConcAberto();
                    conexaoFireBird.Open();
                    string mSQL = "select c.apelido from VENCEDOR a join APOSTA b on a.id_aposta = b.id join apostador c on a.id_apostador = c.id where id_concurso =" + concAtual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";

                    DataTable dt = new DataTable("Vencedores");
                    DataColumn coluna;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "APELIDO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = dr[0].ToString();

                        linha["APELIDO"] = resultado;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaDadosDoRelatorioDeAcertos()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from RELATORIO order by ID_SEQUENCIA asc";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int col1 = 0, col5 = 0;
                    String col2 = "VAZIA", col3 = "VAZIA", col4 = "VAZIA";

                    DataTable dt = new DataTable("RELATORIO");
                    DataColumn coluna1, coluna2, coluna3, coluna4, coluna5;

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "ID_SEQUENCIA";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "APELIDO";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "NUM_N_PONT";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    coluna4 = new DataColumn();
                    coluna4.DataType = System.Type.GetType("System.String");
                    coluna4.ColumnName = "NUM_S_PONT";
                    coluna4.ReadOnly = false;
                    coluna4.Unique = false;
                    dt.Columns.Add(coluna4);

                    coluna5 = new DataColumn();
                    coluna5.DataType = System.Type.GetType("System.Int32");
                    coluna5.ColumnName = "QTD_ACERTOS";
                    coluna5.ReadOnly = false;
                    coluna5.Unique = false;
                    dt.Columns.Add(coluna5);

                    //DataRow linha;
                    //linha = dt.NewRow();

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        col1 = Convert.ToInt32(dr[0]);
                        col2 = dr[1].ToString();
                        col3 = dr[2].ToString();
                        col4 = dr[3].ToString();
                        col5 = Convert.ToInt32(dr[4]);

                        linha["ID_SEQUENCIA"] = col1;
                        linha["APELIDO"] = col2;
                        linha["NUM_N_PONT"] = col3;
                        linha["NUM_S_PONT"] = col4;
                        linha["QTD_ACERTOS"] = col5;

                        dt.Rows.Add(linha);

                        /*
                        dt.Rows.Add(Convert.ToInt32(linha["ID_SEQUENCIA"]));
                        dt.Rows.Add(Convert.ToString(linha["APELIDO"]));
                        dt.Rows.Add(Convert.ToString(linha["NUM_N_PONT"]));
                        dt.Rows.Add(Convert.ToString(linha["NUM_S_PONT"]));
                        dt.Rows.Add(Convert.ToInt32(linha["QTD_ACERTOS"]));
                        */
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaDadosDoRelatorioDeAcertosQTDACERTOS() //select com ordenação pela quantidade de acertos
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from RELATORIO order by QTD_ACERTOS desc";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int col1 = 0, col5 = 0;
                    String col2 = "VAZIA", col3 = "VAZIA", col4 = "VAZIA";

                    DataTable dt = new DataTable("RELATORIO");
                    DataColumn coluna1, coluna2, coluna3, coluna4, coluna5;

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "ID_SEQUENCIA";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "APELIDO";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "NUM_N_PONT";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    coluna4 = new DataColumn();
                    coluna4.DataType = System.Type.GetType("System.String");
                    coluna4.ColumnName = "NUM_S_PONT";
                    coluna4.ReadOnly = false;
                    coluna4.Unique = false;
                    dt.Columns.Add(coluna4);

                    coluna5 = new DataColumn();
                    coluna5.DataType = System.Type.GetType("System.Int32");
                    coluna5.ColumnName = "QTD_ACERTOS";
                    coluna5.ReadOnly = false;
                    coluna5.Unique = false;
                    dt.Columns.Add(coluna5);

                    //DataRow linha;
                    //linha = dt.NewRow();

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        col1 = Convert.ToInt32(dr[0]);
                        col2 = dr[1].ToString();
                        col3 = dr[2].ToString();
                        col4 = dr[3].ToString();
                        col5 = Convert.ToInt32(dr[4]);

                        linha["ID_SEQUENCIA"] = col1;
                        linha["APELIDO"] = col2;
                        linha["NUM_N_PONT"] = col3;
                        linha["NUM_S_PONT"] = col4;
                        linha["QTD_ACERTOS"] = col5;

                        dt.Rows.Add(linha);

                        /*
                        dt.Rows.Add(Convert.ToInt32(linha["ID_SEQUENCIA"]));
                        dt.Rows.Add(Convert.ToString(linha["APELIDO"]));
                        dt.Rows.Add(Convert.ToString(linha["NUM_N_PONT"]));
                        dt.Rows.Add(Convert.ToString(linha["NUM_S_PONT"]));
                        dt.Rows.Add(Convert.ToInt32(linha["QTD_ACERTOS"]));
                        */
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static String fb_pesquisaApostadorCOMPLETO(String apostador)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select APELIDO from APOSTADOR where APELIDO = '" + apostador + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    while (dr.Read())
                    {
                        resultado = dr[0].ToString();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaIdApostaComNumerosApelido(String apelido, String numeros)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select a.ID from aposta a join apostador b on a.id_apostador = b.id where a.numeros = '" + numeros + "' and b.apelido = '" + apelido + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int idEncontrado = 0;
                    while (dr.Read())
                    {
                        idEncontrado = Convert.ToInt32(dr[0]);
                    }
                    return idEncontrado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaQtdAcertosBaseadoEmIdAposta(int idAposta)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select QTD_ACERTOS from ACERTOS where ID_APOSTA = " + idAposta;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static String fb_pesquisaApostadorCOMECA(String apostador)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select APELIDO from APOSTADOR where APELIDO like '" + apostador + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    while (dr.Read())
                    {
                        resultado = dr[0].ToString();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static String fb_pesquisaApostadorCONTENDO(String apostador)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select APELIDO from APOSTADOR where APELIDO like '%" + apostador + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    while (dr.Read())
                    {
                        resultado = dr[0].ToString();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static String fb_pesquisaCambistaCONTENDO(String cambista)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select NOME from CAMBISTA where NOME like '%" + cambista + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    while (dr.Read())
                    {
                        resultado = dr[0].ToString();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static String fb_pesquisaApostadorFINAL(String apostador)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select APELIDO from APOSTADOR where APELIDO like '%" + apostador + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    while (dr.Read())
                    {
                        resultado = dr[0].ToString();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static DataTable fb_preencheAutoComplete()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select APELIDO from APOSTADOR";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        

        public static int fb_verificaConcAberto()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from CONCURSO where STATUS = 'A'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_verificaUltIdAposta()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from APOSTA where ID = (select max(ID) from APOSTA)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);
                        
                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdFinanceiro()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from FINANCEIRO where ID = (select max(ID) from FINANCEIRO)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_verificaUltIdVencedor()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from VENCEDOR where ID = (select max(ID) from VENCEDOR)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_verificaUltIdSorteio()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from SORTEIO where ID = (select max(ID) from SORTEIO)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdAcertos()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from ACERTOS where ID = (select max(ID) from ACERTOS)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdComprovante()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from COMPROVANTE where ID = (select max(ID) from COMPROVANTE)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdApostador()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from APOSTADOR where ID = (select max(ID) from APOSTADOR)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdCambista()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from CAMBISTA where ID = (select max(ID) from CAMBISTA)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaIdApostador(String apelido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from APOSTADOR where APELIDO = '" + apelido + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int id = new int();
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr[0]);

                    }
                    return id;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaIdApostadorComAposta(int aposta)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_APOSTADOR from APOSTA where ID = " + aposta;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int id = new int();
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr[0]);

                    }
                    return id;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_verificaIdCambista(String nome)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from CAMBISTA where NOME = '" + nome + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int id = new int();
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr[0]);

                    }
                    return id;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_InserirNovoCambista(Cambista novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into CAMBISTA (ID, NOME, CIDADE) values (" + novo.ID + ", '" + novo.Nome + "', '" + novo.Cidade + "')";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_InserirNovoApostador(Apostador novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into APOSTADOR (ID, APELIDO) values (" + novo.ID + ", '" + novo.Apelido + "')";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarNovoConcurso(int num)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into CONCURSO (ID, STATUS) values (" + num + ", 'A')";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static void fb_InserirNovoSorteio(Sorteio novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into SORTEIO (ID, NUMEROS, CONCURSO) values (" + novo.ID + ", '" + novo.Numeros + "', " + novo.Concurso + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionaNovoAcerto(Acertos novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into ACERTOS (ID, ID_APOSTA, ACERTOS, RESTANTES, QTD_ACERTOS) values (" + novo.ID + ", " + novo.Aposta + ", '" + novo.NumAcertos + "', '" + novo.Restantes + "', "+ novo.QtdAcertos +")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizarAcertos(Acertos atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update ACERTOS set ACERTOS = '" + atualizar.NumAcertos + "', RESTANTES = '" + atualizar.Restantes + "', QTD_ACERTOS = " + atualizar.QtdAcertos + " where ID = " + atualizar.ID;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_encerrarConcurso(int atual)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update CONCURSO set STATUS = 'F' where ID = " + atual;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_LimpaTabelaApostadores()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM APOSTADOR";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_LimpaTabelaRelatorio()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM RELATORIO";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_LimpaTabelaApostas()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM APOSTA";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_LimpaTabelaAcertos()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM ACERTOS";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_LimpaCambista()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM CAMBISTA";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_LimpaComprovantes()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM COMPROVANTE";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_LimpaConcurso()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM CONCURSO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_LimpaSorteio()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM SORTEIO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_LimpaUsuario()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM USUARIO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_LimpaVencedor()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM VENCEDOR";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_LimpaFinanceiro()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM FINANCEIRO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_LimpaBanco()
        {
            fb_LimpaTabelaAcertos();
            fb_LimpaTabelaApostas();
            fb_LimpaTabelaApostadores();
            fb_LimpaCambista();
            fb_LimpaComprovantes();
            fb_LimpaConcurso();
            fb_LimpaTabelaRelatorio();
            fb_LimpaSorteio();
            fb_LimpaUsuario();
            fb_LimpaVencedor();
            fb_LimpaFinanceiro();
        }
        
        public static void fb_alterarCambista(Cambista novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update CAMBISTA set NOME = '" + novo.Nome + "', CIDADE = '" + novo.Cidade + "' where ID = " + novo.ID;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirCambista(int id)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "delete from CAMBISTA where ID = " + id;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_InserirNovaAposta1000(Aposta nova)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    for(int i=0; i < 1000; i++)
                    {
                        
                        string mSQL = "insert into APOSTA (ID, NUMEROS, ID_APOSTADOR, ID_CAMBISTA, CONCURSO) values (" + nova.ID + ", '" + nova.Numeros + "'," + nova.Apostador + ", " + nova.Cambista + ", " + nova.Concurso + ")";

                        FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                        cmd.ExecuteNonQuery();
                        nova.ID++;
                        
                    }   
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_InserirNovaAposta(Aposta nova)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into APOSTA (ID, NUMEROS, ID_APOSTADOR, ID_CAMBISTA, CONCURSO) values (" + nova.ID + ", '" + nova.Numeros + "'," + nova.Apostador + ", " + nova.Cambista + ", " + nova.Concurso + ")";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_InserirNovoFinanceiro(int id, int conc, int part, int valIns, int valPrem, int valTot, String inicio)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into FINANCEIRO (ID, ID_CONCURSO, PARTICIPANTES, VALOR_INSC, VALOR_PREMIO, VALOR_TOTAL_REC, DATA_INICIO) values (" + id + ", " + conc + "," + part + ", " + valIns + ", " + valPrem + ", " + valTot + ", '" + inicio + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_InserirNovoComprovante(Comprovante novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into COMPROVANTE (ID, DATA, ID_CONCURSO, ID_APOSTA, NOME_CAMBISTA, NUMEROS_APOSTA, NOME_APOSTADOR) values (" + novo.ID + ", '" + novo.Data + "'," + novo.Concurso + ", " + novo.Aposta + ", '" + novo.Cambista + "', '" + novo.Numeros + "', '" + novo.NomeApostador + "')";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaNumeroConcursoAtual()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID from CONCURSO where STATUS = 'A'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Financeiro fb_buscaDadosFinanceiroAtual()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int atual = fb_buscaNumeroConcursoAtual();
                    conexaoFireBird.Open();
                    string mSQL = "Select * from FINANCEIRO WHERE ID_CONCURSO =" + atual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Financeiro fin = new Financeiro();
                    while (dr.Read())
                    {
                        fin.Id = Convert.ToInt32(dr[0]);
                        fin.Conc = Convert.ToInt32(dr[1]);
                        fin.Part = Convert.ToInt32(dr[2]);
                        fin.Insc = Convert.ToInt32(dr[3]);
                        fin.Premio = Convert.ToInt32(dr[4]);
                        fin.Total = Convert.ToInt32(dr[5]);
                        fin.inicio = Convert.ToString(dr[6]);
                    }
                    return fin;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaDadosFinanceiroAtual(int insc, int premio, String inicio, int numPart, int total, int atual)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update FINANCEIRO set PARTICIPANTES = "+ numPart +", VALOR_INSC = "+ insc +", VALOR_PREMIO = "+ premio +", VALOR_TOTAL_REC = " + total + ", DATA_INICIO = '"+ inicio +"' where ID_CONCURSO = " + atual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaTotalFinanceiroAtuala(int val, int atual, int part)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update FINANCEIRO set VALOR_TOTAL_REC = " + val + ", PARTICIPANTES = "+ part +" where ID_CONCURSO = " + atual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        

        public static int fb_buscaSorteioAtualConcurso(int numConcAtual)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select count(*) from SORTEIO where concurso = " + numConcAtual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_verificaSeJaHouvesorteioNoConAtual(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select First(1) ID from SORTEIO where CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaSeExisteApostaNoConcursoAtual(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select First(1) ID from APOSTA where CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaSeExisteDadosFinanceiroAtual(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select First(1) ID from FINANCEIRO where ID_CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_verificaIdDoPrimCompDoConc(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select First(1) ID from COMPROVANTE where ID_CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaSeExisteConcursoNaTabela()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select First(1) ID from CONCURSO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static String fb_buscaNumerosApostados(int aposta)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select NUMEROS from APOSTA where ID =" + aposta;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "";
                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static String fb_buscaNumerosRestantes(int aposta)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select RESTANTES from ACERTOS where ID_APOSTA =" + aposta;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "";
                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }



        public static String fb_buscaNumerosAcertadosAnteriormente(int aposta)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ACERTOS from ACERTOS where ID_APOSTA =" + aposta;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "";
                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaMaiorQtdAcertosConcursoAtual()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int atual = fb_buscaNumeroConcursoAtual();

                    conexaoFireBird.Open();
                    string mSQL = "select max(a.qtd_acertos) from acertos a join aposta b on a.id_aposta = b.id  where b.concurso = "+ atual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_buscaQtdAcertosRodadaAnterior(int aposta)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select QTD_ACERTOS from ACERTOS where ID_APOSTA =" + aposta;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaIdAcertos(int aposta)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from ACERTOS where ID_APOSTA =" + aposta;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaNumPrimeiraApostaConcursoAtual(int conc) // FUNÇÃO PRA VER A PRIMEIRA APOSTA DO CONCURSO E INICIAR UM FOR LA NO PROGRAMA DE SORTEI
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select first (1) ID FROM APOSTA WHERE CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaQtdApostadoresConcurso(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from APOSTA where CONCURSO = " + conc; // Poderia usar "SELECT COUNT(*) FROM APOSTA where CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int contador = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                        contador++;
                    }
                    return contador;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_buscaIdComprovante(int conc, int apo)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from COMPROVANTE where ID_CONCURSO = " + conc + " and ID_APOSTA = " + apo; // Poderia usar "SELECT COUNT(*) FROM APOSTA where CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static String fb_buscaNumerosDoComprovante(int idComp)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select NUMEROS_APOSTA from COMPROVANTE where ID = " + idComp;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "";
                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr[0]);

                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_verificaPrimeiroSorteioDoConcurso(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "SELECT COUNT(*) FROM SORTEIO where CONCURSO = " + conc; // Poderia usar "SELECT COUNT(*) FROM APOSTA where CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contarQtdApostasNoConc(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "SELECT COUNT(*) FROM APOSTA where CONCURSO = " + conc; 
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contarQtdComprovantesNoConc(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "SELECT COUNT(*) FROM COMPROVANTE WHERE ID_CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_contarQtdSorteiosNoConc(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "SELECT COUNT(*) FROM SORTEIO where CONCURSO = " + conc; 
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Comprovante fb_buscaDadosComprovante(int comp)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "SELECT ID, DATA, ID_CONCURSO, ID_APOSTA, NOME_CAMBISTA, NUMEROS_APOSTA, NOME_APOSTADOR FROM COMPROVANTE where ID = " + comp;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Comprovante buscado = new Comprovante();
                    while (dr.Read())
                    {
                        buscado.ID = Convert.ToInt32(dr[0]);
                        buscado.Data = Convert.ToString(dr[1]);
                        buscado.Concurso = Convert.ToInt32(dr[2]);
                        buscado.Aposta = Convert.ToInt32(dr[3]);
                        buscado.Cambista = Convert.ToString(dr[4]);
                        buscado.Numeros = Convert.ToString(dr[5]);
                        buscado.NomeApostador = Convert.ToString(dr[6]);
                    }
                    return buscado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaNumApostaDaTabelaDeVencedor(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "SELECT ID_APOSTA FROM VENCEDOR where CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaQuantidadesDeAcertosParaStatus(int qtd)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select count(*) from acertos where qtd_acertos =" + qtd; 
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //Aqui é a função responsável por buscar as informações e inserir o vencedor na tabela VENCEDOR

        public static void fb_insereVencedor()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int idConc = fb_verificaConcAberto();

                    conexaoFireBird.Open();
                    string mSQL = "select a.ID_APOSTA from ACERTOS a join APOSTA b on a.id_aposta = b.id where a.QTD_ACERTOS = 10 and b.concurso =" + idConc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int idAposta = 0;
                    while (dr.Read())
                    {
                        idAposta = Convert.ToInt32(dr[0]);

                        int idApostador = fb_verificaIdApostadorComAposta(idAposta);
                        int idVenc = fb_verificaUltIdVencedor() + 1;
                        
                        int idComprovante = fb_buscaIdComprovante(idConc, idAposta);

                        string mSQL1 = "insert into VENCEDOR (ID, ID_APOSTA, ID_APOSTADOR, ID_CONCURSO, ID_COMPROVANTE) values (" + idVenc + ", " + idAposta + ", " + idApostador + ", " + idConc + ", " + idComprovante + ")";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_preencheTabelaRelatorio()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    fb_LimpaTabelaRelatorio();

                    int concAtual = fb_buscaNumeroConcursoAtual();

                    conexaoFireBird.Open();
                    string mSQL = "select c.apelido, a.restantes, a.acertos, a.qtd_acertos from ACERTOS a join APOSTA b on a.id_aposta = b.id join APOSTADOR c on b.id_apostador = c.id where b.concurso = " + concAtual + " order by c.apelido asc";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Relatorio inserir = new Relatorio();
                    int contador = 1;
                    while (dr.Read())
                    {
                        inserir.Sequencia = contador;
                        inserir.Apelido = Convert.ToString(dr[0]);
                        inserir.N_pont = Convert.ToString(dr[1]);
                        inserir.Pont = Convert.ToString(dr[2]);
                        inserir.QtdAcertos = Convert.ToInt32(dr[3]);

                        string mSQL1 = "insert into RELATORIO (ID_SEQUENCIA, APELIDO, NUM_N_PONT, NUM_S_PONT, QTD_ACERTOS) values (" + inserir.Sequencia + ", '" + inserir.Apelido + "', '" + inserir.N_pont + "', '" + inserir.Pont + "', " + inserir.QtdAcertos + ")";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                        contador = contador + 1;
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaSeConcursoJaTemVencedor(int concAtual)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_APOSTA from VENCEDOR where ID_CONCURSO = " + concAtual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int idAposta = 0;
                    while (dr.Read())
                    {
                        idAposta = Convert.ToInt32(dr[0]);
                    }
                    return idAposta;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_contaQtdVencedores(int conc)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "SELECT COUNT(*) FROM VENCEDOR where ID_CONCURSO = " + conc; // Poderia usar "SELECT COUNT(*) FROM APOSTA where CONCURSO = " + conc;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridVencedores()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int concAtual = fb_verificaConcAberto();

                    conexaoFireBird.Open();
                    string mSQL = "select c.apelido as APELIDO, b.numeros as APOSTA from VENCEDOR a join APOSTA b on a.id_aposta = b.id join apostador c on a.id_apostador = c.id where id_concurso =" + concAtual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static DataTable fb_PreencheGridVencedoresFinal()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int concAtual = fb_verificaConcAberto();
                    conexaoFireBird.Open();
                    string mSQL = "select c.apelido as APELIDO, b.numeros as APOSTA from VENCEDOR a join APOSTA b on a.id_aposta = b.id join apostador c on a.id_apostador = c.id where id_concurso =" + concAtual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA", resultado1 = "VAZIA";

                    DataTable dt = new DataTable("Vencedores");
                    DataColumn coluna, coluna1;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "APELIDO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "APOSTA";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = dr[0].ToString();
                        resultado1 = dr[1].ToString();

                        linha["APELIDO"] = resultado;
                        linha["APOSTA"] = resultado1;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_PreencheGridVencedoresConsulta()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    int concAtual = fb_verificaConcAberto();
                    conexaoFireBird.Open();
                    string mSQL = "select c.apelido from VENCEDOR a join APOSTA b on a.id_aposta = b.id join apostador c on a.id_apostador = c.id where id_concurso =" + concAtual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        /*

        public static DataTable fb_GetDados()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from Clientes";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_InserirDados(Cliente cliente)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "INSERT into Clientes Values(" + cliente.ID + ",'" + cliente.Nome + "','" + cliente.Endereco + "','" +
 cliente.Telefone + "','" + cliente.Email + "')";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_ExcluirDados(int id)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE from Clientes Where id= " + id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Cliente fb_ProcuraDados(int id)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from Clientes Where id = " + id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Cliente cliente = new Cliente();
                    while (dr.Read())
                    {
                        cliente.ID = Convert.ToInt32(dr[0]);
                        cliente.Nome = dr[1].ToString();
                        cliente.Endereco = dr[2].ToString();
                        cliente.Telefone = dr[3].ToString();
                        cliente.Email = dr[4].ToString();
                    }
                    return cliente;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_AlterarDados(Cliente cliente)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Update Clientes set nome= '" + cliente.Nome + "', endereco= '" + cliente.Endereco +
                                           "', telefone = '" + cliente.Telefone + "', email= '" + cliente.Email + "'" + " Where id= " + cliente.ID;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }*/
    }
}
