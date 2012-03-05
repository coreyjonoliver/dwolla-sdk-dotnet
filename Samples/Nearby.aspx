<%@ Page Language="C#" AutoEventWireup="true" Inherits="Dwolla.Samples.Nearby" Codebehind="Nearby.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		The following Dwolla spots were found:
		<asp:PlaceHolder ID="nearbyHolder" runat="server" />
	</div>
	</form>
</body>
</html>
