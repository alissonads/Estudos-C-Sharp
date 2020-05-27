using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

public partial class CadastroPedido : System.Web.UI.Page
{
    private Pedido pedido;

    protected void Page_Load(object sender, EventArgs e)
    {
        var materiais = Material.Buscar();

        ddpMaterial.Items.Clear();
        ddpMaterial.Items.Add(new ListItem("-- Materiais --", "0"));

        foreach (var material in materiais)
        {
            ddpMaterial.Items.Add(new ListItem(material.Descricao, material.Codigo));
        }

        mostrarDadosMaterial();
        mostrarItensPedido();
    }

    protected void btnIncluir_Click(object sender, EventArgs e)
    {
        validacao.InnerHtml = "";
        if (Request["ddpMaterial"] == null)
        {
            validacao.InnerHtml = "<script>alert('É necessário escolher um matérial para inserir no pedido.')</script>";
            return;
        }

        if (txtQtd.Text == "")
        {
            validacao.InnerHtml = "<script>alert('É necessáio colocar uma quantidade do material.')</script>";
            return;
        }

        criarPedido();

        var item = new ItemPedido()
        {
            Cd_material = Request["ddpMaterial"],
            ValorTotal = double.Parse(lbValorUnitario.Text) * int.Parse(txtQtd.Text),
            Quantidade = int.Parse(txtQtd.Text)
        };
        item.SetSituacao('S');

        pedido.Itens.Add(item);
        pedido.ValorTotal = pedido.ValorTotal + item.ValorTotal;
        pedido.TotalItens += 1;

        if (string.IsNullOrEmpty(pedido.Codigo))
        {
            pedido.DataPedido = DateTime.Today.Year.ToString() + "-" +
                                DateTime.Today.Month.ToString() + "-" +
                                DateTime.Today.Day.ToString();
            pedido.Cd_cliente = Acesso.Buscar(Session["usuario"].ToString()).CodigoEmpresa;
            pedido.DataLiberacao = pedido.DataPedido;
            int d = DateTime.Today.Day + 10;
            pedido.DataEntrega = DateTime.Today.Date.Year.ToString() + "-" +
                                 DateTime.Today.Month.ToString() + "-" +
                                 d.ToString();
            pedido.SetSituacao('S');
            pedido.Salvar();
            Session["cd_pedido"] = pedido.Codigo;
        }
        else
        {
            pedido.Atualizar();
        }

        item.Cd_pedido = pedido.Codigo;
        item.Salvar();
        
        mostrarItensPedido();
    }

    private void criarPedido()
    {
        if (Session["cd_pedido"] == null)
        {
            pedido = new Pedido();
            return;
        }

        pedido = Pedido.Buscar(Session["cd_pedido"].ToString());
    }

    private void mostrarDadosMaterial()
    {
        if (!string.IsNullOrEmpty(Request["ddpMaterial"]) && Request["ddpMaterial"] != "0")
        {
            var material = Material.Buscar(Request["ddpMaterial"]);
            ddpMaterial.SelectedValue = material.Codigo;
            lbValorUnitario.Text = material.ValorUnitario.ToString();
            lbUnMedida.Text = " - " + material.UnidadeMedida;
        }
    }

    private void mostrarItensPedido()
    {
        if (Session["cd_pedido"] == null)
        {
            pnItens.Visible = false;
            return;
        }
        
        pnItens.Visible = true;
        var itens = ItemPedido.Buscar(Session["cd_pedido"].ToString());
        gdvItensPedido.DataSource = itens;
        gdvItensPedido.DataBind();
    }
    
    protected void btnConcluir_Click(object sender, EventArgs e)
    {
        Session.Remove("cd_pedido");
        Response.Redirect("/");
    }
}