<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FFB1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Fantasy Football Analyzer</h1>
        <p class="lead">Free web application to research and predict fantasy performance</p>
        <p><a href="About" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Teams</h2>
            <p>
                Analyze performance by team.
            </p>
            <p>
                <a class="btn btn-default" href="Teams">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Rankings</h2>
            <p>
                Analyze players by position
            </p>
            <p>
                <a class="btn btn-default" href="Rankings">Learn more &raquo;</a>
            </p>
        </div>

    </div>

</asp:Content>
