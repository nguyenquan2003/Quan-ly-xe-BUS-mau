<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistoryGPS.aspx.cs" Inherits="UI_Map_HistoryGPS" EnableEventValidation="false" %>
<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bản đồ xe Buýt</title>
    <link href="~/Styles/Copy of Site1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function keypress(e) {
            //Hàm dùng để ngăn người dùng nhập các ký tự khác ký tự số vào TextBox
            var keypressed = null;

            if (window.event) {
                keypressed = window.event.keyCode; //IE
            }
            else {
                keypressed = e.which; //NON-IE, Standard
            }

            if (keypressed < 48 || keypressed > 57) { //CharCode của 0 là 48 (Theo bảng mã ASCII)
                //CharCode của 9 là 57 (Theo bảng mã ASCII)

                if (keypressed == 8 || keypressed == 127) {//Phím Delete và Phím Back
                    return;
                }

                return false;
            }

        }
</script>
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
                <li> <a href="AdminGPSRealTime.aspx">Giám sát</a></li>
                <li ><a href="HistoryGPS.aspx" title="" id="current">Báo cáo lịch sử</a></li>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div style="margin-left:5px; font-size:16px;margin-top:10px; color:Black; font-weight:bold;" >
                Chọn tuyến xe: <asp:DropDownList ID="drlBusLine" 
                            runat="server" Width="220px" BackColor="#99CCFF" AutoPostBack="True" 
                         onselectedindexchanged="drlBusLine_SelectedIndexChanged">
                     </asp:DropDownList>
            </div>
                 <div style="margin-left:5px; font-size:16px; color:Black;margin-top:10px; height: 35px;font-weight:bold;">
                     Chọn xe:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="drlBus" 
                        runat="server" Width="220px" BackColor="#99CCFF" >
                 </asp:DropDownList>
                 </div>
                <div style="margin-left:5px; font-size:16px; color:Black;margin-top:0px; height: 35px;font-weight:bold;" >Thời gian bắt đầu (ngày/tháng/năm/giờ:phút: giây):</div>
                 <div style="margin-left:0px; width:340px;" >
                     <table style="width: 100%;">
                         <tr>
                             <td>
                                &nbsp; <asp:DropDownList ID="drlStartDate" runat="server" Width="55px">
                                 </asp:DropDownList> &nbsp;&nbsp;&nbsp; / 
                             </td>
                             <td>
                                &nbsp; <asp:DropDownList ID="drlStartMonth" runat="server" Width="55px">
                                 </asp:DropDownList> &nbsp;&nbsp;&nbsp;/ 
                             </td>
                             <td>
                                &nbsp; <asp:DropDownList ID="drlStartYear" runat="server" Width="55px">
                                 </asp:DropDownList>
                             </td>
                            
                         </tr>
                         <tr>
                             <td>
                                 &nbsp; <asp:TextBox ID="txtStartHour" runat="server" Width="50px" onkeypress="return keypress(event);" Text="0"></asp:TextBox>
                                 <asp:Label ID="lbStarHour" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                &nbsp;&nbsp;:
                                 </td>
                            <td>
                                &nbsp; <asp:TextBox ID="txtStartMinute" runat="server" Width="50px" onkeypress="return keypress(event);">0</asp:TextBox>
                                <asp:Label ID="lbStartMinute" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                &nbsp;&nbsp;:
                            </td>
                            <td>
                                &nbsp; <asp:TextBox ID="txtStartSecond" runat="server" Width="50px" onkeypress="return keypress(event);">0</asp:TextBox>
                                <asp:Label ID="lbStartSecond" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                         </tr>
                         
                     </table>
                 </div>
                <asp:Label ID="lbHienThiStart" runat="server" 
                    Text="Thời gian bắt đầu không đúng, xin chọn lại" Font-Italic="True" Visible="false"
                    ForeColor="Red"></asp:Label><br />
                     <div style="margin-left:5px; font-size:16px; color:Black;margin-top:0px; height: 35px;font-weight:bold;" >Thời gian đến (ngày /tháng /năm /giờ: phút: giây):</div>
                 <div style="margin-left:0px; width:340px;" >
                     <table style="width: 100%;">
                         <tr>
                             <td>
                                &nbsp; <asp:DropDownList ID="drlEndDate" runat="server" Width="55px">
                                 </asp:DropDownList> &nbsp;&nbsp;&nbsp; / 
                             </td>
                             <td>
                                &nbsp; <asp:DropDownList ID="drlEndMonth" runat="server" Width="55px">
                                 </asp:DropDownList> &nbsp;&nbsp;&nbsp;/ 
                             </td>
                             <td>
                                &nbsp; <asp:DropDownList ID="drlEndYear" runat="server" Width="55px">
                                 </asp:DropDownList>
                             </td>
                            
                         </tr>
                         <tr>
                             <td>
                                &nbsp;  <asp:TextBox ID="txtEndHour" runat="server" Width="50px" onkeypress="return keypress(event);">0</asp:TextBox>
                                 <asp:Label ID="lbEndHour" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                 </td>
                            <td>
                                &nbsp;  <asp:TextBox ID="txtEndMinute" runat="server" Width="50px" onkeypress="return keypress(event);">0</asp:TextBox>
                                <asp:Label ID="lbEndMinute" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                            <td>
                                &nbsp;  <asp:TextBox ID="txtEndSecond" runat="server" Width="50px" onkeypress="return keypress(event);">0</asp:TextBox>
                                <asp:Label ID="lbEndsecond" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                
                            </td>
                         </tr>
                         
                     </table>
                 </div>
                 <asp:Label ID="lbHienThiEnd" runat="server" 
                    Text="Thời gian đến không đúng, xin chọn lại" Font-Italic="True" Visible="false"
                    ForeColor="Red"></asp:Label><br />
                    
                <div style="margin-left:100px;">
                    <asp:Button ID="btnHistory" runat="server" Text="Xem lịch sử" 
                        onclick="btnHistory_Click" />
                </div>
                <asp:Label ID="lbDate" runat="server" Font-Italic="True" 
                    ForeColor="Red" Visible = "false"></asp:Label>
                <div>
                    <asp:GridView ID="grvGPSHistory" runat="server" AutoGenerateColumns="False" 
                        Width="345px" AllowPaging="True" 
                        onpageindexchanging="grvGPSHistory_PageIndexChanging" 
                        onrowdatabound="grvGPSHistory_RowDataBound" PageSize="6" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        onselectedindexchanged="grvGPSHistory_SelectedIndexChanged" >
                        <Columns>
                            <asp:BoundField DataField="Time" HeaderText="Thời gian" />
                            <asp:BoundField DataField="Latitude" HeaderText="Vĩ độ" />
                            <asp:BoundField DataField="Longitude" HeaderText="Kinh độ" />
                            <asp:BoundField DataField="Speed" HeaderText="Tốc độ" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
                <asp:Button ID="btnAllHistory" runat="server" Text="Xem toàn bộ" Visible="false" onclick="btnAllHistory_click" /><asp:Label
                    ID="lbCount" runat="server" Text="0" Visible ="false"></asp:Label>
                </ContentTemplate>
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