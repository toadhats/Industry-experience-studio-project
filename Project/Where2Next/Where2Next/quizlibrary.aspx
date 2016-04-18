<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="quizlibrary.aspx.cs" Inherits="Where2Next.quizlibrary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <table>
            <tr>
                <asp:Label ID="Label1" runat="server" Text="Would you like to live around a library?"></asp:Label>
            </tr>
            <tr>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem>Yes, I would</asp:ListItem>
                    <asp:ListItem>No, I don&#39;t like library</asp:ListItem>
                    <asp:ListItem>It doesn&#39;t matter</asp:ListItem>
                </asp:RadioButtonList>
            </tr>
        </table>
    <a runat="server" href="~/quizlibrary" class="button" >Continue</a>
    
</asp:Content>
