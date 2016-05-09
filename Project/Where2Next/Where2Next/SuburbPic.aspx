<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuburbPic.aspx.cs" Inherits="Where2Next.WebForm1" %>

<!DOCTYPE html>
<script
    src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
</script>
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
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="SQL server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="cleanDB" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="VM　　　" Width="26px" />
        <br />
        <br />
        VM and cleanDB can test the connection not for the map<br />
        <br />
        <br />
        <asp:Literal ID="js" runat="server"></asp:Literal>
    <div id="map_canvas" style="background-color: #EEEEEE; height: 1000px; width: 900px; float: left;">
            </div>
        <br />
        <br />
        <br />
&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    
    </div>

    </form>
</body>
</html>
