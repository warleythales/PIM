using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class VisitaController : Controller
    {
        // GET: Visita
        public ActionResult Index()
        {
            return View(Control.VisitaDAO.Listar());
        }

        // GET: Visita/Create
        public ActionResult Create()
        {
            ViewBag.Condomino = Control.ItensSelecao.Condomino.GetSelectListItems;
            ViewBag.Visitante = Control.ItensSelecao.Visitante.GetSelectListItems;
            return View();
        }

        [ChildActionOnly]
        public ActionResult CriarPartial()
        {
            ViewBag.Condomino = Control.ItensSelecao.Condomino.GetSelectListItems;
            ViewBag.Visitante = Control.ItensSelecao.Visitante.GetSelectListItems;
            return View();
        }

        // POST: Visita/Create
        [HttpPost]
        public ActionResult Create(Model.Visita visita)
        {
            try
            {
                // TODO: Add insert logic here
                Control.VisitaDAO.Salvar(visita);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visita/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Condomino = Control.ItensSelecao.Condomino.GetSelectListItems;
            ViewBag.Visitante = Control.ItensSelecao.Visitante.GetSelectListItems;
            return View(Control.VisitaDAO.BuscarPorId(id));
        }

        // POST: Visita/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Visita visita)
        {
            try
            {
                // TODO: Add update logic here
                Control.VisitaDAO.Salvar(visita);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visita/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.VisitaDAO.BuscarPorId(id));
        }

        // POST: Visita/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Control.VisitaDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
