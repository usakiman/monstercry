<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Emulator_Battle2.aspx.cs" Inherits="Emulator_Battle2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head id="Head1" runat="server">
    <title>몬크 전투 시뮬레이터</title>
<LINK rel="stylesheet" type="text/css" href="Scripts/development-bundle/themes/smoothness/jquery.ui.all.css">
<style>
  .td 
  {
  	font-size:8pt;
  }
  .ui-progressbar {
    position: relative;
  }
  .progress-label {
    position: absolute;
    left:10%;
    font-size:9pt;
    top: 4px;
    font-weight: bold;
    text-shadow: 1px 1px 0 #fff;
  }
</style>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/jquery-1.5.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.core.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.widget.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.tabs.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.accordion.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/js/jquery-1.5.1.min.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/js/jquery-ui-1.8.13.custom.min.js"></script>
<script language="javascript">
    $(document).ready(function() {
        $("#progressbar").progressbar({ value: 0 });
    });

    function progress() {
        var value = $("#progressbar").progressbar("option", "value");

        if (value < 100) {
            $("#progressbar").progressbar("value", value + 1);
            $(".progress-label").text(" 전투당 150턴 제한이있습니다! 좀비시러요~ (" + value + ") 초");
            setTimeout("progress()", 1000);
        } else {
            
        }
    }    
</script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="progressbar" style="width:100%"><div class="progress-label">AI셋팅이 되지않은 카드는 리스트에 보이지않습니다 @_@</div></div>
    
    <div>    
        <table cellpadding="1" cellspacing="1" border="1" width="100%">
        <tr>
            <td style="padding-left:10px;" colspan="3">           
                전투횟수 :                                     
                <asp:RadioButton runat="server" ID="rbLoop5" GroupName="LOOP" Text="5번" />&nbsp;
                <asp:RadioButton runat="server" ID="rbLoop10" GroupName="LOOP" Text="10번" />&nbsp;
                <asp:RadioButton runat="server" ID="rbLoop20" GroupName="LOOP" Text="20번" /><br />
                <asp:Button runat="server" ID="btnBattleStartNew" Text="시작" onclick="btnBattleStartNew_Click" />&nbsp;     
                <asp:Button runat="server" ID="btnClose" Text="종료" onclick="btnClose_Click" />
                <br />
                <asp:Label runat="server" ID="lblMsg" Text="" ForeColor="Tomato"></asp:Label>
                <br />
            </td>
        </tr>
        <tr style="height:40%">
            <td style="width:45%; padding-bottom:10px;" valign="top" align="center">
                <asp:DropDownList runat="server" Width="130" ID="ddlBattleList1" onselectedindexchanged="ddlBattleList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
                <br />
                <asp:Label runat="server" ID="lblCardName_Left" Font-Bold="true"></asp:Label>&nbsp;Lv<asp:Label runat="server" ID="lblCardLevel_Left"></asp:Label>                        
                <br /><br />
                체력 (<asp:Label runat="server" ID="lblHealth_left_Total"></asp:Label>)&nbsp;
                현재체력(<asp:Label runat="server" ID="lblHealth_Left"></asp:Label>)<br />
                공격력(카드공격력)&nbsp;<asp:Label runat="server" ID="lblStrong1_Left"></asp:Label>(<asp:Label runat="server" ID="lblStrong2_Left"></asp:Label>)<br />
                방어력&nbsp;<asp:Label runat="server" ID="lblDefense_Left"></asp:Label>
                현재방어력&nbsp;<asp:Label runat="server" ID="lblDefenseNow_Left"></asp:Label>                
                <br />
                <asp:Image runat="server" ID="imgLeft" Width="100%" />
                <br />                       
            </td>
            <td style="width:10%" valign="middle" align="center">
                VS
            </td>            
            <td style="width:45%; padding-bottom:10px;" valign="top" align="center">
                <asp:RadioButton runat="server" ID="rbType1" GroupName="LISTTYPE" Text="ID별" 
                    Checked="true" AutoPostBack="true" oncheckedchanged="rbType1_CheckedChanged" />
                <asp:RadioButton runat="server" ID="rbType2" GroupName="LISTTYPE" Text="카드별" 
                    AutoPostBack="true" oncheckedchanged="rbType2_CheckedChanged"/>
                <br />
                <asp:DropDownList runat="server" Width="130" ID="ddlBattleType" 
                    AutoPostBack="true" onselectedindexchanged="ddlBattleType_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <asp:DropDownList runat="server" Width="130" ID="ddlBattleList2" onselectedindexchanged="ddlBattleList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
                <br />
                <asp:Label runat="server" ID="lblCardName_Right" Font-Bold="true"></asp:Label>&nbsp;Lv<asp:Label runat="server" ID="lblCardLevel_Right"></asp:Label>
                <br /><br />
                체력 (<asp:Label runat="server" ID="lblHealth_Right_Total"></asp:Label>)&nbsp;
                현재체력(<asp:Label runat="server" ID="lblHealth_Right"></asp:Label>)<br />
                공격력(카드공격력)&nbsp;<asp:Label runat="server" ID="lblStrong1_Right"></asp:Label>(<asp:Label runat="server" ID="lblStrong2_Right"></asp:Label>)<br />
                방어력&nbsp;<asp:Label runat="server" ID="lblDefense_Right"></asp:Label>
                현재방어력&nbsp;<asp:Label runat="server" ID="lblDefenseNow_Right"></asp:Label>                                
                <br />
                <asp:Image runat="server" ID="imgRight" Width="100%" />
                <br />
            </td>
        </tr>
        <tr>
            <td valign="top" align="center">
                <asp:TextBox runat="server" ID="txtLeft" TextMode="MultiLine" Width="90%"></asp:TextBox>
            </td>
            <td>
            
            </td>
            <td valign="top" align="center">
                <asp:TextBox runat="server" ID="txtRight" TextMode="MultiLine" Width="90%"></asp:TextBox>
            </td>
        </tr>
        </table>   
    </div>
    </form>
</body>
</html>
