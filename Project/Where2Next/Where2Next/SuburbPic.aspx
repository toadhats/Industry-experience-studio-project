<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuburbPic.aspx.cs" Inherits="Where2Next.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        Please enter your suburb name:<br />
        <br />
        <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:Literal ID="js" runat="server"></asp:Literal>
    
    </div>
    </form>
</body>
</html>
