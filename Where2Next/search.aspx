<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentbody" Runat="Server">
    <asp:Label ID="Label2" runat="server" Text="Enter the postcode:"></asp:Label><br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
    <br />
    <asp:Label ID="Label1" runat="server" Text="Choose the suburb:"></asp:Label> <br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Clayton</asp:ListItem>
        <asp:ListItem>Caulfield</asp:ListItem>
    </asp:DropDownList> <br />
    <asp:Button ID="Button1" runat="server" Text="Search" /> 
</asp:Content>

