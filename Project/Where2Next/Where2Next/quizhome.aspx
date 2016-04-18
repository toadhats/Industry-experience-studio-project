<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="quizhome.aspx.cs" Inherits="Where2Next.quizhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="Label1" runat="server" Text="Welcome! From this page, we will help you discover which suburb is the best suitable for you!"></asp:Label><br />
    <br />
    <br />
    <img src="Images/letsmoveto.png" /> <br />
    <br />
    <br />
    <a runat="server" href="~/quizschool" class="button" >Let's Start!</a>
</asp:Content>
