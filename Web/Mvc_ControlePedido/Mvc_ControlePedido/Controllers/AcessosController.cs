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

        public ActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public void Buscar()
        {
            if (string.IsNullOrEmpty(Request["usuario"].ToString()) ||
                string.IsNullOrEmpty(Request["senha"].ToString()) )
            {
                TempData["erro"] = "Usuário ou Senha em branco.";
                Response.Redirect("/Acessos");
                return;
            }

            var acesso = new Acesso(Request["usuario"].ToString());
            acesso.Atualizar();

            if (acesso.Id != 0 && acesso.Senha == Request["senha"].ToString())
            {
                Session["usuario"] = acesso.Login;
                Response.Redirect("/Perfils");
            }
            else
            {
                TempData["erro"] = "Usuário ou Senha incorreto.";
                Response.Redirect("/Acessos");
            }
        }

        [HttpPost]
        public void Salvar()
        {
            switch (Request["acao"])
            {
                case "0":
                    cadastrar();
                    break;
                case "1":
                    recadastrarSenha();
                    break;
            }

            Response.Redirect("/Acessos");
        }

        private void cadastrar()
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

        }

        private void recadastrarSenha()
        {
            if (Request["senha"] != Request["senha"])
            {
                TempData["erro"] = "Senha e Confirmação de senha pecisão ser iguais.";
            }
            else
            {
                var acesso = new Acesso(Request["usuario"]);

                acesso.Atualizar();
                acesso.Senha = Request["senha"];
                acesso.Salvar();
            }
        }
    }
}