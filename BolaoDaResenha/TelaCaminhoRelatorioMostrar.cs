using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BolaoDaResenha
{
    public partial class TelaCaminhoRelatorioMostrar : Form
    {
        int click = 0; // Se for 1, é dos relatórios, se for 2, é dos comprovantes
        public void DeOndeVem(int gerado)
        {
            click = gerado;
        }
        public void MostraLabels()
        {
            if(click == 1)
            {
                labelComps.Visible = false;
                labelComps1.Visible = false;
                com1.Visible = false;
                com2.Visible = false;
                rel1.Visible = true;
                rel3.Visible = true;
            }
            if (click == 2)
            {
                labelComps.Visible = false;
                labelComps1.Visible = false;
                com1.Visible = true;
                com2.Visible = true;
                rel1.Visible = false;
                rel3.Visible = false;
            }
            if (click == 3)
            {
                labelComps.Visible = true;
                labelComps1.Visible = true;
                com1.Visible = false;
                com2.Visible = true;
                rel1.Visible = false;
                rel3.Visible = false;
            }
        }
        public TelaCaminhoRelatorioMostrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(click == 1)
            {
                Process.Start("Explorer", @"C:\BolaoDaResenha\Relatorios");
            }
            if(click == 2)
            {
                Process.Start("Explorer", @"C:\BolaoDaResenha\Comprovantes");
            }
            if (click == 3)
            {
                Process.Start("Explorer", @"C:\BolaoDaResenha\Comprovantes");
            }
        }

        private void TelaCaminhoRelatorioMostrar_Load(object sender, EventArgs e)
        {
            MostraLabels();
        }
    }
}
