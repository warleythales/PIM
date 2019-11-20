using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Model
{
    class Apartamento : Basico
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        public int QtdQuartos { get; set; }

        [Required]
        public int QtdMoradores { get; set; }

        [Required]
        public bool Disponivel { get; set; }

        [MaxLength(45)]
        [Required]
        public string Tipo { get; set; }

        [Required]
        public int IdTorre { get; set; }
    }
}
