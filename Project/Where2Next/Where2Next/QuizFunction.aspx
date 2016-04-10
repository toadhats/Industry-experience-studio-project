<%@ Page Title="QuizFunction" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizFunction.aspx.cs" Inherits="Where2Next.QuizFunction" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script
src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
</script>
   <div id="question" runat="server">
    <h3>Please choose the option you prefer the best:</h3>
    <br />
    <br />


    <table style="width: 100%">
        <tr>
            <asp:Label ID="Label1" runat="server" Text="Do you want to live near centrelink?"></asp:Label>
        </tr>
        <tr>
            <asp:RadioButtonList ID="centrelinkList" runat="server" >
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Never mind</asp:ListItem>
            </asp:RadioButtonList>
        </tr>
                    <tr>
            <asp:Label ID="Label2" runat="server" Text="Do you need to attend audlt education class?"></asp:Label>
        </tr>
        <tr>
            <asp:RadioButtonList ID="audlteducationList" runat="server" >
                <asp:ListItem>TOFE</asp:ListItem>
                <asp:ListItem>VEC</asp:ListItem>
                <asp:ListItem>I not attend any class</asp:ListItem>
            </asp:RadioButtonList>
        </tr>
                  <tr>
            <asp:Label ID="Label3" runat="server" Text="Do you have a kid? "></asp:Label>
        </tr>
        <tr>
            <asp:RadioButtonList ID="schoolList" runat="server" >
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </tr>
        </table>
    <br />
   <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Check now~" OnClick="Button1_Click" />
    <br />
    <br />
       </div>
     <asp:Literal ID="result" runat="server"></asp:Literal>
    </asp:Content>