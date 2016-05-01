<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuburbPic.aspx.cs" Inherits="Where2Next.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="Content/bootstrap.min.css" rel="stylesheet">
    <script src="Content/jquery.min.js"></script>
    <script src="Content/bootstrap.min.js"></script>
    <title></title>
</head>

<body>
     <div class="modal fade" id="myModal" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true" style="position: absolute; top: 50%; height: 240px; margin-top: -120px;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    </button>
                </div>
                <div class="modal-body">
                    Thanks for voting.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default"
                        data-dismiss="modal">
                        Close
                    </button>
                </div>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
    <div>
    
        <br />
        Please enter your suburb name:<br />
        <br />
        <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search Now" />
        <br />
        <br />
        <br />
        <asp:Literal ID="js" runat="server"></asp:Literal>
    
    </div>

    </form>
</body>
</html>
