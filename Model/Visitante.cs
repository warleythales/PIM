using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Visitante : Basico
    {
        [MaxLength(50)] 
        public string Nome { get; set; }
        [MaxLength(11)]
        public string CPF { get; set; }
        [MaxLength(9)]
        public string RG { get; set; }
        [MaxLength(11)]
        public string Telefone { get; set; }
        [MaxLength(11)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}
