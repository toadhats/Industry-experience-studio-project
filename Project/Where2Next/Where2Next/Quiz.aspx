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
               <td> <asp:Button Text="Centrelink" id="centrelinkbutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="centrelink" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/centrelink.png); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
               <td> <asp:Button Text="Disability Activity" id="disabilityactivitybutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="disabilityactivity" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/disabilityactivity.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
               <td> <asp:Button Text="GP Super" id="gpsuperbutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="gpsuper" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/gpsuper.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
           </tr>
           <tr>
               <td> <asp:Button Text="Ice Skating" id="iceskatingbutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="iceskating" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/iceskating.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
               <td> <asp:Button Text="Library" id="librarybutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="library" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/library.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
               <td> <asp:Button Text="Medicare" id="medicarebutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="medicare" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/medicare.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
               <td> <asp:Button Text="Roller Skating" id="rollerskatingbutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="rollerskating" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/rollerskating.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
           </tr>
           <tr>
               <td> <asp:Button Text="Skate Parks" id="skateparksbutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="skateparks" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/skateparks.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
               <td> <asp:Button Text="Sporting Clubs" id="sportingclubsbutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="sportingclubs" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/sportingclubs.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
               <td> <asp:Button Text="Swimming Pools" id="swimmingpoolsbutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="swimmingpools" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/swimmingpools.jpg); background-size:contain"  
                  Width="300px" Height="200px" ForeColor="Yellow" Font-Size="XX-Large" Font-Bold="true"/>
              </td>
               <td> <asp:Button Text="TAFE" id="tafebutton" runat="server" 
                  CssClass="buttonDeselected" 
                  CommandArgument="tafe" OnClick="SelectService" 
                  Style="background-image:url(Images/quizbuttonimage/tafe.jpg); background-size:contain"  
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