<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Venture_List.aspx.cs" Inherits="Venture_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head runat="server">
    <title>투기 시뮬레이터</title>
<link rel="stylesheet" href="Scripts/development-bundle/themes/base/jquery.ui.all.css">
<script src="Scripts/development-bundle/jquery-1.5.1.js"></script>
<script src="Scripts/development-bundle/external/jquery.bgiframe-2.1.2.js"></script>
<script src="Scripts/development-bundle/ui/jquery.ui.core.js"></script>
<script src="Scripts/development-bundle/ui/jquery.ui.widget.js"></script>
<script src="Scripts/development-bundle/ui/jquery.ui.mouse.js"></script>
<script src="Scripts/development-bundle/ui/jquery.ui.draggable.js"></script>
<script src="Scripts/development-bundle/ui/jquery.ui.position.js"></script>
<script src="Scripts/development-bundle/ui/jquery.ui.resizable.js"></script>
<script src="Scripts/development-bundle/ui/jquery.ui.dialog.js"></script>
<script language="javascript">
    
    $(function() {
		$( "#dialog" ).dialog({
		    autoOpen: false,
		    height: 200,
            width: 300,
		    modal: true
		});
	});

	function openView(n) {
	    document.getElementById("dialog").innerHTML = n.replace(/,/g, "<br/>");	    
	    
        $("#dialog").dialog("open");
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>            
        <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>    
        <asp:updatepanel ID="Updatepanel1" runat="server">
        <ContentTemplate>                                 
        
        <table border="1" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height:200px; text-align:center;">
                <asp:Image ID="imgMy1" runat="server" />
                <asp:Image ID="imgMy2" runat="server" />
                <asp:Image ID="imgMy3" runat="server" />                
                <br />
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td style="height:50px; text-align:center;">                
                <asp:Button runat="server" ID="btnVenture_Setting" Text="셋팅" 
                    onclick="btnVenture_Setting_Click" />
                &nbsp;
                <asp:Button runat="server" ID="btnUpdate" Text="갱신" onclick="btnUpdate_Click" />
                &nbsp;
                <asp:Button runat="server" ID="btnClose" Text="나가기" onclick="btnClose_Click"/>
            </td>
        </tr>
        <tr>
            <td style="text-align:center; vertical-align:top;">
                <asp:Label runat="server" ID="lblBattleMsg"></asp:Label>                                
                <br />
                <asp:Repeater ID="Repeater1" runat="server" 
                    onitemdatabound="Repeater1_ItemDataBound" 
                    onitemcommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <table border="1" cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblInfo"></asp:Label>
                            <asp:HiddenField runat="server" ID="hidSeq" Value='<%# DataBinder.Eval(Container.DataItem, "SEQ") %>' />
                            <asp:HiddenField runat="server" ID="hidUserSeq" Value='<%# DataBinder.Eval(Container.DataItem, "USER_SEQ") %>' />                            
                            <asp:HiddenField runat="server" ID="hidPoint" Value='<%# DataBinder.Eval(Container.DataItem, "POINT") %>' />                                                        
                        </td>
                        <td>                            
                            <asp:Image runat="server" ID="img1" />
                            <asp:Image runat="server" ID="img2" />
                            <asp:Image runat="server" ID="img3" />
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="BATTLE" ID="btnBattle" Text="전투" />
                        </td>
                    </tr>
                    </table>                    
                </ItemTemplate>
                </asp:Repeater>                
            </td>
        </tr>
        <tr>            
            <td style="text-align:center;">                
                <table border="0" width="100%">
                <tr>
                    <td>                    
                        <asp:TextBox runat="server" ID="txtLeft" Width="100%" Height="200" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRight" Width="100%" Height="200" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                </table>
            </td>
        </tr>
        </table>                                                
        
        </ContentTemplate>        
        </asp:updatepanel>        
        
        <div runat="server" id="dialog" title="CARD INFO">
	        
        </div>
    </div>
    </form>
</body>
</html>
