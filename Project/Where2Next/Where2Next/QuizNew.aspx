<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizNew.aspx.cs" Inherits="Where2Next.QuizNew" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script runat="server">
        private void imageClick(object sender, EventArgs e) {

        }
    </script>
    <div>
        
        <table id="table1" runat="server" >
            <tr>
                <td>
                    <asp:ImageButton ID="HealthIB" runat="server" ImageUrl="~/Images/Healthcare1.jpg" Height="300px" Width="400px" CommandArgument="" OnClick="imageClick" />
                </td>
                <td>
                    <asp:ImageButton ID="HigherEducationIB" runat="server" ImageUrl="~/Images/Higheducation.jpg" Height="300px" Width="400px" OnClick="imageClick" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="SchoolIB" runat="server" ImageUrl="~/Images/school.jpg" Height="300px" Width="400px" OnClick="imageClick" />
                </td>
                <td>
                    <asp:ImageButton ID="LibraryIB" runat="server" ImageUrl="~/Images/library.jpg" Height="300px" Width="400px" OnClick="imageClick" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="ServicesIB" runat="server" ImageUrl="~/Images/medicare.jpg" Height="300px" Width="400px" OnClick="imageClick" />
                </td>
                <td>
                    <asp:ImageButton ID="SportIB" runat="server" ImageUrl="~/Images/sport.jpg" Height="300px" Width="400px" OnClick="imageClick" />
                </td>
            </tr>
        </table>
        </div>
   
    <asp:Literal ID="result" runat="server"></asp:Literal>

</asp:Content>
