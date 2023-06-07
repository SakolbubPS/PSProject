<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Warning.test" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxSpreadsheet.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpreadsheet" tagprefix="dx" %>

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
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="3" Width="100%">
                        <Items>
                            <dx:EmptyLayoutItem>
                            </dx:EmptyLayoutItem>
                            <dx:LayoutItem Caption="" HorizontalAlign="Center">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxLabel runat="server" Font-Size="XX-Large" Text="โปรแกรมใบเตือน">
                                        </dx:ASPxLabel>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <ParentContainerStyle Font-Italic="False" Font-Size="XX-Large" Font-Bold="True">
                                </ParentContainerStyle>
                            </dx:LayoutItem>
                            <dx:EmptyLayoutItem>
                            </dx:EmptyLayoutItem>
                        </Items>
                    </dx:ASPxFormLayout>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <center>
                    <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" Width="100%">
                        <Items>
                            <dx:LayoutGroup Caption="" ColCount="3">
                                <Items>
                                    <dx:LayoutItem Caption="" HorizontalAlign="Right">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <asp:FileUpload ID="FileUpload1" runat="server" Height="30px" Width="100%" />
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <asp:Button ID="Button1" runat="server" Height="30px" Text="อัพโหลด" Width="100%" />
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <asp:Button ID="Button2" runat="server" Height="30px" Text="Button" Width="100%" />
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:ASPxFormLayout>
                    <br />
                    <br />
                    <dx:ASPxSpreadsheet ID="ASPxSpreadsheet1" runat="server" WorkDirectory="~/App_Data/WorkDirectory">
                    </dx:ASPxSpreadsheet>
                    <br />
                    <br />
                    <br />
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
