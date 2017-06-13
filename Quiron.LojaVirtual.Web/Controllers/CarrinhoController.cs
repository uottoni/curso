using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private QuironContext db;
        // GET: Carrinho      
        
        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {               
            db = new QuironContext();
            Produto produto = db.Produtos.FirstOrDefault(x => x.ProdutoId == produtoId);
            if(produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Carrinho ObterCarrinho()
        {
            const string nomeCarrinho = "Carrinho";
            Carrinho carrinho = (Carrinho)Session[nomeCarrinho];
            if(carrinho == null)
            {
                carrinho = new Carrinho();
                Session[nomeCarrinho] = carrinho;
            }
            return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            db = new QuironContext();
            var produto = db.Produtos.FirstOrDefault(x => x.ProdutoId == produtoId);
            if(produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel()
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnUrl
            
            });
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }
    }
}