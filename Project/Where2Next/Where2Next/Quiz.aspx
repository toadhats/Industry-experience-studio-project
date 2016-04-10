<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="quiz.aspx.cs" Inherits="Where2Next.quizTest" %>


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
            <asp:Label ID="Label1" runat="server" Text="Do you have seniors in your family？ "></asp:Label>
        </tr>
        <tr>
            <asp:RadioButtonList ID="centrelinkList" runat="server" >
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </tr>

                    <tr> <tr>
            <asp:Label ID="Label2" runat="server" Text="Do you need to attend audlt education class?"></asp:Label>
        </tr>
        <tr>
            <asp:RadioButtonList ID="audlteducationList" runat="server" >
                <asp:ListItem>Yes, TOFE</asp:ListItem>
                <asp:ListItem>Yes, VEC</asp:ListItem>
                <asp:ListItem>I do not attend any class</asp:ListItem>
            </asp:RadioButtonList>
        </tr>
        </table>
    <br />
   <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Begin Now" OnClick="Button1_Click" />
    <br />
    <br />
       </div>
     <asp:Literal ID="result" runat="server"></asp:Literal>
    </asp:Content>