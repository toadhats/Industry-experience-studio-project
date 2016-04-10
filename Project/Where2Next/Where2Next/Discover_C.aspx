<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discover_C.aspx.cs" Inherits="Where2Next.Discover" %>

<script language="c#" runat="server">
    private void findsuburb(object sender, EventArgs e)
    {
        Button Button1 = (Button)sender;

        //var data = getData(); // uses the function above to get a list of Service objects
        //IEnumerable<DataDigester.Service> query; // Empty containter to fill, bad practice but I don't know what to initialise it with. A List<Service> constructor???

        if (centrelinkrbl.Items[0].Selected)
        {
            if (internetrbl.Items[1].Selected) {
                //query = from DataDigester.Service service in data where service.serviceType == "centrelink" select service;
                servicesds.SelectCommand = "select * from socialservices t where t.suburb not in (select suburb from internet)";
                ResultList.DataSource = servicesds;
                ResultList.DataBind(); }
            else {
                servicesds.SelectCommand = "select * from socialservices t, internet s where t.suburb = s.suburb";
                ResultList.DataSource = servicesds;
                ResultList.DataBind();
            }

        }

        // Only one condition, use centrelinkbtl.Items[1].Selected == true if more
        // this query logic is a silly hack, we cannot implement the search this way when we have more datasets
        else if(centrelinkrbl.Items[1].Selected == true)
        {
            if (internetrbl.Items[0].Selected) {
                //query = from DataDigester.Service service in data where service.serviceType == "centrelink" select service;
                servicesds.SelectCommand = "select * from internet t where t.suburb not in (select suburb from socialservices)";
                ResultList.DataSource = servicesds;
                ResultList.DataBind();
            }
            else {
                //ignore this
                feedbackLabel.Text = "Sorry, no such suburb";
            }
            //query = from DataDigester.Service service in data where service.serviceType != "centrelink" select service;            
        }

        // bind the result of the query as the datasource for the table


        //show result panel
        ResultPanel.Visible = true;
    }
</script>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Please choose the option you prefer the best:</h3>
    <br />
    <br />

    <asp:SqlDataSource ID="servicesds" runat="server" 
        ConnectionString="<%$ ConnectionStrings:where2nextConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:where2nextConnectionString.ProviderName %>" 
        SelectCommand="SELECT * FROM socialservices, internet, postcodes_geo">
    </asp:SqlDataSource>

    <table style="width: 100%">
        <tr>
            <asp:Label ID="Label1" runat="server" Text="Do you want to live near centrelink?"></asp:Label>
        </tr>
        <tr>
            <!-- options-->
            <asp:RadioButtonList ID="centrelinkrbl" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
               
            </asp:RadioButtonList>
        </tr>


        <tr>
            <asp:Label ID="Label2" runat="server" Text="Do you want to live near a public internet?"></asp:Label>
        </tr>
        <tr>
            <!-- options-->
            <asp:RadioButtonList ID="internetrbl" runat="server">
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
                <table border="1">
                    <tr>
                        <td>
                         <b> <%# Eval("suburb") %><br /></b>
                            </td>
                        <td>
                          <%# Eval("postcode") %><br />
                            </td>
                        </tr>
                    </table>
            </ItemTemplate>
        </asp:ListView>
    </asp:Panel>
</asp:Content>
