using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Veiculo : Basico
    {
        [MaxLength(50)]
        public string Modelo { get; set; }
        [MaxLength(20)]
        public string Marca { get; set; }
        [MaxLength(4)]
        public string Ano { get; set; }
        [MaxLength(10)]
        public string Placa { get; set; }

        [Display(Name = "Condomino")]
        public int CondominoId { get; set; }
        [Display(Name = "Visitante")]
        public int VisitanteId { get; set; }

        public virtual Condominio Condomino { get; set; }
        public virtual Visitante Visitante { get; set; }
    }
}
