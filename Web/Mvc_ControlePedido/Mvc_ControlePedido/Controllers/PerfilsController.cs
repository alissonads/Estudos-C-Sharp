using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_ControlePedido.Controllers
{
    public class PerfilsController : Controller
    {
        // GET: Perfils
        public ActionResult Index()
        {
            criarUsuario();
            return View();
        }

        private void criarUsuario()
        {
            if (Session["usuario"] != null)
            {
                var acesso = new Acesso(Session["usuario"].ToString());
                acesso.Atualizar();

                ViewBag.Acesso = acesso;
            }
            
        }
    }
}