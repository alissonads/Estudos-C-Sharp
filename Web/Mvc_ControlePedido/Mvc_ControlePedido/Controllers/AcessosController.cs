using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_ControlePedido.Controllers
{
    public class AcessosController : Controller
    {
        // GET: Acessos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public void Salvar()
        {
            if (Request["senha"] != Request["senha"])
            {
                TempData["erro"] = "Senha e Confirmação de senha pecisão ser iguais.";
            }
            else
            {
                var empresa = new Empresa()
                {
                    Nome = Request["nomeEmpresa"],
                    Fantasia = Request["fantasia"],
                    Cnpj = Request["cnpj"],
                    Fone = Request["telefone"],
                    Contato = Request["contato"],
                    Email = Request["email"],
                    Endereco = Request["endereco"],
                    Numero = Request["numero"],
                    Bairro = Request["bairro"],
                    Municipio = Request["cidade"],
                    Uf = Request["uf"],
                    Cep = Convert.ToInt32(Request["cep"]),
                    Ativo = 1,
                };
                empresa.Salvar();

                empresa = Empresa.Todos().Last();

                var acesso = new Acesso()
                {
                    Cd_empresa = empresa.Cd_empresa,
                    Login = Request["usuario"],
                    Senha = Request["senha"],
                    Nivel = "C"
                };
                acesso.Salvar();
            }

            Response.Redirect("/Acessos");
        }
    }
}