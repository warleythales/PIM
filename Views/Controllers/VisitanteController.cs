using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class VisitanteController : Controller
    {
        // GET: Visitante
        public ActionResult Index()
        {
            return View(Control.VisitanteDAO.Listar());
        }

        // GET: Visitante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitante/Create
        [HttpPost]
        public ActionResult Create(Model.Visitante visitante)
        {
            try
            {
                // TODO: Add insert logic here
                Control.VisitanteDAO.Salvar(visitante);
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
            return View(Control.VisitanteDAO.BuscarPorId(id));
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Visitante visitante)
        {
            try
            {
                // TODO: Add update logic here
                Control.VisitanteDAO.Salvar(visitante);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visitante/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.VisitanteDAO.BuscarPorId(id));
        }

        // POST: Visitante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Control.VisitanteDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
