<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizResults.aspx.cs" Inherits="Where2Next.QuizResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="http://allfont.net/allfont.css?fonts=montserrat-light" rel="stylesheet" type="text/css" />

    <style type="text/css" media="screen">

        .tableHeading
        {
            font-family: 'montserrat light', montserrat, 'Helvetica Neue LT Pro', sans-serif;
            margin-bottom: 20px;
        }

        .cardContainer 
        {
            border: 3px #222222;
            background: #eeeded;
            
        }

        .resultCard
        {
            background: #fdfdfd;
            border-radius: 2px;
            border-collapse: collapse;
            box-shadow: 0 3px 6px rgba(0,0,0,0.16), 0 3px 6px rgba(0,0,0,0.23);
            display: inline-block;
            padding: 10px;
            margin: 15px;
            float: left;
            position:relative;
            width: 188px;
            height: 188px;
            font-family: 'montserrat light', montserrat, 'Helvetica Neue LT Pro', sans-serif;
            line-height: 2;
        }

        .resultCard:hover 
        {
            box-shadow: 0 10px 20px rgba(0,0,0,0.19), 0 6px 6px rgba(0,0,0,0.23);
        }

        .requestedService
        {
            font-size: small;
        }

        hr {
            display: block;
            position: relative;
            padding: 0;
            margin: 8px auto;
            height: 0;
            width: 100%;
            max-height: 0;
            font-size: 1px;
            line-height: 0;
            clear: both;
            border: none;
            border-top: 1px solid #aaaaaa;
            border-bottom: 1px solid #ffffff;
        }

        .sorryCard {
            background: #fafafa;
            width: 400px;
            height: 185px;
            padding: 20px;
        }

        .sorryCard * {
            margin: 15px;
        }

    </style>

        <asp:Literal ID="resultsTable" runat="server"></asp:Literal>

    <asp:HyperLink id="hyperlink1" NavigateUrl="/quiz.aspx" Text="Search again?"  runat="server"/> 

   

</asp:Content>
