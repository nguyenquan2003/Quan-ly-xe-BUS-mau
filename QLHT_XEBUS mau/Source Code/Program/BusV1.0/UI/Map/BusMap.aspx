<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusMap.aspx.cs" Inherits="UI_Map_BusLine" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>
<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bản đồ xe Buýt</title>
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
        <div class="content1">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="content_left1">
	            <div id="tabs-1">
                
                    <asp:UpdatePanel ID="updatepnlTuyenXe" runat="server">
                    <ContentTemplate>
		                <div style="margin-left:0px; font-size:18px; color:Black;margin-top:10px; height: 35px;font-weight:bold;" >Tuyến xe buýt:</div>
                        <div style="margin-left: 5px; height: 35px;">
                            <asp:DropDownList ID="drlBusLine" runat="server" Width="300px" 
                                BackColor="#99CCFF" >
                            </asp:DropDownList>
                        </div>
                        <div>
                        <div style="margin-left:50px; float:left; width:80px; ">
                            <asp:Button ID="btnChieuDi" runat="server" Text="Chiều đi" ForeColor="Red" 
                                onclick="btnChieuDi_Click" />
                        </div>
                           <div style="margin-right:50px;width:100px; float:right; "> 
                               <asp:Button ID="btnChieuVe" runat="server" Text="Chiều về" ForeColor="Green" 
                                   onclick="btnChieuVe_Click" />
                            </div>
                        </div>
                        <div style="margin-left:0px;width:325px; float:left;margin-top:20px; ">
                            <asp:Panel ID="pnBusLine" runat="server" Height="650px" Width="320px" BorderColor="Aqua">
                            <hr style="width:300px; margin-left: 10px;"/>
                                <b><asp:Label ID="lbDescription" runat="server"></asp:Label></b><br />
                                <b>Giá vé: </b><asp:Label ID="lbCost" runat="server"></asp:Label><br />
                                <b>Tần suất: </b><asp:Label ID="lbFrequence" runat="server"></asp:Label><br />
                                <b>Thời gian hoạt động: </b><asp:Label ID="lbTime" runat="server"></asp:Label><br /><br />
                                <font color='Red'  ><b>Chiều đi: </b></font><asp:Label ID="lbPathGo" runat="server"></asp:Label><br /><br />
                                <font color='Green'  ><b>Chiều về: </b></font><asp:Label ID="lbPathBack" runat="server"></asp:Label><br />
                            </asp:Panel>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
	            </div>
	            <div id="tabs-2">
                <asp:UpdatePanel ID="updatepnlBaiDoXe" runat="server">
                    <ContentTemplate>
		            <div style="margin-left:5px; font-size:16px; color:Black;margin-top:10px; height: 35px;font-weight:bold;">Bãi đỗ xe:</div>
                    <div style="margin-left: 20px; height: 35px;">
                        <asp:DropDownList ID="drlBusPark" runat="server" Width="300px" BackColor="#99CCFF">
                        </asp:DropDownList>
                    </div>
                    <div>
                            <div style="margin-left:100px; float:left; width:80px; ">
                                <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" 
                                    onclick="btnSearch_Click"   />
                            </div>
                    </div>
                     <div style="margin-left:0px;width:330px; float:left;margin-top:20px; ">
                        <asp:Panel ID="pnBusPark" runat="server" Height="650px" Width="330px">
                        <hr style="width:300px; margin-left: 10px;"/>
                            <b>Tên bãi đỗ xe: </b><asp:Label ID="lbName" runat="server"></asp:Label><br />
                            <b>Tọa độ: </b><asp:Label ID="lbCoordinate" runat="server"></asp:Label><br />
                            <b>Diện tích: </b><asp:Label ID="lbArea" runat="server"></asp:Label><br /><br />
                            <b>Mô tả: </b><asp:Label ID="Label1" runat="server"></asp:Label><br /><br />
                            <b>Địa chỉ: </b><asp:Label ID="lbAddress" runat="server"></asp:Label><br /><br />
                            <b>Các tuyến xe Buýt đỗ tại bến: </b><br />
                            <asp:Label ID="lbBusLine" 
                                runat="server" ForeColor="Blue" ></asp:Label>
                            </asp:Panel>
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
	            </div>
	            <div id="tabs-3" style="display:none;" >
                <div style="overflow: auto; height:725px;width:325px;">
                    <div style="margin-left:5px; font-size:16px; color:Black;margin-top:10px; height: 35px;font-weight:bold;">Nhập tên đường:</div>
                    <table style="margin-left: 10px; height: 35px;width:300px;">
                        <tr>
                            <td style="width:260px;">
                                <asp:TextBox ID="txtStartPoint" runat="server" Width="250px" BackColor="#99CCFF"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtStartPoint" ServicePath="AutoComplete.asmx" ServiceMethod="GetCountriesList" MinimumPrefixLength="1" EnableCaching="true" />
                            </td>
                            <td>
                                <img src="Images/BusIcon/DirectionOrder/gA.png"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:260px;">
                                <asp:TextBox ID="txtEndPoint" runat="server" Width="250px" BackColor="#99CCFF"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtEndPoint" ServicePath="AutoComplete.asmx" ServiceMethod="GetCountriesList" MinimumPrefixLength="1" EnableCaching="true" />
                            </td>
                            <td>
                                <img src="Images/BusIcon/DirectionOrder/gB.png"/>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <div style="margin-left:100px; float:left; width:80px; "><br />
                            <asp:Button ID="btnSearchDirection" runat="server" Text="Tìm kiếm" 
                                onclick="btnSearchDirection_Click"   />
                        </div>
                    </div>
                     <div style="margin-left:0px;width:300px;float:left;margin-top:20px;" id= "d">
 
                    </div>
                    </div>
	            </div>
                <div id="tabs-4">
                <asp:UpdatePanel ID="updatepnlGridview" runat="server">
                    <ContentTemplate>
                    <div style="margin-left:5px; font-size:16px; color:Black;margin-top:10px; height: 35px;font-weight:bold;">Tên tuyến phố:</div>
                    <div style="margin-left: 0px; height: 35px;">
                        <asp:TextBox ID="txtStreet" runat="server" Width="300px" BackColor="#99CCFF"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="txtStreet" ServicePath="AutoComplete.asmx" ServiceMethod="GetCountriesList" MinimumPrefixLength="1" EnableCaching="true" />
                    </div>
                    <div>
                        <div style="margin-left:100px; float:left; width:80px; ">
                        
                            <asp:Button ID="btnSearchStreet" runat="server" Text="Tìm kiếm" 
                                onclick="btnSearchStreet_Click"  />
                        </div >
                        <div style="margin-left:0px; float:left; width:300px; ">
                                <asp:Label ID="lbKetQuaStreet" runat="server" Visible ="False" ForeColor="Red"></asp:Label>
                        </div>
                        
                    </div>
                    <asp:Panel ID="pnlStreet" runat="server" Visible="false">
                        <div style="margin-left:0px; margin-top:10px; float:left; width:300px; ">
                        <div style="margin-left:5px;margin-top:20px; font-size:16px; color:Black; height: 35px;font-weight:bold;">Các tuyến xe Buýt đi qua 
                            <asp:Label ID="lbStreet" runat="server" Text="Label"></asp:Label>:</div>
                        
                            <asp:Label ID="lbBusLineOfStreet" runat="server" ForeColor="Blue"></asp:Label>
                     <%--       <asp:GridView ID="grvBusLineName" runat="server" AutoGenerateColumns="False" 
                                 onrowdatabound="grvBusLineName_RowDataBound" 
                                onselectedindexchanged="grvBusLineName_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="Name">
                                    <ItemStyle Font-Underline="True" ForeColor="Blue" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>--%>
                        </div>
                        <div style="margin-left:0px; margin-top:10px; float:left; width:320px; ">
                    <div style="margin-left:5px;margin-top:20px; font-size:16px; color:Black; height: 35px;font-weight:bold;">Các trạm chờ xe Buýt:</div>
                      
                        <asp:GridView ID="grvBusList" runat="server" AutoGenerateColumns="False" 
                            Width="320px" AllowPaging="True" onrowdatabound="grvBusList_RowDataBound" 
                            onselectedindexchanged="grvBusList_SelectedIndexChanged" 
                                onpageindexchanging="grvBusList_PageIndexChanging" PageSize="5">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Tên trạm chờ" />
                                <asp:BoundField DataField="Latitude" HeaderText="Tung độ" />
                                <asp:BoundField DataField="Longitude" HeaderText="Vĩ độ" />
                                <asp:BoundField DataField="Address" HeaderText="Địa Chỉ" 
                                    SortExpression="Address" />
                            </Columns>

                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" /> 
                        </asp:GridView>
                    </div>
                    </asp:Panel>
                    
                </ContentTemplate>
                </asp:UpdatePanel>
                </div>
                <div id="tabs-5">
                    <asp:UpdatePanel ID="updatePnlTicket" runat="server">
                    <ContentTemplate>
                    <div style="margin-left:5px; font-size:16px; color:Black;margin-top:10px; height: 35px;font-weight:bold;">Tên quận:</div>
                    <div style="margin-left: 0px; height: 35px;">
                        <asp:TextBox ID="txtDistrict" runat="server" Width="300px" BackColor="#99CCFF"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender runat="server" ID="AutoCompleteExtender3" TargetControlID="txtDistrict" ServicePath="AutoComplete.asmx" ServiceMethod="GetDistrictList" MinimumPrefixLength="1" EnableCaching="true" />
                    </div>
                    <div>
                        <div style="margin-left:90px; float:left; width:80px; ">
                        
                            <asp:Button ID="btnSearchTicketPark" runat="server" Text="Tìm điểm bán vé" 
                                onclick="btnSearchTicketPark_Click"  /><br />
                                
                        </div>
                        <div style="margin-left:0px; float:left; width:300px; ">
                             <asp:Label ID="lblKetQua" runat="server" Visible ="False" ForeColor="Red"></asp:Label></div>
                    </div>
                    <asp:Panel ID="pnlTicket" runat="server" Visible="false">
                        <div style="margin-left:0px; margin-top:10px; float:left; width:320px; ">
                        <div style="margin-left:0px; margin-top:10px; float:left; width:320px; ">
                        <div style="margin-left:5px;margin-top:20px; font-size:16px; color:Black; height: 35px;font-weight:bold;">Điểm bán vé tháng xe Buýt:</div>
                        
                        <asp:ListBox ID="lsTicketPark" runat="server" Width="320px"  Height="100px"
                                SelectionMode="Multiple" EnableTheming="True"></asp:ListBox>
                        <div style="margin-left:90px;margin-top:10px; ">
                            <asp:Button ID="btnInfoTicket" runat="server" Text="Xem thông tin" 
                                onclick="btnInfoTicket_Click" Font-Bold="True" BackColor="#99CCFF" />
                        </div>
                        <asp:Panel ID="pnlInfoTicket" runat="server" Visible = "false"><br /><br />
                            <b>Thông tin về địa điểm bán vé </b>
                            <asp:Label ID="lbTicketName" runat="server"  ForeColor="Blue"></asp:Label><br />
                                <hr width="250" />
                            <b>Tung độ: </b><asp:Label ID="lbLatitudeTicket" runat="server" Text=""></asp:Label><br />
                            <b>Vĩ độ: </b><asp:Label ID="lbLongitudeTicket" runat="server" Text=""></asp:Label><br /><br />
                            <b>Mô tả: </b><asp:Label ID="lbDescriptionTicket" runat="server" Text=""></asp:Label><br /><br />
                            <b>Địa chỉ: </b><asp:Label ID="lbAddressTicket" runat="server" 
                                Font-Italic="True"></asp:Label><br />
                        </asp:Panel>
                    </div>
                            
                    </div>
                    </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>
                </div>
            </div>
            
            <div class="content_right1">
                <div class="map">
                    <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
