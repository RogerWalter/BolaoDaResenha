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
    public partial class TelaConfirmacaoSorteio : Form
    {
        public TelaConfirmacaoSorteio()
        {
            InitializeComponent();
        }
        String num1 = "", num2 = "", num3 = "", num4 = "", num5 = "";
        public void RecebeNumeros(String n1, String n2, String n3, String n4, String n5)
        {
            num1 = n1;
            num2 = n2;
            num3 = n3;
            num4 = n4;
            num5 = n5;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TelaConfirmacaoSorteio_Load(object sender, EventArgs e)
        {
            labN1.Text = num1;
            labN2.Text = num2;
            labN3.Text = num3;
            labN4.Text = num4;
            labN5.Text = num5;
        }
    }
}
