using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Mvc_ControlePedido.Controllers
{
    public class MateriaisController : Controller
    {
        // GET: Materiais
        public ActionResult Index()
        {
            ViewBag.Materiais = Material.Todos();

            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public void Cadastrar()
        {
            var material = new Material()
            {
                Descricao = Request["descricao"],
                Unidade_medida = Request["un_medida"],
                Valor_unitario = Convert.ToDecimal(Request["valor_unitatio"])
            };

            material.Salvar();
            Response.Redirect("/Materiais");
        }

        [HttpPost]
        public void Alterar(string id)
        {
            try
            {
                var material = new Material(id);
                material.Descricao = Request["descricao"].ToString();
                material.Unidade_medida = Request["un_medida"].ToString();
                material.Valor_unitario = Convert.ToDecimal(Request["valor_unitatio"]);

                material.Salvar();

                TempData["sucesso"] = "Material alterado com sucesso!";
            }
            catch (Exception e)
            {
                TempData["erro"] = "Não foi possivel alterar esse material. <br \\> Erro: " +
                                      e.Message;
            }

            Response.Redirect("/Materiais");
        }

        public ActionResult Editar(string id)
        {
            var material = new Material(id);
            material.Atualizar();

            ViewBag.Material = material;

            return View();
        }

        public void Excluir(string id)
        {
            try
            {
                var material = new Material(id);
                //material.Atualizar();
                material.Excluir();

                TempData["sucesso"] = "Material excluido com sucesso!";
            }
            catch (Exception e)
            {
                TempData["erro"] = "Material não pode ser excluido. <br //>Erro: " + 
                                      e.Message;
            }

            Response.Redirect("/Materiais");
        }
    }
}