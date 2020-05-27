<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #validacao {
            color: red;
        }
    </style>
</head>
<body>
    <script>
        var Validar = function () {
            var login = document.getElementById("txtLogin");
            var validacao = document.getElementById("validacao");
            validacao.innerHTML = "";

            if (login.value == "") {
                validacao.innerHTML = "* Nome de Usuário não preenchido.";
                login.focus();
                return false;
            }

            var senha = document.getElementById("txtSenha");
            if (senha.value == "") {
                validacao.innerHTML = "* Senha não preenchido.";
                senha.focus();
                return false;
            }

            return true;
        }
    </script>

    <form id="form1" runat="server" onsubmit="//return Validar()">
        <div>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Login: "></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server" Width="230px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Senha: "></asp:Label>
            <asp:TextBox ID="txtSenha" runat="server" Width="230px" TextMode="Password"></asp:TextBox>
            
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Italic="True" Font-Size="Small" PostBackUrl="~/CadastrarSenha.aspx">Esqueceu a senha?</asp:LinkButton>
            <br />
            <br />
            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" Width="141px" OnClick="btnEntrar_Click" />
            
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Você não possui um cadastro?"></asp:Label>
&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" Font-Italic="True" Font-Size="Small" PostBackUrl="~/CadastroUsuarios.aspx">Cadastre-se</asp:LinkButton>
            
        </div>
        <div id="validacao"></div>
    </form>

</body>
</html>
