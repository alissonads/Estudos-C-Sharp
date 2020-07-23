using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Mvc_ControlePedido.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                Response.Redirect("/Acessos");

            var acesso = new Acesso(Session["usuario"].ToString());
            acesso.Atualizar();
            
            if (acesso.Nivel == "C")
            {
                ViewBag.Pedidos = Pedido.BuscarPorCliente(acesso.Cd_empresa);
            }
            else
            {
                ViewBag.Pedidos = Pedido.Todos();
            }

            ViewBag.NivelAcesso = acesso.Nivel;

            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }
    }
}