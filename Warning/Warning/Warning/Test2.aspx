<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test2.aspx.cs" Inherits="Warning.Test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Upload" runat="server" OnClick="Upload_Click" Text="Upload" />
        </asp:Panel>
    </form>
</body>
</html>
