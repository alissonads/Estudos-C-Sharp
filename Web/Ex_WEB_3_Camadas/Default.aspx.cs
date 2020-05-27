using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        string erro = "Usuário ou Senha incorreto.";
        var acesso = Acesso.Buscar(txtLogin.Text);

        if (acesso == null)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('" + erro + "')</script>");
            return;
        }

        if (acesso.Senha != txtSenha.Text)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('" + erro + "')</script>");
            return;
        }

        Session["usuario"] = acesso.Login;
        Session["empresa"] = acesso.CodigoEmpresa;

        Response.Redirect("~/Perfil.aspx");
    }
}