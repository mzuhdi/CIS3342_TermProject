<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContentPage.aspx.cs" Inherits="TermProject.ContentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style15 {
            color: #FFFFFF;
            font-size: 45pt;
            font-weight: normal;
        }

        .auto-style14 {
            text-align: center;
            background-color: #990000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style14">
            <asp:Label ID="lblName" runat="server" CssClass="auto-style15" Font-Names="Arial"></asp:Label>
        </h1>
        <div style="text-align: center">
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblPageName" runat="server" Font-Names="Arial" style="font-size: 30pt"></asp:Label>
            <br />
            <br />
            <asp:Repeater ID="rptContentPage" runat="server" OnItemCommand="rptContentPage_ItemCommand">
                <ItemTemplate>
                    <separatortemplate>
                        <hr />
                        <table id="Table1" border="0" cellpadding="5" cellspacing="0"
                        style="width: 677px" align="center">
                            <tr>
                                <td rowspan="4" style="width: 123px; height: 140px;" valign="top">
                                    <asp:Image ID="imgProduct" runat="server" Height="100px" Width="120px" ImageUrl="~/Img/thumbtack-pushpin-2-hi.png" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblTitle" runat="server"
                                    Style="font-weight: 700; font-size: x-large"  Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblDescription" runat="server" Style="font-size: medium" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblProfessor" runat="server" Style="font-size: large"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFileName" runat="server" visible ="true" Text='<%# DataBinder.Eval(Container.DataItem, "FileTitle") %>'></asp:Label>
                                &nbsp 
                                    <asp:LinkButton ID="Download" runat="server" CommandName="download">Download</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblId" runat="server" visible ="false" Text='<%# DataBinder.Eval(Container.DataItem, "Id") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="lblDate" Font-Size ="Small" runat="server" visible ="true" Text='<%# DataBinder.Eval(Container.DataItem, "DateCreated") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </separatortemplate>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <div style="text-align: center">
                <asp:Button ID="txtBack" runat="server" OnClick="txtBack_Click" Text="Back" />
            </div>
        </div>
        <p>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
