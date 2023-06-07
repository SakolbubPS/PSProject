<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarningSearch.aspx.cs" Inherits="Warning.WarningSearch" %>

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
        <asp:SqlDataSource ID="SQL_DataWarning" runat="server" ConnectionString="<%$ ConnectionStrings:MysqlPSConnection %>" ProviderName="<%$ ConnectionStrings:MysqlPSConnection.ProviderName %>" SelectCommand="SELECT Employee_ID,Employee_Name,Employee_LName FROM ps_employee"></asp:SqlDataSource>
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
            <Items>
                <dx:LayoutGroup Caption="" ColCount="3" Height="35px">
                    <Items>
                        <dx:LayoutItem Caption="ค้นหาข้อมูล">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" DataSourceID="SqlDataSource1" Height="36px" OnButtonClick="ASPxGridLookup1_ButtonClick" OnTextChanged="ASPxGridLookup1_TextChanged" Width="456px">
                                        <GridViewProperties>
                                            <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                        </GridViewProperties>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MysqlPSConnection %>" ProviderName="<%$ ConnectionStrings:MysqlPSConnection.ProviderName %>" SelectCommand="SELECT UsreID FROM showwaring"></asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionStyle Font-Size="X-Large">
                            </CaptionStyle>
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
                        <dx:GridViewDataTextColumn Caption="รหัสพนักงาน" VisibleIndex="0" FieldName="L_UsreID">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="ชื่อ - นามสกุล" VisibleIndex="1" FieldName="L_UsreName">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="แผนก" VisibleIndex="2" FieldName="L_Department">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="เดือนที่สาย" VisibleIndex="3" FieldName="L_Date_Blame">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Larger">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="จำนวนครั้งที่สาย" VisibleIndex="4" FieldName="L_Quantity">
                            <HeaderStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" />
                            <CellStyle Font-Size="Large">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="ประเภทที่สาย" VisibleIndex="5" FieldName="L_Blame">
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
