<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewCourses.ascx.cs" Inherits="TermProject.ViewCourses" %>

<style type="text/css">
    .style1
    {
        width: 124px;
    }
    .auto-style2 {
        width: 191px;
        text-align: left;
    }
    .auto-style3 {
        width: 1034px;
        height: 154px;
    }
    .auto-style4 {
        height: 143px;
        width: 50px;
    }
    .auto-style6 {
        font-size: xx-large;
    }
    .auto-style9 {
        font-size: smaller;
    }
    .auto-style11 {
        text-align: right;
    }
    .auto-style12 {
        text-align: left;
    }
    .auto-style13 {
        font-size: x-large;
    }
</style>
<body style="text-align: center">
<table id="Table1" border="0" cellpadding="5" cellspacing="0" align ="center" class="auto-style3">
    <tr>
        <td rowspan="4" valign="top" class="auto-style4">
            <asp:Image ID="imgProduct" runat="server" Height="193px" Width="220px" ImageUrl="~/Img/467717-200.png" /></td>
        <td>
            <h1 class="auto-style12">
            <asp:Label ID="lblTitle" runat="server"
                style="font-weight: 700; " CssClass="auto-style6"></asp:Label></h1>
        </td>
    </tr>
    <tr>
        <td class="auto-style12">
            <asp:Label ID="lblDescription" runat="server" CssClass="auto-style13"></asp:Label></td>
    </tr>
    <tr>
        <td class="auto-style11">
            <em>
            <asp:Label ID="lblDate" runat="server" CssClass="auto-style9"></asp:Label></em></td>
    </tr>
    <tr>
        <td class="auto-style2">
            &nbsp;</td>
    </tr>
</table>
        <hr style="background-color: #800000" />&nbsp;</p>

