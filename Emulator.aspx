<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Emulator.aspx.cs" Inherits="Emulator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head id="Head1" runat="server">
    <title>몬크 시뮬레이터 - by usaki (몬스터주식회사)</title>
<LINK rel="stylesheet" type="text/css" href="Scripts/development-bundle/themes/smoothness/jquery.ui.all.css">    
<style type="text/css">
.orientleft #shell {
    -webkit-transform: rotate(-90deg);
    -webkit-transform-origin:160px 160px;
}

.orientright #shell {
    -webkit-transform: rotate(90deg);
    -webkit-transform-origin:230px 230px;    
} 

body {
  background-color: #ffffff;
  background-image: linear-gradient(45deg, rgba(255, 255, 255, 0.2) 25%, rgba(0, 0, 0, 0) 25%, rgba(0, 0, 0, 0) 50%, rgba(255, 255, 255, 0.2) 50%, rgba(255, 255, 255, 0.2) 75%, rgba(0, 0, 0, 0) 75%, rgba(0, 0, 0, 0));  
}

div {  
  display: block;
  position: relative;
  border: 1px solid #000;  
}

/*
div:after 
{   	
  background: url(Files/하모니.jpg) center;  
  opacity: 0.05;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  position: absolute;
  z-index: -1;
  content: "";
}
*/

</style>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/jquery-1.5.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.core.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.widget.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.tabs.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/development-bundle/ui/jquery.ui.accordion.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/js/jquery-1.5.1.min.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/js/jquery-ui-1.8.13.custom.min.js"></script>
<script language="javascript" type="text/javascript">

    function init() {
        var mobileKeyWords = new Array('iPhone', 'iPod', 'BlackBerry', 'Android', 'Windows CE', 'LG', 'MOT', 'SAMSUNG', 'SonyEricsson');
        for (var word in mobileKeyWords) {
            if (navigator.userAgent.match(mobileKeyWords[word]) != null) {
                changeOrientation();
                break;
            }
        }
    }

