using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Patrimonio : Basico
    {
        [Display(Name = "Descrição")]
        [MaxLength(100)]
        [Required]
        public string Descricao { get; set; }

        [MaxLength(100)]
        [Required]
        public string Local { get; set; }

        [MaxLength(100)]
        [Required]
        public string Tipo { get; set; }
        
        [Display(Name = "Em Manutenção")]
        [Required]
        public bool EmManutecao { get; set; }

        public int TorreId { get; set; }
        public virtual Torre Torre { get; set; }
    }
}
