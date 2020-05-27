<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastroPedido.aspx.cs" Inherits="CadastroPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Pedido</h1>
    <hr />
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="Label1" runat="server" Text="Material: "></asp:Label>
            <asp:DropDownList ID="ddpMaterial" runat="server" AutoPostBack="True">
                <asp:ListItem Selected="False" Value="0">--Material--</asp:ListItem>
            </asp:DropDownList>


            &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Valor Unitário: "></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="R$ "></asp:Label>
            <asp:Label ID="lbValorUnitario" runat="server" Text=""></asp:Label>
&nbsp;
            <asp:Label ID="Label7" runat="server" Text="- Un. Medida: "></asp:Label>
            <asp:Label ID="lbUnMedida" runat="server" Text=" - "></asp:Label>
&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Quantidade: "></asp:Label>
            <asp:TextBox ID="txtQtd" runat="server" Width="92px"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Valor Total: "></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="R$ "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - <asp:Button ID="btnIncluir" runat="server" Height="20px" Text="Incluir" OnClick="btnIncluir_Click" />
&nbsp;
            <asp:Button ID="btnCancelar" runat="server" Height="20px" Text="Cancelar" Width="66px" />
            
            <br />
            <br />
            
            <br />
            <hr />
            <br />
            <asp:Button ID="Button1" runat="server" PostBackUrl="~/Perfil.aspx" Text="Sair" />
            <br />
            <asp:Panel ID="pnItens" runat="server">
                <h2>Itens</h2>
                <hr />
                <asp:GridView ID="gdvItensPedido" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Cd_material" HeaderText="Código" />
                        <asp:BoundField DataField="Material.Descricao" HeaderText="Descricao" />
                        <asp:BoundField DataField="Material.UnidadeMedida" HeaderText="Unidade Medida" />
                        <asp:BoundField DataField="Material.ValorUnitario" HeaderText="Valor Unitário" />
                        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
                        <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total" />
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
                <asp:Button ID="btnConcluir" runat="server" Text="Concluir" OnClick="btnConcluir_Click" />
                <br />
            </asp:Panel>
            <br />
            <div id="validacao" runat="server"></div>
        </div>
    </form>
</body>
</html>
