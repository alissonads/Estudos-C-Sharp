<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Empresas.aspx.cs" Inherits="Empresas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Empresas</h1>
        <hr />
        <br />
        <div id="resEmpresas" runat="server">

        </div>
        <br />
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/Perfil.aspx" Text="OK" />
    
    </div>
    </form>
</body>
</html>
