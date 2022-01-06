using Grpc.Core;
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
using System.Security.AccessControl;

namespace BolaoDaResenha
{
    public partial class TelaComprovanteGerado : Form
    {
        int comp = 0;
        String numerosApostados = "";


        public void recebeNumComp(int nc, String numerosDoComp)
        {
            comp = nc;
            numerosApostados = numerosDoComp;
        }
        public TelaComprovanteGerado()
        {
            InitializeComponent();
        }

        Microsoft.Reporting.WinForms.LocalReport report;

        public void SavePDF(ReportViewer comprovante, string savePath)

        {
            byte[] Bytes = comprovante.LocalReport.Render(format: "Image" /*"PDF"*/, deviceInfo: "<DeviceInfo><OutputFormat>PNG</OutputFormat></DeviceInfo>");

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }
        }

        private void TelaComprovanteGerado_Load(object sender, EventArgs e)
        {
            Comprovante gerar = new Comprovante();
            gerar = AcessoFB.fb_buscaDadosComprovante(comp);

            reportViewerComprovante.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewerComprovante.LocalReport;
            //localReport.ReportPath = @"C:\Users\Marcio Stiz\repos\BolaoDaResenha\BolaoDaResenha\Comprovante.rdlc";
            localReport.ReportPath = @"C:\Users\Suporte02\source\repos\BolaoDaResenha\BolaoDaResenha\Comprovante.rdlc";
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("APOSTA", gerar.Aposta.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CONCURSO", gerar.Concurso.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CAMBISTA", gerar.Cambista.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", gerar.Data.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("APELIDO", gerar.NomeApostador.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("NUMEROS", numerosApostados.ToString()));

            String diretorio = @"C:\BolaoDaResenha\Comprovantes\Comprovante-" + comp.ToString() + ".png";
            this.reportViewerComprovante.RefreshReport();
            SavePDF(reportViewerComprovante, diretorio);
            DialogResult = DialogResult.OK;
        }

        private void reportViewerComprovante_Load(object sender, EventArgs e)
        {
            /*
            Comprovante gerar = new Comprovante();
            gerar = AcessoFB.fb_buscaDadosComprovante(comp);

            reportViewerComprovante.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewerComprovante.LocalReport;
            //localReport.ReportPath = @"C:\Users\Marcio Stiz\repos\BolaoDaResenha\BolaoDaResenha\Comprovante.rdlc";
            localReport.ReportPath = @"C:\Users\Suporte02\source\repos\BolaoDaResenha\BolaoDaResenha\Comprovante.rdlc";
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("APOSTA", gerar.Aposta.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CONCURSO", gerar.Concurso.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CAMBISTA", gerar.Cambista.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", gerar.Data.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("APELIDO", gerar.NomeApostador.ToString()));
            this.reportViewerComprovante.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("NUMEROS", numerosApostados.ToString()));
 
            String diretorio = @"C:\BolaoDaResenha\Comprovantes\Comprovante-" + comp.ToString() + ".jpg";
            this.reportViewerComprovante.RefreshReport();
            SavePDF(reportViewerComprovante, diretorio);
            DialogResult = DialogResult.OK;
            */
        }
    }
}
