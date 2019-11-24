using System.Web.Mvc;

namespace Views.Controllers
{
    public class CondominoController : Controller
    {
        // GET: Condomino
        public ActionResult Index()
        {
            return View(Control.CondominoDAO.Listar());
        }

        // GET: Condomino/Create
        public ActionResult Create()
        {
            ViewBag.Apartamento = Control.ItensSelecao.Apartamento.GetSelectListItems;
            return View();
        }

        // POST: Condomino/Create
        [HttpPost]
        public ActionResult Create(Model.Condomino condomino)
        {
            try
            {
                Control.CondominoDAO.Salvar(condomino);
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
            ViewBag.Apartamento = Control.ItensSelecao.Apartamento.GetSelectListItems;
            return View(Control.CondominoDAO.BuscarPorId(id));
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Condomino condominio)
        {
            try
            {
                // TODO: Add update logic here
                Control.CondominoDAO.Salvar(condominio);
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
            return View(Control.CondominoDAO.BuscarPorId(id));
        }

        // POST: Condomino/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.CondominoDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
