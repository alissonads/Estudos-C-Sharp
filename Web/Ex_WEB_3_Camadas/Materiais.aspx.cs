using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class Materiais : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CriarTabelaMateriais();
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        var material = new Material() { Descricao = txtDescricao.Text,
                                        UnidadeMedida = ddlUnMedida.Text,
                                        ValorUnitario = double.Parse(txtValorUnitario.Text)
        };
        material.Salvar();
        
        Response.Write("<script>alert('Material Cadastrado com Sucesso!')</script>");
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Materiais.aspx");
    }

    public void CriarTabelaMateriais()
    {
        var materiais = Material.Buscar();
        
        gdvResultado.DataSource = materiais;
        gdvResultado.DataBind();
    }
}