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
            return View();
        }

        // GET: Visitante/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Visitante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitante/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Visitante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
