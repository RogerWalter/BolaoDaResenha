namespace BolaoDaResenha
{
    partial class TelaRelatorioAcertosGerado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaRelatorioAcertosGerado));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabelaRelatorioBDRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabelaRelatorioBDR = new BolaoDaResenha.TabelaRelatorioBDR();
            this.RELATORIOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bDBolaoDaResenha = new BolaoDaResenha.BDBolaoDaResenha();
            this.rELATORIOTableAdapter = new BolaoDaResenha.TabelaRelatorioBDRTableAdapters.RELATORIOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaRelatorioBDRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaRelatorioBDR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RELATORIOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDBolaoDaResenha)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BolaoDaResenha.RelatorioAcertos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(823, 532);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // tabelaRelatorioBDRBindingSource
            // 
            this.tabelaRelatorioBDRBindingSource.DataSource = this.tabelaRelatorioBDR;
            this.tabelaRelatorioBDRBindingSource.Position = 0;
            this.tabelaRelatorioBDRBindingSource.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // tabelaRelatorioBDR
            // 
            this.tabelaRelatorioBDR.DataSetName = "TabelaRelatorioBDR";
            this.tabelaRelatorioBDR.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RELATORIOBindingSource
            // 
            this.RELATORIOBindingSource.DataMember = "RELATORIO";
            this.RELATORIOBindingSource.DataSource = this.tabelaRelatorioBDR;
            // 
            // bDBolaoDaResenha
            // 
            this.bDBolaoDaResenha.DataSetName = "BDBolaoDaResenha";
            this.bDBolaoDaResenha.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rELATORIOTableAdapter
            // 
            this.rELATORIOTableAdapter.ClearBeforeFill = true;
            // 
            // TelaRelatorioAcertosGerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 532);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaRelatorioAcertosGerado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Acertos";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.TelaRelatorioAcertosGerado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaRelatorioBDRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaRelatorioBDR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RELATORIOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDBolaoDaResenha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tabelaRelatorioBDRBindingSource;
        private TabelaRelatorioBDR tabelaRelatorioBDR;
        private System.Windows.Forms.BindingSource RELATORIOBindingSource;
        private BDBolaoDaResenha bDBolaoDaResenha;
        private TabelaRelatorioBDRTableAdapters.RELATORIOTableAdapter rELATORIOTableAdapter;
    }
}