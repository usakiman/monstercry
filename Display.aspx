<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Display.aspx.cs" Inherits="Display"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head runat="server">
    <title>모아보기</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table cellpadding="0" cellspacing="0" border="1" width="100%">        
    <tr>
        <td style="height:50px; text-align:center; font-size:larger;">
            <asp:Label runat="server" ID="lblCardName"></asp:Label>
            <asp:Label runat="server" ID="lblLevel"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:40px; text-align:center; font-size:large;">
            <asp:Label runat="server" ID="lblPassive"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align:center;">
            [스텟] <br />
            체 : <asp:Label runat="server" ID="lblStat1"></asp:Label><br />
            공 : <asp:Label runat="server" ID="lblStat2"></asp:Label><br />
            방 : <asp:Label runat="server" ID="lblStat3"></asp:Label><br />
            카 : <asp:Label runat="server" ID="lblStat4"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align:center;">
            [최종] <br />
            체 : <asp:Label runat="server" ID="lblResult1"></asp:Label><br />
            공 : <asp:Label runat="server" ID="lblResult2"></asp:Label><br />
            방 : <asp:Label runat="server" ID="lblResult3"></asp:Label><br />
            카 : <asp:Label runat="server" ID="lblResult4"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align:center;">
            1검 : <asp:Label runat="server" ID="lblAttack1"></asp:Label><br />
            2검 : <asp:Label runat="server" ID="lblAttack2"></asp:Label><br />
            3검 : <asp:Label runat="server" ID="lblAttack3"></asp:Label><br />
            4검 : <asp:Label runat="server" ID="lblAttack4"></asp:Label><br />
            5검 : <asp:Label runat="server" ID="lblAttack5"></asp:Label><br />
        </td>
    </tr>
    <tr>
        <td style="text-align:center;">
            [장비] <br />
            <asp:Label runat="server" ID="lblEquipment1"></asp:Label><br />
            <asp:Label runat="server" ID="lblEquipment2"></asp:Label><br />
            <asp:Label runat="server" ID="lblEquipment3"></asp:Label><br />
        </td>
    </tr>
    <tr>
        <td align="center">
            <input type="button" value="돌아가기" style="width:80%;" onclick="javascript:self.close();" />                
        </td>
    </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
