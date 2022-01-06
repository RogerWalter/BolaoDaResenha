using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoDaResenha
{
    public class Vencedor
    {
        public int ID { get; set; }
        public int ID_Aposta { get; set; }
        public int ID_Apostador { get; set; }
        public int ID_Concurso { get; set; }
        public int ID_Comprovante { get; set; }

        //caso precise do nome do apostador, dá pra pegar da tabela comprovante
    }
}
