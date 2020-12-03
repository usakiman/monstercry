<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head runat="server">
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
</script>
</head>
<body>
<center>
    <form id="form1" runat="server">
    <div>                       
        <table cellpadding="1" cellspacing="2" border="1" width="100%" style="text-align:center;">
        <tr>
            <td colspan="2" style="text-align:center;">
                <a href="https://drive.google.com/file/d/0B1IDsw9ayJWhUldsZTFMNlZ3aXc/edit?usp=sharing" target="_blank">
                    몬스터크라이 모든 카드 목록 Excel (PC)
                </a>                
                <br />
                <a href="Default2.aspx" target="_blank">
                    극혐.. 전탑 층별 완료 퍼센트계산
                </a>
                <br /><br />
            </td>
        </tr>        
        <tr>
            <td>   
                ID <asp:TextBox runat="server" ID="txtID" Width="80" TabIndex="1"></asp:TextBox>    
            </td>
            <td rowspan="2" style="width:60%">
                <asp:Button runat="server" ID="btnLogin" Text="로그인" onclick="btnLogin_Click" TabIndex="3" Width="60%" Height="40" />
            </td>
        </tr>
        <tr>
            <td>
                PW <asp:TextBox runat="server" ID="txtPwd" TextMode="Password" Width="80" TabIndex="2"></asp:TextBox>    
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblMsg" ForeColor="Tomato"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnGotoEmu" Text="시뮬레이터 바로가기" Height="50" Width="180"
                    onclick="btnGotoEmu_Click" />
                    &nbsp;
                <asp:Button runat="server" ID="btnGotoPhoto" Text="몬스터 도감" Height="50" 
                    Width="90" onclick="btnGotoPhoto_Click"/>
            </td>
        </tr>
        <!--
        <tr>
            <td colspan="2" style="text-align:center;">
                같은 살사 동호회에 있는 아이들인데 요번에 IDO 개인전 1등 해서 올려봤음! 잘한다~~ㅋ<br />
                출처 : http://www.salsafocus.com/ <br /><br />
                <iframe width="100%" height="315" src="//www.youtube.com/embed/YgIOSG-krlw" frameborder="0" allowfullscreen></iframe>
            </td>
        </tr>
        -->
        <tr height="20">
            <td colspan="2" align="center">메모 @_@ (40자 제한있어요)</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <asp:TextBox ID="txtInputMsg" Width="40%" runat="server" MaxLength="40"></asp:TextBox>
                &nbsp;<asp:Button ID="btnInputMsg" runat="server" Text="Memo" 
                    onclick="btnInputMsg_Click" />
                <br />                
                <div style="width:100%; height:150px; overflow:auto; text-align:center;">
                    <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" HorizontalAlign="Center" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black">                       
                        <RowStyle BackColor="White" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />     
                    <Columns>
                        <asp:BoundField DataField="Memo" HeaderStyle-Font-Size="Small" HeaderText="Memo" />
                        <asp:BoundField DataField="cre_date" HeaderStyle-Font-Size="Small" HeaderText="Time" />
                    </Columns>              
                    </asp:GridView>
                </div>                
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label runat="server" ID="lbllogMsg"></asp:Label>
            </td>
        </tr>
        </table>
    </div>        
    </form>
</center>    

<script>
    (function(i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function() {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-64154770-1', 'auto');
    ga('send', 'pageview');

</script>

</body>
</html>
