using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class Empresas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            var acesso = Acesso.Buscar(Session["usuario"].ToString());

            if (acesso.NivelAcesso == "Administrador")
                criarTableEmpresas();
        }
    }

    private void criarTableEmpresas()
    {
        var empresas = Empresa.Buscar();
        int i = 1;
        string html = "<table cellspacing=\"0\" cellpadding=\"4\" style = \"color:#333333;border-collapse:collapse;\">" +
        "<tr style=\"color:White;background-color:#507CD1;font-weight:bold;\" >" +
        "<th scope=\"col\">C&#243;digo</th><th scope=\"col\">CNPJ</th><th scope=\"col\">Nome</th><th scope=\"col\">Telefone</th><th scope=\"col\">Endereço</th><th scope=\"col\"> </th>" +
        "</tr>";

        foreach (var empresa in empresas)
        {
            if (empresa.Ativo)
            {
                html += "<tr style=\"background-color:" + ((i % 2 != 0) ? "#EFF3FB" : "White") + "; \" >\n" +
                        "<td>" + empresa.Codigo + "</td>" +
                        "<td>" + empresa.Cnpj + "</td>" +
                        "<td>" + empresa.Nome + "</td>" +
                        "<td>" + empresa.Fone + "</td>" +
                        "<td>" + empresa.Endereco + ", " + empresa.Numero + " - " + empresa.Bairro + ", " + empresa.Municipio + "/" + empresa.UF + "</td>" +
                        //"<td><a href=\"~/Empresas.aspx?cd_empresa=" + empresa.Codigo + "\">" +
                        //"<input type=\"button\" name=\"btnEmpresa-" + empresa.Codigo + "\" value=\"Remover\" id=\"btnEmpresa-" + empresa.Codigo + "\" /></td>\n" +
                        //"</a>" +
                        "</tr>\n";
                i++;
            }
        }
        html += "</table>";
        resEmpresas.InnerHtml = html;
    }
}