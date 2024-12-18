<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusParkManagement.aspx.cs" Inherits="UI_Map_BusParkManagement" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý bãi đỗ xe</title>
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
            width: 123px;
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
                <li ><a href="" title="" id="current" >Quản lý bãi đỗ</a>
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
      <div class="content_left2">
        
           <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
        <div style="font-weight:bold;color:Orange; font-size:20px;margin-top:0px;margin-left:150px;"> 
            Thêm Mới Bãi Đỗ Xe Buýt </div>
            
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate><br />
        <div style="margin-left:30px;margin-top:10px;">   Nhập thông tin vào các ô, chú ý các ô có dấu (<font color="red">*</font>) là bắt buộc phải nhập.<br />
             
         <div> 
               <table style="width: 100%;margin-top:20px;">
                    <tr style="height: 30px;">
                        <td class="style1">
                            Tên bãi đỗ xe (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewName" runat="server" Width="200px"></asp:TextBox>&nbsp; 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtNewName" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            </td>
                    </tr> 
                    <tr style="height: 30px;">
                        <td class="style1">
                            Vĩ độ (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewLatitude" runat="server" Width="200px"  ></asp:TextBox>

                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                runat="server" ControlToValidate="txtNewLatitude" 
                                ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="Nhập số thực" ControlToValidate="txtNewLatitude" 
                                ValidationExpression="(\+|-)?[1-9][0-9]*(\.[0-9]*)?"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Kinh độ (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewLongitude" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                runat="server" ControlToValidate="txtNewLongitude" 
                                ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="Nhập số thực" ControlToValidate="txtNewLongitude" 
                                ValidationExpression="(\+|-)?[1-9][0-9]*(\.[0-9]*)?"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Mô tả&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewDescription" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Diện tích (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewArea" runat="server" Width="200px" onkeypress="return keypress(event);"></asp:TextBox>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtNewArea" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Địa chỉ (<font color="red">*</font>)
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewAddress" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Không được để trống" ControlToValidate="txtNewAddress"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td class="style1">
                            Hình ảnh
                        </td>
                        <td>
                            <asp:FileUpload ID="fulImages" runat="server"  />&nbsp;&nbsp; <asp:CustomValidator ID="CustomValidator1"
                            ClientValidationFunction="ValidateFile" runat="server"
                            ControlToValidate="fulImages"
                            Display="dynamic" ErrorMessage="Chỉ nhận hình ảnh ">
                            </asp:CustomValidator>
                        </td>
                    </tr>
                </table>         
           
         </div>  
        
        </div>
        
       <div style="margin-left:50px;"><asp:Label ID="lbThongBao" runat="server" 
                        ForeColor="Red" Visible="false"></asp:Label></div>
                        
       <div style="margin-left:50px;"><asp:Label ID="lbKetQua" runat="server" 
                        ForeColor="Blue" Visible="false"></asp:Label></div>
      
                   
        </ContentTemplate>
        </asp:UpdatePanel>
       <div style="margin-left:220px;margin-top:10px;">
                    <asp:Button ID="btnNew" runat="server" Text="Thêm mới" onclick="btnNew_Click" />
        </div>
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
