<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CBMain.aspx.cs" Inherits="TermProject.CBMain" %>

<%@ Register Src="~/ViewCourses.ascx" TagName="ViewCourses" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        .auto-style2 {
            color: #FFFFFF;
            background-color: #990000;
        }

        .auto-style14 {
            text-align: center;
            background-color: #990000;
        }

        .auto-style15 {
            color: #FFFFFF;
            font-size: 45pt;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="auto-style14">
        <asp:Label ID="lblName" runat="server" CssClass="auto-style15"></asp:Label>
    </h1>
    <asp:Button ID="btnAnnoucements" runat="server" Enabled="False" Text="Annoucements" Width="150px" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAssignments" runat="server" Text="Assignments" Width="150px" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" Text="Button" Width="150px" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button4" runat="server" Text="Button" Width="150px" />
    <br />
    <h2 class="text-center">Annoucements</h2>
    <br />
    <br />
    <br />
    <%--<uc1:ViewCourses ID="gvCourses" runat="server"> </uc1:ViewCourses>--%>
    <uc1:ViewCourses runat="server" ID="viewCourseButton" />

    <br />
    <h1 class="text-center">
        <asp:Label ID="lblError" runat="server" ForeColor="#999999"></asp:Label>
    </h1>

</asp:Content>
