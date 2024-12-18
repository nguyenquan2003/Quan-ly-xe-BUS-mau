<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UI_Map_UserManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Quản lý người dùng</title>
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
                <li><a href="" title="" id="current">Quản lý người dùng</a>
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
        <div style="margin-left:300px;">
            <br />
            <div style="font-weight:bold;color:Orange; font-size:20px;margin-top:0px;margin-left:150px;"> Thêm mới người sử dụng </div>
            <div style="margin-left:30px;margin-top:10px;">   Nhập thông tin vào các ô, chú ý các ô có dấu (<font color="red">*</font>) là bắt buộc phải nhập.<br />
             
         <div> 
               <table style="width: 100%;margin-top:20px;">
                    <tr style="height: 30px;">
                        <td class="style1">
                            Tên đăng nhập (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>&nbsp; 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtName" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Mật khẩu (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtPass" runat="server" Width="200px" TextMode="Password"  ></asp:TextBox>

                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                runat="server" ControlToValidate="txtPass" 
                                ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Email (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                runat="server" ControlToValidate="txtEmail" 
                                ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="Nhập đúng email" ControlToValidate="txtEmail" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                   
                    <tr style="height: 30px;">
                        <td class="style1">
                            Số điện thoại (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" Width="200px" onkeypress="return keypress(event);"></asp:TextBox>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPhone" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        &nbsp;</td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Địa chỉ (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Không được để trống" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>         
           
         </div>  
         <div style="margin-left:100px; margin-top:10px;"><asp:Label ID="lbThongBao" runat="server" 
                        ForeColor="Red" Visible="false"></asp:Label></div>
         <div style="margin-left:100px; margin-top:10px;"><asp:Label ID="lbKetQua" runat="server" 
                        ForeColor="Blue" Visible="false"></asp:Label></div>
      
       <div style="margin-left:220px;margin-top:10px;">
                    <asp:Button ID="btnNew" runat="server" Text="Thêm mới" 
                        onclick="btnNew_Click"  />
        </div>
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