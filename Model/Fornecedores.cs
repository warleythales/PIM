using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Model
{
    class Fornecedores : Basico
    {
        [MaxLength(100)]
        [Required]
        public string Atividade { get; set; }

        [MaxLength(11)]
        [Required]
        public string Telefone { get; set; }

        [MaxLength(14)]
        [Required]
        public string CNPJ { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        [Required]
        public int IdCondominio { get; set; }
    }
}
