﻿using System.Web.Mvc;

namespace Views.Controllers
{
    public class OcorrenciaController : Controller
    {
        // GET: Ocorrencia
        public ActionResult Index()
        {
            return View(Control.OcorrenciaDAO.Listar());
        }

        // GET: Ocorrencia/Create
        public ActionResult Create()
        {
            ViewBag.TipoOcorrencia = Control.ItensSelecao.TipoOcorrencia.GetSelectListItems;
            ViewBag.Condomino = Control.ItensSelecao.Condomino.GetSelectListItems;
            return View();
        }

        // POST: Ocorrencia/Create
        [HttpPost]
        public ActionResult Create(Model.Ocorrencia ocorrencia)
        {
            try
            {
                Control.OcorrenciaDAO.Salvar(ocorrencia);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visitante/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TipoOcorrencia = Control.ItensSelecao.TipoOcorrencia.GetSelectListItems;
            ViewBag.Condomino = Control.ItensSelecao.Condomino.GetSelectListItems;
            return View(Control.OcorrenciaDAO.BuscarPorId(id));
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Ocorrencia tipoOcorrencia)
        {
            try
            {
                // TODO: Add update logic here
                Control.OcorrenciaDAO.Salvar(tipoOcorrencia);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ocorrencia/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.OcorrenciaDAO.BuscarPorId(id));
        }

        // POST: Ocorrencia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.OcorrenciaDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
