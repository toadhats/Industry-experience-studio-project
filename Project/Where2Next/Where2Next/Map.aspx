<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="Where2Next.Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <script src="Content/jquery.min.js"></script>
    <script src="Content/bootstrap.min.js"></script>
    <div style="text-align: center">
        <iframe runat="server" src="Mapfunction.aspx" width="1150" height="1300" frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes"></iframe>
    </div>

</asp:Content>
