using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class CadastroUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        validacao.InnerHtml = "";
        if (txtSenha.Text != txtSenha2.Text)
        {
            validacao.InnerHtml = "<script>alert('senha e confirmação de senha precisão ser iguais.')</script>";
            return;
        }

        var empresa = new Empresa() { Cnpj = txtCnpj.Text,
                                      Nome = txtNomeEmpresa.Text,
                                      Contato = txtContato.Text,
                                      Fantasia = txtFantasia.Text,
                                      Fone = txtTelefone.Text,
                                      Email = txtEmail.Text,
                                      Endereco = txtEndereco.Text,
                                      Bairro = txtBairro.Text,
                                      Municipio = txtCidade.Text,
                                      UF = txtUf.Text,
                                      CEP = int.Parse(txtCep.Text),
                                      Numero = int.Parse(txtNum.Text),
                                      Ativo = true };
        empresa.Salvar();

        var acessos = new Acesso() { Login = txtLogin.Text, CodigoEmpresa = empresa.Codigo };
        acessos.SetNivelAcesso('C');
        acessos.SetSenha(txtSenha.Text);
        acessos.Salvar();

        validacao.InnerHtml += "<script>alert('Usuário cadastrado com SUCESSO!')</script>";
        LimparCampos();

        Response.Redirect("~/");
    }

    private void LimparCampos()
    {
        txtCnpj.Text = "";
        txtNomeEmpresa.Text = "";
        txtContato.Text = "";
        txtFantasia.Text = "";
        txtTelefone.Text = "";
        txtEmail.Text = "";
        txtEndereco.Text = "";
        txtBairro.Text = "";
        txtCidade.Text = "";
        txtUf.Text = "";
        txtCep.Text = "";
        txtNum.Text = "";
        txtLogin.Text = "";
    }
}