/*
    $(window).bind("orientationchange", function() {
        var orientation = window.orientation;
        var new_orientation = (orientation) ? 0 : 90 + orientation;
        $('body').css({
            "-webkit-transform": "rotate(" + new_orientation + "deg)"
            //"-webkit-transform": "rotate(90deg)"
        });
    });
*/

    function changeOrientation() {
        alert("Mobile Display");
        document.getElementById("orient").className = "orientright";
    }

    window.addEventListener("onorientationchange", function() {
        if (window.orientation == -90) {
            document.getElementById("orient").className = "orientright";
        }
        if (window.orientation == 90) {
            document.getElementById("orient").className = "orientleft";
        }
        if (window.orientation == 0) {
            document.getElementById("orient").className = "";
        }
    }, true);

    //setTimeout("init", 100);
    
    function showDisplay() {     
        //$("btnRun").trigger("click");
       
        //__doPostBack("btnRun", null);
        
        var cardname = "";
        var cardlevel = "";
        var passive = "";
        var stat1 = "";
        var stat2 = "";
        var stat3 = "";
        var stat4 = "";
        var result1 = "";
        var result2 = "";
        var result3 = "";
        var result4 = "";
        var attack1 = "";
        var attack2 = "";
        var attack3 = "";
        var attack4 = "";
        var attack5 = "";
        var equipment1 = "";
        var equipment2 = "";
        var equipment3 = "";
        var type1 = "";
        var type2 = "";
        var type3 = "";

        cardname = document.getElementById("ddlList").value;
        if (document.getElementsByName("LEVEL")[0].checked) cardlevel = "100";
        if (document.getElementsByName("LEVEL")[1].checked) cardlevel = "110";
        if (document.getElementsByName("LEVEL")[2].checked) cardlevel = "120";                        
        passive = document.getElementById("lblPassive").innerHTML.replace("<br/>", " ").replace("<br>", " ");
        stat1 = document.getElementById("txtHealth").value;
        stat2 = document.getElementById("txtStrong1").value;
        stat3 = document.getElementById("txtDefense").value;
        stat4 = document.getElementById("txtStrong2").value;
        result1 = document.getElementById("lblResultHealth").innerHTML;
        result2 = document.getElementById("lblResultStrong1").innerHTML;
        result3 = document.getElementById("lblResultDefense").innerHTML;
        result4 = document.getElementById("lblResultStrong2").innerHTML;
        attack1 = document.getElementById("lblResultAttack1").innerHTML;
        attack2 = document.getElementById("lblResultAttack2").innerHTML;
        attack3 = document.getElementById("lblResultAttack3").innerHTML;
        attack4 = document.getElementById("lblResultAttack4").innerHTML;
        attack5 = document.getElementById("lblResultAttack5").innerHTML

        // 장비
        switch (document.getElementById("ddlEquipment1").value)
        {
            case "HEALTH":
                equipment1 = "[갑옷] " + document.getElementById("txtEquipment1_basic").value + " 강 : ";
                break;
            case "STRONG1":
                equipment1 = "[검] " + document.getElementById("txtEquipment1_basic").value + " 강 : ";
                break;
            case "DEFENSE":
                equipment1 = "[방패] " + document.getElementById("txtEquipment1_basic").value + " 강 : ";
                break;
            case "STRONG2":
                equipment1 = "[반지] " + document.getElementById("txtEquipment1_basic").value + " 강 : ";
                break;
        }

        switch (document.getElementById("ddlEquipment2").value)
        {
            case "HEALTH":
                equipment2 = "[갑옷] " + document.getElementById("txtEquipment2_basic").value + " 강 : ";
                break;
            case "STRONG1":
                equipment2 = "[검] " + document.getElementById("txtEquipment2_basic").value + " 강 : ";
                break;
            case "DEFENSE":
                equipment2 = "[방패] " + document.getElementById("txtEquipment2_basic").value + " 강 : ";
                break;
            case "STRONG2":
                equipment2 = "[반지] " + document.getElementById("txtEquipment2_basic").value + " 강 : ";
                break;
        }

        switch (document.getElementById("ddlEquipment3").value)
        {
            case "HEALTH":
                equipment3 = "[갑옷] " + document.getElementById("txtEquipment3_basic").value + " 강 : ";
                break;
            case "STRONG1":
                equipment3 = "[검] " + document.getElementById("txtEquipment3_basic").value + " 강 : ";
                break;
            case "DEFENSE":
                equipment3 = "[방패] " + document.getElementById("txtEquipment3_basic").value + " 강 : ";
                break;
            case "STRONG2":
                equipment3 = "[반지] " + document.getElementById("txtEquipment3_basic").value + " 강 : ";
                break;
        }

        // 옵션1
        switch (document.getElementById("ddlEquipment1_option1").value)
        {
            case "HEALTH":
                equipment1 += "(체력 " + document.getElementById("txtEquipment1_option1").value + " 강)";
                break;
            case "STRONG1":
                equipment1 += "(공격 " + document.getElementById("txtEquipment1_option1").value + " 강)";
                break;
            case "DEFENSE":
                equipment1 += "(방어 " + document.getElementById("txtEquipment1_option1").value + " 강)";
                break;
            case "STRONG2":
                equipment1 += "(카공 " + document.getElementById("txtEquipment1_option1").value + " 강)";
                break;
        }

        switch (document.getElementById("ddlEquipment2_option1").value)
        {
            case "HEALTH":
                equipment2 += "(체력 " + document.getElementById("txtEquipment2_option1").value + " 강)";
                break;
            case "STRONG1":
                equipment2 += "(공격 " + document.getElementById("txtEquipment2_option1").value + " 강)";
                break;
            case "DEFENSE":
                equipment2 += "(방어 " + document.getElementById("txtEquipment2_option1").value + " 강)";
                break;
            case "STRONG2":
                equipment2 += "(카공 " + document.getElementById("txtEquipment2_option1").value + " 강)";
                break;
        }

        switch (document.getElementById("ddlEquipment3_option1").value)
        {
            case "HEALTH":
                equipment3 += "(체력 " + document.getElementById("txtEquipment3_option1").value + " 강)";
                break;
            case "STRONG1":
                equipment3 += "(공격 " + document.getElementById("txtEquipment3_option1").value + " 강)";
                break;
            case "DEFENSE":
                equipment3 += "(방어 " + document.getElementById("txtEquipment3_option1").value + " 강)";
                break;
            case "STRONG2":
                equipment3 += "(카공 " + document.getElementById("txtEquipment3_option1").value + " 강)";
                break;
        }

        // 옵션2
        switch (document.getElementById("ddlEquipment1_option2").value)
        {
            case "HEALTH":
                equipment1 += ",(체력 " + document.getElementById("txtEquipment1_option2").value + " 강)";
                break;
            case "STRONG1":
                equipment1 += ",(공격 " + document.getElementById("txtEquipment1_option2").value + " 강)";
                break;
            case "DEFENSE":
                equipment1 += ",(방어 " + document.getElementById("txtEquipment1_option2").value + " 강)";
                break;
            case "STRONG2":
                equipment1 += ",(카공 " + document.getElementById("txtEquipment1_option2").value + " 강)";
                break;
        }

        switch (document.getElementById("ddlEquipment2_option2").value)
        {
            case "HEALTH":
                equipment2 += ",(체력 " + document.getElementById("txtEquipment2_option2").value + " 강)";
                break;
            case "STRONG1":
                equipment2 += ",(공격 " + document.getElementById("txtEquipment2_option2").value + " 강)";
                break;
            case "DEFENSE":
                equipment2 += ",(방어 " + document.getElementById("txtEquipment2_option2").value + " 강)";
                break;
            case "STRONG2":
                equipment2 += ",(카공 " + document.getElementById("txtEquipment2_option2").value + " 강)";
                break;
        }

        switch (document.getElementById("ddlEquipment3_option2").value)
        {
            case "HEALTH":
                equipment3 += ",(체력 " + document.getElementById("txtEquipment3_option2").value + " 강)";
                break;
            case "STRONG1":
                equipment3 += ",(공격 " + document.getElementById("txtEquipment3_option2").value + " 강)";
                break;
            case "DEFENSE":
                equipment3 += ",(방어 " + document.getElementById("txtEquipment3_option2").value + " 강)";
                break;
            case "STRONG2":
                equipment3 += ",(카공 " + document.getElementById("txtEquipment3_option2").value + " 강)";
                break;
        }        

        if (document.getElementById("rbUpgrade1_100").checked)
        {
            type1 = "100";            
        }
        if (document.getElementById("rbUpgrade1_110").checked)
        {
            type1 = "110";            
        }
        if (document.getElementById("rbUpgrade1_120").checked)
        {
            type1 = "120";            
        }
        if (document.getElementById("rbUpgrade1_Legend").checked)
        {
            type1 = "Legend";            
        }
        
        if (document.getElementById("rbUpgrade2_100").checked)
        {
            type2 = "100";            
        }
        if (document.getElementById("rbUpgrade2_110").checked)
        {
            type2 = "110";            
        }
        if (document.getElementById("rbUpgrade2_120").checked)
        {
            type2 = "120";            
        }
        if (document.getElementById("rbUpgrade2_Legend").checked)
        {
            type2 = "Legend";            
        }
        
        if (document.getElementById("rbUpgrade3_100").checked)
        {
            type3 = "100";            
        }
        if (document.getElementById("rbUpgrade3_110").checked)
        {
            type3 = "110";            
        }
        if (document.getElementById("rbUpgrade3_120").checked)
        {
            type3 = "120";            
        }
        if (document.getElementById("rbUpgrade3_Legend").checked)
        {
            type3 = "Legend";            
        }                

        var url = "Display.aspx?cardname=" + cardname + "&cardlevel=" + cardlevel + "&passive=" + passive +
            "&stat1=" + stat1 + "&stat2=" + stat2 + "&stat3=" + stat3 + "&stat4=" + stat4 +
            "&result1=" + result1 + "&result2=" + result2 + "&result3=" + result3 + "&result4=" + result4 +
            "&attack1=" + attack1 + "&attack2=" + attack2 + "&attack3=" + attack3 + "&attack4=" + attack4 + "&attack5=" + attack5 +
            "&equipment1=" + equipment1 + "&equipment2=" + equipment2 + "&equipment3=" + equipment3 +
            "&type1=" + type1 + "&type2=" + type2 + "&type3=" + type3;                        
        
        window.open(url, "Display", "");
    }
    
