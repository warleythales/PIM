using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Control
{
    public class ItensSelecao
    {
        public class TipoOcorrencia
        {
            public static List<SelectListItem> GetSelectListItems
            {
                get
                {
                    List<SelectListItem> retorno = new List<SelectListItem>();
                    retorno.Add(new SelectListItem() { Text = "----- Selecione -----", Value = "0" });
                    Control.TipoOcorrenciaDAO.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }));
                    return retorno;
                }
            }
        }
        public class Condominio
        {
            public static List<SelectListItem> GetSelectListItems
            {
                get
                {
                    List<SelectListItem> retorno = new List<SelectListItem>();
                    retorno.Add(new SelectListItem() { Text = "----- Selecione -----", Value = "0" });
                    Control.CondominioDAO.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }));
                    return retorno;
                }
            }
        }
        public class Condomino
        {
            public static List<SelectListItem> GetSelectListItems
            {
                get
                {
                    List<SelectListItem> retorno = new List<SelectListItem>();
                    retorno.Add(new SelectListItem() { Text = "----- Selecione -----", Value = "0" });
                    Control.CondominoDAO.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }));
                    return retorno;
                }
            }
        }
        public class Torre
        {
            public static List<SelectListItem> GetSelectListItems
            {
                get
                {
                    List<SelectListItem> retorno = new List<SelectListItem>();
                    retorno.Add(new SelectListItem() { Text = "----- Selecione -----", Value = "0" });
                    Control.TorreDAO.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }));
                    return retorno;
                }
            }
        }
        public class Apartamento
        {
            public static List<SelectListItem> GetSelectListItems
            {
                get
                {
                    List<SelectListItem> retorno = new List<SelectListItem>();
                    retorno.Add(new SelectListItem() { Text = "----- Selecione -----", Value = "0" });
                    Control.ApartamentoDAO.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Numero.ToString(), Value = c.Id.ToString() }));
                    return retorno;
                }
            }
        }
        public class Visitante
        {
            public static List<SelectListItem> GetSelectListItems
            {
                get
                {
                    List<SelectListItem> retorno = new List<SelectListItem>();
                    retorno.Add(new SelectListItem() { Text = "----- Selecione -----", Value = "0" });
                    Control.VisitanteDAO.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }));
                    return retorno;
                }
            }
        }
    }
}
