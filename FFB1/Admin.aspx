<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FFB1.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Player <asp:DropDownList ID="ddlPlayers" runat="server" ></asp:DropDownList>
            Team: <asp:DropDownList ID="ddlTeams" runat="server"></asp:DropDownList>
            EffWk: <asp:DropDownList ID="ddlEffWk" runat="server"></asp:DropDownList>
            EffYr: <asp:DropDownList ID="ddlEffYr" runat="server"></asp:DropDownList>
            ExpWk: <asp:DropDownList ID="ddlExpWk" runat="server"></asp:DropDownList>
            ExpYr <asp:DropDownList ID="ddlExpYr" runat="server"></asp:DropDownList>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnNew" runat="server" Text="+New" OnClick="btnNew_Click" />
        </div>
    </form>
</body>
</html>
