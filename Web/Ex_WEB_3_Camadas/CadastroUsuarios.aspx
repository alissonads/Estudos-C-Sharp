<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastroUsuarios.aspx.cs" Inherits="CadastroUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <h1>Dados da Empresa</h1>
            <asp:Label ID="Label1" runat="server" Text="Nome da Empresa: "></asp:Label>
            <asp:TextBox ID="txtNomeEmpresa" runat="server" Width="382px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Fantasia: "></asp:Label>
            <asp:TextBox ID="txtFantasia" runat="server" Width="357px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="CNPJ: "></asp:Label>
            <asp:TextBox ID="txtCnpj" runat="server" Width="206px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Telefone: "></asp:Label>
            <asp:TextBox ID="txtTelefone" runat="server" Width="189px"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Contato: "></asp:Label>
            <asp:TextBox ID="txtContato" runat="server" Width="184px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="E-mail: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="457px"></asp:TextBox>
            <br />
            <br />
            <br />
            <hr />
            <h2>Endereço da Empresa</h2>
            <asp:Label ID="Label7" runat="server" Text="Endereço: "></asp:Label>
            <asp:TextBox ID="txtEndereco" runat="server" Width="329px"></asp:TextBox>
            &nbsp;<asp:Label ID="Label8" runat="server" Text="Nº"></asp:Label>
            <asp:TextBox ID="txtNum" runat="server" TextMode="Number" Width="78px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Bairro: "></asp:Label>
            <asp:TextBox ID="txtBairro" runat="server" Width="277px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Cidade: "></asp:Label>
            <asp:TextBox ID="txtCidade" runat="server" Width="188px"></asp:TextBox>
            
            <asp:Label ID="Label11" runat="server" Text="UF: "></asp:Label>
            <asp:TextBox ID="txtUf" runat="server" Width="38px"></asp:TextBox>
            
        &nbsp;
            <asp:Label ID="Label12" runat="server" Text="CEP: "></asp:Label>
            <asp:TextBox ID="txtCep" runat="server" TextMode="Number" Width="130px"></asp:TextBox>
            <br />
            <br />
            <hr />
            <h2>Dados de Acesso</h2>
            <asp:Label ID="Label13" runat="server" Text="Login: "></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server" Width="191px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label14" runat="server" Text="Senha: "></asp:Label>
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="184px"></asp:TextBox>
            
        &nbsp;
            <asp:Label ID="Label15" runat="server" Text="Confirmação: "></asp:Label>
            <asp:TextBox ID="txtSenha2" runat="server" TextMode="Password" Width="184px"></asp:TextBox>
            
            <br />
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="131px" OnClick="btnSalvar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="131px" PostBackUrl="~/Default.aspx" />
            <br />
            <br />
        <div id="validacao" runat="server"></div>
        </div>
    </form>
</body>
</html>
