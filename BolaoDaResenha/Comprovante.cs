using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoDaResenha
{
    public class Comprovante
    {
        public int ID { get; set; }
        public String Data {get; set;}
        public int Concurso { get; set; }
        public int Aposta { get; set; }
        public String Cambista { get; set; }
        public String Numeros { get; set; }
        public String NomeApostador { get; set; }

    }
}
