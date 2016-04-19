<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizResults.aspx.cs" Inherits="Where2Next.QuizResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css" media="screen">

        .tableHeading
        {
            border: 3px solid blue;
        }

        .cardContainer 
        {
            border: 3px solid green;
            
        }

        .resultCard
        {
            border: 3px solid red;
            display: inline-block;
            width: 200px;
            height: 200px;
        }

    </style>

        <h1>Results</h1> <%--This should probably say something more "on brand"--%>

        <asp:Literal ID="resultsTable" runat="server"></asp:Literal>

   

</asp:Content>
