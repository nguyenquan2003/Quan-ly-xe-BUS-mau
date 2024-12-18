<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginAdmin.aspx.cs" Inherits="UI_Map_LoginAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="~/Styles/admin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 270px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:450px; padding-top:80px;color:white; font-size:x-large;"><b>HỆ THỐNG QUẢN LÝ XE BUÝT HÀ NỘI</b></div>
    <div id="login">
        <div id="content"><br />
            <table style="width: 100%;">
                <tr>
                    <td class="style1">
                       <label class="login-info">Tên đăng nhập</label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                    <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <label class="login-info">Mật khẩu</label>
                        <asp:TextBox ID="txtPass" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
			<div id="login-buttton">
                <asp:ImageButton ID="ibtnLogin" runat="server" 
                    ImageUrl="~/Images/WebImages/loginbtn.png" onclick="ibtnLogin_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
