using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Torre : Basico
    {
        [Display(Name = "Descrição")]
        [MaxLength(100)]
        [Required]
        public string Descricao { get; set; }

        [Required]
        public int Pavimentos { get; set; }

        [Required]
        public int Vagas { get; set; }

        [Required]
        public bool Academia { get; set; }

        [Display(Name = "Salão de Festas")]
        [Required]
        public bool SalaoFesta { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        [Display(Name="Condominio")]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }

    }
}
