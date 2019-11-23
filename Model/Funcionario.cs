using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Model
{
    public class Funcionario : Basico
    {
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(9)]
        [Required]
        public string CPF { get; set; }

        [MaxLength(9)]
        [Required]
        public string RG { get; set; }

        [MaxLength(11)]
        [Required]
        public string Telefone { get; set; }

        [MaxLength(20)]
        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string Tipo { get; set; }

        [MaxLength(45)]
        [Required]
        public string Conta { get; set; }

        [Required]
        public int PIS { get; set; }

        [Required]
        public int IdCondominio { get; set; }
    }
}
