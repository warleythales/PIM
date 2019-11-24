using System.Web.Mvc;

namespace Views.Controllers
{
    public class CondominioController : Controller
    {
        // GET: Condominio
        public ActionResult Index()
        {
            return View(Control.CondominioDAO.Listar());
        }

        // GET: Condominio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condominio/Create
        [HttpPost]
        public ActionResult Create(Model.Condominio ocorrencia)
        {
            try
            {
                Control.CondominioDAO.Salvar(ocorrencia);
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
            return View(Control.CondominioDAO.BuscarPorId(id));
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Condominio condominio)
        {
            try
            {
                // TODO: Add update logic here
                Control.CondominioDAO.Salvar(condominio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Condominio/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.CondominioDAO.BuscarPorId(id));
        }

        // POST: Condominio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.CondominioDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
