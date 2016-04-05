<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>
    <script
src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Your Data on Google Map </title>
     <%--Google API reference--%>
     <script src="http://maps.google.com/maps? file=api&amp;
	v=2&amp;sensor=false&amp;key=abcdefg" type="text/javascript">
     </script>
</head><body onload="initialize()" onunload="GUnload()">
  <form id="form1" runat="server">
       <asp:Panel ID="Panel1" runat="server">
           <asp:Literal ID="js" runat="server"></asp:Literal>
           <%--Place for google to show your MAP--%>
           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
           <div id="map_canvas" style="width: 100%; height: 728px; 
		margin-bottom: 2px;">
           </div>
       </asp:Panel> 
       <asp:Button ID="Button1" runat="server" Text="Button" />
       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</form>
</body> 
</html> 
