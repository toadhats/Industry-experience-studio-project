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
            padding: 10px;
            display: inline-block;
            width: auto;
            float: left;
        }

            .serviceTable tr {
                padding: 5px;
            }

            .serviceTable td {
                padding: 15px;
            }

        .suburbPic {
            display: inline-block;
            float: right;
            max-width: 38%;
            height: auto;
            padding: 6px;
            box-shadow: 0 3px 6px rgba(0,0,0,0.16), 0 3px 6px rgba(0,0,0,0.23);
        }

        .priceCard {
            display: inline-block;
            float: right;
            max-width: 38%;
            padding: 6px;
            margin-top: 32px;
            
        }

        .priceCard p {
            float: left;
            text-align: start;
            font-family: Montserrat, 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


        <asp:Panel ID="profileCard" CssClass="profileCard" runat="server" HorizontalAlign="Center" ScrollBars="Auto" Wrap="false">
            <%--Mostly everything's getting injected into here programmatically--%>
        </asp:Panel>
</asp:Content>