</script>
</head>
<body>
    <form id="form1" runat="server">    
    <div>
        <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>    
        <asp:updatepanel ID="Updatepanel1" runat="server">
        <ContentTemplate>                 
        
        <table cellpadding="0" cellspacing="0" border="1" width="100%">
        <tr>
            <td colspan="2" style="height:40px; text-align:center;">
                <asp:Button ID="btnGoFight" runat="server" Text="전투시뮬" 
                    onclick="btnGoFight_Click"/>
                &nbsp;                
                <asp:Button ID="btnGoVenture" runat="server" Text="투기장시뮬" 
                    onclick="btnGoVenture_Click"/>
                &nbsp;
                <asp:Button ID="btnAIGo" runat="server" Text="AI편집" onclick="btnAIGo_Click"/>
                &nbsp;
                <asp:Button ID="btnMain" runat="server" Text="메인" onclick="btnMain_Click" />
                <br />
                <asp:DropDownList runat="server" ID="ddlListType" AutoPostBack="true" 
                    onselectedindexchanged="ddlListType_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddlList" AutoPostBack="true" 
                    onselectedindexchanged="ddlList_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <asp:RadioButton runat="server" ID="rb1" Text="LV100" GroupName="LEVEL" 
                    Checked="true" oncheckedchanged="rb1_CheckedChanged" AutoPostBack="True" />
                <asp:RadioButton runat="server" ID="rb2" Text="LV110" GroupName="LEVEL" 
                    AutoPostBack="True" oncheckedchanged="rb2_CheckedChanged" />
                <asp:RadioButton runat="server" ID="rb3" Text="LV120" GroupName="LEVEL" 
                    AutoPostBack="True" oncheckedchanged="rb3_CheckedChanged"/>
                <br />
                <asp:CheckBox runat="server" ID="cbLegend" Text="전설화" 
                    oncheckedchanged="cbLegend_CheckedChanged" AutoPostBack="true" />
                &nbsp;                
                <asp:CheckBox runat="server" ID="cbEpic" Text="에픽화" 
                    oncheckedchanged="cbEpic_CheckedChanged" AutoPostBack="true" />
                &nbsp;                
                <asp:CheckBox runat="server" ID="cbNormal" Text="일반화" 
                    oncheckedchanged="cbNormal_CheckedChanged" AutoPostBack="true" />
                &nbsp;                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                [Passive] <br />
                <asp:Label runat="server" ID="lblPassive"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" border="1" width="100%">
                <tr>
                    <td colspan="2">[기본정보]</td>
                    <td colspan="2">[스텟] <asp:Label runat="server" ID="lblStat"></asp:Label></td>                    
                </tr>
                <tr>
                    <td style="width:60px;" rowspan="2">체력</td>
                    <td style="width:60px;" rowspan="2"><asp:Label runat="server" ID="lblbHealth"></asp:Label></td>                                        
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtHealth" Width="30px" MaxLength="3"></asp:TextBox>
                        <asp:Button runat="server" ID="btnHealth1" Text="+1" 
                            onclick="btnHealth1_Click" />
                        <asp:Button runat="server" ID="btnHealth5" Text="+5" 
                            onclick="btnHealth5_Click" />
                        <asp:Button runat="server" ID="btnHealth10" Text="+10" 
                            onclick="btnHealth10_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">                        
                        <asp:Button runat="server" ID="btnHealth50" Text="+50" 
                            onclick="btnHealth50_Click" />
                        <asp:Button runat="server" ID="btnHealth100" Text="+100" 
                            onclick="btnHealth100_Click" />
                        <asp:Button runat="server" ID="btnHealthALL" Text="+ALL" 
                            onclick="btnHealthALL_Click" />                            
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">공격력</td>
                    <td rowspan="2"><asp:Label runat="server" ID="lblbStrong1"></asp:Label></td>                    
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtStrong1" Width="30px" MaxLength="3"></asp:TextBox>
                        <asp:Button runat="server" ID="btnStrong1_1" Text="+1" 
                            onclick="btnStrong1_1_Click" />
                        <asp:Button runat="server" ID="btnStrong1_5" Text="+5" 
                            onclick="btnStrong1_5_Click" />
                        <asp:Button runat="server" ID="btnStrong1_10" Text="+10" 
                            onclick="btnStrong1_10_Click" />                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnStrong1_50" Text="+50" 
                            onclick="btnStrong1_50_Click" />
                        <asp:Button runat="server" ID="btnStrong1_100" Text="+100" onclick="btnStrong1_100_Click" 
                            />
                        <asp:Button runat="server" ID="btnStrong1_ALL" Text="+ALL" onclick="btnStrong1_ALL_Click" 
                            />
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">방어</td>
                    <td rowspan="2"><asp:Label runat="server" ID="lblbDefense"></asp:Label></td>                    
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtDefense" Width="30px" MaxLength="3"></asp:TextBox>
                        <asp:Button runat="server" ID="btnDefense1" Text="+1" 
                            onclick="btnDefense1_Click" />
                        <asp:Button runat="server" ID="btnDefense5" Text="+5" 
                            onclick="btnDefense5_Click" />
                        <asp:Button runat="server" ID="btnDefense10" Text="+10" 
                            onclick="btnDefense10_Click" />                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnDefense50" Text="+50" 
                            onclick="btnDefense50_Click" />
                        <asp:Button runat="server" ID="btnDefense100" Text="+100" onclick="btnDefense100_Click" 
                            />
                        <asp:Button runat="server" ID="btnDefenseALL" Text="+ALL" onclick="btnDefenseALL_Click" 
                            />
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">카공</td>
                    <td rowspan="2"><asp:Label runat="server" ID="lblbStrong2"></asp:Label></td>                    
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtStrong2" Width="30px" MaxLength="3"></asp:TextBox>
                        <asp:Button runat="server" ID="btnStrong2_1" Text="+1" 
                            onclick="btnStrong2_1_Click" />
                        <asp:Button runat="server" ID="btnStrong2_5" Text="+5" 
                            onclick="btnStrong2_5_Click"/>
                        <asp:Button runat="server" ID="btnStrong2_10" Text="+10" 
                            onclick="btnStrong2_10_Click"/>                        
                    </td>
                </tr>
                <tr>                    
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnStrong2_50" Text="+50" 
                            onclick="btnStrong2_50_Click" />
                        <asp:Button runat="server" ID="btnStrong2_100" Text="+100" onclick="btnStrong2_100_Click" 
                            />
                        <asp:Button runat="server" ID="btnStrong2_ALL" Text="+ALL" onclick="btnStrong2_ALL_Click" 
                            />
                    </td>
                </tr>
                </table>                                                                 
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" border="1" width="100%">
                <tr>
                    <td>                        
                        <asp:Button runat="server" ID="btnEquipment_12" Text="12강" 
                            onclick="btnEquipment_12_Click"/>
                            &nbsp;
                        <asp:Button runat="server" ID="btnEquipment_14" Text="14강" 
                            onclick="btnEquipment_14_Click"/>
                            &nbsp;
                        <asp:Button runat="server" ID="btnEquipment_16" Text="16강"
                            onclick="btnEquipment_16_Click"/>
                            &nbsp;
                        <asp:Button runat="server" ID="btnEquipment_0" Text="18강"
                            onclick="btnEquipment_18_Click"/>
                            &nbsp;
                        <asp:Button runat="server" ID="Button1" Text="20강"
                            onclick="btnEquipment_20_Click"/>                            
                    </td>
                </tr>
                <tr>                    
                    <td>
                        <asp:RadioButton runat="server" ID="rbUpgrade1_100" Text="영웅" Checked="true" GroupName="UPGRADE1" />
                        <asp:RadioButton runat="server" ID="rbUpgrade1_110" Text="각성" GroupName="UPGRADE1"/>
                        <asp:RadioButton runat="server" ID="rbUpgrade1_120" Text="수호" GroupName="UPGRADE1"/>
                        <asp:RadioButton runat="server" ID="rbUpgrade1_Legend" Text="전설" GroupName="UPGRADE1"/>
                        <br />
                        [장비1]
                        <asp:DropDownList runat="server" ID="ddlEquipment1" Width="100">
                        <asp:ListItem Text="갑옷" Value="HEALTH" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="검" Value="STRONG1"></asp:ListItem>
                        <asp:ListItem Text="방패" Value="DEFENSE"></asp:ListItem>
                        <asp:ListItem Text="반지" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment1_basic" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnEquipment1_basic_plus" Text="+1" 
                            onclick="btnEquipment1_basic_plus_Click" />
                        <asp:Button runat="server" ID="btnEquipment1_basic_minus" Text="-1" 
                            onclick="btnEquipment1_basic_minus_Click" />                        
                        <br />                    
                        [옵션1]
                        <asp:DropDownList runat="server" ID="ddlEquipment1_option1" Width="100">
                        <asp:ListItem Text="체력" Value="HEALTH"></asp:ListItem>
                        <asp:ListItem Text="공격력" Value="STRONG1"></asp:ListItem>
                        <asp:ListItem Text="방어" Value="DEFENSE"></asp:ListItem>
                        <asp:ListItem Text="카드공격력" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment1_option1" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnEquipment1_option1_plus" Text="+1" 
                            onclick="btnEquipment1_option1_plus_Click" />
                        <asp:Button runat="server" ID="btnEquipment1_option1_minus" Text="-1" 
                            onclick="btnEquipment1_option1_minus_Click" />                        
                        <br />
                        [옵션2]
                        <asp:DropDownList runat="server" ID="ddlEquipment1_option2" Width="100">
                        <asp:ListItem Text="체력" Value="HEALTH"></asp:ListItem>
                        <asp:ListItem Text="공격력" Value="STRONG1"></asp:ListItem>
                        <asp:ListItem Text="방어" Value="DEFENSE"></asp:ListItem>
                        <asp:ListItem Text="카드공격력" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment1_option2" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnEquipment1_option2_plus" Text="+1" 
                            onclick="btnEquipment1_option2_plus_Click" />
                        <asp:Button runat="server" ID="btnEquipment1_option2_minus" Text="-1" 
                            onclick="btnEquipment1_option2_minus_Click" />
                    </td>
                </tr>
                <tr>                    
                    <td>
                        <asp:RadioButton runat="server" ID="rbUpgrade2_100" Text="영웅" Checked="true" GroupName="UPGRADE2" />
                        <asp:RadioButton runat="server" ID="rbUpgrade2_110" Text="각성" GroupName="UPGRADE2"/>
                        <asp:RadioButton runat="server" ID="rbUpgrade2_120" Text="수호" GroupName="UPGRADE2"/>
                        <asp:RadioButton runat="server" ID="rbUpgrade2_Legend" Text="전설" GroupName="UPGRADE2"/>
                        <br />
                        [장비2]
                        <asp:DropDownList runat="server" ID="ddlEquipment2" Width="100">
                        <asp:ListItem Text="갑옷" Value="HEALTH"></asp:ListItem>
                        <asp:ListItem Text="검" Value="STRONG1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="방패" Value="DEFENSE"></asp:ListItem>
                        <asp:ListItem Text="반지" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment2_basic" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="txtEquipment2_basic_plus" Text="+1" 
                            onclick="txtEquipment2_basic_plus_Click" />
                        <asp:Button runat="server" ID="txtEquipment2_basic_minus" Text="-1" 
                            onclick="txtEquipment2_basic_minus_Click" />                        
                        <br />                    
                        [옵션1]
                        <asp:DropDownList runat="server" ID="ddlEquipment2_option1" Width="100">
                        <asp:ListItem Text="체력" Value="HEALTH"></asp:ListItem>
                        <asp:ListItem Text="공격력" Value="STRONG1"></asp:ListItem>
                        <asp:ListItem Text="방어" Value="DEFENSE"></asp:ListItem>
                        <asp:ListItem Text="카드공격력" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment2_option1" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnEquipment2_option1_plus" Text="+1" 
                            onclick="btnEquipment2_option1_plus_Click"/>
                        <asp:Button runat="server" ID="btnEquipment2_option1_minus" Text="-1" 
                            onclick="btnEquipment2_option1_minus_Click" />
                        <br />
                        [옵션2]
                        <asp:DropDownList runat="server" ID="ddlEquipment2_option2" Width="100">
                        <asp:ListItem Text="체력" Value="HEALTH"></asp:ListItem>
                        <asp:ListItem Text="공격력" Value="STRONG1"></asp:ListItem>
                        <asp:ListItem Text="방어" Value="DEFENSE"></asp:ListItem>
                        <asp:ListItem Text="카드공격력" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment2_option2" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnEquipment2_option2_plus" Text="+1" 
                            onclick="btnEquipment2_option2_plus_Click" />
                        <asp:Button runat="server" ID="btnEquipment2_option2_minus" Text="-1" 
                            onclick="btnEquipment2_option2_minus_Click" />
                    </td>
                </tr>
                <tr>                    
                    <td>
                        <asp:RadioButton runat="server" ID="rbUpgrade3_100" Text="영웅" Checked="true" GroupName="UPGRADE3" />
                        <asp:RadioButton runat="server" ID="rbUpgrade3_110" Text="각성" GroupName="UPGRADE3"/>
                        <asp:RadioButton runat="server" ID="rbUpgrade3_120" Text="수호" GroupName="UPGRADE3"/>
                        <asp:RadioButton runat="server" ID="rbUpgrade3_Legend" Text="전설" GroupName="UPGRADE3"/>
                        <br />
                        [장비3]
                        <asp:DropDownList runat="server" ID="ddlEquipment3" Width="100">
                        <asp:ListItem Text="갑옷" Value="HEALTH"></asp:ListItem>
                        <asp:ListItem Text="검" Value="STRONG1"></asp:ListItem>
                        <asp:ListItem Text="방패" Value="DEFENSE" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="반지" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment3_basic" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnEquipment3_basic_plus" Text="+1" 
                            onclick="btnEquipment3_basic_plus_Click" />
                        <asp:Button runat="server" ID="btnEquipment3_basic_minus" Text="-1" 
                            onclick="btnEquipment3_basic_minus_Click" />                        
                        <br />                    
                        [옵션1]
                        <asp:DropDownList runat="server" ID="ddlEquipment3_option1" Width="100">
                        <asp:ListItem Text="체력" Value="HEALTH"></asp:ListItem>
                        <asp:ListItem Text="공격력" Value="STRONG1"></asp:ListItem>
                        <asp:ListItem Text="방어" Value="DEFENSE"></asp:ListItem>
                        <asp:ListItem Text="카드공격력" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment3_option1" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnEquipment3_option1_plus" Text="+1" 
                            onclick="btnEquipment3_option1_plus_Click" />
                        <asp:Button runat="server" ID="btnEquipment3_option1_minus" Text="-1" 
                            onclick="btnEquipment3_option1_minus_Click" />
                        <br />
                        [옵션2]
                        <asp:DropDownList runat="server" ID="ddlEquipment3_option2" Width="100">
                        <asp:ListItem Text="체력" Value="HEALTH"></asp:ListItem>
                        <asp:ListItem Text="공격력" Value="STRONG1"></asp:ListItem>
                        <asp:ListItem Text="방어" Value="DEFENSE"></asp:ListItem>
                        <asp:ListItem Text="카드공격력" Value="STRONG2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEquipment3_option2" Width="30px" MaxLength="2" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnEquipment3_option2_plus" Text="+1" 
                            onclick="btnEquipment3_option2_plus_Click" />
                        <asp:Button runat="server" ID="btnEquipment3_option2_minus" Text="-1" 
                            onclick="btnEquipment3_option2_minus_Click" />
                    </td>
                </tr>
                </table>
            </td>            
        </tr>
        <tr>
            <td>            
                <input runat="server" id="btnShow2" type="button" name="btnShow2" onclick="showDisplay()" value="Full Display" disabled="true" />                                
                &nbsp;                
                <asp:Button ID="btnClear" runat="server" Text="초기화 (스텟만 초기화)" onclick="btnClear_Click"/>
                <br />
                <asp:Button ID="btnRun" runat="server" Text="실행" onclick="btnRun_Click"/>                                
                &nbsp;                
                카드명 : <asp:TextBox runat="server" ID="txtBattleName" Width="60"></asp:TextBox>
                <asp:Button ID="btnFightSave" runat="server" Text="시뮬용 저장" 
                    onclick="btnFightSave_Click"/>&nbsp;                
                <br />
                <asp:DropDownList runat="server" ID="ddlCardSimulInfo" AutoPostBack="true" Width="250"
                    onselectedindexchanged="ddlCardSimulInfo_SelectedIndexChanged"></asp:DropDownList>
                &nbsp;
                <asp:Button ID="btnSimulSave" runat="server" Text="신규" 
                    onclick="btnSimulSave_Click"/>
                <br />
                <asp:Label runat="server" ID="lblMsg" ForeColor="Tomato"></asp:Label>                
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" border="1" width="100%">
                <tr>
                    <td colspan="2" align="center">최종 수치</td>
                </tr>
                <tr>
                    <td style="width:100px;">체력</td>
                    <td><asp:Label runat="server" ID="lblResultHealth"></asp:Label></td>                    
                </tr>
                <tr>
                    <td style="width:100px;">공격력</td>
                    <td><asp:Label runat="server" ID="lblResultStrong1"></asp:Label></td>                    
                </tr>
                <tr>
                    <td style="width:100px;">방어</td>
                    <td><asp:Label runat="server" ID="lblResultDefense"></asp:Label></td>                    
                </tr>
                <tr>
                    <td style="width:100px;">카드공격력</td>
                    <td><asp:Label runat="server" ID="lblResultStrong2"></asp:Label></td>                    
                </tr>
                <tr>
                    <td colspan="2" align="center">검 수치 (분노) (투쟁) (분노+투쟁)</td>
                </tr>
                <tr>
                    <td style="width:100px;">1검</td>
                    <td><asp:Label runat="server" ID="lblResultAttack1"></asp:Label></td>                    
                </tr>
                <tr>
                    <td style="width:100px;">2검</td>
                    <td><asp:Label runat="server" ID="lblResultAttack2"></asp:Label></td>                    
                </tr>
                <tr>
                    <td style="width:100px;">3검</td>
                    <td><asp:Label runat="server" ID="lblResultAttack3"></asp:Label></td>                    
                </tr>
                <tr>
                    <td style="width:100px;">4검</td>
                    <td><asp:Label runat="server" ID="lblResultAttack4"></asp:Label></td>                    
                </tr>
                <tr>
                    <td style="width:100px;">5검</td>
                    <td><asp:Label runat="server" ID="lblResultAttack5"></asp:Label></td>                    
                </tr>
                <tr>
                    <td colspan="2" align="center">스킬 수치</td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label runat="server" ID="lblResultSkill"></asp:Label>
                    </td>
                </tr>                
                </table>
            </td>
        </tr>        
        </table>                                
        </ContentTemplate>
        </asp:updatepanel>
    </div>            
    </form>
</body>
</html>
