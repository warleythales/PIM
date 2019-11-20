using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Model
{
    class DocumentosFinanceiros : Basico
    {
        [Required]
        public double Valor { get; set; }

        [Required]
        public TipoDocumento Tipo { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [MaxLength(45)]
        [Required]
        public string ContaBancaria { get; set; }

        [Required]
        public int IdCondominio { get; set; }
    }
}
