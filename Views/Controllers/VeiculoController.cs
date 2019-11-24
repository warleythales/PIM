using System.Web.Mvc;

namespace Views.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult Index()
        {
            return View(Control.VeiculoDAO.Listar());
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            ViewBag.Condomino = Control.ItensSelecao.Condomino.GetSelectListItems;
            ViewBag.Visitante = Control.ItensSelecao.Visitante.GetSelectListItems;
            return View();
        }

        // POST: Veiculo/Create
        [HttpPost]
        public ActionResult Create(Model.Veiculo veiculo)
        {
            try
            {
                Control.VeiculoDAO.Salvar(veiculo);
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
            return View(Control.VeiculoDAO.BuscarPorId(id));
        }

        // POST: Visitante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Veiculo condominio)
        {
            try
            {
                // TODO: Add update logic here
                Control.VeiculoDAO.Salvar(condominio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Veiculo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Control.VeiculoDAO.BuscarPorId(id));
        }

        // POST: Veiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                Control.VeiculoDAO.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
