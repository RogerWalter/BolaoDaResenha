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
    public partial class TelaSplashScreen : Form
    {
        public TelaSplashScreen()
        {
            InitializeComponent();
        }

        public void iniciaContador()
        {
            this.BringToFront();
            timer1.Interval = 30;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();
        }
        Double contador = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (contador > 1.50)
            {
                timer1.Stop();
                timer2.Interval = 10;
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Enabled = true;
                timer2.Start();
                return;
            }
            contador = contador + .01;

            this.Opacity = contador;
            Console.WriteLine(contador);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (contador <= 0)
            {
                timer2.Stop();
                DialogResult = DialogResult.OK;
                return;
            }
            contador = contador - .01;
            this.Opacity = contador;
            Console.WriteLine(contador);
        }

        private void TelaSplashScreen_Load(object sender, EventArgs e)
        {
            this.Show();
            iniciaContador();
        }

        private void TelaSplashScreen_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
