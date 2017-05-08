using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repo;
        // GET: Vitrine
        public ActionResult ListarProdutos(int pagina = 1)
        {
            int itensPorPagina = 5;
            _repo = new ProdutosRepositorio();
            var ret = (from x in _repo.Produtos select x).Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);
            return View(ret);
        }
    }
}