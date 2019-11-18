using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Apartamento : Basico
    {
        public int Numero { get; set; }
        public int QtdQuartos { get; set; }
        public int QtdMoradores { get; set; }
        public bool Disponivel { get; set; }
        public string Tipo { get; set; }
        public int IdTorre { get; set; }
    }
}
