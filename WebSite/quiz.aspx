<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="quiz.aspx.cs" Inherits="quiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentbody" Runat="Server">
    <link href="App_Themes/StyleSheet.css" rel="stylesheet" />
    <table>
        <tr>
            <asp:Label ID="Label1" runat="server" Text="Are you a student?"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </tr>

        <tr>
            <asp:Label ID="Label2" runat="server" Text="How do you usually commute?"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                <asp:ListItem>Car</asp:ListItem>
                <asp:ListItem>Bus</asp:ListItem>
                <asp:ListItem>Bike</asp:ListItem>
                <asp:ListItem>Walk</asp:ListItem>
            </asp:RadioButtonList>
        </tr>

        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" /></td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Reset" /></td>
        </tr>
    </table>
</asp:Content>

