<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuburbProfile.aspx.cs" Inherits="Where2Next.SuburbProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="extraHeadContent" runat="server">

    <link href='http://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,800italic,700italic,600italic,400italic,300italic,800,700,600' rel='stylesheet' type='text/css'>

    <link href="Content/css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="Content/css/style.css" rel="stylesheet" type="text/css">
    <link href="Content/css/font-awesome.css" rel="stylesheet" type="text/css">
    <link href="Content/css/responsive.css" rel="stylesheet" type="text/css">
    <link href="Content/css/animate.css" rel="stylesheet" type="text/css">

    <script type="text/javascript" src="Scripts/js/jquery.1.8.3.min.js"></script>
    <script type="text/javascript" src="Scripts/js/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/js/jquery-scrolltofixed.js"></script>
    <script type="text/javascript" src="Scripts/js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="Scripts/js/jquery.isotope.js"></script>
    <script type="text/javascript" src="Scripts/js/wow.js"></script>
    <script type="text/javascript" src="Scripts/js/classie.js"></script>

    <style>
        .serviceTable {
            padding: "10px";
        }
        .serviceTable tr {
            padding: "5px";
        }

        .serviceTable td {
            padding: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="profileCard" CssClass="profileCard" runat="server" HorizontalAlign="Center" ScrollBars="Auto" Wrap="false">
            <%--Mostly everything's getting injected into here programmatically--%>
        </asp:Panel>
</asp:Content>
