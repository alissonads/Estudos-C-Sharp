<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeusDados.aspx.cs" Inherits="MeusDados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlDados" runat="server">
            <h1>Dados</h1>
            <asp:Label ID="Label1" runat="server" Text="Nome da Empresa: "></asp:Label>
            <asp:Label ID="lbNome" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Fantasia: "></asp:Label>
            <asp:Label ID="lbFantasia" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="CNPJ: "></asp:Label>
            <asp:Label ID="lbCnpj" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Telefone: "></asp:Label>
&nbsp;
            <asp:Label ID="lbFone" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="Contato: "></asp:Label>
            <asp:Label ID="lbContato" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="E-mail: "></asp:Label>
            <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <hr />
            <h2>Endereço</h2>
            <asp:Label ID="Label7" runat="server" Text="Endereço: "></asp:Label>
            &nbsp;<asp:Label ID="lbEndereco" runat="server" Text=""></asp:Label>
            &nbsp;
            <asp:Label ID="Label8" runat="server" Text="Nº"></asp:Label>
            <asp:Label ID="lbNumero" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Bairro: "></asp:Label>
            <asp:Label ID="lbBairro" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Cidade: "></asp:Label>
            <asp:Label ID="lbCidade" runat="server" Text=""></asp:Label>
            
            <asp:Label ID="Label11" runat="server" Text="UF: "></asp:Label>
            <asp:Label ID="lbUf" runat="server" Text=""></asp:Label>
            
        &nbsp;
            <asp:Label ID="Label12" runat="server" Text="CEP: "></asp:Label>
            <asp:Label ID="lbCep" runat="server" Text=""></asp:Label>
            <br />
            <br />

            <hr />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Editar" Width="85px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Voltar" Width="85px" PostBackUrl="~/Perfil.aspx" />
        </asp:Panel>

        <asp:Panel ID="pnlEditar" runat="server">

        </asp:Panel>
    </div>
    </form>
</body>
</html>
