using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View(Control.FuncionarioDAO.Listar());
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            ViewBag.Condominio = Control.ItensSelecao.Condominio.GetSelectListItems;
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(Model.Funcionario funcionario)
        {
            try
            {
                Control.FuncionarioDAO.Salvar(funcionario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Condominio = Control.ItensSelecao.Condominio.GetSelectListItems;
            return View(Control.FuncionarioDAO.BuscarPorId(id));
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Funcionario funcionario)
        {
            try
            {
                // TODO: Add update logic here
                Control.FuncionarioDAO.Salvar(funcionario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.FuncionarioDAO.BuscarPorId(id));
        }

        // POST: Funcionario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.FuncionarioDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}