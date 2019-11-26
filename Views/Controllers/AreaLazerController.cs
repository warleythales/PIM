using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class AreaLazerController : Controller
    {
        // GET: AreaLazer
        public ActionResult Index()
        {
            return View(Control.AreaLazerDAO.Listar());
        }

        // GET: AreaLazer/Create
        public ActionResult Create()
        {
            ViewBag.Torre = Control.ItensSelecao.Torre.GetSelectListItems;
            return View();
        }

        // POST: AreaLazer/Create
        [HttpPost]
        public ActionResult Create(Model.AreaLazer arealazer)
        {
            try
            {
                Control.AreaLazerDAO.Salvar(arealazer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AreaLazer/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Torre = Control.ItensSelecao.Torre.GetSelectListItems;
            return View(Control.AreaLazerDAO.BuscarPorId(id));
        }

        // POST: AreaLazer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.AreaLazer arealazer)
        {
            try
            {
                // TODO: Add update logic here
                Control.AreaLazerDAO.Salvar(arealazer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Condomino/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.AreaLazerDAO.BuscarPorId(id));
        }

        // POST: Condomino/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.AreaLazerDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}