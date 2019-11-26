using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class ReuniaoController : Controller
    {
        // GET: Reuniao
        public ActionResult Index()
        {
            return View(Control.ReuniaoDAO.Listar());
        }

        // GET: Reuniao/Create
        public ActionResult Create()
        {
            ViewBag.Condominio = Control.ItensSelecao.Condominio.GetSelectListItems;
            return View();
        }

        // POST: Reuniao/Create
        [HttpPost]
        public ActionResult Create(Model.Reuniao reuniao)
        {
            try
            {
                Control.ReuniaoDAO.Salvar(reuniao);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reuniao/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Condominio = Control.ItensSelecao.Condominio.GetSelectListItems;
            return View(Control.ReuniaoDAO.BuscarPorId(id));
        }

        // POST: Reuniao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Reuniao reuniao)
        {
            try
            {
                // TODO: Add update logic here
                Control.ReuniaoDAO.Salvar(reuniao);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reuniao/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.ReuniaoDAO.BuscarPorId(id));
        }

        // POST: Reuniao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.ReuniaoDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}