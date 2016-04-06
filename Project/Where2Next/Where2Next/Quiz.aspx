<%@ Page Title="Quiz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Where2Next.Quiz" %>

<script language="c#" runat="server">

    public List<DataDigester.Service> getData()
    {
        var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]); // get account
        var tableClient = storageAccount.CreateCloudTableClient(); // get client referring to account
        var table = tableClient.GetTableReference("Services"); // get table out of account
        var query = new Microsoft.WindowsAzure.Storage.Table.TableQuery<DataDigester.Service>().Where(Microsoft.WindowsAzure.Storage.Table.TableQuery.GenerateFilterCondition("PartitionKey", Microsoft.WindowsAzure.Storage.Table.QueryComparisons.Equal, "centrelink")); // query to get all centrelink data. It cannot work this way in the next version but I will submit for now, since it sort of works.
        var data = table.ExecuteQuery(query).ToList<DataDigester.Service>(); // execute the query and store the result in a variable
        return data;
    }

    private void findsuburb(object sender, EventArgs e)
    {
        Button Button1 = (Button)sender;

        var data = getData(); // uses the function above to get a list of Service objects
        IEnumerable<DataDigester.Service> query; // Empty containter to fill, bad practice but I don't know what to initialise it with. A List<Service> constructor???

        if (centrelinkbtl.Items[0].Selected == true)
        {
            query = from DataDigester.Service service in data where service.serviceType == "centrelink" select service;
        }

        // Only one condition, use centrelinkbtl.Items[1].Selected == true if more
        // this query logic is a silly hack, we cannot implement the search this way when we have more datasets
        else {
            query = from DataDigester.Service service in data where service.serviceType != "centrelink" select service;
            feedbackLabel.Text = "Sorry, there is not a suggested suburb....";
        }

        // bind the result of the query as the datasource for the table
        ResultList.DataSource = query;
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

<%--    <asp:SqlDataSource ID="centrelinkds" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
        SelectCommand="SELECT * FROM [CentreLink]"></asp:SqlDataSource>--%>

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
