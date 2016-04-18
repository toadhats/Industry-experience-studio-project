<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="quiz.aspx.cs" Inherits="Where2Next.quizTest" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script
src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
</script>
    <style type="text/css" media="screen">

        .buttonDeselected 
        {
            border: 1px solid gray;
        }

        .buttonSelected 
        {
            border: 5px solid green;
            
        }

    </style>
   <div id="question" runat="server">
    <h3>Please choose the option you prefer the best:</h3>
    <br />
    <br />


       <table style="width: 100%">
           <tr>
              <td> <asp:Button Text="School" id="schoolButton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="school" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/school.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
           </tr>
       </table>
    <br />
   <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Search Now" OnClick="SubmitButton" />
    <br />
    <br />
       </div>
     <asp:Literal ID="result" runat="server"></asp:Literal>
    </asp:Content>