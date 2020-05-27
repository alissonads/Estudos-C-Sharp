using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class ListaPedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            var acesso = Acesso.Buscar(Session["usuario"].ToString());

            if (acesso.NivelAcesso == "Administrador")
                criarTablePedidosAdm();
            else
                criarTablePedidosCliente(acesso);
        }
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Perfil.aspx");
    }

    private void criarTablePedidosAdm()
    {
        var pedidos = Pedido.Buscar();
        int i = 1;
        string html = "<table cellspacing=\"0\" cellpadding=\"4\" style = \"color:#333333;border-collapse:collapse;\">" +
        "<tr style=\"color:White;background-color:#507CD1;font-weight:bold;\" >" +
        "<th scope=\"col\">C&#243;digo</th><th scope=\"col\">Data</th><th scope=\"col\">Cliente</th><th scope=\"col\">Valor Total</th><th scope=\"col\">Total Itens</th><th scope=\"col\"> </th>" +
        "</tr>";
        
        foreach (var pedido in pedidos)
        {
            html += "<tr style=\"background-color:" + ((i%2!=0)? "#EFF3FB" : "White") + "; \" >\n" +
                    "<td>" + pedido.Codigo + "</td>" +
                    "<td>" + pedido.DataPedido + "</td>" +
                    "<td>" + pedido.Cliente.Nome + "</td>" +
                    "<td>" + pedido.ValorTotal + "</td>" +
                    "<td>" + pedido.TotalItens  + "</td>" +
                    "<td><a href=\"Itens.aspx?cd_pedido=" + pedido.Codigo + "\">" +
                    "<input type=\"button\" name=\"btnItens-" + pedido.Codigo + "\" value=\"Itens\" id=\"btnItens-" + pedido.Codigo + "\" /></td>\n" +
                    "</a>" +
                    "</tr>\n";
                                                                      
        }
        html += "</table>";
        resPedidos.InnerHtml = html;
    }

    private void criarTablePedidosCliente(Acesso acesso)
    {
        var pedidos = Pedido.Buscar();
        int i = 1;
        string html = "<table cellspacing=\"0\" cellpadding=\"4\" style = \"color:#333333;border-collapse:collapse;\">" +
        "<tr style=\"color:White;background-color:#507CD1;font-weight:bold;\" >" +
        "<th scope=\"col\">C&#243;digo</th><th scope=\"col\">Data</th><th scope=\"col\">Cliente</th><th scope=\"col\">Valor Total</th><th scope=\"col\">Total Itens</th><th scope=\"col\"> </th>" +
        "</tr>";

        foreach (var pedido in pedidos)
        {
            if (pedido.Cd_cliente == acesso.CodigoEmpresa)
            {
                html += "<tr style=\"background-color:" + ((i % 2 != 0) ? "#EFF3FB" : "White") + "; \" >\n" +
                        "<td>" + pedido.Codigo + "</td>" +
                        "<td>" + pedido.DataPedido + "</td>" +
                        "<td>" + pedido.Cliente.Nome + "</td>" +
                        "<td>" + pedido.ValorTotal + "</td>" +
                        "<td>" + pedido.TotalItens + "</td>" +
                        "<td><a href=\"Itens.aspx?cd_pedido=" + pedido.Codigo + "\">" +
                        "<input type=\"button\" name=\"btnItens-" + pedido.Codigo + "\" value=\"Itens\" id=\"btnItens-" + pedido.Codigo + "\" /></td>\n" +
                        "</a>" +
                        "</tr>\n";
                i++;
            }

        }
        html += "</table>";
        resPedidos.InnerHtml = html;
    }
}