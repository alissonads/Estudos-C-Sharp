using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Mvc_ControlePedido.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var empresa = new Empresa() { Ativo = 1, Bairro = "Teste", Cd_empresa = "0000004", Cep = 102458962, Cnpj = "00000000000000",
             Contato = "123 Testando", Email="teste.com.br", Endereco="Teste", Fantasia="Testando", Fone="(00) 00000000", Municipio="Teste", Nome="Testando 123",
             Numero="0000", Uf="TS"};
            // empresa.Salvar();

            var acesso = new Acesso() { Cd_empresa = empresa.Cd_empresa, Id = 0, Login = "teste123", Nivel = "C", Senha="123456" };
            acesso.Salvar();

            var emps = new Empresa().BuscarTodos();

            var acessos = new Acesso().BuscarTodos();

            var emp = acesso.Empresa;

            acesso.Excluir();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}