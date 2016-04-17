<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizTest.aspx.cs" Inherits="Where2Next.QuizTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script runat="server">
        private void imageClick(object sender, EventArgs e) {

        }
    </script>
    <div>
        <asp:CheckBoxList ID="x" runat="server">
  <asp:ListItem Text="<img src='Images/school.jpg' /> "></asp:ListItem>
  <asp:ListItem Text="<img src='Images/library.jpg' /> "></asp:ListItem>
</asp:CheckBoxList>
    </div>

    <div>
        <a>
            <img width="200" height="150" title="School" class="pic" alt="School" src="Images/school.jpg">
            </a>
        <a>
            <label>
            <input name="search school" onclick="imageclick" type="checkbox"   >
                School
                </label>
        </a>
            </div>
</asp:Content>
