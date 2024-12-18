<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminGPSRealTime.aspx.cs" Inherits="AdminGPSRealTime" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bản đồ xe Buýt</title>
    <link href="~/Styles/Copy of Site1.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <div class="logo">
            <div class="logo_icon" style="float:right;margin-right:20px;">
                <asp:Label ID="lbAdmin" runat="server" Text="Hello" ForeColor="Blue"></asp:Label></div>
            <%--<div class="logo_text">Hệ thống giám sát và quản lý Xe Buýt Hà Nội</div>--%>
        </div>
        <div class="menuHeader" >
            <ul id="menu">
                <li ><a href="BusMap.aspx">Trang chủ</a></li>
                <li> <a href="AdminGPSRealTime.aspx" id="current">Giám sát</a></li>
                <li ><a href="HistoryGPS.aspx" title="">Báo cáo lịch sử</a></li>
                <li ><a href="" title="">Quản lý tuyến xe</a>
                    <ul>
                        <li ><a href="BusLineManagement.aspx" id="A1">Thêm mới tuyến xe</a></li>
					    <li ><a href="EditBusLine.aspx" id="A2">Chỉnh sửa tuyến xe</a></li>
					    <li><a href="DeleteBusLine.aspx">Xóa tuyến xe</a></li>
                    </ul>   
                </li>
                <li ><a href="" title="" >Quản lý bãi đỗ</a>
                    <ul>
					    <li ><a href="BusParkManagement.aspx" id="h1">Thêm mới bãi đỗ</a></li>
					    <li ><a href="EditBusParkManagement.aspx" id="h2">Chỉnh sửa bãi đỗ</a></li>
					    <li><a href="DeleteBusPark.aspx">Xóa bãi đỗ</a></li>
			        </ul>
                </li>
                <li><a href="" title="" >Quản lý điểm bán vé</a>
                    <ul>
					    <li ><a href="TicketManagement.aspx" >Thêm mới điểm bán vé</a></li>
					    <li ><a href="EditTicketManagement.aspx" >Chỉnh sửa điểm bán vé</a></li>
					    <li><a href="DeleteTicketPark.aspx">Xóa điểm bán vé</a></li>
			        </ul>
                </li>
                <li><a href="" title="" >Quản lý người dùng</a>
                    <ul>
					    <li ><a href="UserManagement.aspx" >Thêm mới người dùng</a></li>
					    <li ><a href="EditUserManagement.aspx" >Chỉnh sửa người dùng</a></li>
					    <li><a href="DeleteUser.aspx">Xóa người dùng</a></li>
			        </ul>
                </li>
            </ul>
        </div>
    </div>
    <div class ="content1">
        <div class="content_left1">
        <div id="BusMap">
                 <div style="margin-left:5px; font-size:18px; color:Black;margin-top:10px; height: 35px;font-weight:bold;" >Tuyến xe buýt:</div>
                 <div style="margin-left:50px; height: 35px" ><asp:DropDownList ID="drlBusLine" 
                            runat="server" Width="250px" BackColor="#99CCFF" AutoPostBack="True" 
                         onselectedindexchanged="drlBusLine_SelectedIndexChanged">
                     </asp:DropDownList></div>
                 <div style="margin-left:5px; font-size:18px; color:Black;margin-top:10px; height: 35px";>
                    <b>Chọn xe: </b>
                 </div>  
             
                 <div style="margin-left:50px; height: 35px" ><asp:DropDownList ID="drlBus" 
                        runat="server" Width="250px" BackColor="#99CCFF" 
                         onselectedindexchanged="drlBus_SelectedIndexChanged">
                 </asp:DropDownList></div>
            
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
           
             <div style="margin-left:80px; height: 35px" >
                 <asp:Button ID="btnTracking" runat="server" Text="Theo dõi" 
                     onclick="btnTracking_Click" ForeColor="Blue" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnStop" runat="server" Text="Dừng lại" 
                     onclick="btnStop_Click" ForeColor="Red" />   
                 </div>
                 <asp:Label ID="lbInfo" runat="server" Font-Italic="True" ForeColor="#999966"></asp:Label><br />
                <b>Đang theo dõi xe: </b><asp:Label ID="lblBusID" runat="server" Text=""></asp:Label><br />
                <b>Tung độ: </b><asp:Label ID="lbLatitude" runat="server" Text=""></asp:Label><br />
                <b>Vĩ độ: </b><asp:Label ID="lbLongitude" runat="server" Text=""></asp:Label><br />
                <b>Tốc độ: </b><asp:Label ID="lbSpeed" runat="server" Text=""></asp:Label><br />
                
                <b>Thời gian: </b><asp:Label ID="lbTime" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Timer ID="timeGps" runat="server" Interval="1000" ontick="timeGps_Tick" >
                </asp:Timer>
            </ContentTemplate>
            <Triggers>
              <asp:AsyncPostBackTrigger ControlID="timeGps" EventName="Tick" />
            </Triggers>
            </asp:UpdatePanel>
         </div> 
        </div>
        <div class="content_right1">
            <div class="map">
                   
                <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
                   
                </div>
        </div>
        <div class="footerline"></div>
    </div>
    <div class="footer">
        Copyright © 2012 SEBK - HUT<br />
	        <span class="bgfooter"><a href="http://www.hut.edu.vn" target="_blank">Ha Noi University Of Technology</a></span><br />
    </div>
    </form>
</body>
</html>
