<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentGrades.aspx.cs" Inherits="TermProject.StudentGrades" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        * {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }

        *, :after, :before {
            color: #000 !important;
            text-shadow: none !important;
            background: 0 0 !important;
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
        }

        hr {
            margin-top: 20px;
            margin-bottom: 20px;
            border: 0;
            border-top: 1px solid #eee;
        }

        hr {
            height: 0;
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
        }

        table {
            background-color: transparent;
        }

        table {
            border-spacing: 0;
            border-collapse: collapse;
        }

        td, th {
            padding: 0;
        }

        #form1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </h1>
        <br />
        <asp:Repeater ID="rptGrades" runat="server" OnItemCommand="rptContentPage_ItemCommand">
            <ItemTemplate>
                <separatortemplate>
                    <hr />
                    <table id="Table1" border="0" cellpadding="5" cellspacing="0"
                        style="width: 677px" align="center">
                        <tr>
                            <td rowspan="4" style="width: 123px; height: 140px;" valign="top">
                                <asp:Image ID="imgProduct" runat="server" Height="200" Width="200" ImageUrl="~/Img/Assignment-512.png" /></td>
                            <td colspan="2">
                                <asp:Label ID="lblTitle" runat="server"
                                    Style="font-weight: 700; font-size: x-large"  Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' Font-Bold="True" Font-Size="XX-Large"></asp:Label></td>
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
                            <td>
                                <asp:Label ID="lblGrade" runat="server" visible ="true" Text='<%# DataBinder.Eval(Container.DataItem, "Grade") %>'></asp:Label>
                                /<asp:Label ID="lblMaxGrade" runat="server" visible ="true" Text='<%# DataBinder.Eval(Container.DataItem, "MaximumGrade") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGradeId" runat="server" visible ="false" Text='<%# DataBinder.Eval(Container.DataItem, "GradeID") %>'></asp:Label>
                                <asp:Label ID="lblAssignmentID" runat="server" visible ="false" Text='<%# DataBinder.Eval(Container.DataItem, "AssignmentID") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="lblDate" Font-Size ="Small" runat="server" visible ="true" Text='<%# DataBinder.Eval(Container.DataItem, "DueDate") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                            </separatortemplate>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <div>
            <asp:Label ID="lblError" runat="server" Font-Size="40pt" ForeColor="#CC3300" Visible="False"></asp:Label>
        </div>
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return" />
    </form>
</body>
</html>
