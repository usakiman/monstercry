<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhotoGuideView.aspx.cs" Inherits="PhotoGuideView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densitydpi=medium-dpi" />
<head runat="server">
    <title>셋팅 정보</title>    
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
        <a href="javascript:self.close();">종료</a>
        <br />
        <asp:DataList ID="DataList1" runat="server" 
            RepeatColumns="1" RepeatDirection="Horizontal" 
            onitemdatabound="DataList1_ItemDataBound">
        <ItemTemplate>
        <table border="1" cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblBasicInfo"></asp:Label>
            </td>
        </tr>
        </table>
        </ItemTemplate>    
        </asp:DataList>
        
    </div>
    </form>
</body>
</html>
