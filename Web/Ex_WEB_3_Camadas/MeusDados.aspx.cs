using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class MeusDados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empresa"] != null)
        {
            buscarDados();
        }
    }

    private void buscarDados()
    {
        var empresa = Empresa.Buscar(Session["empresa"].ToString());

        lbNome.Text = empresa.Nome;
        lbFantasia.Text = empresa.Fantasia;
        lbCnpj.Text = empresa.Cnpj;
        lbFone.Text = empresa.Fone;
        lbContato.Text = empresa.Contato;
        lbEmail.Text = empresa.Email;
        lbEndereco.Text = empresa.Endereco;
        lbNumero.Text = empresa.Numero.ToString();
        lbBairro.Text = empresa.Bairro;
        lbCidade.Text = empresa.Municipio;
        lbUf.Text = empresa.UF;
        lbCep.Text = DataBase.Utils.StringUtil.Format(empresa.CEP.ToString(), "##.###-###");
    }

            
}