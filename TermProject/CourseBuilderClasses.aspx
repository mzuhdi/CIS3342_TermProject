<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseBuilderClasses.aspx.cs" Inherits="TermProject.CourseBuilderClasses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            font-size: 45pt;
        }
        .auto-style3 {
            text-align: center;
            font-weight: normal;
            background-color: #800000;
        }
        .auto-style4 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style3">
                <asp:Label ID="lblName" runat="server" CssClass="auto-style1"></asp:Label>
            </h1>
            <div class="auto-style4">
                <h2 style="font-size: xx-large">My Courses</h2>
            </div>
            <asp:Repeater ID="rptClasses" runat="server" OnItemCommand="rptClasses_ItemCommand">
                <ItemTemplate>
                    <separatortemplate>
                    <hr />
                    <table id="Table1" border="0" cellpadding="5" cellspacing="0"
                        style="width: 677px" align="center">
                        <tr>
                            <td rowspan="4" style="width: 123px; height: 140px;" valign="top">
                                <asp:Image ID="imgProduct" runat="server" Height="100px" Width="120px" ImageUrl="~/Img/transparent-green-checkmark-hi.png" /></td>
                            <td colspan="2">
                                <asp:Label ID="lblCourse" runat="server"
                                    Style="font-weight: 700; font-size: x-large"  Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblCourseCode" runat="server" Style="font-size: medium" Text='<%# DataBinder.Eval(Container.DataItem, "CourseCode") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                <asp:Label ID="lblProfessor" runat="server" Style="font-size: large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="lblCourseID" runat="server" visible ="false" Text='<%# DataBinder.Eval(Container.DataItem, "CourseID") %>'></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:Button ID="btnView" Text="View Course" runat="server" CommandName="view" />
                            </td>
                        </tr>
                    </table>
                            </separatortemplate>
                </ItemTemplate>
                
            </asp:Repeater>
        </div>
        <h2 style="background-color: #990000">
            &nbsp;</h2>
        <p>
            <asp:Label ID="lblError" runat="server" Style="font-size: xx-large"></asp:Label>
            <asp:Label ID="lblStudentID" runat="server" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnSignOut" runat="server" OnClick="btnSignOut_Click" Text="Sign Out" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
