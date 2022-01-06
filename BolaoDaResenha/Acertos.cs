using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoDaResenha
{
    public class Acertos
    {
        public int ID { get; set; }
        public int Aposta { get; set; }
        public String NumAcertos { get; set; } // modificado pra não conflitar com o nome da classe
        public String Restantes { get; set; }
        public int QtdAcertos { get; set; }
    }
}
