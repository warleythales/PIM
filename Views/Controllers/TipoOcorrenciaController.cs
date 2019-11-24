using System.Web.Mvc;

namespace Views.Controllers
{
    public class TipoOcorrenciaController : Controller
    {
        // GET: TipoOcorrencia
        public ActionResult Index()
        {
            return View(Control.TipoOcorrenciaDAO.Listar());
        }

        // GET: TipoOcorrencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoOcorrencia/Create
        [HttpPost]
        public ActionResult Create(Model.TipoOcorrencia ocorrencia)
        {
            try
            {
                Control.TipoOcorrenciaDAO.Salvar(ocorrencia);
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
            return View(Control.TipoOcorrenciaDAO.BuscarPorId(id));
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.TipoOcorrencia tipoOcorrencia)
        {
            try
            {
                // TODO: Add update logic here
                Control.TipoOcorrenciaDAO.Salvar(tipoOcorrencia);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: TipoOcorrencia/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.TipoOcorrenciaDAO.BuscarPorId(id));
        }

        // POST: TipoOcorrencia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.TipoOcorrenciaDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
