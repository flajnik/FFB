<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rankings.aspx.cs" Inherits="FFB1.Rankings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 5px;">
        Position: 
    <asp:DropDownList ID="ddlPosition" runat="server" OnSelectedIndexChanged="ddlPosition_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Text="ALL" Value="ALL" />
        <asp:ListItem Text="RB" Value="RB" />
        <asp:ListItem Text="WR" Value="WR" />
        <asp:ListItem Text="QB" Value="QB" />
        <asp:ListItem Text="TE" Value="TE" />
        <asp:ListItem Text="K" Value="K" />
        <asp:ListItem Text="DST" Value="DST" />
    </asp:DropDownList>
        Scoring Format: 
    <asp:DropDownList ID="ddlScoring" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlScoring_SelectedIndexChanged">
        <asp:ListItem Text="PPR" Value="PPR" />
        <asp:ListItem Text="1/2 PPR" Value="Half" />
        <asp:ListItem Text="TD Only" Value="TD" />
    </asp:DropDownList>
    </div>
    <asp:GridView ID="gvRanking" runat="server" CssClass="table table-striped"
        OnRowDataBound="gvRanking_RowDataBound">
    </asp:GridView>
<script>
    //format grid
    $(document).ready(function () {
        $('td').each(function () {
            var text = parseInt($(this).text());
            if (text == 0) {
                $(this).css('background', 'DARKgray');
            } else if (0 < text && text <= 6) {
                $(this).css('background', '#cfd186');//LightGreen
            } else if (6 < text && text <= 12) {
                $(this).css('background', '#ffd868'); 
            } else if (12 < text && text <= 20) {
                $(this).css('background', '#feb72b');//yellow
            } else if (20 < text && text <= 28) {
                $(this).css('background', '#ffa34d');//orange
            } else if (28 < text && text <= 35) {
                $(this).css('background', '#f8615a');//orange darker
            } else if (35 < text && text <= 40) {
                $(this).css('background', '#b80d57');//red
            } else if (40 < text && text <= 100) {
                $(this).css('background', '#721b65').css('color', '#ff5733');
            }        
        })
        //default colors on totals column
        $('tr td:nth-last-child(3)').each(function () {
            $(this).css('background', 'white').css('color', 'black');
        })
        $('tr td:nth-last-child(2)').each(function () {
            $(this).css('background', 'white').css('color', 'black');
        })
        $('tr td:nth-last-child(1)').each(function () {
            $(this).css('background', 'white').css('color', 'black');
        })

        $('tr:eq(12)').each(function () {
            $(this).css('border-bottom', '3px solid black');
        })
        $('tr:eq(24)').each(function () {
            $(this).css('border-bottom', '3px solid black');
        })

    })
</script>
</asp:Content>
