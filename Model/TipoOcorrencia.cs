﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TipoOcorrencia : Basico
    {
        [Display(Name = "Descrição")]
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
