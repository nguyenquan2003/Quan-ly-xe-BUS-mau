<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditBusLine.aspx.cs" Inherits="UI_Map_EditBusLine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Quản lý tuyến xe</title>
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
            <div class="logo_icon" style="float:right;margin-rigth:20px;">
                <asp:Label ID="lbAdmin" runat="server" Text="Hello" ForeColor="Blue"></asp:Label></div>
            <%--<div class="logo_text">Hệ thống giám sát và quản lý Xe Buýt Hà Nội</div>--%>
        </div>
        <div class="menuHeader" >
             <ul id="menu">
                <li ><a href="BusMap.aspx">Trang chủ</a></li>
                <li> <a href="AdminGPSRealTime.aspx">Giám sát</a></li>
                <li ><a href="HistoryGPS.aspx" title="">Báo cáo lịch sử</a></li>
                <li ><a href="" title="" id="current">Quản lý tuyến xe</a>
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

    <div class ="content2">
        <div style="margin-left:300px;" id="div1">
            <asp:Panel ID="pnThemMoi" runat="server" >
                <div style="font-weight:bold;color:Orange; font-size:20px;margin-top:0px;margin-left:150px;"> Chỉnh sửa tuyến xe Buýt </div>
                 <div style="margin-left:30px;margin-top:10px;">   Nhập thông tin vào các ô, chú ý các ô có dấu (<font color="red">*</font>) là bắt buộc phải nhập.
                </div>
                <div style="margin-top:10px;"><b>Chọn tuyến xe Buýt:&nbsp;&nbsp;&nbsp; &nbsp; </b> <asp:DropDownList ID="drlBusLine" 
                        runat="server" Width="250px" AutoPostBack="True" 
                        onselectedindexchanged="drlBusLine_SelectedIndexChanged" >
                    </asp:DropDownList>
                </div><br />
                <div><b>Thông tin bãi đỗ xe: </b></div>
                <table style="width: 100%; margin-left:50px; margin-top:10px;">
                    <tr style="height: 30px;">
                        <td style="width:150px;">
                            Tên tuyến (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Không được để trống" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td style="width:150px;">
                            Tuyến đường (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtPathName" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                ID="RequiredFieldValidator9" runat="server" 
                                ErrorMessage="Không được để trống" ControlToValidate="txtPathName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td style="width:150px;">
                            Thời gian bắt đầu (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartTime" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="Không được để trống" ControlToValidate="txtStartTime"></asp:RequiredFieldValidator>
                       
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td style="width:150px;">
                            Thời gian kết thúc (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndTime" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtEndTime" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 100px;">
                        <td style="width:150px;">
                            Chiều đi (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtPathGo" runat="server"  Width="294px" Height="80px" 
                                TextMode="MultiLine"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtPathGo" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 100px;">
                        <td style="width:150px;">
                            Chiều về (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtPathBack" runat="server" Width="294px" Height="80px" 
                                TextMode="MultiLine"></asp:TextBox>
                            &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtPathBack" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td style="width:150px;">
                            Mô tả (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtDescription" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td style="width:150px;">
                            Giá vé (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtCost" runat="server" Width="200px" onkeypress="return keypress(event);"></asp:TextBox>
                            &nbsp;<i>đ/lượt </i>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="txtCost" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td style="width:150px;">
                            Tần suất (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtFrequence" runat="server" Width="200px" onkeypress="return keypress(event);"></asp:TextBox> 
                            &nbsp;<i>phút/chuyến</i> &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="txtFrequence" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <div style="margin-left:220px;"><asp:Label ID="lbKetQua" runat="server" 
                        ForeColor="Blue" Visible="false"></asp:Label></div>
                <div style="margin-left:220px;margin-top:10px;">
                    <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" 
                        onclick="btnUpdate_Click"  />
                </div>
            </asp:Panel>
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
