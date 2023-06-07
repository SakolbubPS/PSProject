<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarningUpdate.aspx.cs" Inherits="Warning.WarningUpdate" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

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
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
            <Items>
                <dx:LayoutGroup Caption="" ColCount="4" Height="35px">
                    <Items>
                        <dx:LayoutItem Caption="ค้นหาข้อมูล">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" DataSourceID="SqlDataSource1" Height="36px" OnButtonClick="ASPxGridLookup1_ButtonClick" OnTextChanged="ASPxGridLookup1_TextChanged" Width="456px" AutoGenerateColumns="False">
                                        <GridViewProperties>
                                            <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                        </GridViewProperties>
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="W_UName" ShowInCustomizationForm="True" VisibleIndex="0">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MysqlPSConnection %>" ProviderName="<%$ ConnectionStrings:MysqlPSConnection.ProviderName %>" SelectCommand="SELECT W_UName FROM ps_warning"></asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionStyle Font-Size="X-Large">
                            </CaptionStyle>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" Name="BT_Update">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="ASPxFormLayout1_E1" runat="server" BackColor="#9999FF" Font-Bold="True" Font-Size="X-Large" Text="บันทึกการแก้ไข" Theme="Metropolis">
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" Height="35px">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="ASPxFormLayout1_E2" runat="server" BackColor="#66FF99" Font-Bold="True" Font-Size="X-Large" Height="35px" Text="แสดงข้อมูล" Theme="Metropolis" Width="40%" OnClick="ASPxFormLayout1_E2_Click">
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" Height="35px">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="ASPxFormLayout1_E3" runat="server" BackColor="#66FFFF" Font-Bold="True" Font-Size="X-Large" Height="35px" Text="กลับหน้าหลัก" Theme="Metropolis" Width="40%" OnClick="ASPxFormLayout1_E3_Click">
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Visible="False" Width="100%" AutoGenerateColumns="False">
                    <SettingsPager PageSize="30">
                    </SettingsPager>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="รหัสพนักงาน" VisibleIndex="0" FieldName="IDUser">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="ชื่อ - นามสกุล" VisibleIndex="1" FieldName="UName">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="รหัสแผนก" VisibleIndex="2" FieldName="IDDepartment">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="วันที่สาย" VisibleIndex="3" FieldName="Date">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Larger">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="ชั่วโมงที่สาย" VisibleIndex="4" FieldName="HOUR">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="นาทีที่สาย" VisibleIndex="5" FieldName="MINUTE">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
