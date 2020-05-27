<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Itens.aspx.cs" Inherits="Itens" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    
            <asp:Label ID="Label1" runat="server" Text="Pedido: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="lbPedido" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="cliente" runat="server" Text="Cliente: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:Label ID="lbCliente" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Panel ID="pnlItens" runat="server">
                <asp:Label ID="Label3" runat="server" Text="Itens" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <hr />
                <br />
                <asp:GridView ID="gdvItens" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Cd_material" HeaderText="Código" />
                        <asp:BoundField DataField="Material.Descricao" HeaderText="Descrição" />
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
                <asp:Label ID="Label4" runat="server" Text="Valor Total: "></asp:Label>
                <asp:Label ID="lbTotal" runat="server"></asp:Label>
                <hr />
            </asp:Panel>
            <asp:Button ID="btnOk" runat="server" Text="OK" PostBackUrl="~/ListaPedidos.aspx" />
        </div>
    </form>
</body>
</html>
