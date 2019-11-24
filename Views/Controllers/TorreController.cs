using System.Web.Mvc;

namespace Views.Controllers
{
    public class TorreController : Controller
    {
        // GET: Torre
        public ActionResult Index()
        {
            return View(Control.TorreDAO.Listar());
        }

        // GET: Torre/Create
        public ActionResult Create()
        {
            ViewBag.Condominio = Control.ItensSelecao.Condominio.GetSelectListItems;
            return View();
        }

        // POST: Torre/Create
        [HttpPost]
        public ActionResult Create(Model.Torre torre)
        {
            try
            {
                Control.TorreDAO.Salvar(torre);
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
            ViewBag.Condominio = Control.ItensSelecao.Condominio.GetSelectListItems;
            return View(Control.TorreDAO.BuscarPorId(id));
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Torre condominio)
        {
            try
            {
                // TODO: Add update logic here
                Control.TorreDAO.Salvar(condominio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Torre/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.TorreDAO.BuscarPorId(id));
        }

        // POST: Torre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.TorreDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
