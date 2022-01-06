using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BolaoDaResenha
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine($"Version: {Environment.Version}");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new TelaFinanceiroPremios());
            ///*
            TelaLogin login = new TelaLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                TelaSplashScreen splash = new TelaSplashScreen();
                if (splash.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new TelaPrincipal());
                }
            }
            //*/
        }
    }
}
