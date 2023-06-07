<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Warning.WebForm1" %>

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
            <asp:Panel ID="Panel3" runat="server" Font-Size="XX-Large" HorizontalAlign="Center">
                <asp:Label ID="Label1" runat="server" Height="30px" Text="ใบเตือน"></asp:Label>
            </asp:Panel>
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:FileUpload ID="FileUpload1" runat="server" Height="35px" Width="75%" />
            <asp:Button ID="Button1" runat="server" Text="แสดง" OnClick="Button1_Click" Font-Size="X-Large" Height="35px" Width="20%" />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Font-Size="X-Large" HorizontalAlign="Center">
            
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:BoundField DataField="รหัส" HeaderText="รหัส" />
                    <asp:BoundField DataField="รหัสแผนก" HeaderText="รหัสแผนก" />
                    <asp:BoundField DataField="ชื่อพนักงาน" HeaderText="ชื่อพนักงาน" />
                    <asp:BoundField DataField="วันที่" HeaderText="วันที่" />
                    <asp:BoundField DataField="รหัสกะ" HeaderText="รหัสกะ" />
                    <asp:BoundField DataField="ชื่อกะ" HeaderText="ชื่อกะ" />
                    <asp:BoundField DataField="รายละเอียดเวลารูดบัตร" HeaderText="รายละเอียดเวลารูดบัตร" />
                    <asp:BoundField DataField="ประเภทเงินหัก" HeaderText="ประเภทเงินหัก" />
                    <asp:BoundField DataField="ประเภท" HeaderText="ประเภท" />
                    <asp:BoundField DataField="จำนวน" HeaderText="จำนวน" />
                    <asp:BoundField DataField="หน่วยนาที" HeaderText="หน่วยนาที" />

                </Columns>
                
            </asp:GridView>
                
        </asp:Panel>
    </form>
</body>
</html>
