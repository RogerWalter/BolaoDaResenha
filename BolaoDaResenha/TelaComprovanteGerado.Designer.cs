namespace BolaoDaResenha
{
    partial class TelaComprovanteGerado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaComprovanteGerado));
            this.reportViewerComprovante = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerComprovante
            // 
            this.reportViewerComprovante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerComprovante.LocalReport.ReportEmbeddedResource = "BolaoDaResenha.Comprovante.rdlc";
            this.reportViewerComprovante.Location = new System.Drawing.Point(0, 0);
            this.reportViewerComprovante.Name = "reportViewerComprovante";
            this.reportViewerComprovante.ServerReport.BearerToken = null;
            this.reportViewerComprovante.Size = new System.Drawing.Size(481, 572);
            this.reportViewerComprovante.TabIndex = 0;
            this.reportViewerComprovante.Load += new System.EventHandler(this.reportViewerComprovante_Load);
            // 
            // TelaComprovanteGerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 572);
            this.Controls.Add(this.reportViewerComprovante);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaComprovanteGerado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprovante";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.TelaComprovanteGerado_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerComprovante;
    }
}