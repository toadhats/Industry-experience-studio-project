<%@ Page Title="Quiz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Where2Next.Quiz" %>

<script language="c#" runat="server">
    private void findsuburb(object sender, EventArgs e)
    {
        Button Button1 = (Button)sender;

        if (centrelinkbtl.Items[0].Selected == true)
        {
            centrelinkds.SelectCommand = "SELECT suburb FROM CentreLink WHERE serviceType= 'centrelink'";
        }

        // Only one condition, use centrelinkbtl.Items[1].Selected == true if more
        else {
            centrelinkds.SelectCommand = "SELECT suburb FROM CentreLink WHERE serviceType <> 'centrelink'";
        }

        ResultList.DataSource = centrelinkds;
        ResultList.DataBind();

        //show result panel
        ResultPanel.Visible = true;
    }
</script>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Please choose the option you prefer the best:</h3>
    <br />
    <br />

    <asp:SqlDataSource ID="centrelinkds" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
        SelectCommand="SELECT * FROM [CentreLink]"></asp:SqlDataSource>

    <table style="width: 100%">
        <tr>
            <asp:Label ID="Label1" runat="server" Text="Do you want to live near centrelink?"></asp:Label>
        </tr>
        <tr>
            <!-- options-->
            <asp:RadioButtonList ID="centrelinkbtl" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </tr>
        <tr>

            <!--submit button-->
            <asp:Button ID="Button1" runat="server" Text="Find" OnClick="findsuburb" />
        </tr>
    </table>
    <br />
    <br />

    <!--rusult panel-->
    <asp:Panel ID="ResultPanel" Visible="false" runat="server">
        <asp:Label ID="feedbackLabel" runat="server" Text="The suburb you may choose:"></asp:Label> <br />
        <asp:ListView ID="ResultList" runat="server">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                         <b> <%# Eval("suburb") %><br /></b>
                            </td>
                        </tr>
                    </table>
            </ItemTemplate>
        </asp:ListView>
    </asp:Panel>

</asp:Content>
