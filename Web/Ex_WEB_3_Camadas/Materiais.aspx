<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Materiais.aspx.cs" Inherits="Materiais" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <h1>Cadastro de materiais</h1>
            <asp:Label ID="Label1" runat="server" Text="Descrição: "></asp:Label>
            <asp:TextBox ID="txtDescricao" runat="server" Width="284px"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label2" runat="server" Text="Un. Medida: "></asp:Label>
            <asp:DropDownList ID="ddlUnMedida" runat="server">
                <asp:ListItem>...</asp:ListItem>
                <asp:ListItem>UN</asp:ListItem>
                <asp:ListItem>KG</asp:ListItem>
                <asp:ListItem>LT</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:Label ID="Label3" runat="server" Text="Valor Unitário: "></asp:Label>
            <asp:TextBox ID="txtValorUnitario" runat="server" Width="85px"></asp:TextBox>
            
            
        &nbsp;
            <asp:Button ID="btnCadastrar" runat="server" Height="22px" Text="Cadastrar" OnClick="btnCadastrar_Click" />
&nbsp;
            <asp:Button ID="btnCancelar" runat="server" Height="20px" Text="Cancelar" OnClick="btnCancelar_Click" />
            
            
        </div>
        <p>
            &nbsp;
        </p>

    <hr />
    <asp:Panel ID="Panel1" runat="server">
        <h1>Materiais</h1>
        <asp:GridView ID="gdvResultado" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="UnidadeMedida" HeaderText="Unidade de Medida" />
                <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitário" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
    </asp:Panel>
    </form>

    </body>
</html>
