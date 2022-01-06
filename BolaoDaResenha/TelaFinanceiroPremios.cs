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
    public partial class TelaFinanceiroPremios : Form
    {
        public TelaFinanceiroPremios()
        {
            InitializeComponent();
        }

        private void TelaFinanceiroPremios_Load(object sender, EventArgs e)
        {
            Financeiro novo = new Financeiro();
            novo = AcessoFB.fb_buscaDadosFinanceiroAtual();
            premio.Text = novo.Premio.ToString("C", CultureInfo.CurrentCulture);
            insc.Text = novo.Insc.ToString("C", CultureInfo.CurrentCulture);
            inic.Text = novo.inicio;
        }

        private void qtdpart_Click(object sender, EventArgs e)
        {
            
        }
    }
}
