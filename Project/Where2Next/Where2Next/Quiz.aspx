<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Where2Next.quizTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://code.jquery.com/ui/1.10.4/jquery-ui.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

    <script
        src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
        <%--Why is this here?--%>
    </script>
    <style type="text/css" media="screen">
        .buttonDeselected {
            position: relative;
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
            margin: 8px;
            border: 3px solid #00F18A;
            border-radius: 2px;
            border-collapse: collapse;
            box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
            text-shadow: -1px -1px 0 #000, 1px -1px 0 #000, -1px 1px 0 #000, 1px 1px 0 #000;
            background-size: 100% auto;
        }
    </style>
    <div id="question" runat="server">
        <h3>Please choose the option you prefer the best:</h3>
        <br />
        <br />

        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Button Text="School" ID="schoolButton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="school" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/school.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="Centrelink" ID="centrelinkbutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="centrelink" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/centrelink.png); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="Disability Activity" ID="disabilityactivitybutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="disabilityactivity" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/disabilityactivity.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="GP Super" ID="gpsuperbutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="gpsuper" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/gpsuper.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Ice Skating" ID="iceskatingbutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="iceskating" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/iceskating.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="Library" ID="librarybutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="library" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/library.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="Medicare" ID="medicarebutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="medicare" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/medicare.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="Roller Skating" ID="rollerskatingbutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="rollerskating" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/rollerskating.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Skate Parks" ID="skateparksbutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="skateparks" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/skateparks.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="Sporting Clubs" ID="sportingclubsbutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="sportingclubsorgs" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/sportingclubs.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="Swimming Pools" ID="swimmingpoolsbutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="swimmingpools" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/swimmingpools.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
                <td>
                    <asp:Button Text="TAFE" ID="tafebutton" runat="server"
                        CssClass="buttonDeselected"
                        CommandArgument="tafe" OnClick="SelectService"
                        Style="background-image: url(Images/quizbuttonimage/tafe.jpg); background-size: 100% auto;"
                        Width="282px" Height="188px" ForeColor="#4dd0e1" Font-Size="XX-Large" Font-Bold="true" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <asp:Panel runat="server" HorizontalAlign="Center">
            <asp:Button ID="Button1" runat="server" Text="Search Now" Width="300" Height="100" Font-Size="XX-Large" Font-Bold="true" OnClick="SubmitButton" />
        </asp:Panel>
    </div>
    <asp:Literal ID="result" runat="server"></asp:Literal>
</asp:Content>
