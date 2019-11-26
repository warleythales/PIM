using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class PatrimonioController : Controller
    {
        // GET: Patrimonio
        public ActionResult Index()
        {
            return View(Control.PatrimonioDAO.Listar());
        }

        // GET: Patrimonio/Create
        public ActionResult Create()
        {
            ViewBag.Torre = Control.ItensSelecao.Torre.GetSelectListItems;
            return View();
        }

        // POST: Patrimonio/Create
        [HttpPost]
        public ActionResult Create(Model.Patrimonio patrimonio)
        {
            try
            {
                Control.PatrimonioDAO.Salvar(patrimonio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patrimonio/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Torre = Control.ItensSelecao.Torre.GetSelectListItems;
            return View(Control.PatrimonioDAO.BuscarPorId(id));
        }

        // POST: Patrimonio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Patrimonio patrimonio)
        {
            try
            {
                // TODO: Add update logic here
                Control.PatrimonioDAO.Salvar(patrimonio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patrimonio/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.PatrimonioDAO.BuscarPorId(id));
        }

        // POST: Patrimonio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.PatrimonioDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}