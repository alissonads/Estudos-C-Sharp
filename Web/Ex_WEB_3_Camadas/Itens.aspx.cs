using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class Itens : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            if (Acesso.Buscar(Session["usuario"].ToString()).NivelAcesso == "Cliente")
                cliente.Visible = lbCliente.Visible = false;
        }
        
        if (Request["cd_pedido"] != null)
        {
            var pedido = Pedido.Buscar(Request["cd_pedido"]);

            lbPedido.Text = pedido.Codigo;
            lbCliente.Text = pedido.Cd_cliente + " - " + pedido.Cliente.Nome;
            gdvItens.DataSource = pedido.Itens;
            gdvItens.DataBind();
            lbTotal.Text = pedido.ValorTotal.ToString();
            pnlItens.Visible = true;

            return;
        }

        pnlItens.Visible = false;
    }
}