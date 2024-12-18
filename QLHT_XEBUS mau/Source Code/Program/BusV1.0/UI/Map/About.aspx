<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="UI_Map_About" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site1.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="~/Styles/jquery-ui-1.8.18.custom.css" rel="stylesheet" />	
		<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
		<script type="text/javascript" src="js/jquery-ui-1.8.18.custom.min.js"></script>
       <script type="text/javascript">
           $(function () {

               // Tabs
               //$('#tabs').tabs();
               $('#tabs').bind('tabsselect', function (event, ui) {
                   var selectedTab = ui.index;
                   //alert(selectedTab);
                   $("#<%= hidLastTab.ClientID %>").val(selectedTab);
               });

           });
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header1">
        <div class="logo">
            <div class="logo_icon"></div>
         </div>
    </div>
    <asp:HiddenField ID="hidLastTab" runat="server" Value="0" />
     <div id="tabs">
	    <ul>
		    <li><a href="#tabs-1">Tìm tuyến xe</a></li>
		    <li><a href="#tabs-2">Tra cứu bãi đỗ</a></li>
            <li><a href="#tabs-4">Tra cứu tuyến phố</a></li>
            <li><a href="#tabs-5">Điểm bán vé</a></li>
	    </ul>
     </div>
    </form>
</body>
</html>
