using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoDaResenha
{
    public class Aposta
    {
        public int ID { get; set; }
        public String Numeros { get; set; }
        public int Apostador { get; set; }
        public int Cambista { get; set; }
        public int Concurso { get; set; }

    }
}
