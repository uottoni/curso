using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        // GET: Vitrine
        public ActionResult ListarProdutos(int pagina = 1)
        {

            return View();
        }
    }
}