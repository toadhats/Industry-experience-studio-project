<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizCategories.aspx.cs" Inherits="Where2Next.QuizCategories" %>

<asp:Content ContentPlaceHolderID="extraHeadContent" runat="server">

    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <script src="Content/jquery.min.js"></script>
    <script src="Content/bootstrap.min.js"></script>

    <%--We should move this to a real CSS file--%>
    <style type="text/css" media="screen">
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

        .buttonDeselected {
            position: relative;
            float: left;
            margin: 8px;
            border: 1px solid gray;
            border-radius: 2px;
            border-collapse: collapse;
            box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
            transition: all 0.2s ease-in-out;
            text-shadow: -1px -1px 0 #000, 1px -1px 0 #000, -1px 1px 0 #000, 1px 1px 0 #000;
            background-size: 100% auto;
        }

            .buttonDeselected:hover {
                box-shadow: 0 10px 20px rgba(0,0,0,0.19), 0 6px 6px rgba(0,0,0,0.23);
            }

        .buttonSelected {
            position: relative;
            float: left;
            margin: 8px;
            border: 3px solid #00F18A;
            border-radius: 2px;
            border-collapse: collapse;
            box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
            text-shadow: -1px -1px 0 #000, 1px -1px 0 #000, -1px 1px 0 #000, 1px 1px 0 #000;
            background-size: 100% auto;
        }

        .tableHeading {
            font-family: 'montserrat light', montserrat, 'Helvetica Neue LT Pro', sans-serif;
            margin-bottom: 5px;
        }

        .cardContainer {
            border: 3px #222222;
            background: #eeeded;
            width: auto;
            height: auto;
            float: left;
            display: inline-block;
        }

        .categoryCard {
            background: #fdfdfd;
            border-radius: 2px;
            border-collapse: collapse;
            box-shadow: 0 3px 6px rgba(0,0,0,0.16), 0 3px 6px rgba(0,0,0,0.23);
            display: inline-block;
            position: relative;
            padding: 16px;
            margin: 16px;
            float: left;
            width: 188px;
            height: 188px;
        }

            .categoryCard:hover {
                box-shadow: 0 10px 20px rgba(0,0,0,0.19), 0 6px 6px rgba(0,0,0,0.23);
            }

            .categoryCard h4 {
                font-family: 'montserrat light', montserrat, 'Helvetica Neue LT Pro', sans-serif;
                text-align: left;
            }

            .categoryCard img {
                width: 95%;
                height: auto;
                display: inline-block;
                object-fit: contain;
            }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="tableHeading">Select the categories you're interested in:</h1>
    <div id="categories" runat="server" class="cardContainer">
        <div id="cat_education" runat="server" class="categoryCard">
            <h4>Education</h4>
            <hr />
            <img src="Images/quizCategories/school.jpg" alt="education" />
        </div>

        <asp:Literal ID="displayCategories" runat="server" />
    </div>
</asp:Content>
