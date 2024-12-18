<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTicketManagement.aspx.cs" Inherits="UI_Map_TicketManagement" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Quản lý điểm bán vé</title>
    <link href="~/Styles/Copy of Site1.css" rel="stylesheet" type="text/css" />
      <script language="javascript">

          function ValidateFile(source, args) {

              try {

                  var fileAndPath =

                  document.getElementById(source.controltovalidate).value;

                  var lastPathDelimiter = fileAndPath.lastIndexOf("\\");

                  var fileNameOnly = fileAndPath.substring(lastPathDelimiter + 1);

                  var file_extDelimiter = fileNameOnly.lastIndexOf(".");

                  var file_ext = fileNameOnly.substring(file_extDelimiter + 1).toLowerCase();

                  if (file_ext != "jpg") {

                      args.IsValid = false;

                      if (file_ext != "gif")

                          args.IsValid = false;

                      if (file_ext != "png") {

                          args.IsValid = false;

                          return;

                      }

                  }

              } catch (err) {

                  txt = "There was an error on this page.\n\n";

                  txt += "Error description: " + err.description + "\n\n";

                  txt += "Click OK to continue.\n\n";

                  txt += document.getElementById(source.controltovalidate).value;

                  alert(txt);

              }
              args.IsValid = true;

          }

          // ham chi nhap so
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
    <style type="text/css">
        .style1
        {
            width: 133px;
        }
    </style>
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
                <li><a href="" title="" id="current">Quản lý điểm bán vé</a>
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
        <div class="content_left2">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
            <asp:Panel ID="pnThemMoi" runat="server"><br />
                <div style="font-weight:bold;color:Orange; font-size:20px;margin-top:0px;margin-left:150px;"> Chỉnh Sửa Điểm Bán Vé Tháng Xe Buýt </div>
                 <div style="margin-left:30px;margin-top:10px;">   Nhập thông tin vào các ô, chú ý các ô có dấu (<font color="red">*</font>) là bắt buộc phải nhập.
                </div>
                <div style="margin-top:20px;"><b>Chọn điểm bán vé xe:&nbsp;&nbsp;&nbsp; &nbsp; </b> <asp:DropDownList ID="drlTicketPark" 
                runat="server" Width="250px" AutoPostBack="True" 
                        onselectedindexchanged="drlTicketPark_SelectedIndexChanged">
                </asp:DropDownList>
                </div>
                <div style="margin-top:10px;"><b>Thông tin điểm bán vé xe:</b></div>
                <table style="width: 100%; margin-left:10px; margin-top:20px;">
                    <tr style="height: 30px;">
                        <td class="style1">
                            Tên điểm bán vé (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>&nbsp; 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtName" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Vĩ độ (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtLatitude" runat="server" Width="200px"  ></asp:TextBox>

                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                runat="server" ControlToValidate="txtLatitude" 
                                ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="Nhập số thực" ControlToValidate="txtLatitude" 
                                ValidationExpression="(\+|-)?[1-9][0-9]*(\.[0-9]*)?"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Kinh độ (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtLongitude" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                runat="server" ControlToValidate="txtLongitude" 
                                ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="Nhập số thực" ControlToValidate="txtLongitude" 
                                ValidationExpression="(\+|-)?[1-9][0-9]*(\.[0-9]*)?"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                   <tr style="height: 30px;">
                        <td class="style1">
                            Thời gian làm việc (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtTime" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtTime" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Mô tả&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" Width="300px" Height="62px" 
                                TextMode="MultiLine"></asp:TextBox>
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
                    <tr style="height: 30px;">
                        <td class="style1">
                            Thuộc Quận (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:DropDownList ID="drlDistrict" runat="server" Width="200px" 
                                AutoPostBack="True" onselectedindexchanged="drlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Thuộc đường (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:DropDownList ID="drlStreet" runat="server" Width="200px">
                            </asp:DropDownList>
                             &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ErrorMessage="Không được để trống" ControlToValidate="drlStreet"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <div style="margin-left:100px;"><asp:Label ID="lbThongBao" runat="server" 
                        ForeColor="Red" Visible="false"></asp:Label></div>
                        
                <div style="margin-left:100px;"><asp:Label ID="lbKetQua" runat="server" 
                        ForeColor="Blue" Visible="false"></asp:Label></div>
                <div style="margin-left:220px;margin-top:10px;">
                    <asp:Button ID="btnEdit" runat="server" Text="Chỉnh sửa" 
                        onclick="btnEdit_Click" />
                </div>
            </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>
            </div>
            
        <div class="content_right2">
            <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
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
