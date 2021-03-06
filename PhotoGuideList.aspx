﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhotoGuideList.aspx.cs" Inherits="PhotoGuideList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head runat="server">
    <title>몬스터 도감</title>
<LINK rel="stylesheet" type="text/css" href="Scripts/development-bundle/themes/smoothness/jquery.ui.all.css">    
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/jquery-1.5.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.core.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.widget.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.tabs.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.accordion.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/js/jquery-1.5.1.min.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/js/jquery-ui-1.8.13.custom.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>                
        <asp:DropDownList runat="server" ID="ddlPhotoType" AutoPostBack="true" 
            Width="70%" onselectedindexchanged="ddlPhotoType_SelectedIndexChanged">
        <asp:ListItem Text="레전드" Value="0"></asp:ListItem>
        <asp:ListItem Text="에픽" Value="1"></asp:ListItem>        
        <asp:ListItem Text="에픽(한정)" Value="7"></asp:ListItem>        
        <asp:ListItem Text="에픽(투기)" Value="8"></asp:ListItem>        
        <asp:ListItem Text="SSS" Value="2"></asp:ListItem>
        <asp:ListItem Text="SSS(한정)" Value="9"></asp:ListItem>
        <asp:ListItem Text="SS" Value="3"></asp:ListItem>
        <asp:ListItem Text="SS(한정)" Value="A"></asp:ListItem>
        <asp:ListItem Text="S" Value="4"></asp:ListItem>
        <asp:ListItem Text="A" Value="5"></asp:ListItem>
        <asp:ListItem Text="B" Value="6"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <asp:Button runat="server" id="btnBack" Text="메인으로" onclick="btnBack_Click" />
        <br /><br />
        <asp:Label runat="server" ID="lblMsg"></asp:Label>
        <br /><br />
        <asp:DataList ID="DataList1" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Both" RepeatColumns="2" 
            onitemdatabound="DataList1_ItemDataBound" RepeatDirection="Horizontal">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <AlternatingItemStyle BackColor="#DCDCDC" />
            <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
        <table border="1" cellpadding="1" cellspacing="2">
        <tr>
            <td style="text-align:center; vertical-align:top; width:100%;">
                <asp:Image runat="server" ID="imgPhoto"/>
            </td>
        </tr>
        <tr>
            <td style="text-align:center; vertical-align:middle; width:100%;">
                <asp:Label runat="server" ID="lblCardName" Font-Bold="true" Font-Size="Large"></asp:Label>
                <br />
                <asp:Label runat="server" ID="lblCardInfo"></asp:Label>
                <br />
                <asp:Label runat="server" ID="lblCardInfo2"></asp:Label>
            </td>
        </tr>
        </table>        
        </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
