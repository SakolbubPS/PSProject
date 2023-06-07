<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PSWarning.aspx.cs" Inherits="Warning.WebForm1" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="~/img/PSWarning.ico" rel="shortcut icon" type="image/x-icon" />
    <script>
        function Confirm() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("ยืนยันการทำรายการ?")) {
            confirm_value.value = "Yes";
        } else {
            confirm_value.value = "No";
        }
        document.forms[0].appendChild(confirm_value);
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         
            <asp:ScriptManager ID="ScriptManager1" runat="server">  </asp:ScriptManager>
            <h1>TESSSSSSSSSSSSSSSSSSSSSSSSSST</h1>


        <div>            
            <asp:Panel ID="Panel3" runat="server" Font-Size="XX-Large" HorizontalAlign="Center">
            <asp:Label ID="Label1" runat="server" Height="30px" Text="อัพโหลดข้อมูลใบเตือน"></asp:Label>
            </asp:Panel>
        </div>
        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="75px">
            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Theme="Metropolis" Width="100%" Height="72px">
                <Items>
                    <dx:LayoutGroup Caption="" ColCount="5">
                        <Items>
                            <dx:LayoutItem Caption="อัพโหลดไฟล์.xlsx">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Height="35px" Width="100%" Font-Size="X-Large" />
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <CaptionStyle Font-Size="X-Large">
                                </CaptionStyle>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxButton ID="BTSave1" runat="server" EnableTheming="True" Font-Bold="True" Font-Size="X-Large" Height="35px" OnClick="BTSave1_Click" Text="บันทึก" Theme="Metropolis" Width="20%" BackColor="#00CC00">
                                            <ClientSideEvents Click="function(s, e) {
	                                            Confirm();
                                            }" />
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" Name="BT_Search">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxButton ID="ASPxFormLayout1_E1" runat="server" BackColor="#FF9999" Font-Bold="True" Font-Size="X-Large" Height="35px" OnClick="ASPxFormLayout1_E1_Click" Text="ค้นหา" Theme="Metropolis" Width="25%">
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" Name="BT_UpDate">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxButton ID="ASPxFormLayout1_E2" runat="server" BackColor="#FF33CC" Font-Bold="True" Font-Size="X-Large" Height="35px" OnClick="ASPxFormLayout1_E2_Click" Text="แก้ไข" Width="25%" Theme="Metropolis">
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxButton ID="BT_Call" runat="server" BackColor="#339966" Font-Bold="True" Font-Size="X-Large" Height="35px" OnClick="BT_Call_Click" Text="คำนวณ" Theme="Metropolis" Width="25%">
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Font-Size="X-Large" HorizontalAlign="Center" Height="80px">
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="แสดงข้อมูล"></asp:Label>
             <h1>TESSSSSSSSSSSSSSSSSSSSSSSSSST5555555555555555555555</h1>   
        </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server"  UpdateMode="Conditional">
                <ContentTemplate>
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="ASPxGridView1_RowCommand1" Theme="Material">
                        <SettingsPager PageSize="30">
                        </SettingsPager>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="รหัสพนักงาน" FieldName="WIDUser" ShowInCustomizationForm="True" VisibleIndex="0">
                                <HeaderStyle BackColor="#3399FF" Font-Size="X-Large" HorizontalAlign="Center" />
                                <CellStyle Font-Size="Large">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="รหัสแผนก" FieldName="WIDDepartment" ShowInCustomizationForm="True" VisibleIndex="2">
                                <HeaderStyle BackColor="#3399FF" Font-Size="X-Large" Font-Strikeout="False" HorizontalAlign="Center" />
                                <CellStyle Font-Size="Large">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ชื่อพนักงาน" FieldName="WUName" ShowInCustomizationForm="True" VisibleIndex="1">
                                <HeaderStyle BackColor="#3399FF" Font-Bold="False" Font-Size="X-Large" HorizontalAlign="Center" />
                                <CellStyle Font-Size="Large">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="วันที่สาย" FieldName="WDate" ShowInCustomizationForm="True" VisibleIndex="4" Visible="False">
                                <HeaderStyle BackColor="#3399FF" Font-Size="X-Large" HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="รหัสกะ" FieldName="WIDka" ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ชื่อกะและรายละเอียด" FieldName="WNameka" ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="เวลารูดบัตร" FieldName="WDetailsTime" ShowInCustomizationForm="True" VisibleIndex="7" Visible="False">
                                <HeaderStyle BackColor="#3399FF" Font-Size="X-Large" HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="รหัสเงินหัก" FieldName="WIDType" ShowInCustomizationForm="True" VisibleIndex="8" Visible="False">
                                <HeaderStyle BackColor="#3399FF" Font-Size="X-Large" HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ประเภทการหัก" FieldName="WWType " ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="จำนวน" FieldName="WNum" ShowInCustomizationForm="True" Visible="False" VisibleIndex="10">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ประเภทการสาย" FieldName="WcType" ShowInCustomizationForm="True" VisibleIndex="12">
                                <HeaderStyle BackColor="#3399FF" Font-Size="X-Large" HorizontalAlign="Center" />
                                <CellStyle Font-Size="Large">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="จำนวนครั้งที่สาย" VisibleIndex="11" FieldName="Wcount">
                                <HeaderStyle BackColor="#3399FF" Font-Size="X-Large" HorizontalAlign="Center" />
                                <CellStyle Font-Size="Large">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ชื่อแผนก" FieldName="DName" VisibleIndex="3">
                                <HeaderStyle BackColor="#3399FF" Font-Size="X-Large" Font-Strikeout="False" HorizontalAlign="Center" />
                                <CellStyle Font-Size="Large">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="พิมพ์" ShowInCustomizationForm="True" VisibleIndex="13" >
                                <DataItemTemplate>
                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="true" CommandName="Print" Font-Size="X-Large" RenderMode="Link" Text="พิมพ์" Theme="Material"    >
                                    </dx:ASPxButton>
                                    &nbsp;
                                    <dx:ASPxButton ID="ASPxButton8" runat="server" CommandName="End" Font-Size="X-Large" ForeColor="#33FF00" RenderMode="Link" Text="ยกเลิก" Theme="Material">     <%--<-------<<<<<<<<<-------->--%>
                                    </dx:ASPxButton>
                                </DataItemTemplate>
                                <HeaderStyle BackColor="#3399FF" Font-Bold="False" Font-Size="X-Large" HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </ContentTemplate>
        </asp:UpdatePanel>
                
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        </asp:UpdatePanel>
        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" CloseAction="CloseButton" Height="353px" ShowHeader="False" Width="1111px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="Metropolis">
            <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" EnableTheming="True" Theme="Metropolis" Width="1033px">
        <Items>
            <dx:LayoutGroup Caption="">
                <Items>
                    <dx:LayoutItem Caption="รหัสพนักงาน">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <asp:DropDownList ID="CmdWUser" runat="server" Height="35px" Width="90%"  DataTextField="W_IDUser" AutoPostBack="True" 
                                                    DataValueField="W_ID" OnSelectedIndexChanged="CmdWUser_SelectedIndexChanged">
                                </asp:DropDownList>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <HelpTextStyle Font-Bold="False">
                        </HelpTextStyle>
                        <ParentContainerStyle Font-Bold="True" Font-Size="X-Large">
                        </ParentContainerStyle>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="ชื่อ-นามสกุล">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="T_Name" runat="server" Height="35px" Width="90%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <ParentContainerStyle Font-Bold="True" Font-Size="X-Large">
                        </ParentContainerStyle>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="รหัสแผนก">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="T_IDDepartment" runat="server" Height="35px" Width="90%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <ParentContainerStyle Font-Bold="True" Font-Size="X-Large">
                        </ParentContainerStyle>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="วันที่สาย">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="T_Datein" runat="server" Height="35px" Width="90%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <ParentContainerStyle Font-Bold="True" Font-Size="X-Large">
                        </ParentContainerStyle>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="ชั่วโมงที่สาย">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="T_HOUR" runat="server" Height="35px" Width="90%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <ParentContainerStyle Font-Bold="True" Font-Size="X-Large">
                        </ParentContainerStyle>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="นาทีที่สาย">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="T_MINUTE" runat="server" Height="35px" Width="90%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <ParentContainerStyle Font-Bold="True" Font-Size="X-Large">
                        </ParentContainerStyle>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
            <dx:LayoutGroup Caption="" ColCount="3">
                <Items>
                    <dx:LayoutItem Caption="" HorizontalAlign="Center">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="BT_UPSave" runat="server" BackColor="#00CC00" Font-Bold="True" Font-Size="X-Large" Height="35px" HorizontalAlign="Center" Text="บันทึก" Theme="Metropolis" Width="50%" OnClick="BT_UPSave_Click">
                                <ClientSideEvents Click="function(s, e) {
	                             Confirm(); }" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" HorizontalAlign="Center">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="BT_Del" runat="server" BackColor="Red" Font-Bold="True" Font-Size="X-Large" OnClick="BT_Del_Click" Text="ลบข้อมูล" Theme="Metropolis">
                                <ClientSideEvents Click="function(s, e) {
	                             Confirm(); }" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" HorizontalAlign="Center">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="BT_Can" runat="server" BackColor="#FF9933" Font-Bold="True" Font-Size="X-Large" Height="35px" HorizontalAlign="Center" Text="ยกเลิก" Theme="Metropolis" Width="50%" OnClick="BT_Can_Click">

                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
                </dx:PopupControlContentControl>
</ContentCollection>
        </dx:ASPxPopupControl>






      
    </form>
</body>
</html>
