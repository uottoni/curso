using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.HtmlHelpers;
using Quiron.LojaVirtual.Web.Models;


namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestandoDeAPaginacaoEstaSendoGeradaCorretamente()
        {
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao()
            {
                PaginaAtual = 1,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            MvcHtmlString t = new MvcHtmlString(
                @"<a class='btn btn-default btn-primary selected' href='Pagina1'>1</a><a class='btn btn-default' href='Pagina2'>2</a><a class='btn btn-default' href='Pagina3'>3</a>"
);
            
            //assert
            Assert.AreEqual(
                t, resultado);


        }
    }
}
