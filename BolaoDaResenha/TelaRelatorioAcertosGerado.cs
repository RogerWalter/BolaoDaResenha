using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BolaoDaResenha
{
    public partial class TelaRelatorioAcertosGerado : Form
    {
        //int parametro = 0;

        String ConcA, SortA;
        Microsoft.Reporting.WinForms.LocalReport report;
        public TelaRelatorioAcertosGerado(int parametro)  // 1 - Sequencia | 2 - Qtd acertos
        {
            InitializeComponent();
            report = new Microsoft.Reporting.WinForms.LocalReport();
            report.ReportEmbeddedResource = "ReportViewerExport.RelatorioAcertos.rdlc";
            String data, hora, concurso, sorteio;
            int concursoAtual;
            String atual = DateTime.Now.ToString();
            data = atual.Substring(0, 10);
            hora = atual.Substring(11, 8);
            concurso = AcessoFB.fb_buscaNumeroConcursoAtual().ToString();
            ConcA = concurso;
            concursoAtual = AcessoFB.fb_buscaNumeroConcursoAtual();
            sorteio = AcessoFB.fb_buscaSorteioAtualConcurso(concursoAtual).ToString();
            SortA = sorteio;
            //report.ReportPath = @"C:\Users\Marcio Stiz\repos\BolaoDaResenha\BolaoDaResenha\RelatorioAcertos.rdlc";
            report.ReportPath = @"C:\Users\Suporte02\source\repos\BolaoDaResenha\BolaoDaResenha\RelatorioAcertos.rdlc";
            DataSet dataset = new DataSet("Acertos");
            ReportDataSource dsAcertos = new ReportDataSource();
            dsAcertos.Name = "Acertos";
            dsAcertos.Value = dataset.Tables["RELATORIO"];
            report.DataSources.Add(dsAcertos);
            BindingSource bindingSource1 = new BindingSource();
            DataTable dados = new DataTable("Apostadores");
            DataSet teste = new DataSet();
            if(parametro == 1)
            {
                dados = AcessoFB.fb_buscaDadosDoRelatorioDeAcertos();
            }
            if(parametro == 2)
            {
                dados = AcessoFB.fb_buscaDadosDoRelatorioDeAcertosQTDACERTOS();
            }
            teste.Tables.Add(dados);
            bindingSource1.DataSource = dados;
            var dataTable = new DataTable();
            dataTable = dados;
            var dataSource = new ReportDataSource("TabelaRelatoriosBDR", dataTable);
            this.report.DataSources.Clear();
            this.report.DataSources.Add(dataSource);
            this.report.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", data));
            this.report.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("HORA", hora));
            this.report.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CONCURSO", concurso));
            this.report.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("SORTEIO", sorteio));
            report.Refresh();
            if(parametro == 1)
            {
                ExportarRelatorio("PDF", @"C:\BolaoDaResenha\Relatorios\Relatorio-C-" + ConcA + "-S-" + SortA + "-Sequencia.pdf");
            }
            if(parametro == 2)
            {
                ExportarRelatorio("PDF", @"C:\BolaoDaResenha\Relatorios\Relatorio-C-" + ConcA + "-S-" + SortA + "-QtdAcertos.pdf");
            }
            DialogResult = DialogResult.OK;
        }
        private void ExportarRelatorio(string formato, string nomeArquivo)
        {
            var bytes = report.Render(formato);
            System.IO.File.WriteAllBytes(nomeArquivo, bytes);
        }

        private void TelaRelatorioAcertosGerado_Load(object sender, EventArgs e)
        { 
            String data, hora, concurso, sorteio;
            int concursoAtual;
            String atual = DateTime.Now.ToString();
            data = atual.Substring(0, 10);
            hora = atual.Substring(11, 8);
            concurso = AcessoFB.fb_buscaNumeroConcursoAtual().ToString();
            ConcA = concurso;
            concursoAtual = AcessoFB.fb_buscaNumeroConcursoAtual();
            sorteio = AcessoFB.fb_buscaSorteioAtualConcurso(concursoAtual).ToString();
            SortA = sorteio;
            BindingSource bindingSource1 = new BindingSource();
            DataTable dados = new DataTable("Acertos");
            DataSet teste = new DataSet();
            dados = AcessoFB.fb_buscaDadosDoRelatorioDeAcertos();
            teste.Tables.Add(dados);
            bindingSource1.DataSource = dados;
            var dataTable = new DataTable();
            dataTable = dados;
            var dataSource = new Microsoft.Reporting.WinForms.ReportDataSource("TabelaRelatoriosBDR", dataTable);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", data));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("HORA", hora));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CONCURSO", concurso));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("SORTEIO", sorteio));
            this.reportViewer1.RefreshReport();
            DialogResult = DialogResult.OK;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            String data, hora, concurso, sorteio;
            int concursoAtual;
            String teste = DateTime.Now.ToString();
            data = teste.Substring(0, 10);
            hora = teste.Substring(11, 8);
            concurso = AcessoFB.fb_buscaNumeroConcursoAtual().ToString();
            concursoAtual = AcessoFB.fb_buscaNumeroConcursoAtual();
            ConcA = concurso;
            sorteio = AcessoFB.fb_buscaSorteioAtualConcurso(concursoAtual).ToString();
            SortA = sorteio;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;
            //localReport.ReportPath = @"C:\Users\Marcio Stiz\repos\BolaoDaResenha\BolaoDaResenha\RelatorioAcertos.rdlc";
            localReport.ReportPath = @"C:\Users\Suporte02\source\repos\BolaoDaResenha\BolaoDaResenha\RelatorioAcertos.rdlc";
            DataSet dataset = new DataSet("Acertos");
            ReportDataSource dsAcertos = new ReportDataSource();
            dsAcertos.Name = "Acertos";
            dsAcertos.Value = dataset.Tables["RELATORIO"];
            localReport.DataSources.Add(dsAcertos);
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", data));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("HORA", hora));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CONCURSO", concurso));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("SORTEIO", sorteio));
            this.reportViewer1.RefreshReport();
            DialogResult = DialogResult.OK;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
