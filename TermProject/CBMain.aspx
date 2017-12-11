<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="CBMain.aspx.cs" Inherits="TermProject.CBMain" %>

<%@ Register Src="~/ViewCourses.ascx" TagName="ViewCourses" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style14 {
            text-align: center;
            background-color: #990000;
        }

        .auto-style15 {
            color: #FFFFFF;
            font-size: 45pt;
        }

        .auto-style16 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style14">
            <asp:Label ID="lblName" runat="server" CssClass="auto-style15"></asp:Label>
        </h1>
        <div style="text-align: center">
            <asp:Button ID="btnAnnoucements" runat="server" Enabled="False" Text="Annoucements" Width="150px" />
            &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAssignments" runat="server" Text="Assignments" Width="150px" />
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlContentPages" runat="server" OnSelectedIndexChanged="ddlContentPages_SelectedIndexChanged" DataTextField="Title" DataValueField="Id" AutoPostBack="True">
        </asp:DropDownList>
        </div>
        <br />
        <h2 class="auto-style16">Annoucements</h2>
        <%--<uc1:ViewCourses ID="gvCourses" runat="server"> </uc1:ViewCourses>--%>
        <div>
            <uc1:ViewCourses runat="server" ID="viewCourseButton" EnableTheming="False" ViewStateMode="Enabled" />
            <br />
            <asp:Button ID="btnSignOut" runat="server" Text="Sign Out" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnMyClasses" runat="server" Text="My Classes" Width="150px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddAnnoucment" runat="server" OnClick="lblAddAnnoucment_Click" Text="New Announcement" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCourseBuilderTools" runat="server" OnClick="Button5_Click" Text="Coursebuilder Tools" Visible="False" />
        </div>
        <br />
        <h1 class="text-center">
            <asp:Label ID="lblError" runat="server" ForeColor="#999999"></asp:Label>
        </h1>
    </form>
</body>
</html>

