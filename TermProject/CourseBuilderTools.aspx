<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseBuilderTools.aspx.cs" Inherits="TermProject.CourseBuiderTools" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            color: #FFFFFF;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style4 {
            font-size: large;
            padding-left: 0px;
        }
    </style>
</head>
<body>
    
        <h1 class="auto-style1" style="text-align: center; background-color: #990000">Coursebuilder Tools</h1>
    
    <form id="form1" runat="server">
    <div class="auto-style2">
    
        <h2>
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </h2>
        <br />
        <asp:Button ID="btnManageAssignments" runat="server" CssClass="auto-style4" OnClick="btnManageAssignments_Click" Text="Manage Assignments" Width="350px" />
        <br class="auto-style3" />
        <br class="auto-style3" />
        <asp:Button ID="btnManageContentPages" runat="server" CssClass="auto-style3" OnClick="Button2_Click" Text="Manage Content Pages" Width="350px" />
        <br class="auto-style3" />
        <br class="auto-style3" />
        <asp:Button ID="btnManageAnnouncements" runat="server" CssClass="auto-style3" OnClick="btnManageAnnouncements_Click" Text="Manage Announcements" Width="350px" />
        <br class="auto-style3" />
        <br class="auto-style3" />
        <asp:Button ID="btnManageStudents" runat="server" CssClass="auto-style3" OnClick="btnManageStudents_Click" Text="Manage Students" Width="350px" />
        <br />
        <br class="auto-style3" />
        <br class="auto-style3" />
        <asp:Button ID="btnCancel" runat="server" CssClass="auto-style3" OnClick="btnCancel_Click" Text="Cancel" />
    
    </div>
    </form>
</body>
</html>
