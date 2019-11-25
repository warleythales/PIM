using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Visita : Basico
    {
        [Display(Name = "Data da Visita")]
        public DateTime DataVisita { get; set; }
        [Display(Name = "Data da Entrada")]
        public TimeSpan HoraEntrada { get; set; }
        [Display(Name = "Data da Saída")]
        public TimeSpan HoraSaida { get; set; }
        
        [Display(Name = "Condomino")]
        public int CondominoId { get; set; }
        [Display(Name = "Visitante")]
        public int VisitanteId { get; set; }

        public virtual Condomino Condomino { get; set; }
        public virtual Visitante Visitante { get; set; }
    }
}
