<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastrarSenha.aspx.cs" Inherits="CadastrarSenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Recadastrar Senha</h1>
            <hr />
            <br />
            
            <asp:Label ID="Label3" runat="server" Text="Login: "></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server" Width="215px"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label1" runat="server" Text="Senha: "></asp:Label>
            <asp:TextBox ID="txtSenha1" runat="server" Width="215px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Confirmação: "></asp:Label>
            <asp:TextBox ID="txtSenha2" runat="server" Width="215px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Confirmar" Width="120px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Cancelar" Width="120px" OnClick="Button2_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
