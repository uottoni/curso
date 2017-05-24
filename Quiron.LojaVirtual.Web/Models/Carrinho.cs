using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Web.Models
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itensCarrinho = new List<ItemCarrinho>();

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = _itensCarrinho.FirstOrDefault(x => x.Produto.ProdutoId == produto.ProdutoId);
            if (item == null)
            {
                _itensCarrinho.Add(new ItemCarrinho()
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        public void RemoverItem(Produto produto)
        {
            _itensCarrinho.RemoveAll(x => x.Produto.ProdutoId == produto.ProdutoId);
        }

        public decimal ObterValorTotal()
        {
            return _itensCarrinho.Sum(x => x.Produto.Preco * x.Quantidade);
        }

        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();
        }

           public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itensCarrinho; }
        }

    }
    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}