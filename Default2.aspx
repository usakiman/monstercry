<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>극혐... 층별 완료 퍼센트 계산..</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" cellpadding="1" cellspacing="1">
        <tr>
            <td>
                1층~100층
            </td>
            <td>
                101층~150층
            </td>
            <td>
                151층~180층
            </td>
            <td>
                181층~200층
            </td>
            <td>
                201층~250층
            </td>
            <td>
                1층~250층
            </td>
        </tr>                
        <tr>
            <td valign="top">
                <asp:Label runat="server" ID="lblMsg"></asp:Label>    
            </td>
            <td valign="top">
                <asp:Label runat="server" ID="lblMsg2"></asp:Label>    
            </td>
            <td valign="top">
                <asp:Label runat="server" ID="lblMsg3"></asp:Label>    
            </td>
            <td valign="top">
                <asp:Label runat="server" ID="lblMsg4"></asp:Label>    
            </td>
            <td valign="top">
                <asp:Label runat="server" ID="lblMsg5"></asp:Label>    
            </td>
            <td valign="top">
                <asp:Label runat="server" ID="lblMsg6"></asp:Label>    
            </td>
        </tr>
        </table>                       
    </div>
    </form>
</body>
</html>
