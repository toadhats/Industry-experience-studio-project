<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="quizschool.aspx.cs" Inherits="Where2Next.quizschool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <asp:Label ID="Label1" runat="server" Text="What type of School do you need in this suburb?"></asp:Label>
            </tr>
            <tr>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        <asp:ListItem>Primary</asp:ListItem>
        <asp:ListItem>Secondary</asp:ListItem>
        <asp:ListItem>Primary/Secondary</asp:ListItem>
        <asp:ListItem>Language</asp:ListItem>
        <asp:ListItem>Don't Care about Schools</asp:ListItem>
    </asp:CheckBoxList>
                </tr>
            
            </table>
        <br />
        <br />
        <a runat="server" href="~/quizlibrary" class="button" >Next Question</a>
        </div>
</asp:Content>
