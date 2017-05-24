using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinho
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
              ProdutoId = 1,
              Nome = "Teste 1"
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };
            Produto produto3 = new Produto()
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);


            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void AdicionarProdutoExistenteNoCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };
            //Produto produto3 = new Produto()
            //{
            //    ProdutoId = 3,
            //    Nome = "Teste 3"
            //};

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);


            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho
                .OrderBy(x=>x.Produto.ProdutoId).ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Quantidade, 11);
        }

        [TestMethod]
        public void RemoverItensDoCarrinho()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };
            Produto produto3 = new Produto()
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            //Act
            carrinho.RemoverItem(produto2);

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Where(x => x.Produto == produto2).Count(), 0);

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            //Arrange
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1" ,
                Preco = 100M
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado, 450M);
        }

        [TestMethod]
        public void LimparItensDoCarrinho()
        {
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };
            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);


            carrinho.LimparCarrinho();

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
