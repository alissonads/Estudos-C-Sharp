<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaPedidos.aspx.cs" Inherits="ListaPedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Pedidos</h1>
            <hr />
            <div id="resPedidos" runat="server">

            </div>
            
            <br />
            <br />
            <asp:Button ID="btnSair" runat="server" Text="Sair" OnClick="btnSair_Click" PostBackUrl="~/Perfil.aspx" />

        </div>
    </form>
</body>
</html>
