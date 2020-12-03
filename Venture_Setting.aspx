<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Venture_Setting.aspx.cs" Inherits="Venture_Setting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head runat="server">
    <title>투기 셋팅</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="text-align:center; width:30%; height:200px;">
                <asp:DropDownList runat="server" ID="ddlCardSet1" 
                    onselectedindexchanged="ddlCardSet1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <br />
                <asp:Image ID="imgMy1" runat="server" />                
            </td>
            <td style="text-align:center; width:30%; height:200px;">
                <asp:DropDownList runat="server" ID="ddlCardSet2" 
                    onselectedindexchanged="ddlCardSet2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <br />
                <asp:Image ID="imgMy2" runat="server" />                
            </td>            
            <td style="text-align:center; width:30%; height:200px;">
                <asp:DropDownList runat="server" ID="ddlCardSet3" 
                    onselectedindexchanged="ddlCardSet3_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <br />
                <asp:Image ID="imgMy3" runat="server" />                
            </td>            
        </tr>
        <tr>
            <td style="text-align:center; height:80px;" colspan="3">
                시뮬레이터이기 때문에 카드 3가지 모두 등록하여야 저장됩니다<br />
                <asp:Button runat="server" ID="btnVenture_Setting" Text="셋팅완료" 
                    onclick="btnVenture_Setting_Click"/>
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
