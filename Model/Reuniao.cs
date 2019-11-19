using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Model
{
    public class Reuniao : Basico
    {
        [MaxLength(300)]
        [Required]
        public string Assunto { get; set; }

        [MaxLength(300)]
        [Required]
        public string Local { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public SituacaoReuniao Situacao { get; set;}

        [Required]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }
    }
}
