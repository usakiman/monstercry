<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Emulator_Battle.aspx.cs" Inherits="Emulator_Battle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head runat="server">
    <title>몬크 전투 시뮬레이터</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="1" width="100%">
        <tr>
            <td colspan="3">
                <asp:Button runat="server" ID="btnClose" style="width:100%;" Text="종료" onclick="btnClose_Click" />                
                <br />
                <asp:DropDownList runat="server" ID="ddlBattleList1" 
                    onselectedindexchanged="ddlBattleList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
                <asp:DropDownList runat="server" ID="ddlBattleList2" 
                    onselectedindexchanged="ddlBattleList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>             
                <br />
                <asp:Label runat="server" ID="lblMsg" Text="AI셋팅이 되지않은 카드는 리스트에 보이지않습니다 @_@" ForeColor="Tomato"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:40%" valign="top">
                <table cellpadding="0" cellspacing="0" border="1" width="100%">
                <tr>
                    <td style="text-align:center;">
                        <asp:Label runat="server" ID="lblCardName_Left" Font-Bold="true"></asp:Label>&nbsp;Lv<asp:Label runat="server" ID="lblCardLevel_Left"></asp:Label>                        
                        <br />                                                
                        체력 (<asp:Label runat="server" ID="lblHealth_left_Total"></asp:Label>)&nbsp;
                        현재체력(<asp:Label runat="server" ID="lblHealth_Left"></asp:Label>)<br />
                        공격력(카드공격력)&nbsp;<asp:Label runat="server" ID="lblStrong1_Left"></asp:Label>(<asp:Label runat="server" ID="lblStrong2_Left"></asp:Label>)<br />
                        방어력&nbsp;<asp:Label runat="server" ID="lblDefense_Left"></asp:Label>
                        현재방어력&nbsp;<asp:Label runat="server" ID="lblDefenseNow_Left"></asp:Label>
                        <br /><br />
                        <asp:TextBox runat="server" ID="txtLeft" TextMode="MultiLine" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                </table>
            </td>
            <td style="width:20%;" valign="top">
                <table cellpadding="0" cellspacing="0" border="1" width="100%">
                <tr style="height:40%">
                    <td>
                        <asp:Image runat="server" ID="imgLeft" Width="100%" />
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Button runat="server" ID="btnBattleStart" Text="시작" Width="100%" 
                            Height="50px" onclick="btnBattleStart_Click" Visible="false" />
                       <asp:Button runat="server" ID="btnBattleStartNew" Text="시작" Width="100%" 
                            Height="50px" onclick="btnBattleStartNew_Click" />     
                    </td>
                </tr>
                <tr style="height:40%">
                    <td>
                        <asp:Image runat="server" ID="imgRight" Width="100%" />
                    </td>
                </tr>
                </table>
            </td>
            <td style="width:40%" valign="top">
                <table cellpadding="0" cellspacing="0" border="1" width="100%">
                <tr>
                    <td style="text-align:center;">
                        <asp:Label runat="server" ID="lblCardName_Right" Font-Bold="true"></asp:Label>&nbsp;Lv<asp:Label runat="server" ID="lblCardLevel_Right"></asp:Label>                        
                        <br />                                                
                        체력 (<asp:Label runat="server" ID="lblHealth_Right_Total"></asp:Label>)&nbsp;
                        현재체력(<asp:Label runat="server" ID="lblHealth_Right"></asp:Label>)<br />
                        공격력(카드공격력)&nbsp;<asp:Label runat="server" ID="lblStrong1_Right"></asp:Label>(<asp:Label runat="server" ID="lblStrong2_Right"></asp:Label>)<br />
                        방어력&nbsp;<asp:Label runat="server" ID="lblDefense_Right"></asp:Label>
                        현재방어력&nbsp;<asp:Label runat="server" ID="lblDefenseNow_Right"></asp:Label>
                        <br /><br />
                        <asp:TextBox runat="server" ID="txtRight" TextMode="MultiLine" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                </table>
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
