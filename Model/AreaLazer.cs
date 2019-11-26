using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Model
{
    public class AreaLazer : Basico
    {
        [MaxLength(100)]
        [Required]
        public string Descricao { get; set; }

        [Required]
        public int CapacidadePessoas { get; set; }

        [Required]
        public bool Visitante { get; set; }

        [Required]
        public bool Aluguel { get; set; }

        [MaxLength(45)]
        [Required]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Torre")]
        public int IdTorre { get; set; }
        public Torre Torre { get; set; }
    }
}
