<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Where2Next._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <img src="/Images/logo-500px.png" alt="Where2next" style="height: 100px; width: auto"/>
        <p class="lead">Discover your ideal suburb</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Need a hand?</h2>
            <p>
                If you don't know where to begin, our guided search will help you to decide what's important to you, and guide you towards the perfect suburb for you
            </p>
            <p>
                <a class="btn btn-default" href="/Quiz">Discover &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>See for yourself</h2>
            <p>
                Take a look at our map and explore Melbourne on your own
            </p>
            <p>
                <a class="btn btn-default" href="/Map">Map &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Advanced Search</h2>
            <p>
                Know exactly what you're looking for? Try the advanced search tool for full access to the data we have available.
            </p>
            <p>
                <a class="btn btn-default" href="/Search">Advanced Search &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
