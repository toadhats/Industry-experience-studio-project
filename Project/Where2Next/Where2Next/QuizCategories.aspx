<%@ Page Title="Where2Next - Discover" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizCategories.aspx.cs" Inherits="Where2Next.QuizCategories" %>

<asp:Content ContentPlaceHolderID="extraHeadContent" runat="server">

    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <script src="Content/jquery.min.js"></script>
    <script src="Content/bootstrap.min.js"></script>
    <link href="Content/css/quiz.css" rel="stylesheet" />
    <%--New unified css file for quiz, finally. Please don't move it lol--%>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="tableHeading">Select the categories you're interested in:</h1>
    <div id="categories" runat="server" class="cardContainer">
        <asp:PlaceHolder ID="displayCategories" runat="server" />
    </div>
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Button ID="Button1" runat="server" Text="Search Now" Width="300" Height="100" Font-Size="XX-Large" Font-Bold="true" OnClick="NextButton" />
    </asp:Panel>
</asp:Content>
