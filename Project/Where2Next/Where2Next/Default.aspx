<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Where2Next._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="banner-wrapper">
        <div id="banner" class="container">
            <div class="title">
                <h2>Consectetuer adipiscing elit</h2>
                <span class="byline">Donec pulvinar ullamcorper metus</span>
            </div>
            <ul class="actions">
                <li><a runat="server" href="~/Quiz" class="button">Start Here!</a></li>
            </ul>
        </div>
    </div>

    <div id="wrapper">
        <div id="three-column" class="container">

            <div class="title">
                <h2></h2>
                <span class="byline"></span>
            </div>
            <div class="boxA">
                <h2>Need a hand?</h2>
                <p>If you're not sure where to start, our guided search will help you to decide what's important.</p>
                <a href="/Quiz" class="button button-alt">Discover &raquo;</a>
            </div>
            <div class="boxB">
                <h2>See for yourself</h2>
                <p>Want to look at the bigger picture? Take a look at our map and explore Melbourne on your own.</p>
                <a href="/Map" class="button button-alt">Map &raquo;</a>
            </div>
            <div class="boxC">
                <h2>Suburb Profiles</h2>
                <p>Browse our data and get to know the suburbs in Victoria.</p>
                <a href="/Profile" class="button button-alt">Profiles &raquo;</a>
            </div>
        </div>
    </div>

</asp:Content>
