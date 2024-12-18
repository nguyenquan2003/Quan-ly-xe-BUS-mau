<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteBusPark.aspx.cs" Inherits="UI_Map_Images_DeleteBusPark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý bãi đỗ xe</title>
    <link href="~/Styles/Copy of Site1.css" rel="stylesheet" type="text/css" />
    <script language='JavaScript' type='text/javascript'>
         function DeleteConfirm() {
             return confirm('Bạn có chắc chắn muốn xóa không?');
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <div class="logo">
           <div class="logo_icon" style="float:right;margin-rigth:20px;">
                <asp:Label ID="lbAdmin" runat="server" Text="Hello" ForeColor="Blue"></asp:Label></div>
            <%--<div class="logo_text">Hệ thống giám sát và quản lý Xe Buýt Hà Nội</div>--%>
        </div>
        <div class="menuHeader">
             <ul id="menu">
                <li ><a href="BusMap.aspx">Trang chủ</a></li>
                <li> <a href="AdminGPSRealTime.aspx">Giám sát</a></li>
                <li ><a href="HistoryGPS.aspx" title="">Báo cáo lịch sử</a></li>
                <li ><a href="" title="">Quản lý tuyến xe</a>
                    <ul>
                        <li ><a href="BusLineManagement.aspx" id="A1">Thêm mới tuyến xe</a></li>
					    <li ><a href="EditBusLine.aspx" id="A2">Chỉnh sửa tuyến xe</a></li>
					    <li><a href="DeleteBusLine.aspx">Xóa tuyến xe</a></li>
                    </ul>   
                </li>
                <li ><a href="" title=""  id="current" >Quản lý bãi đỗ</a>
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

    <div class ="content2">
        <div style="margin-left:300px;"><br />
            <div style="font-weight:bold;color:Orange; font-size:20px;margin-top:0px;margin-left:150px;"> Xóa Bãi Đỗ Xe Buýt </div>
            <div style="margin-left:30px;margin-top:10px;"> Chọn bãi đỗ xe muốn xóa, rồi ấn nút 
                &#39;Xóa bỏ &#39;để xóa thông tin ra khỏi cơ sở dữ liệu.<br /><br />
                <asp:GridView ID="grvBusPark" runat="server" AutoGenerateColumns="False" 
                    Width="455px" AllowPaging="True" 
                     PageSize="15" onpageindexchanging="grvBusPark_PageIndexChanging" 
                    onrowdatabound="grvBusPark_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="IDBusPark" HeaderText="Mã bãi đỗ">
                        <ControlStyle Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Tên bãi đỗ xe" />
                        <asp:TemplateField HeaderText="Chọn">
                        <ItemTemplate>
                            <asp:CheckBox ID="ckDelete" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="margin-left:50px;margin-top:10px;"><asp:Label ID="lbThongBao" runat="server" 
                        ForeColor="Red" Visible="false"></asp:Label></div>
            <div style="margin-left:50px;margin-top:10px;"><asp:Label ID="lbKetQua" runat="server" 
                        ForeColor="Blue" Visible="false"></asp:Label></div>
            <div style="margin-left:200px;margin-top:10px;">
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa bỏ" Width="67px" 
                        onclick="btnDelete_Click" OnClientClick="return DeleteConfirm()" />
        </div>
        </div>
    </div>
    <div class="footerline"></div>
        <div class="footer">
        Copyright © 2012 SEBK - HUT<br />
	        <span class="bgfooter"><a href="http://www.hut.edu.vn" target="_blank">Ha Noi University Of Technology</a></span><br />
    </div>
    </form>
</body>
</html>
