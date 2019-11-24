using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ocorrencia : Basico
    {
        [Display(Name="Descrição")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Display(Name = "Data de Abertura")]
        public DateTime DataAbertura { get; set; }

        [Display(Name = "Data de Fechamento")]
        public DateTime DataFechamento { get; set; }

        [Display(Name = "Situação")]
        [MaxLength(45)]
        public string Situacao { get; set; }

        [Display(Name="Tipo Ocorrência")]
        public int TipoOcorrenciaId { get; set; }

        public virtual TipoOcorrencia TipoOcorrencia { get; set; }

        [Display(Name = "Condomino")]
        public int CondominoId { get; set; }

        public virtual Condomino Condomino { get; set; }
    }
}
