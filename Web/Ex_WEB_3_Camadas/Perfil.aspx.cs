using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            criarUsuario();
        }
    }

    private void criarUsuario()
    {
        var acesso = Acesso.Buscar(Session["usuario"].ToString());

        lbUsuario.Text = acesso.Login;
        lbEmpresa.Text = acesso.Empresa.Nome;

        if (acesso != null)
        {
            if (acesso.NivelAcesso == "Administrador")
            {
                lkbDados.Visible = false;
                lkbNPedido.Visible = false;
                lkbPedidos.Text = "Pedidos";
                lbUsuario.Text += " - " + acesso.NivelAcesso;
            }
            else
            {
                lkbEmpresas.Visible = false;
            }
        }
    }

    protected void lkbSair_Click(object sender, EventArgs e)
    {
        Session.Remove("usuario");
        Session.Remove("empresa");
    }
}