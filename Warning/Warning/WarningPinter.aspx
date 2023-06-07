<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarningPinter.aspx.cs" Inherits="Warning.WarningPinter" %>

<%@ Register assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server" Height="1000px" ReportSourceId="Warning.XtraReport3">
            </dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
