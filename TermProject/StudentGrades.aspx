<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentGrades.aspx.cs" Inherits="TermProject.StudentGrades" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            background-color: #990000;
        }
        .auto-style2 {
            color: #FFFFFF;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style1">
            <asp:Label ID="lblName" runat="server" CssClass="auto-style2"></asp:Label>
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
        <asp:GridView ID="gvGrades" runat="server" Width="786px" OnSelectedIndexChanged="gvGrades_SelectedIndexChanged">
            <Columns>
                        <asp:BoundField DataField="GradeID" Visible="false" />
                        <asp:BoundField DataField="Grade" HeaderText="Grade" />
                        <asp:BoundField DataField="Name" HeaderText="Assignment Name" />
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
                        <asp:BoundField DataField="MaximumGrade" HeaderText="MaximumGrade" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                       <%-- <asp:ButtonField runat="server" ButtonType="Button" CommandName="Delete" HeaderText="Delete Assignment" Text="Delete Assignment" />--%>
                    </Columns>
        </asp:GridView>
        <br />
        <div>
            <asp:Label ID="lblError" runat="server" Font-Size="40pt" ForeColor="#CC3300" Visible="False"></asp:Label>
        </div>
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return" />
    </form>
</body>
</html>
