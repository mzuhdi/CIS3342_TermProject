<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewCourses.ascx.cs" Inherits="TermProject.ViewCourses" %>

<style type="text/css">
    .style1 {
        width: 124px;
    }

    </style>
<body style="text-align: center">
    <asp:Label ID="lblError" runat="server" ForeColor="#CC3300" style="font-size: xx-large"></asp:Label>
    <asp:Repeater ID="rptAnnouncements" runat="server" OnItemCommand="rptAnnouncements_ItemCommand">
        <ItemTemplate>
            <separatortemplate>
                    <hr />
                    <table id="Table1" border="0" cellpadding="5" cellspacing="0"
                        style="width: 677px" align="center">
                        <tr>
                            <td rowspan="4" style="width: 123px; height: 140px;" valign="top">
                                <asp:Image ID="imgProduct" runat="server" Height="150px" Width="150px" ImageUrl="~/Img/thumbtack-pushpin-2-hi.png" /></td>
                            <td colspan="2">
                                <asp:Label ID="lblTitle" runat="server"
                                    Style="font-weight: 700; font-size: x-large"  Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' Font-Bold="True" Font-Size="XX-Large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblDescription" runat="server" Style="font-size: medium" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                <asp:Label ID="lblProfessor" runat="server" Style="font-size: large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="lblDate" runat="server" visible ="true" Text='<%# DataBinder.Eval(Container.DataItem, "Date") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="lblAnnoucementID" runat="server" visible ="false" Text='<%# DataBinder.Eval(Container.DataItem, "AnnoucementID") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                            </separatortemplate>
        </ItemTemplate>
    </asp:Repeater>
    

