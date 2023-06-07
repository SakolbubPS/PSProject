<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrint.aspx.cs" Inherits="Warning.frmPrint" %>

<%@ Register assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" CloseAction="CloseButton" ShowHeader="False">
                <ContentCollection>
<dx:PopupControlContentControl runat="server"></dx:PopupControlContentControl>
</ContentCollection>
            </dx:ASPxPopupControl>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
