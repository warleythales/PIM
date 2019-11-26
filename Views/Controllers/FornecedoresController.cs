using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class FornecedoresController : Controller
    {
        // GET: Fornecedores
        public ActionResult Index()
        {
            return View(Control.FornecedoresDAO.Listar());
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            ViewBag.Torre = Control.ItensSelecao.Condominio.GetSelectListItems;
            return View();
        }

        // POST: Fornecedores/Create
        [HttpPost]
        public ActionResult Create(Model.Fornecedores fornecedores)
        {
            try
            {
                Control.FornecedoresDAO.Salvar(fornecedores);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Fornecedores/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Torre = Control.ItensSelecao.Condominio.GetSelectListItems;
            return View(Control.FornecedoresDAO.BuscarPorId(id));
        }

        // POST: Fornecedores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Fornecedores fornecedores)
        {
            try
            {
                // TODO: Add update logic here
                Control.FornecedoresDAO.Salvar(fornecedores);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fornecedores/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.FornecedoresDAO.BuscarPorId(id));
        }

        // POST: Fornecedores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.FornecedoresDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}