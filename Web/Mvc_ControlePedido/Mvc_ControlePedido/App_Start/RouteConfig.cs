using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc_ControlePedido
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Acessos",
                url: "Acessos",
                defaults: new { controller = "Acessos", action = "Index" }
            );

            routes.MapRoute(
                name: "Acessos-Cadastro",
                url: "Acessos/Cadastro",
                defaults: new { controller = "Acessos", action = "Cadastro" }
            );

            routes.MapRoute(
                name: "Acessos-RedefinirSenha",
                url: "Acessos/RedefinirSenha",
                defaults: new { controller = "Acessos", action = "RedefinirSenha" }
            );

            routes.MapRoute(
                name: "Acessos-Salvar",
                url: "Acessos/Salvar",
                defaults: new { controller = "Acessos", action = "Salvar" }
            );

            routes.MapRoute(
                name: "Acessos-Buscar",
                url: "Acessos/Buscar",
                defaults: new { controller = "Acessos", action = "Buscar" }
            );

            routes.MapRoute(
                name: "Perfils",
                url: "Perfils",
                defaults: new { controller = "Perfils", action = "Index" }
            );

            routes.MapRoute(
                name: "Materiais",
                url: "Materiais",
                defaults: new { controller = "Materiais", action = "Index" }
            );

            routes.MapRoute(
                name: "Materiais-Novo",
                url: "Materiais/Novo",
                defaults: new { controller = "Materiais", action = "Novo" }
            );

            routes.MapRoute(
                name: "Materiais-Cadastrar",
                url: "Materiais/Cadastrar",
                defaults: new { controller = "Materiais", action = "Cadastrar" }
            );

            routes.MapRoute(
                name: "Materiais-Excluir",
                url: "Materiais/Excluir/{id}",
                defaults: new { controller = "Materiais", action = "Excluir", id = string.Empty }
            );

            routes.MapRoute(
                name: "Materiais-Editar",
                url: "Materiais/Editar/{id}",
                defaults: new { controller = "Materiais", action = "Editar", id = string.Empty }
            );

            routes.MapRoute(
                name: "Materiais-Alterar",
                url: "Materiais/Alterar/{id}",
                defaults: new { controller = "Materiais", action = "Alterar", id = string.Empty }
            );

            routes.MapRoute(
                name: "Sobre",
                url: "Sobre",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "Contato",
                url: "Contato",
                defaults: new { controller = "Home", action = "Contact" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
