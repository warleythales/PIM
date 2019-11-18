using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class AreaLazer : Basico
    {
        public string Descricao { get; set; }
        public int CapacidadePessoas { get; set; }
        public bool Visitante { get; set; }
        public bool Aluguel { get; set; }
        public string Status { get; set; }
        public int IdTorre { get; set; }
    }
}
