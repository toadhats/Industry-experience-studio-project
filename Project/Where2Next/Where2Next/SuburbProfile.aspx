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

        #custom-search-input {
            margin: 0;
            margin-top: 10px;
            padding: 0;
        }

            #custom-search-input .search-query {
                padding-right: 3px;
                padding-right: 4px \9;
                padding-left: 3px;
                padding-left: 4px \9;
                /* IE7-8 doesn't have border-radius, so don't indent the padding */
                margin-bottom: 0;
                -webkit-border-radius: 3px;
                -moz-border-radius: 3px;
                border-radius: 3px;
            }

            #custom-search-input button {
                border: 0;
                background: none;
                /** belows styles are working good */
                padding: 2px 5px;
                margin-top: 2px;
                position: relative;
                left: -28px;
                /* IE7-8 doesn't have border-radius, so don't indent the padding */
                margin-bottom: 0;
                -webkit-border-radius: 3px;
                -moz-border-radius: 3px;
                border-radius: 3px;
                color: #D9230F;
            }

        .search-query:focus + button {
            z-index: 3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--Search bar--%>
    <div class="container">
        <div class="row">
            <div id="custom-search-input">
                <div class="input-group col-md-12">
                    <input type="text" class="search-query form-control" placeholder="Search" />
                    <span class="input-group-btn">
                        <button class="btn btn-info" type="button">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="profileCard" CssClass="profileCard" runat="server" HorizontalAlign="Center" ScrollBars="Auto" Wrap="false">
        <%--Mostly everything's getting injected into here programmatically--%>
    </asp:Panel>
</asp:Content>
