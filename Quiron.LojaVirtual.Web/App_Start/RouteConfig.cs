﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // 1
            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Vitrine",
                    action = "ListarProdutos",
                    categoria = (string)null,
                    pagina = 1
                });
           
            //2
            routes.MapRoute(
              null,
              "Pagina{pagina}",
              new
              {
                  controller = "Vitrine",
                  action = "ListarProdutos",
                  categoria = (string)null
              },
              new { pagina = @"\d+" }
              );

            routes.MapRoute(null,
                "{categoria}",
                new { controller="Vitrine", action="ListarProdutos", pagina = 1});

            routes.MapRoute(null,
                "{categoria}/Pagina{pagina}",
                new { controller = "Vitrine", action = "ListarProdutos"},
                new { pagina = @"\d+" });

            


            routes.MapRoute(
                name: null,
                url: "Pagina{pagina}",
                defaults: new { controller = "Vitrine", action = "ListarProdutos" });



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vitrine", action = "ListarProdutos", id = UrlParameter.Optional }
            );

          


         
        }
    }
}
