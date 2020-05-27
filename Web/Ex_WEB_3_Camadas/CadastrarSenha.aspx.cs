using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class CadastrarSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtLogin.Text))
        {
            txtLogin.BorderColor = System.Drawing.Color.Red;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('Campo de login necessário!')</script>");
        }
        else
        {
            txtLogin.BorderColor = System.Drawing.Color.Empty;

            if (!String.IsNullOrEmpty(txtSenha1.Text) &&
                !String.IsNullOrEmpty(txtSenha2.Text) &&
                txtSenha1.Text == txtSenha2.Text)
            {
                //tratar o recadastramento de senha no banco aqui!!!
                var acesso = Acesso.Buscar(txtLogin.Text);
                acesso.SetSenha(txtSenha1.Text);
                acesso.Atualizar();
                
                txtLogin.Text = "";

                Response.Write("<script>alert('Senha cadastrada com SUCESSO!!!!')</script>");
                Response.Redirect("/");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('Senha e Confirmação de senha diferentes!')</script>");
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/");
    }
}