<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AISetting.aspx.cs" Inherits="AISetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head runat="server">
    <title>AI 및 스킬 셋팅</title>
<script language="javascript">

    function deleteItem() {
        if(!confirm("삭제합니까?")) {
            return false;
        }
        return true;
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="1" width="100%">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height:50px;">
                리스트 : <asp:DropDownList runat="server" ID="ddlBattleList" AutoPostBack="true" 
                    onselectedindexchanged="ddlBattleList_SelectedIndexChanged"></asp:DropDownList>
                <br />
                AI : <asp:DropDownList runat="server" ID="ddlAIList" AutoPostBack="true" 
                    onselectedindexchanged="ddlAIList_SelectedIndexChanged"></asp:DropDownList>
                <br />
                스킬1 : <asp:DropDownList runat="server" ID="ddlSkill1" AutoPostBack="true" 
                    onselectedindexchanged="ddlSkill1_SelectedIndexChanged"></asp:DropDownList>
                <br />
                스킬2 : <asp:DropDownList runat="server" ID="ddlSkill2" AutoPostBack="true" 
                    onselectedindexchanged="ddlSkill2_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr runat="server" id="tr1">
            <td>
                1순위 : <asp:Label runat="server" ID="lblAI_1"></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="tr2">
            <td>
                2순위 : <asp:Label runat="server" ID="lblAI_2"></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="tr3">
            <td>
                3순위 : <asp:Label runat="server" ID="lblAI_3"></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="tr4">
            <td>
                4순위 : <asp:Label runat="server" ID="lblAI_4"></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="tr5">        
            <td>
                방어 % : 
                <asp:DropDownList runat="server" ID="ddlDefensePer">
                <asp:ListItem Text="무조건 사용" Value="ALL"></asp:ListItem>
                <asp:ListItem Text="90% 사용" Value="90"></asp:ListItem>
                <asp:ListItem Text="80% 사용" Value="80"></asp:ListItem>
                <asp:ListItem Text="70% 사용" Value="70"></asp:ListItem>
                <asp:ListItem Text="60% 사용" Value="60"></asp:ListItem>
                <asp:ListItem Text="50% 사용" Value="50"></asp:ListItem>
                <asp:ListItem Text="40% 사용" Value="40"></asp:ListItem>
                <asp:ListItem Text="30% 사용" Value="30"></asp:ListItem>
                <asp:ListItem Text="20% 사용" Value="20"></asp:ListItem>
                <asp:ListItem Text="10% 사용" Value="10"></asp:ListItem>
                <asp:ListItem Text="0% 사용" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr runat="server" id="tr6">
            <td>                
                <asp:Button runat="server" ID="btnUpdate" Text="저장" onclick="btnUpdate_Click" />&nbsp;
                <asp:Button runat="server" ID="btnDelete" Text="삭제" onclick="btnDelete_Click"/>&nbsp;
                <asp:Button runat="server" ID="btnGoBack" Text="돌아가기" 
                    onclick="btnGoBack_Click"/>
                <br />
                
                ※ AI설명 : <br />
                공격형 재주꾼은 스킬1 -> 공 -> 스킬2 -> 방 <br />
                방어형 재주꾼은 스킬1 -> 방 -> 스킬2 -> 공 <br />
                등과 같이 실제 게임상에서 가장 효율적인 순서로 셋팅해놓았습니다
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
