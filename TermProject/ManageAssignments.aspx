<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAssignments.aspx.cs" Inherits="TermProject.ManageAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table {
            background-color: transparent;
        }

        table {
            border-spacing: 0;
            border-collapse: collapse;
        }

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

        td, th {
            padding: 0;
        }

        th {
            text-align: left;
        }

        .auto-style1 {
            text-align: center;
            background-color: #990000;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style1">Manage Assignments</h1>
        <br />
        <div class="auto-style2">
            <asp:Button ID="btnNewAssignment" runat="server" Text="New Assignment" EnableTheming="True" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnGradeAssignments" runat="server" Text="Grade Assignments" />
        </div>
        <asp:Panel ID="newAssignment" runat="server">
            <h2>New Assignment</h2>
            <p>
                Title:
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </p>
            <p>
                Due Date:
                <asp:Calendar ID="calendarDueDate" runat="server"></asp:Calendar>
            </p>
            <p>
                Maximum Grade:
                <asp:TextBox ID="txtMaxGrade" runat="server"></asp:TextBox>
                &nbsp;&nbsp; Description:
                <asp:TextBox ID="txtDescription" runat="server" Width="222px"></asp:TextBox>
                &nbsp; Select file:&nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" />
                &nbsp;
                <asp:Label ID="lblUpload" runat="server" />
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Create Assignment" Width="179px" OnClick="btnSubmit_Click" />
                &nbsp;
                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
            </p>
        </asp:Panel>
        <asp:Panel ID="panGradeAssignments" runat="server">
        </asp:Panel>
    </form>
</body>
</html>
