<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Usuário: " Font-Bold="True" Font-Size="Larger"></asp:Label>
            <asp:Label ID="lbUsuario" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Empresa: "></asp:Label>
            <asp:Label ID="lbEmpresa" runat="server"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="lkbDados" runat="server" PostBackUrl="~/MeusDados.aspx">Meus dados</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lkbEmpresas" runat="server" PostBackUrl="~/Empresas.aspx">Empresas</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lkbPedidos" runat="server" PostBackUrl="~/ListaPedidos.aspx">Meus Pedidos</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lkbNPedido" runat="server" PostBackUrl="~/CadastroPedido.aspx">Novo Pedido</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lkbSair" runat="server" PostBackUrl="~/Default.aspx" OnClick="lkbSair_Click">Sair</asp:LinkButton>
        </div>
    </form>
</body>
</html>
