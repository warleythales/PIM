using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Model
{
    public class Condominio : Basico
    {
        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(14)]
        [Required]
        public string CNPJ { get; set; }

        [MaxLength(300)]
        [Required]
        public string Endereco { get; set; }
    }
}
