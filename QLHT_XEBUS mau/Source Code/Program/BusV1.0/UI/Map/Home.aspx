<%@ Page Title="" Language="C#" MasterPageFile="BusMasterPageV2.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" 
        runat="server" />
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
<br />   <font size="4" face="Time News Roman" color="Blue">Tuyến xe buýt:</font> 
    <br />
<br />
    <asp:DropDownList ID="drlBusLine" runat="server" Width="220px">
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />

</asp:Content>

