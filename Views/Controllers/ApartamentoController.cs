using System.Web.Mvc;

namespace Views.Controllers
{
    public class ApartamentoController : Controller
    {
        // GET: Apartamento
        public ActionResult Index()
        {
            return View(Control.ApartamentoDAO.Listar());
        }

        // GET: Apartamento/Create
        public ActionResult Create()
        {
            ViewBag.Torre = Control.ItensSelecao.Torre.GetSelectListItems;
            return View();
        }

        // POST: Apartamento/Create
        [HttpPost]
        public ActionResult Create(Model.Apartamento apartamento)
        {
            try
            {
                Control.ApartamentoDAO.Salvar(apartamento);
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
            return View(Control.ApartamentoDAO.BuscarPorId(id));
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Apartamento condominio)
        {
            try
            {
                // TODO: Add update logic here
                Control.ApartamentoDAO.Salvar(condominio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Apartamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.ApartamentoDAO.BuscarPorId(id));
        }

        // POST: Apartamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.ApartamentoDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
