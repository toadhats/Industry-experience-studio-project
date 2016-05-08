<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizServices.aspx.cs" Inherits="Where2Next.QuizServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="extraHeadContent" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <script src="Content/jquery.min.js"></script>
    <script src="Content/bootstrap.min.js"></script>
    <link href="Content/css/quiz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="tableHeading">Select the specific services you're interested in:</h1>
    <div id="categories" runat="server" class="cardContainer">
        <asp:PlaceHolder ID="displayServices" runat="server" />
    </div>
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Button ID="Button1" runat="server" Text="Search Now" Width="300" Height="100" Font-Size="XX-Large" Font-Bold="true" OnClick="SubmitButton" />
    </asp:Panel>
</asp:Content>
