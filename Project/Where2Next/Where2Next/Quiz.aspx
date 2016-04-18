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
              <td> <asp:Button Text="School" runat="server" CommandArgument="school" OnClick="SelectService" /></td>
           </tr>
       </table>
    <br />
   <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Search Now" OnClick="SubmitButton" />
    <br />
    <br />
       </div>
     <asp:Literal ID="result" runat="server"></asp:Literal>
    </asp:Content>