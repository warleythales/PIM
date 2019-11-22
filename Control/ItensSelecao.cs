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
        //public class Produtora
        //{
        //    public static List<SelectListItem> GetSelectListItems
        //    {
        //        get
        //        {
        //            List<SelectListItem> retorno = new List<SelectListItem>();
        //            retorno.Add(new SelectListItem() { Text = "----- Selecione -----", Value = "0" });
        //            Controller.Produtora.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }));
        //            return retorno;
        //        }
        //    }
        //}
        //public class Genero
        //{
        //    public static List<SelectListItem> GetSelectListItems
        //    {
        //        get
        //        {
        //            List<SelectListItem> retorno = new List<SelectListItem>();
        //            retorno.Add(new SelectListItem() { Text = "----- Selecione -----", Value = "0" });
        //            Controller.Genero.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Tipo, Value = c.Id.ToString() }));
        //            return retorno;
        //        }
        //    }
        //}
        //public class Funcionario
        //{
        //    public static List<SelectListItem> GetSelectListItems
        //    {
        //        get
        //        {
        //            List<SelectListItem> retorno = new List<SelectListItem>();
        //            Controller.Funcionario.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }));
        //            return retorno;
        //        }
        //    }
        //}
        //public class Cliente
        //{
        //    public static List<SelectListItem> GetSelectListItems
        //    {
        //        get
        //        {
        //            List<SelectListItem> retorno = new List<SelectListItem>();
        //            Controller.Cliente.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }));
        //            return retorno;
        //        }
        //    }
        //}
        //public class Filme
        //{
        //    public static List<SelectListItem> GetSelectListItems
        //    {
        //        get
        //        {
        //            List<SelectListItem> retorno = new List<SelectListItem>();
        //            Controller.Filme.Listar().ForEach(c => retorno.Add(new SelectListItem() { Text = c.Titulo, Value = c.Id.ToString() }));
        //            return retorno;
        //        }
        //    }
        //}
    }
}
