using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Mvc_ControlePedido.Controllers
{
    public class ItensPedidoController : Controller
    {
        // GET: ItensPedido
        public ActionResult Index(string id)
        {
            ViewBag.Itens = ItemPedido.BuscarPorPedido(id);

            return View();
        }
    }
}