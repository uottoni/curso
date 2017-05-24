using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
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
        public ViewResult ListarProdutos(string categoria,int pagina = 1)
        {
            
            int itensPorPagina = 5;
            _repo = new ProdutosRepositorio();
            ProdutosViewModel model = new ProdutosViewModel()
            {
                Produtos = (from x in _repo.Produtos select x)
                .Where(x => categoria == null || x.Categoria == categoria)
                .OrderBy(x => x.Descricao)
                .Skip((pagina - 1) * itensPorPagina)
                .Take(itensPorPagina),
                Paginacao = new Paginacao()
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = itensPorPagina,
                    ItensTotal = _repo.Produtos.Count(x => categoria == null || x.Categoria == categoria)
                },
                UserIP = HttpContext.Request.UserHostAddress,
                CategoriaAtual = categoria


            };

            //if (string.IsNullOrEmpty(categoria))
            //{
            //    var query = (from x in _repo.Produtos select x)
            //        .OrderBy(x => x.Descricao);

            //    model.Produtos = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);

            //    model.Paginacao = new Paginacao()
            //    {
            //        PaginaAtual = pagina,
            //        ItensPorPagina = itensPorPagina,
            //        ItensTotal = query.Count()
            //    };

            //}
            //else
            //{
            //    var query = (from x in _repo.Produtos select x).Where(x=>x.Categoria.ToUpper().Contains(categoria.ToUpper()))
            //     .OrderBy(x => x.Descricao);

            //    model.Produtos = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);

            //    model.Paginacao = new Paginacao()
            //    {
            //        PaginaAtual = pagina,
            //        ItensPorPagina = itensPorPagina,
            //        ItensTotal = query.Count()
            //    };
            //}
            //var ret = (from x in _repo.Produtos select x).Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);
            return View(model);
        }
    }
}